#! /bin/bash
hor=0
dep=0
aim=0
while IFS=" " read -r command value
do
  case $command in
    down)
      aim=$(($aim+$value))
      ;;
    up)
      aim=$(($aim-$value))
      ;;
    forward)
      hor=$(($hor+$value))
      dep=$(($dep+$aim*$value))
      ;;
  esac
done < data.txt
echo "Part 2 " $(($hor*$dep))