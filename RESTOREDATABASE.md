cd .\src\appdata\; git clean -xdf -n; cd ..\Foundation\App_Data\; git clean -xdf -n; 
sqlcmd -S . -E -Q "Restore DATABASE [Foundation4.Commerce] FROM DISK = 'C:\Users\cuond\Desktop\Foundation4\Foundation4.Commerce.bak' WITH REPLACE";
sqlcmd -S . -E -Q "Restore DATABASE [Foundation4.Cms] FROM DISK = 'C:\Users\cuond\Desktop\Foundation4\Foundation4.Cms.bak' WITH REPLACE";

cd ..; npm ci; cd ..; cd ..