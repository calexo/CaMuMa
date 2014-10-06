#!/usr/bin/python

import serial
import socket
#import sys
import io


TCP_IP = '127.0.0.1'
TCP_PORT = 5023


ser=serial.Serial(port='/dev/ttyAMA0',baudrate=9600,xonxoff=True,
						bytesize=serial.EIGHTBITS,
                        parity=serial.PARITY_NONE,
                        stopbits=serial.STOPBITS_ONE)

ser_io = io.TextIOWrapper(io.BufferedRWPair(ser, ser, 1),  
                               newline = '\n',
                               line_buffering = True)

End='END'
def recv_end(the_socket):
    total_data=[];data=''
    while True:
            data=the_socket.recv(8192)
            if End in data:
                total_data.append(data[:data.find(End)])
                break
            total_data.append(data)
            if len(total_data)>1:
                #check if end_of_data was split
                last_pair=total_data[-2]+total_data[-1]
                if End in last_pair:
                    total_data[-2]=last_pair[:last_pair.find(End)]
                    total_data.pop()
                    break
    return ''.join(total_data) + End


while True:
	ser_io.write(unicode('Awaiting...\n'))
	# ser.flushOutput()

	# Receiving from Bluetooth Serial connection
	# ser.flushInput()
	inputs=ser_io.readline().strip()
	print "input : " + inputs

	skt = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	skt.connect((TCP_IP, TCP_PORT))
	
	#Sending command
	try:
		skt.send(inputs)
	except:
		print "Inputs non Unicode : " + inputs

	if 'stats' in inputs:
		# Receiving response
		print "send stats"

		ret = recv_end(skt)
		print "retour stats recu"
		# ser.write('stat:playing,random:off\r')
		ser_io.write(unicode(ret, "iso8859-1", errors='ignore'))

		print "retour stats envoye via BT"
	if 'listalbums' in inputs:
		print "send listalbums"

		ret = recv_end(skt)
		print "retour listalbums recu"
		# ser.write('stat:playing,random:off\r')
		# ser_io.write(unicode(ret, "iso8859-1", errors='ignore'))
		print ret
		# ser_io.write(ret.encode("iso8859-1", errors='ignore'))
		ser_io.write(unicode(ret, "iso8859-1", errors='ignore'))



		print "retour listalbums envoye via BT"


	skt.close()



while True:
	ser.write('Awaiting...\n')
	ser.flushOutput()

	# Receiving from Bluetooth Serial connection
	ser.flushInput()
	inputs=ser.readline().strip()
	print inputs

	skt = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	skt.connect((TCP_IP, TCP_PORT))
	
	#Sending command
	skt.send(inputs)

	# if 'stats' in inputs:
	# Receiving response
	#ret=skt.recv(512)
	
	# ret = recv_end(skt)
	# print ret
	# ser.write('stat:playing,random:off\r')
	# ser.write(ret)
	# ser.write('\n')
	# ser.flushOutput()

	
	ser_io.write(unicode("stat:playing,random:off\n"))
	#ser_io.flush()

	hello = ser_io.readline()
	# print hello
	# print hello == unicode("stat:playing,random:off\n")



	skt.close()

