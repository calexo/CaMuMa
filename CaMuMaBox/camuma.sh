#!/bin/bash

MPC=`which mpc`
BC="`which bc` -l"
LOGGER="`which logger`"
CURRENTIDFILE="/home/pi/current_id"
STAT_FILE="/home/pi/stat_file"

NORMAL_VOLUME=100
FADED_VOLUME=30
FADE_TIME=2
SLEEP=0.02

source /home/pi/camuma.cfg

if [ "$PORTABLE_BOX" -eq 1 ]; then
	MEDIAPATH=/mnt/USB
fi
if [ "$PORTABLE_BOX" -eq 0 ]; then
	MEDIAPATH=/mnt/music
fi

#echo $USE_PIONEER_VSX
#
$LOGGER -t camuma "Arg : $1"

fadeout() {
	VOLUME=$(($NORMAL_VOLUME - 5))
	while [ $VOLUME -ge $FADED_VOLUME ]
	do
	    $MPC volume $VOLUME > /dev/null
	    VOLUME=$(($VOLUME - 5))
	    sleep $SLEEP
	    $MPC volume
	done
}

fadein() {
	VOLUME=$(($FADED_VOLUME + 5))
	while [ $VOLUME -le $NORMAL_VOLUME ]
	do
	    $MPC volume $VOLUME > /dev/null
	    VOLUME=$(($VOLUME + 5))
	    #sleep `echo "$FADE_TIME/(5*($NORMAL_VOLUME - $FADED_VOLUME))" | $BC`
	    sleep $SLEEP
	    $MPC volume
	done
}

case "$1" in
	"poweron")
        /usr/bin/expect ~pi/vsx_on.expect &
        ;;
    "poweroff")
        /usr/bin/expect ~pi/vsx_off.expect &
        ;;
    "reboot")
		sudo reboot
		;;
	"halt")
		sudo halt
		;;
	"reload"|"update")
		$MPC update
		if [ "$PORTABLE_BOX" -eq 1 ]; then
			echo "Update From USB"
			sudo dos2unix -n /media/USB/camuma.lst /home/pi/camuma.lst.unix &
		else
			echo "Update From Network"
			sudo dos2unix -n /mnt/music/camuma.lst /home/pi/camuma.lst.unix &
		fi
		;;
	"modeusb")
		mv /home/pi/camuma.cfg /home/pi/camuma.cfg.old
		sed 's/PORTABLE_BOX=0/PORTABLE_BOX=1/' /home/pi/camuma.cfg.old > /home/pi/camuma.cfg
		rm /home/pi/mpd.conf
		ln -s /home/pi/mpd-USB.conf /home/pi/mpd.conf
		;;
	"modenet")
		mv /home/pi/camuma.cfg /home/pi/camuma.cfg.old
		sed 's/PORTABLE_BOX=1/PORTABLE_BOX=0/' /home/pi/camuma.cfg.old > /home/pi/camuma.cfg
		rm /home/pi/mpd.conf
		ln -s /home/pi/mpd-net.conf /home/pi/mpd.conf
		;;

    "toggle"|"shuffle"|"status"|"random")
		$MPC $1
		;;
	"next"|"prev")
		# fadeout
		$MPC $1
		# fadein
		;;
	"play")
		$MPC play
		fadein
		;;
	"stop")
		fadeout
		$MPC stop
		fadein
		;;
	"stats")
		date
		cat $STAT_FILE
		date
		;;
    [0-9][0-9][0-9][0-9][0-9][0-9])
		fadeout
		#sudo dos2unix -n /media/USB/camuma.lst /home/pi/camuma.lst.unix
		$MPC clear
		ALBUM=`cat /home/pi/camuma.lst.unix | grep $1 | cut -d':' -f2`
		echo Album : $ALBUM
		echo ID : $1
		echo $1 > $CURRENTIDFILE
		$LOGGER -t camuma "Album : $ALBUM"
		$MPC add "$ALBUM"
		# cat /home/pi/camuma.lst.unix | grep $1 | cut -d':' -f2
		if [ "$1" == "111111" ]; then
			echo "Random On"
			$MPC random on
		else
			echo "Random Off"
			$MPC random off
		fi
		echo Start playing
		$MPC play
		fadein
		if [ "$KODI" -eq 1 ]; then
			/home/pi/xbmc_pic.sh "$MEDIAPATH/$ALBUM/folder.jpg"
		else
			/usr/bin/fbi -T 1 "$MEDIAPATH/$ALBUM/folder.jpg"
		fi
		;;
    *)
		echo Error
		$LOGGER -t camuma "Error"
	;;
esac	

