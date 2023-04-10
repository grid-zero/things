from ctypes import windll

import autoit
import pyautogui
import time
import math
import pydirectinput
import numpy as np
from PIL import Image
import random as r
import win32api
import mousemacro
from collections import deque




def pickColour(colours):
    center = [170,970]


    sortedColours = {key: val for key, val in sorted(colours.items(), key=lambda ele: ele[1], reverse = True)}

    scale = list(sortedColours.values())[0]
    if scale == 0:
        scale = 1

    colourMainWeight = list(sortedColours.values())[0]/scale
    colourSecondaryWeight = list(sortedColours.values())[1]/scale
    colourMainFactor = parseAngle(list(sortedColours.keys())[0])
    colourSecondaryFactor = parseAngle(list(sortedColours.keys())[1])


    if(abs(colourMainFactor-colourSecondaryFactor)>180):
        if(colourMainFactor>colourSecondaryFactor):
            colourMainFactor-=360
        else:
            colourSecondaryFactor-=360

    angle = (colourMainFactor-(colourSecondaryWeight*(colourMainFactor-colourSecondaryFactor)/2))
    angle = abs(angle)
    if angle == 360:
        angle = 0
    print("angle", angle)

    hightloss = list(sortedColours.values())[2]
    heightMax = list(sortedColours.values())[0]

    distFactor = interp(0,255,0,90,heightMax) - interp(0,255,0,90,hightloss)
    print("dist factor", distFactor)
    x = math.sin(math.radians(angle))*distFactor + center[0]
    y = (math.cos(math.radians(angle)) * - distFactor) + center[1]

    autoit.mouse_move(int(x),int(y),1)
    oneclick()
    #autoit.mouse_click("left", int(x), int(y),2)
    #pydirectinput.leftClick(int(x),int(y))
    print("x & y", x,y)

    darkness = (list(sortedColours.values())[0] + list(sortedColours.values())[1]) / 2
    darknessy = interp(0, 255, 1062, 920, darkness)
    print("darknessy", darknessy)
    time.sleep(0.2)
    autoit.mouse_move(int(40),int(darknessy),1)
    oneclick()
    time.sleep(0.2)
def oneclick():
    autoit.mouse_down()
    time.sleep(0.05)
    autoit.mouse_up()
def parseAngle(key):
    if key == 'R':
        return 270
    if key == 'G':
        return 150
    if key == 'B':
        return 30

def interp(fromMin, fromMax, toMin, toMax, val):
    return ((val - fromMin) * (toMax - toMin)) / (fromMax - fromMin) + toMin


def drawPoint(x,y,colour):
    autoit.mouse_move(x,y,1)
    trippleclick()

def drawLine(fromX, fromY, toX, toY, speed):
    #pickColour(colour)
    autoit.mouse_move(fromX,fromY)
    autoit.mouse_click_drag(fromX,fromY,toX,toY,'left',speed)


def drawImage():
    #drawLine(480, 480, 480, 1020, {'R': 60, 'G': 255, 'B': 25})
    #drawLine(1020, 480, 1020, 1020, {'R': 60, 'G': 255, 'B': 25})
    #drawLine(1020, 1020, 1020, 480, {'R': 60, 'G': 255, 'B': 25})
    #drawLine(1020, 480, 480, 480, {'R': 60, 'G': 255, 'B': 25})

    colours = [{'R': 60, 'G': 255, 'B': 25},{'R': 60, 'G': 25, 'B': 255},{'R': 255, 'G': 255, 'B': 25},{'R': 0, 'G': 0, 'B': 0 }]
    for x in range(20):
        for y in range(20):
            print(x,y)
            drawPoint(1000+x*5,450+y*5,colours[y % 3])


