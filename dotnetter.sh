#!/bin/bash

# GOT BORED OF RUNNING DOTNET NEW CONSOLE EVERY DAY
# AFTER DAY2, HAD TO COME UP WITH A SOLUTION
# THIS CREATES dotnet new console IN FOLDERS day3 - day25

# store the current dir
CUR_DIR=$(pwd)

# Let the person running the script know what's going on.
echo "running into folders"

# Find all git repositories and update it to the master latest revision
for d in $(find . -type d -regextype posix-extended -regex "./day[3-9]|./day[1-2][0-9]"); do

    cd "$d";
    dotnet new console

    # lets get back to the CUR_DIR
    cd $CUR_DIR
done

echo "Complete!"