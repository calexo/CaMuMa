#!/usr/bin/python

from socket import *
import thread
import subprocess
import re

BUFF = 1024
HOST = '0.0.0.0'
PORT = 5023


def handler(clientsock,addr):
	while 1:
		data = clientsock.recv(BUFF)
		
		cmd = data.strip()
		if "" != cmd:
			print repr(addr) + ' recv:' + cmd
			if "close" == cmd: break # type 'close' on client console to close connection from the server side
			if "poweron" == cmd:
				subprocess.check_call(["/home/pi/camuma.sh", "poweron"])
			if "poweroff" == cmd:
				subprocess.check_call(["/home/pi/camuma.sh", "poweroff"])
			if "toggle" == cmd:
				subprocess.check_call(["/home/pi/camuma.sh", "toggle"])
			if "next" == cmd:
				subprocess.check_call(["/home/pi/camuma.sh", "next"])
			if "prev" == cmd:
				subprocess.check_call(["/home/pi/camuma.sh", "prev"])
			if "shuffle" == cmd:
				subprocess.check_call(["/home/pi/camuma.sh", "shuffle"])
			if "random" == cmd:
				subprocess.check_call(["/home/pi/camuma.sh", "random"])
			if "play" == cmd:
				subprocess.check_call(["/home/pi/camuma.sh", "play"])
			if "stop" == cmd:
				subprocess.check_call(["/home/pi/camuma.sh", "stop"])
			reres = re.search("([0-9]{6})",cmd)
			if reres:
				subprocess.check_call(["/home/pi/camuma.sh", reres.group(1)])
				clientsock.send("Launched album " + reres.group(1))

	clientsock.close()
	print addr, "- closed connection" #log on console

if __name__=='__main__':
    ADDR = (HOST, PORT)
    serversock = socket(AF_INET, SOCK_STREAM)
    serversock.setsockopt(SOL_SOCKET, SO_REUSEADDR, 1)
    serversock.bind(ADDR)
    serversock.listen(5)
    while 1:
        print 'waiting for connection... listening on port', PORT
        clientsock, addr = serversock.accept()
        print '...connected from:', addr
        thread.start_new_thread(handler, (clientsock, addr))
