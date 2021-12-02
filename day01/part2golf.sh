# original file name
# s=0;read -d '' -a d<data.txt;for i in "${!d[@]}";{ [[ ${d[i]} -lt ${d[$((i+3))]} ]]&&((s++));};echo $s
s=0;read -d '' -a d<t;for i in "${!d[@]}";{ [[ d[i] -lt d[$((i+3))] ]]&&((s++));};echo $s