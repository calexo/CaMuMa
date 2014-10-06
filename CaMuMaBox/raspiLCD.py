#!/usr/bin/python
# Quick test for nokiaSPI class with images

import time

import nokiaSPI

from PIL import Image,ImageDraw,ImageFont


noki = nokiaSPI.NokiaSPI()

start_time = time.time()
noki.load_bitmap("raspi.bmp")
finish_time = time.time()
print 'BMP Load, total time = %.3f' % (finish_time - start_time)

time.sleep(1)

start_time = time.time()
noki.load_bitmap("raspi.bmp", True)
finish_time = time.time()
print 'BMP Load, total time = %.3f' % (finish_time - start_time)

time.sleep(1)

start_time = time.time()
noki.load_bitmap("raspi.bmp")
finish_time = time.time()
print 'BMP Load, total time = %.3f' % (finish_time - start_time)

time.sleep(1)

start_time = time.time()
noki.load_bitmap("raspi.bmp", True)
finish_time = time.time()
print 'BMP Load, total time = %.3f' % (finish_time - start_time)

time.sleep(1)

# Let's try some image manipulation
#start_time = time.time()
im = Image.open("lenna.png")
im = im.convert("L")
im.thumbnail((84,48))
for t in range(1,255):
    tim = im.point(lambda p: p > t and 255, "1")
    noki.cls()
    noki.show_image(tim)
    noki.gotorc(0,8)
    noki.text("Thresh:")
    noki.gotorc(1,10)
    noki.text("%3d" % t)
    time.sleep(0.01)
    del tim

#finish_time = time.time()
#print 'PIL Image, total time = %.3f' % (finish_time - start_time)

# Let's try some image manipulation
start_time = time.time()
im = Image.open("lenna.png")
#im = im.resize((84,48))
im.thumbnail((84,48))
im = im.convert("1")
noki.cls()
noki.show_image(im)
noki.gotorc(0,8)
noki.text("Dither")

finish_time = time.time()
print 'PIL Image, total time = %.3f' % (finish_time - start_time)