#!/bin/bash

source /home/pi/camuma.cfg

COMMAND="stat.py"
RUNNING=`ps -ef | grep ${COMMAND} |grep -v grep  | wc -l`
if [ ${RUNNING} -gt 0 ]; then
	echo "${COMMAND} is already running."
else
	echo "Launching ${COMMAND}..."
	python ~pi/${COMMAND} &
fi




COMMAND="daemon.py"
RUNNING=`ps -ef | grep ${COMMAND} |grep -v grep  | wc -l`
if [ ${RUNNING} -gt 0 ]; then
	echo "${COMMAND} is already running."
else
	echo "Launching ${COMMAND}..."
	python ~pi/${COMMAND} &
fi	

sleep 1

if [ "$BLUETOOTH" -eq 1 ]; then
	COMMAND="daemon_serial.py"
	RUNNING=`ps -ef | grep ${COMMAND} |grep -v grep  | wc -l`
	if [ ${RUNNING} -gt 0 ]; then
		echo "${COMMAND} is already running."
	else
		echo "Launching ${COMMAND}..."
		python ~pi/${COMMAND} &
	fi
fi

if [ "$NOKIA_SCREEN" -eq 1 ]; then
	COMMAND="calexoLCD.py"
	RUNNING=`ps -ef | grep ${COMMAND} |grep -v grep  | wc -l`
	if [ ${RUNNING} -gt 0 ]; then
		echo "${COMMAND} is already running."
	else
		echo "Launching ${COMMAND}..."
		python ~pi/${COMMAND} &
	fi
fi


if [ "$IR" -eq 1 ]; then
	COMMAND="ir_daemon.py"
	RUNNING=`ps -ef | grep ${COMMAND} |grep -v grep  | wc -l`
	if [ ${RUNNING} -gt 0 ]; then
		echo "${COMMAND} is already running."
	else
		echo "Launching ${COMMAND}..."
		python ~pi/${COMMAND} &
	fi
fi

if [ "$IR" -eq 1 ]; then
	COMMAND="gpio_daemon.py"
	RUNNING=`ps -ef | grep ${COMMAND} |grep -v grep  | wc -l`
	if [ ${RUNNING} -gt 0 ]; then
		echo "${COMMAND} is already running."
	else
		echo "Launching ${COMMAND}..."
		python ~pi/${COMMAND} &
	fi
fi

#~/qrdecode.sh &
