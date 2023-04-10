# This is a sample Python script.


# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.
import math


def domath(numb):
    # Use a breakpoint in the code line below to debug your script.
    for i in numb:
        i= 30000*math.pow(1.17,i)
        print(i)

def Recur(numb, numbend, start):
    if numb == numbend:
        return
    i = start+2
    print(i)
    numb+=1
    Recur(numb,numbend,i)


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    print("Hello")
    numbers = [1,2,3,4,5,6,7]
    domath(numbers)
    #Recur(1,5,5)


# See PyCharm help at https://www.jetbrains.com/help/pycharm/
