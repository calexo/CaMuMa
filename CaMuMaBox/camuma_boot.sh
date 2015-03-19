#!/bin/bash

source camuma.cfg

echo "CaMuMa - Reloading server..."
#sudo service mpd start
mpc pause
mpc volume 100

echo "CaMuMa - Updating database..."
mpc update

echo "Preparing album list..."

if [ "$PORTABLE_BOX" -eq 1 ]; then
	echo "From USB"
	./list_camumaid.py /media/USB/ &
else
	echo "From Network"
	./list_camumaid.py /mnt/music/ &
fi



if [ "$PORTABLE_BOX" -eq 1 ]; then
	echo "From USB"
	sudo dos2unix -n /media/USB/camuma.lst /home/pi/camuma.lst.unix &
else
	echo "From Network"
	sudo dos2unix -n /mnt/music/camuma.lst /home/pi/camuma.lst.unix &
fi

if [ "$USE_PIONEER_VSX" -eq 1 -a "$BOOT_POWER_AMP" -eq 1 ]; then
	echo "Preparing Pioneer VSX Amp..."
	/home/pi/camuma.sh poweron
fi

~/camuma_up.sh &

sudo ~/camuma_daemons.sh


if [ "$BOOT_SOUND" -eq 1 ]; then
	aplay ~/Lightning.wav &
	# SI DAC
	if [ "$DAC" -eq 1 ]; then
		aplay --device="default:CARD=Audio" Lightning.wav &
		aplay --device="default:CARD=DAC" Lightning.wav &
	fi
fi

#~/camumad.sh

#~/qrdecode.sh &

sudo /home/pi/update.sh &

logger -t camuma "Boot OK - Ready"