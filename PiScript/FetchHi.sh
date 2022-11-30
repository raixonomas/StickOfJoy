for file in $(find /home/pi/RetroPie/roms/arcade/fbneo -type f -name "*.hi")
do
    fileName=$(basename $file)
    name=$(echo $fileName| cut -f 1 -d '.')
    java -jar /home/pi/RetroPie/roms/arcade/fbneo/hi2txt/hi2txt.jar -hiscoredat /home/pi/RetroPie/roms/arcade/fbneo/ReadableScore/$name.txt
done: