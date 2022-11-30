server="10.4.1.44"
pause=2

for file in $(find /home/pi/RetroPie/roms/arcade/fbneo/ReadableScore/ -type f -name "*.txt")
do
    fileName=$(basename $file)
    name=$(echo $fileName| cut -f 1 -d '.')
    mosquitto_pub -h $server -t Game/$name -p 707 -f $file -r

done: