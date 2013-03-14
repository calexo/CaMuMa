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
		print repr(addr) + ' recv:' + repr(data)
		cmd = data.strip()
		if "close" == cmd: break # type 'close' on client console to close connection from the server side
		if "toggle" == cmd:
			subprocess.check_call(["/home/pi/camuma.sh", "toggle"])
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
