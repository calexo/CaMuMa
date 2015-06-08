#!/usr/bin/python
import subprocess
import re
import time

stat_file="/home/pi/stat_file"
ScreenFile = "/home/pi/screen.txt"

while 1:
        line_song=0
        artist=""
        album=""
        song=""
        filename=""
        line_position=1
        stat="stop"
        piste=0
        pistetot=0
        duree="0:00"
        dureetot="0:00"
        progress=0
        line_info=2
        updating="off"
        volume=0
        repeat="off"
        random="off"
        single="off"
        consume="off"


        mpc = subprocess.check_output(["/usr/bin/mpc" , "-f", "%artist% $ %album% $ %title% $ %file%"])
        mpcs = str.splitlines(mpc)

        vsx = subprocess.check_output(["/home/pi/vsx_get.sh"])

        #print mpc

        if 1: #"[" in  mpc:
                # Line 1 : Song artist - title
                m = re.match(r"(.*) \$ (.*) \$ (.*) \$ (.*)",   mpcs[line_song])
                #print mpcs[line_song]
                if m:
                        artist = m.group(1)
                        album = m.group(2)
                        song = m.group(3)
                        filename = m.group(4)
                        if filename.endswith(".mp3"):
                            filetype="MP3"
                        elif filename.endswith(".flac"):
                            filetype="FLAC"
                        else:
                            filetype="?"
                else:
                        line_info=0
                        line_position=0


                #Line 2 : Status, position
                m = re.match(r"\[(\w+)\]\s+\#([0-9]+)\/([0-9]+)\s+([\d\:]+)\/([\d\:]+)\s+\((\d+)\%\).*",mpcs[line_position])
                #print mpcs[line_position]
                if m:
                        stat=m.group(1)
                        piste = m.group(2)
                        pistetot=m.group(3)
                        duree=m.group(4)
                        dureetot=m.group(5)
                        progress=m.group(6)

                # Line 3 : Updating or Volume, Repeat, Single, Consume

                if mpcs[line_info].startswith("Updating"):
                       updating="on" 
                       line_info=line_info+1

                #m = re.match(r"volume: ([0-9]+)\%\s+repeat: (\w)\s+random: (\w)\s+single: (\w)\s+consume: (\w)",mpcs[line_info])
                #print mpcs[line_info]
                m = re.match(r"volume:\s*([0-9]+)\%\s+repeat: (\w+)\s+random: (\w+)\s+single: (\w+)\s+consume: (\w+)",mpcs[line_info])
                if m:
                        #print "Line Info OK"
                        volume=m.group(1)
                        repeat=m.group(2)
                        random=m.group(3)
                        single=m.group(4)
                        consume=m.group(5)
                
                try:
                        f = open(stat_file, "w")
                        f.write("stat:" + stat + "\n")
                        f.write("piste:" + str(piste) + "\n")
                        f.write("pistetot:" + str(pistetot) + "\n")
                        f.write("duree:" + duree + "\n")
                        f.write("dureetot:" + dureetot + "\n")
                        f.write("progress:" + str(progress) + "\n")
                        f.write("song:" + song + "\n")
                        f.write("artist:" + artist + "\n")
                        f.write("album:" + album + "\n")
                        f.write("volume:" + str(volume) + "\n")
                        f.write("repeat:" + repeat + "\n")
                        f.write("random:" + random + "\n")
                        f.write("single:" + single + "\n")
                        f.write("consume:" + consume + "\n")
                        f.write("updating:" + updating + "\n")
                        f.write("filetype:" + filetype + "\n")
                        f.write("vsx:" + vsx )
                        f.write("END\n")
                        f.close()
                except:
                        print("Can't write stat")

                try:
                        f = open(ScreenFile, "w")
                        # f.write("stat:" + stat + "\n")
                        f.write(str(piste) +"/" + str(pistetot) + "  " + duree + "\n")
                        f.write(artist + "\n")
                        f.write(album + "\n")
                        f.write(song + "\n")
                        f.write("#" + stat +":" + random + ":" + progress + ":" + updating +  ":" + filetype + "\n")
                        f.close()
                except:
                        print("Can't write screen")

                time.sleep(1)
