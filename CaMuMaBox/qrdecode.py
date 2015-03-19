import os
import re

# strpath = "/home/pi/"
strpath = "/run/shm/"
strfile = "qrcode"

print "Reading data from qrcode"
# call os command to read qr data to text file
os.system("zbarimg -q "+strpath+strfile+".jpg > "+strpath+strfile+".txt")

strreadtext = strpath+strfile+".txt"

if os.path.exists(strreadtext):
        strqrcode = open(strreadtext, 'r').read()
        print strqrcode
	m = re.match(r"QR-Code:camuma://([0-9]{6})", strqrcode)
	if m:
		print m.group(1)
		os.system ("/home/pi/camuma.sh " + m.group(1)) 
else:
        print "QR-Code text file not found"
