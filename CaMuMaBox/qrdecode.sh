#!/bin/bash
cd /home/pi

while true
do
    echo Capturing...
	/opt/vc/bin/raspistill -o  /run/shm/qrcode.jpg -w 640 -h 480 -t 1  --nopreview
	echo Decoding...
	python qrdecode.py
 done
 