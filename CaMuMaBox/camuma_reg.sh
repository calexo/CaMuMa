#!/bin/sh
IP=`hostname -I | tr -d ' '`
echo IP : $IP
SERIAL=`cat /proc/cpuinfo | grep Serial | cut -d':' -f2 | tr -d ' '`
echo SERIAL : $SERIAL

echo "Enter 6 digits (0-9)"
read ACTCOD
#echo http://192.168.2.108:8080/camuma_portal/app_dev.php/api/reg/$SERIAL/$IP/$ACTCOD
#sleep 10
#curl http://192.168.2.108:8080/camuma_portal/app_dev.php/api/reg/$SERIAL/$IP/$ACTCOD
curl http://api.camuma.calexo.com/box/reg/$SERIAL/$IP/$ACTCOD

echo "Go to :"
echo "http://api.camuma.calexo.com/registerbox"
echo "And enter the same digits"
