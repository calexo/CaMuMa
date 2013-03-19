ln -s /home/pi/10-my-media-automount.rules /etc/udev/rules.d/10-my-media-automount.rules

#vi /etc/mpd.conf
	# audio_output {
  	# type   "pulse"
  	# name   "MPD PulseAudio Output"
	#}

#vi /etc/pulse/default.pa
	# comment load-module module-suspend-on-idle
	