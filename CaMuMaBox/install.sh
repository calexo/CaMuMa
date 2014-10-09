apt-get update -y
apt-get upgrade -y

apt-get install git -y

apt-get install mpc mpd -y

# WiFi AP
apt-get install rfkill zd1211-firmware hostapd hostap-utils iw dnsmasq  -y

apt-get install expect -y

apt-get install exfat-fuse -y

apt-get install dos2unix -y

apt-get install python-setuptools python-pip -y

apt-get install curl -y


echo "snd_bcm2835" >> /etc/modules
apt-get install alsa-utils -y


apt-get autoremove -y


# CaMuMa itself
cd /home/pi
git clone git://github.com/calexo/CaMuMa.git
cp CaMuMa/CaMuMaBox/* .
chown -R pi.pi .
chmod +x *.sh
chmod +x *.py

ln -s /home/pi/10-my-media-automount.rules /etc/udev/rules.d/10-my-media-automount.rules
mkdir /media/USB
#service udev restart

crontab -l > /tmp/crondump
echo "*/10 * * * * /home/pi/camuma_up.sh" >> /tmp/crondump
echo "* * * * * /home/pi/camuma_daemons.sh" >> /tmp/crondump
crontab /tmp/crondump

cp /etc/inittab /etc/inittab.bak
cat /etc/inittab.bak | sed 's/1:2345.*/1:2345:respawn:\/bin\/login -f pi tty1 <\/dev\/tty1 >\/dev\/tty1 2>\&1/'  > /etc/inittab.tmp1
cat /etc/inittab.tmp1 | sed 's/T0:23:respawn.*/#T0:23:respawn:\/sbin\/getty -L ttyAMA0 115200 vt100/' > /etc/inittab


echo >> ~pi/.bashrc
echo "~/camuma_boot.sh" >> ~pi/.bashrc

cp /boot/config.txt /boot/config.txt.bak
cat /boot/config.txt.bak | sed 's/#hdmi_drive=2/hdmi_drive=2/'  | sed 's/#hdmi_force_hotplug=1/hdmi_force_hotplug=1/' > /boot/config.txt

# MPD-CONF
rm /etc/mpd.conf
ln -s ~pi/mpd.conf /etc/

#TODO
apt-get install bluez bluez-firmware blueman bluez-utils
#echo 'blacklist bnep' >> /etc/modprobe.d/bluetooth.conf
#sdptool add --channel=15 SP
#rfcomm listen rfcomm0 15
usermod -a -G dialout pi

wget http://goo.gl/1BOfJ -O /usr/bin/rpi-update && chmod +x /usr/bin/rpi-update
rpi-update

easy_install pyserial
easy_install python-mpd2

echo "dwc_otg.lpm_enable=0 console=tty1 root=/dev/mmcblk0p2 rootfstype=ext4 elevator=deadline rootwait" > /boot/cmdline.txt


apt-get install locales -y
dpkg-reconfigure locales

# Network Source
#/etc/fstab
#     //192.168.2.108/MP3   /mnt/music      cifs    uid=root,credentials=/etc/cifs.credentials,iocharset=iso8859-1,codepage=850        0       0
#/etc/cifs.credentials
#               username=mon_login_windows
#               password=mon_p4ss
#chmod 600 /etc/cifs.credentials
#mkdir /mnt/music
#mount /mnt/music

apt-get install python-dev -y

apt-get install python-imaging python-imaging-tk python-pip -y

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


Add this to your /etc/modules file:

lirc_dev
lirc_rpi gpio_in_pin=23 gpio_out_pin=22
Change your /etc/lirc/hardware.conf file to:

########################################################
# /etc/lirc/hardware.conf
#
# Arguments which will be used when launching lircd
LIRCD_ARGS="--uinput"

# Don't start lircmd even if there seems to be a good config file
# START_LIRCMD=false

# Don't start irexec, even if a good config file seems to exist.
# START_IREXEC=false

# Try to load appropriate kernel modules
LOAD_MODULES=true

# Run "lircd --driver=help" for a list of supported drivers.
DRIVER="default"
# usually /dev/lirc0 is the correct setting for systems using udev
DEVICE="/dev/lirc0"
MODULES="lirc_rpi"

# Default configuration files for your hardware if any
LIRCD_CONF=""
LIRCMD_CONF=""
########################################################

sudo /etc/init.d/lirc stop
#mode2 -d /dev/lirc0

#sudo irrecord -d /dev/lirc0 tst_lircd.conf
cp tst_lircd2.conf /etc/lirc/lircd.conf
sudo /etc/init.d/lirc start
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

echo "export LANG=fr_FR@euro" >> /etc/profile
echo "export LC_ALL=fr_FR@euro" >> /etc/profile
echo "export LC_CTYPE=fr_FR@euro" >> /etc/profile
echo "export LANGUAGE=fr_FR@euro" >> /etc/profile
cp /home/pi/.xbmc/userdata/addon_data/script.raspbmc.settings/settings.xml /home/pi/xbmc-settings.xml 
cat /home/pi/xbmc-settings.xml | sed 's/<setting id="sys.service.cron" value="false" \/>/<setting id="sys.service.cron" value="true" \/>/' > /home/pi/.xbmc/userdata/addon_data/script.raspbmc.settings/settings.xml