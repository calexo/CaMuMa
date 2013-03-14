#!/bin/sh
cd ~

/usr/bin/fswebcam -d /dev/video0 -r 640x480 qrcode.jpeg  --no-banner -l3 --exec "python qrdecode.py"
