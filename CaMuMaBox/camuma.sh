#!/bin/bash

case "$1" in
    "stop"|"play"|"toggle"|"next"|"prev"|"shuffle"|"status"|"random")
	mpc $1
	;;
    [0-9][0-9][0-9][0-9][0-9][0-9])
	sudo dos2unix -n /media/USB/camuma.lst /media/USB/camuma.lst.unix
	mpc clear
	cat /media/USB/camuma.lst.unix | grep $1 | cut -d':' -f2 | mpc add
	echo ID : $1
	cat /media/USB/camuma.lst.unix | grep $1 | cut -d':' -f2
	mpc play
	;;
    *)
	echo Error
	;;
esac	

