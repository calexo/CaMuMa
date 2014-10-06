#!/usr/bin/python

import os, os.path
import random


# dirs = os.listdir('/media/USB')
dirs = os.walk('/media/USB').next()[1]
for album in dirs:
    #do the check you need on each file
	print album
	camumaidfile_ok = False
	for fichier in os.listdir('/media/USB/' + album):
		if fichier == 'camuma.id':
			print "camumad.id found"
			camumaidfile_ok = True
	if (not camumaidfile_ok):
		print "generate camuma.id"
		id = random.randint(100001, 999999)
		with open('/media/USB/' + album + '/camuma.id', 'w') as cidfile:
			cidfile.write(str(id))
