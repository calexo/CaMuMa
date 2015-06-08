#!/bin/sh

PWR=`/usr/bin/expect /home/pi/vsx_get.expect | tail -n1`

echo $PWR
