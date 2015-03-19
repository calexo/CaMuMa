#!/bin/bash

cd /home/pi/CaMuMa/CaMuMaBox/
git pull 
cd /home/pi/
cp CaMuMa/CaMuMaBox/* .
chown -R pi.pi .
chmod +x *.sh
chmod +x *.py
