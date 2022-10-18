%~d0
cd "%~dp0"
rem Add parameter -hiscoredat <path>\hiscore.dat
rem if hiscore.dat is not in the application directory nor in the working directory
rem Add parameter -descr <path>\db
rem if XML database is not in the application directory nor in the working directory
break>raiden.txt
FOR /F "tokens=* USEBACKQ" %%F IN (`call ..\..\hi2txt.exe -r raiden2.hi`) DO (
SET var=%%F
echo %%F >> raiden.txt
)
pause