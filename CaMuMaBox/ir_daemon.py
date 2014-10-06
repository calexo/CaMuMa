#!/usr/bin/python

import lirc
import subprocess
from mpd import MPDClient


camuma_id =""

sockid = lirc.init("camuma","/home/pi/camuma_lircrc")
#lirc.load_config_file("/home/pi/tst_lircd2.conf")

print "Reading IR..."

client = MPDClient()
#client.timeout = 10                # network timeout in seconds (floats allowed), default: None
client.idletimeout = None          # timeout for fetching the result of the idle command is handled seperately, default: None
client.connect("localhost", 6600)  # connect to localhost:6600
print(client.mpd_version)          # print the MPD version
client.disconnect()


while True:
	code = lirc.nextcode()
	print code
	#print "." + code[0] + "."
	try:
		button = code[0]
		print "Button " + button
	except:
		print "Not recognized..."
		button = ""

	if button != "":
		if button.isdigit():
			print "Number pressed"
			if len(camuma_id) == 6:
				print "Reset ID"
				camuma_id=""
			camuma_id = camuma_id + button
			print "New ID : " + camuma_id
			if len(camuma_id) == 6:
				subprocess.check_call(["/home/pi/camuma.sh", camuma_id])
		else:
			camuma_id=""
			print "Reset ID"
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

			if "toggle" == button:
				print "Toggle from " + client.status()['state']
				if client.status()['state'] in ('play'):
					client.pause()
				else:
					client.play()
			elif "next" == button:
				print "Next"
				client.next()
			elif "prev" == button:
				print "Previous"
				client.previous()
			elif "random" == button:
				if client.status()['random'] == "1":
					print "Random Off"
					client.random( 0 )
				else:
					print "Random On"
					client.random( 1 )

lirc.deinit()

