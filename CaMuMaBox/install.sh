apt-get update -y
apt-get upgrade -y

apt-get install git -y

apt-get install mpc mpd -y

# WiFi AP
apt-get install rfkill zd1211-firmware hostapd hostap-utils iw dnsmasq  -y

apt-get install expect -y

apt-get install exfat-fuse -y

apt-get install dos2unix -y

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
crontab /tmp/crondump

cp /etc/inittab /etc/inittab.bak
cat /etc/inittab.bak | sed 's/1:2345.*/1:2345:respawn:\/bin\/login -f pi tty1 <\/dev\/tty1 >\/dev\/tty1 2>\&1/'  > /etc/inittab

echo >> ~pi/.bashrc
echo "~/camuma_boot.sh" >> ~pi/.bashrc

cp /boot/config.txt /boot/config.txt.bak
cat /boot/config.txt.bak | sed 's/#hdmi_drive=2/hdmi_drive=2/'  | sed 's/#hdmi_force_hotplug=1/hdmi_force_hotplug=1/' > /boot/config.txt

# MPD-CONF
rm /etc/mpd.conf
ln -s ~pi/mpd.conf /etc/

apt-get install bluez bluez-firmware blueman bluez-utils
echo 'blacklist bnep' >> /etc/modprobe.d/bluetooth.conf
# /boot/cmdline.txt -> otg_speed=1
sdptool add --channel=15 SP
rfcomm listen rfcomm0 15

wget http://goo.gl/1BOfJ -O /usr/bin/rpi-update && chmod +x /usr/bin/rpi-update
rpi-update


# Network Source
#/etc/fstab
#     //192.168.2.108/MP3   /mnt/music      cifs    uid=root,credentials=/etc/cifs.credentials,iocharset=iso8859-1,codepage=850        0       0
#/etc/cifs.credentials
#               username=mon_login_windows
#               password=mon_p4ss
#sudo chmod 600 /etc/cifs.credentials
#mkdir /mnt/music
#mount /mnt/music
