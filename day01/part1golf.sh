s=0;read -d '' -a d<t;for i in "${!d[@]}";{ [[ d[i] -lt d[$((i+1))] ]]&&((s++));};echo $s