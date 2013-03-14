#!/bin/bash

CMD="~/camuma.sh"

echo "CaMuMa :"
while read -n1 c
do
    case "$c" in
	".")
	    id=""
	    echo "ID reset"
	    ;;
	"/")
	    $CMD toggle
	    ;;
	"*")
	    $CMD shuffle
	    ;;
	[0-9])
	    id=$id"$c"
	    echo "ID:$id"
        case "$id" in
			"000001")
			    ~/camuma_reg.sh
			    ;;
			"000008")
			    sudo reboot
			    ;;
			"000009")
			    sudo halt
			    ;;
			"000100")
			    # HDMI
				sudo amixer cset numid=3 2
				;;
			"000101")
				# Jack
				sudo amixer cset numid=3 1
				;;
			"000201")
			    sudo service ssh start
			    ;;
			*) 
		        if [ ${#id} -eq 6 ]; then
				    $CMD $id
				    id=""
		        fi
   		esac
	    ;;
	-)
	    $CMD prev
	    ;;
	+)
	    $CMD next
	    ;;
    esac
    
done
