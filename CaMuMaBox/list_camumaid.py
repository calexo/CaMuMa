#!/usr/bin/python

import os, os.path
import sys


dir_media = sys.argv[1]


# dirs = os.listdir('/media/USB')
dirs = os.walk(dir_media).next()[1]

with open('/home/pi/camuma.lst.unix','w') as outfile:
	for album in dirs:
	    #do the check you need on each file
		#print album
		cid=''
		try:
			for fichier in os.listdir(dir_media + album):
				if fichier == 'camuma.id':
					#print "camumad.id found"
					with open(dir_media + album + '/camuma.id', 'r') as cidfile:
						cid = cidfile.readline().strip()
						#print "read " + cid
					# print cid + ":" + album
					outfile.write(cid + ":" + album + "\n")
		except:
			print "Format dir name KO"
			

outfile.close()