def draw(img):
    colorQueue = []
    print("checking colours")
    for y in range(np.size(img, 0)):
        for x in range(np.size(img, 1)):
            imgPixel = img[y, x]
            colours = {'R': imgPixel[0], 'G': imgPixel[1], 'B': imgPixel[2]}
            sortedC = {key: val for key, val in sorted(colours.items(), key=lambda ele: ele[1], reverse=True)}
            sortedC['R'] = round(sortedC['R'] / 30) * 30
            sortedC['G'] = round(sortedC['G'] / 30) * 30
            sortedC['B'] = round(sortedC['B'] / 30) * 30
            if sortedC['R'] >255:
                sortedC['R'] = 255
            if sortedC['G'] >255:
                sortedC['G'] = 255
            if sortedC['B'] >255:
                sortedC['B'] = 255

            if sortedC not in colorQueue:
                colorQueue.append(sortedC)
    print("drawing colours")
    global coloursCashe
    for coloursStore in colorQueue:
        for y in range(np.size(img, 0)):
            for x in range(np.size(img, 1)):
                imgPixel = img[y, x]


                colours = {'R': imgPixel[0], 'G': imgPixel[1], 'B': imgPixel[2]}
                sortedC = {key: val for key, val in sorted(colours.items(), key=lambda ele: ele[1], reverse=True)}
                sortedC['R'] = round(sortedC['R'] / 30) * 30
                sortedC['G'] = round(sortedC['G'] / 30) * 30
                sortedC['B'] = round(sortedC['B'] / 30) * 30
                if sortedC['R'] > 255:
                    sortedC['R'] = 255
                if sortedC['G'] > 255:
                    sortedC['G'] = 255
                if sortedC['B'] > 255:
                    sortedC['B'] = 255
                if coloursStore != sortedC:
                    continue

                if (list(sortedC.values())[0] + list(sortedC.values())[1]+ list(sortedC.values())[2])/3 >229:
                    continue

                if  coloursCashe != sortedC:
                    autoit.mouse_up()
                    coloursCashe = sortedC
                    pickColour(sortedC)



                autoit.mouse_move(500+x*3,80+y*3,1)
                trippleclick()
def trippleclick():
    mousemacro.hold()
    autoit.mouse_down()
    time.sleep(0.01)
    mousemacro.release()
    #autoit.mouse_up()
    #
    mousemacro.hold()
    # autoit.mouse_down()
    time.sleep(0.01)
    mousemacro.release()
    # autoit.mouse_up()
    #
    mousemacro.hold()
    # autoit.mouse_down()
    time.sleep()
    mousemacro.rele0.01ase()
    # autoit.mouse_up()
    #
    mousemacro.hold()
    # autoit.mouse_down()
    time.sleep(0.01)
    mousemacro.release()
    # autoit.mouse_up()
    #
    mousemacro.hold()
    # autoit.mouse_down()
    time.sleep(0.01)
    mousemacro.release()
    # autoit.mouse_up()
    #
def drawSusShape(abc):
    drawLine(100 + abc, 100 + abc, 200 + abc, 200 + abc,15)  # line 1
    drawLine(100 + abc, 200 + abc, 200 + abc, 100 + abc,15)  # line 2
    drawLine(100 + abc, 100 + abc, 150 + abc, 50 + abc,15)  # arm top
    drawLine(200 + abc, 100 + abc, 250 + abc, 150 + abc,15)  # arm left
    drawLine(200 + abc, 200 + abc, 150 + abc, 250 + abc,15)  # arm bottom
    drawLine(100 + abc, 200 + abc, 50 + abc, 150 + abc,15)  # arm right
def fillScreen(rows):
    for x in range(rows):
        drawLine(300+x*10,100,1400+x*10,100,20)

# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    global coloursCashe
    coloursCashe = {}
    img = Image.open('basedjack.png')
    imgArray = np.array(img)
    time.sleep(2)
    print(autoit.mouse_get_pos())
    #for x in range(30):
    #fillScreen(30)

    #    drawLine(520, 200+x*20, 1000, 200+x*20, {'R': 255, 'G': 255, 'B': 255})
    draw(imgArray)
    #drawImage()
    #time.sleep(2)
    #drawImage()
 