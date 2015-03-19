#!/bin/bash

source camuma.cfg

apt-get update -y

apt-get upgrade -y

apt-get install git mpc mpd expect exfat-fuse dos2unix python-setuptools python-pip curl telnet cron -y


echo "$NAME" > /etc/hostname
echo "127.0.0.1 	$NAME" >> /etc/hosts
/etc/init.d/hostname.sh

# WiFi AP
if [ "$WIFI_AP" -eq 1 ]; then
	apt-get install rfkill zd1211-firmware hostapd hostap-utils iw dnsmasq  -y
fi

echo "snd_bcm2835" >> /etc/modules
apt-get install alsa-utils -y

apt-get autoremove -y

echo CaMuMa itself
cd /home/pi
git clone git://github.com/calexo/CaMuMa.git
cp CaMuMa/CaMuMaBox/* .
chown -R pi.pi .
chmod +x *.sh
chmod +x *.py

echo 10-my-media-automount
ln -s /home/pi/10-my-media-automount.rules /etc/udev/rules.d/10-my-media-automount.rules
mkdir /media/USB
#service udev restart

echo cron
crontab -l > /tmp/crondump
echo "*/10 * * * * /home/pi/camuma_up.sh" >> /tmp/crondump
echo "* * * * * /home/pi/camuma_daemons.sh" >> /tmp/crondump
crontab /tmp/crondump

echo inittab
cp /etc/inittab /etc/inittab.bak
cat /etc/inittab.bak | sed 's/1:2345.*/1:2345:respawn:\/bin\/login -f pi tty1 <\/dev\/tty1 >\/dev\/tty1 2>\&1/'  > /etc/inittab.tmp1
cat /etc/inittab.tmp1 | sed 's/T0:23:respawn.*/#T0:23:respawn:\/sbin\/getty -L ttyAMA0 115200 vt100/' > /etc/inittab

echo bashrc
echo >> ~pi/.bashrc
echo "~/camuma_boot.sh" >> ~pi/.bashrc


echo Pas Kodi : config.txt, rpi-update, locales

echo KODI $KODI

if [ "$KODI" -eq 0 ]; then
	cp /boot/config.txt /boot/config.txt.bak
	cat /boot/config.txt.bak | sed 's/#hdmi_drive=2/hdmi_drive=2/'  | sed 's/#hdmi_force_hotplug=1/hdmi_force_hotplug=1/' > /boot/config.txt
	
	echo "dwc_otg.lpm_enable=0 console=tty1 root=/dev/mmcblk0p2 rootfstype=ext4 elevator=deadline rootwait" > /boot/cmdline.txt

	wget http://goo.gl/1BOfJ -O /usr/bin/rpi-update && chmod +x /usr/bin/rpi-update
	rpi-update

	apt-get install locales -y
	dpkg-reconfigure locales
fi


#TODO
echo BT
if [ "$BLUETOOTH" -eq 1 ]; then
	echo BT Oui
	apt-get install bluez bluez-firmware blueman bluez-utils
	#echo 'blacklist bnep' >> /etc/modprobe.d/bluetooth.conf
	#sdptool add --channel=15 SP
	#rfcomm listen rfcomm0 15
	usermod -a -G dialout pi
fi

echo Python
apt-get install python-dev python-imaging python-imaging-tk python-pip -y

easy_install pyserial
easy_install python-mpd2




