#!/bin/bash
sudo service mpd stop
#while [ ping 192.168.1.112 -c 2 2>/dev/null >/dev/null ]
#do
#        echo "CaMuMa - Waiting network..."
#        sleep 1
#done
#echo "CaMuMa - Mounting..."
#sleep 3
#sudo mount /mnt/music
echo "CaMuMa - Reloading server..."
sudo service mpd start
mpc pause
echo "CaMuMa - Updating database..."
#sudo dos2unix -n /mnt/music/camuma.lst /mnt/music/camuma.lst.unix &
mpc update
~/camuma_up.sh &
python ~/daemon.py &
~/qrdecode.sh &
