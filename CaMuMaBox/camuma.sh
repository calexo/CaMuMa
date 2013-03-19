#!/bin/bash

MPC=`which mpc`
BC="`which bc` -l"

NORMAL_VOLUME=80
FADED_VOLUME=30
FADE_TIME=2
SLEEP=0.02

source camuma.cfg

echo $USE_PIONEER_VSX

fadeout() {
	VOLUME=$(($NORMAL_VOLUME - 5))
	while [ $VOLUME -ge $FADED_VOLUME ]
	do
	    $MPC volume $VOLUME > /dev/null
	    VOLUME=$(($VOLUME - 5))
	    sleep $SLEEP
	    mpc volume
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
	    mpc volume
	done
}

case "$1" in
	"poweron")
        /usr/bin/expect ~pi/vsx_on.expect &
        ;;
    "poweroff")
        /usr/bin/expect ~pi/vsx_off.expect &
        ;;
    "toggle"|"shuffle"|"status"|"random")
		$MPC $1
		;;
	"next"|"prev")
		fadeout
		$MPC $1
		fadein
		;;
	"play")
		$MPC play
		fadein
		;;
	"stop")
		fadeout
		$MPC stop
		;;
    [0-9][0-9][0-9][0-9][0-9][0-9])
		fadeout
		#sudo dos2unix -n /media/USB/camuma.lst /home/pi/camuma.lst.unix
		$MPC clear
		cat /home/pi/camuma.lst.unix | grep $1 | cut -d':' -f2 | $MPC add
		echo ID : $1
		cat /home/pi/camuma.lst.unix | grep $1 | cut -d':' -f2
		$MPC play
		fadein
		;;
    *)
		echo Error
	;;
esac	

