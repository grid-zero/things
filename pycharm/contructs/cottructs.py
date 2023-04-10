import pygame
from pygame.locals import *

pygame.init()

screen_width = 600
screen_height = 600

screen =  pygame.display.set_mode((screen_width, screen_height))
pygame.display.set_caption('Platformer')

#load images
bg_image = pygame.image.load('img/bg.png')
floor_image = pygame.image.load('img/floor.png')
tile_size = 60






class Player():
    def __init__(self,x,y):
        img = pygame.image.load('img/guy1.png')
        self.image = pygame.transform.scale(img,(40,80))
        self.rect = self.image.get_rect()
        self.rect.x = x
        self.rect.y = y
        self.vel_y = 0
        self.jumped = False

    def update(self):
        dx = 0
        dy = 0

        #keypresses
        key = pygame.key.get_pressed()
        if key[pygame.K_SPACE] and self.jumped == False:
            self.vel_y = -30
            self.jumped = True
        if key[pygame.K_SPACE] == False:
            self.jumped = False
        if key[pygame.K_LEFT]:
            dx -= 5
        if key[pygame.K_RIGHT]:
            dx += 5


        #gravity
        self.vel_y +=1
        if self.vel_y > 10:
            self.vel_y = 10
        dy += self.vel_y

        #collision


        #player cords
        self.rect.x += dx
        self.rect.y += dy

        if self.rect.bottom > screen_height:
            self.rect.bottom = screen_height
            dy = 0

        #draw player
        screen.blit(self.image, self.rect)



class World():
    def __init__(self, data):
        self.tile_list = []

        def add_to_list(img):
            img = pygame.transform.scale(img, (tile_size, tile_size))
            img_rect = img.get_rect()
            img_rect.x = col_count * tile_size
            img_rect.y = row_count * tile_size
            tile = (img, img_rect)
            self.tile_list.append(tile)
        floor_img = pygame.image.load('img/floor.png')
        dirt_img = pygame.image.load('img/dirt.png')

        row_count = 0
        for row in data:
            col_count = 0
            for tile in row:
                if tile==1:
                    add_to_list(floor_img)
                if tile==2:
                    add_to_list(dirt_img)
                col_count += 1
            row_count +=1

    def draw(self):
        for tile in self.tile_list:
            screen.blit(tile[0], tile[1])

world_data = [
[1,1,1,1,1,1,1,1,1,1],
[1,0,0,0,0,0,0,0,0,1],
[1,0,0,0,0,0,0,0,0,1],
[1,0,2,2,2,2,2,0,0,1],
[1,0,0,0,0,0,0,0,0,1],
[1,0,0,0,0,0,0,0,2,1],
[1,0,0,0,0,0,2,2,0,1],
[1,0,0,0,2,0,0,0,0,1],
[1,0,2,0,0,0,0,0,0,1],
[1,2,2,2,2,2,2,2,2,1],
]

player = Player(100, screen_height - 300)
world = World(world_data)

run = True
while run == True:

    screen.blit(bg_image,(0,0))

    world.draw()
    player.update()

    print(world.tile_list)

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            run = False
    pygame.display.update()
pygame.quit()