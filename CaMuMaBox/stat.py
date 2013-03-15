#!/usr/bin/python
import subprocess
import re

stat="stop"
song=""
piste=0
pistetot=0
duree="0:00"
dureetot="0:00"
progress=0

mpc = subprocess.check_output("mpc")
mpcs = str.splitlines(mpc)

if "[" in  mpc:
        song = mpcs[0]
        #m = re.match(r"\[(\w+)\]\s+\#([0-9]+)\/([0-9]+)\s+([\d\:]+).*",mpcs[1])
        #m = re.match(r"\[(\w+)\].*",mpcs[1])
        m = re.match(r"\[(\w+)\]\s+\#([0-9]+)\/([0-9]+)\s+([\d\:]+)\/([\d\:]+)\s+\((\d+)\%\).*",mpcs[1])
        print mpcs[1]
        if m:
                stat=m.group(1)
                piste = m.group(2)
                pistetot=m.group(3)
                duree=m.group(4)
                dureetot=m.group(5)
                progress=m.group(6)

print "Stat:" + stat
print "Song:" + piste + "/" + pistetot + " " + duree + "/" + dureetot + "("+progress+"/100) : "  + song
