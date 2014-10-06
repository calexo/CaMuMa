#!/usr/bin/python

import time
import socket
import fcntl
import struct
import os
from datetime import datetime
import unicodedata


ScreenFile = "/home/pi/screen.txt"


def get_ip_address(ifname):
    s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    return socket.inet_ntoa(fcntl.ioctl(
        s.fileno(),
        0x8915,  # SIOCGIFADDR
        struct.pack('256s', ifname[:15])
    )[20:24])

# print get_ip_address('lo')
# print get_ip_address('eth0')


import nokiaSPI

# from PIL import Image,ImageDraw,ImageFont

# FONT_PAUSE = [0x0,0xa,0xa,0xa,0xa,0xa,0x0]
FONT_PAUSE = [0x0,0x1f,0x0,0x1f,0x0]
FONT_PLAY = [0x0,0x1f,0xe,0x4,0x0]
FONT_RANDOM = [0x11,0x11,0xa,0x4,0xa]
FONT_NORANDOM = [0x11,0x11,0x11,0x11,0x11]
FONT_UPDATING = [0, 0xe, 0x11, 0x1d, 0x1, 0x6, 0x1c, 0x0]
FONT_F = [0x0,0x1f,0x5,0x1,0x0,0x0]
FONT_M = [0x0,0x1f,0x2,0x4,0x2,0x1f,0x0]
FONT_QUESTION = [0x02, 0x01, 0x51, 0x09, 0x06];


FONT_PROG = {
	0: [0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10],
	1: [0x1f,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10],
	2: [0x1f,0x1f,0x10,0x10,0x10,0x10,0x10,0x10,0x10],
	3: [0x1f,0x1f,0x1f,0x10,0x10,0x10,0x10,0x10,0x10],
	4: [0x1f,0x1f,0x1f,0x1f,0x10,0x10,0x10,0x10,0x10],
	5: [0x1f,0x1f,0x1f,0x1f,0x1f,0x10,0x10,0x10,0x10],
	6: [0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x10,0x10,0x10],
	7: [0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x10,0x10],
	8: [0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x10],
	9: [0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x1f],
	10: [0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x1f,0x1f],
}

# FONT_0ON5 = [0x1f,0x10,0x10,0x10,0x10,0x10]
# FONT_1ON5 = [0x1f,0x10,0x10,0x10,0x10,0x10]
# FONT_2ON5 = [0x1f,0x1f,0x10,0x10,0x10,0x10]
# FONT_3ON5 = [0x1f,0x1f,0x1f,0x10,0x10,0x10]
# FONT_4ON5 = [0x1f,0x1f,0x1f,0x1f,0x10,0x10]
# FONT_5ON5 = [0x1f,0x1f,0x1f,0x1f,0x1f,0x10]
# FONT_5ON5 = [0x1f,0x1f,0x1f,0x1f,0x1f,0x10]

# FONT_

noki = nokiaSPI.NokiaSPI()

# Let's try some image manipulation
#start_time = time.time()
# im = Image.open("calexo.png")
# im = im.convert("L")
# im.thumbnail((84,48))
# # for t in range(1,255):
# t=160
# tim = im.point(lambda p: p > t and 255, "1")
# noki.cls()
# noki.show_image(tim)
#     # noki.gotorc(0,8)
#     # noki.text("Thresh:")
#     # noki.gotorc(1,10)
#     # noki.text("%3d" % t)
#     # time.sleep(0.01)
#     # del tim


# time.sleep(2)

# #finish_time = time.time()
# #print 'PIL Image, total time = %.3f' % (finish_time - start_time)

# # Let's try some image manipulation
# start_time = time.time()
# im = Image.open("calexo.png")
# #im = im.resize((84,48))
# im.thumbnail((84,48))
# im = im.convert("1")
# noki.cls()
# noki.show_image(im)
# # noki.gotorc(0,8)
# # noki.text("Dither")

# # finish_time = time.time()
# # print 'PIL Image, total time = %.3f' % (finish_time - start_time)




noki.cls()
now = datetime.now()
noki.largetext(now.strftime("%H:%M"),0)
noki.largetext(now.strftime("%d.%m"),3)

time.sleep(2)

noki.cls()
noki.load_bitmap("/home/pi/calexo.bmp")

noki.gotorc(0,0)
try:
	noki.text(get_ip_address('eth0'))
except:
	noki.text('No Network')

time.sleep(2)


oldstmt = os.stat(ScreenFile).st_mtime

while True:
	while os.stat(ScreenFile).st_mtime == oldstmt:
		time.sleep(0.2)

	oldstmt = os.stat(ScreenFile).st_mtime

	#print "Changed"
	noki.cls()
	content = open(ScreenFile,"rb") #.read()
	ln=0
	noki.gotorc(ln,0)
	noki.text("Stopped")
	for line in content:
		if line[:1] != '#':
			noki.gotorc(ln,0)
			uline = unicode(line[:14], "iso8859-1", errors='ignore')
			noki.text(unicodedata.normalize("NFKD",uline  ).encode("ascii", "ignore" ))
			#print line
			ln=ln+1
		else:
			isplaying=line[1:].split(':')[0]
			israndom=line[1:].split(':')[1][:2]
			progress=int(line[1:].split(':')[2])
			isupdating=line[1:].split(':')[3][:2]
			filetype=line[1:].split(':')[4][0]

			#print filetype + ":" + israndom
			#print str(progress) + ":" + isupdating

			if isplaying=='playing':
				noki.define_custom(FONT_PLAY)
			else:
				noki.define_custom(FONT_PAUSE)
			noki.gotorc(5,0)
			noki.show_custom()

			if israndom=='on':
				noki.define_custom(FONT_RANDOM)
			else:
				noki.define_custom(FONT_NORANDOM)
			noki.gotorc(5,2)
			noki.show_custom()


			if isupdating=='on':
				noki.define_custom(FONT_UPDATING)
				noki.gotorc(5,4)
				noki.show_custom()

			if filetype=='F':
				noki.define_custom(FONT_F)
			elif filetype=='M':
				noki.define_custom(FONT_M)
			else:
				noki.define_custom(FONT_QUESTION)
			noki.gotorc(5,6)
			noki.show_custom()


			#print "."+str(progress)+"."

			# if progress<10:
			# 	noki.define_custom(FONT_1ON5)
			# elif progress<20:
			# 	noki.define_custom(FONT_2ON5)
			# elif progress<30:
			# 	noki.define_custom(FONT_3ON5)
			# elif progress<40:
			# 	noki.define_custom(FONT_4ON5)
			# else:
			# 	noki.define_custom(FONT_5ON5)
			# noki.gotorc(0,12)
			# noki.show_custom()

			# if progress>50:
			# 	noki.define_custom(FONT_1ON5)
			# elif progress>60:
			# 	noki.define_custom(FONT_2ON5)
			# elif progress>70:
			# 	noki.define_custom(FONT_3ON5)
			# elif progress>80:
			# 	noki.define_custom(FONT_4ON5)
			# elif progress>90:
			# 	noki.define_custom(FONT_5ON5)
			# else:
			# 	noki.define_custom([0x10,0x10,0x10,0x10,0x10,0x10])

			noki.define_custom(FONT_PROG[progress//10])
			noki.gotorc(5,12)
			noki.show_custom()
	
	# noki.text(FONT_PLAY)
	# noki.wiringpi.digitalWrite(noki.dc, noki.ON)
	# noki.spi.writebytes(FONT_PLAY+[0])

