#! /bin/bash
sum=0
read -d '' -a data < data.txt
for i in "${!data[@]}"
do 
  if [[ ${data[$i]} -lt ${data[$(($i+3))]} ]]
  then ((sum++))
  fi
done
echo $sum