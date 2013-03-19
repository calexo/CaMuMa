#!/bin/bash

source camuma.cfg

echo "CaMuMa - Reloading server..."
#sudo service mpd start
mpc pause
mpc volume 80

echo "CaMuMa - Updating database..."
mpc update

if [ "$PORTABLE_BOX" -eq 1 ]; then
	echo "Preparing album list..."
	sudo dos2unix -n /media/USB/camuma.lst /home/pi/camuma.lst.unix &
fi

if [ "$USE_PIONEER_VSX" -eq 1 -a "$BOOT_POWER_AMP" -eq 1 ]; then
	echo "Preparing Pioneer VSX Amp..."
	/home/pi/camuma.sh poweron
fi

~/camuma_up.sh &
python ~/daemon.py &
#~/qrdecode.sh &

if [ "$BOOT_SOUND" -eq 1 ]; then
	aplay ~/Lightning.wav
fi

~/camumad.sh