# Network Source
#/etc/fstab
#     //192.168.2.108/MP3   /mnt/music      cifs    uid=root,credentials=/etc/cifs.credentials,iocharset=iso8859-1,codepage=850        0       0
#/etc/cifs.credentials
#               username=mon_login_windows
#               password=mon_p4ss
#chmod 600 /etc/cifs.credentials
#mkdir /mnt/music
#mount /mnt/music
echo IR
if [ "$IR" -eq 1 ]; then
	/etc/modprobe.d/raspi-blacklist.conf
	comment blacklist spi-bcm2708
	pip install wiringpi wiringpi2
	pip install spidev

	apt-get install lirc liblircclient-dev -y
	#pip install pylirc2
	#pip install python-lirc
	apt-get install cython gcc
	git clone https://github.com/tompreston/python-lirc.git
	cd python-lirc/
	make py2
	python setup.py install

	# Add this to your /etc/modules file:

	# lirc_dev
	# lirc_rpi gpio_in_pin=23 gpio_out_pin=22
	# Change your /etc/lirc/hardware.conf file to:

	# ########################################################
	# # /etc/lirc/hardware.conf
	# #
	# # Arguments which will be used when launching lircd
	# LIRCD_ARGS="--uinput"

	# # Don't start lircmd even if there seems to be a good config file
	# # START_LIRCMD=false

	# # Don't start irexec, even if a good config file seems to exist.
	# # START_IREXEC=false

	# # Try to load appropriate kernel modules
	# LOAD_MODULES=true

	# # Run "lircd --driver=help" for a list of supported drivers.
	# DRIVER="default"
	# # usually /dev/lirc0 is the correct setting for systems using udev
	# DEVICE="/dev/lirc0"
	# MODULES="lirc_rpi"

	# # Default configuration files for your hardware if any
	# LIRCD_CONF=""
	# LIRCMD_CONF=""
	# ########################################################

	sudo /etc/init.d/lirc stop
	#mode2 -d /dev/lirc0

	#sudo irrecord -d /dev/lirc0 tst_lircd.conf
	cp tst_lircd2.conf /etc/lirc/lircd.conf
	sudo /etc/init.d/lirc start
fi
#irw

# free disk space
apt-get clean

# enleve les logs debug, qui finissent par remplir le disque
# http://root42.blogspot.ch/2013/04/delay-warnings-when-using-usb-audio-on.html
echo "options snd-usb-audio nrpacks=1" >> /etc/modprobe.d/alsa-base.conf

######

### Image
apt-get install fbi -y


## RASPBMC ##
if [ "$KODI" -eq 1 ]; then

	echo "export LANG=fr_FR@euro" >> /etc/profile
	echo "export LC_ALL=fr_FR@euro" >> /etc/profile
	echo "export LC_CTYPE=fr_FR@euro" >> /etc/profile
	echo "export LANGUAGE=fr_FR@euro" >> /etc/profile
	# RASPBMC
	# cp /home/pi/.kodi/userdata/addon_data/script.raspbmc.settings/settings.xml /home/pi/xbmc-settings.xml 
	# OSMC, mais 0 cron
	cp /home/osmc/.kodi/userdata/addon_data/script.module.osmcsetting.pi/settings.xml /home/pi/xbmc-settings.xml 
	# cp /home/pi/.xbmc/userdata/addon_data/script.raspbmc.settings/settings.xml /home/pi/xbmc-settings.xml 
	cat /home/pi/xbmc-settings.xml | sed 's/<setting id="sys.service.cron" value="false" \/>/<setting id="sys.service.cron" value="true" \/>/' > /home/osmc/.kodi/userdata/addon_data/script.module.osmcsetting.pi/settings.xml
fi

echo MPD-CONF
rm -f /etc/mpd.conf mpd.conf

if [ "$PORTABLE_BOX" -eq 1 ]; then 
	ln -s mpd-USB.conf mpd.conf
else
	ln -s mpd-net.conf mpd.conf
	# rm /etc/cifs.credentials
	# ln -s cifs.credentials /etc/cifs.credentials
	echo "username=$SAMBA_USER" > /etc/cifs.credentials
	echo "password=$SAMBA_PASS" >> /etc/cifs.credentials
	chmod 600 /etc/cifs.credentials

	echo "$SAMBA_PATH   /mnt/music      cifs    uid=root,credentials=/etc/cifs.credentials,iocharset=iso8859-1,ro        0       0" >> /etc/fstab
	
	mkdir /mnt/music
	mount /mnt/music
fi
ln -s ~pi/mpd.conf /etc/

#QR Code
modprobe bcm2835-v4l2
apt-get install zbar-tools -y
zbarcam -v --nodisplay --prescale=640x480

# WIFI
if [ "$WIFI" -eq 1 ]; then 
	echo "auto wlan0" >> /etc/network/interfaces
	echo "allow-hotplug wlan0" >> /etc/network/interfaces
 	echo "iface wlan0 inet dhcp" >> /etc/network/interfaces
    echo -e "\twpa-ssid \"$WIFI_SSID\"" >> /etc/network/interfaces
    echo -e "\twpa-psk \"$WIFI_PWD\"" >> /etc/network/interfaces
fi

echo REBOOT, press Enter to Reboot
read
sudo reboot