#!/usr/bin/python

from time import sleep
import RPi.GPIO as GPIO
from mpd import MPDClient
import subprocess

GPIO.setmode(GPIO.BOARD)

PIN_MODE=18
PIN_OK=22

GPIO.setup(PIN_MODE, GPIO.IN)
GPIO.setup(PIN_OK, GPIO.IN)

stateOK = 1
nbLoopsOK = 0
OK_long_done = 0

client = MPDClient()
#client.timeout = 10                # network timeout in seconds (floats allowed), default: None
client.idletimeout = None          # timeout for fetching the result of the idle command is handled seperately, default: None


def OK_short():
	print "Toggle"
	try:
		client.ping()
	except:
		try:
			client.disconnect()
		except:
			pass
		try:
			client.connect("localhost", 6600)
			client.ping()
			print("connected to MPD")
		except:
			print("failed to connect to MPD" )

	print "Toggle from " + client.status()['state']
	if client.status()['state'] in ('play'):
		client.pause()
	else:
		client.play()


def OK_long():
	print "111111"
	subprocess.check_call(["/home/pi/camuma.sh", "111111"])


while True:
	#print GPIO.input(18)
	#print GPIO.input(PIN_OK)
	#sleep (1)

	newStateOK = GPIO.input(PIN_OK)
	nbLoopsOK = nbLoopsOK + 1

	if (stateOK != newStateOK):
		if newStateOK == 0:
			# Button pressed
			print "Pressed"
		else:
			print "Released, kept pressed for " + str(nbLoopsOK) + "0 ms"
			if nbLoopsOK < 50:
				OK_short()
			#else:
			#	OK_long()

		stateOK = newStateOK
		nbLoopsOK=0
		OK_long_done=0
	else:
		if stateOK==0:
			if nbLoopsOK > 50:
				if OK_long_done==0:
					OK_long()
					OK_long_done=1


	sleep (.01)


