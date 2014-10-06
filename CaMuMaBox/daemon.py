#!/usr/bin/python

from socket import *
import thread
import subprocess
import re
from mpd import MPDClient

BUFF = 1024
HOST = '0.0.0.0'
PORT = 5023



def handler(clientsock,addr):
	while 1:
		try:
			data = clientsock.recv(BUFF)
		except:
			break
		
		cmd = data.strip()
		if "" != cmd:
			print repr(addr) + ' recv:' + cmd
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
					#self.manager.stop()
					#return False
			# except:
			# 	#print "Client MPD already connected"
			# 	client.connect("localhost", 6600)
			if "close" == cmd: break # type 'close' on client console to close connection from the server side
			if "poweron" == cmd:
				subprocess.check_call(["/home/pi/camuma.sh", "poweron"])
			if "poweroff" == cmd:
				subprocess.check_call(["/home/pi/camuma.sh", "poweroff"])
			if "toggle" == cmd:
				print "Toggle from " + client.status()['state']
				if client.status()['state'] in ('play'):
					client.pause()
				else:
					client.play()

				#subprocess.check_call(["/home/pi/camuma.sh", "toggle"])
			if "next" == cmd:
				#subprocess.check_call(["/home/pi/camuma.sh", "next"])
				client.next()
			if "prev" == cmd:
				#subprocess.check_call(["/home/pi/camuma.sh", "prev"])
				client.previous()
			if "shuffle" == cmd:
				#subprocess.check_call(["/home/pi/camuma.sh", "shuffle"])
				client.shuffle()
			if "random" == cmd:
				#subprocess.check_call(["/home/pi/camuma.sh", "random"])
				if client.status()['random'] == "1":
					client.random( 0 )
				else:
					client.random( 1 )
			if "play" == cmd:
				#subprocess.check_call(["/home/pi/camuma.sh", "play"])
				client.play()
			if "stop" == cmd:
				#subprocess.check_call(["/home/pi/camuma.sh", "stop"])
				client.stop()
			if "stats" == cmd:
				#print "open"
				stats = open("/home/pi/stat_file","rb").read()
				#print "endopen"
				clientsock.send('RET\nSTATS\n' + stats + '\nEND\n')
				#print "endsend"
			if "listalbums" == cmd:
				listalbums = open("/home/pi/camuma.lst.unix","rb").read()
				clientsock.send('RET\nLIST\n' + listalbums + '\nEND\n')

			reres = re.search("([0-9]{6})",cmd)
			if reres:
				subprocess.check_call(["/home/pi/camuma.sh", reres.group(1)])
				# clientsock.send("Launched album " + reres.group(1))

			#clientsock.send("END")
			#client.disconnect()

			clientsock.close()
			print addr, "- closed connection" #log on console

	# MPD Client
	client.close()                     # send the close command
	client.disconnect()  

if __name__=='__main__':
	ADDR = (HOST, PORT)
	serversock = socket(AF_INET, SOCK_STREAM)
	serversock.setsockopt(SOL_SOCKET, SO_REUSEADDR, 1)
	serversock.bind(ADDR)
	serversock.listen(5)

	client = MPDClient()
	#client.timeout = 10                # network timeout in seconds (floats allowed), default: None
	client.idletimeout = None          # timeout for fetching the result of the idle command is handled seperately, default: None
	client.connect("localhost", 6600)  # connect to localhost:6600
	print(client.mpd_version)          # print the MPD version
	client.disconnect()

	print 'waiting for connection... listening on port', PORT

	while 1:
		clientsock, addr = serversock.accept()
		print '...connected from:', addr
		thread.start_new_thread(handler, (clientsock, addr))
