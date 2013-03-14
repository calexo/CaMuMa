#!/bin/sh
IP=`hostname -I | tr -d ' '`
echo IP : $IP
SERIAL=`cat /proc/cpuinfo | grep Serial | cut -d':' -f2 | tr -d ' '`
echo SERIAL : $SERIAL

read ACTCOD
echo http://camuma.calexo.com/api/reg/$SERIAL/$IP/$ACTCOD

sleep 10

curl http://camuma.calexo.com/api/reg/$SERIAL/$IP/$ACTCOD
