#! /bin/bash
hor=0
dep=0
while IFS=" " read -r command amount
do
  case $command in
    down)
      dep=$(($dep+$amount))
      ;;
    up)
      dep=$(($dep-$amount))
      ;;
    forward)
      hor=$(($hor+$amount))
      ;;
  esac
done < data.txt
echo $(($hor*$dep))