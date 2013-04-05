import os
import re

strpath = "/home/pi/"
strfile = "qrcode"

print "Reading data from qrcode"
# call os command to read qr data to text file
os.system("zbarimg -q "+strpath+strfile+".jpeg > "+strpath+strfile+".txt")

strreadtext = strpath+strfile+".txt"

if os.path.exists(strreadtext):
	strqrcode = open(strreadtext, 'r').read()
	print strqrcode
	m = re.match(r"QR-Code:camuma://([0-9]{6})", strqrcode)
	if m:
		print m.group(1)
		os.system ("~/camuma.sh " + m.group(1)) 
else:
		print "QR-Code text file not found"
