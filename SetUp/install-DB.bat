@echo off
echo Updating database...

cd ..
cd Infraestructure.Core

dotnet restore
dotnet build

dotnet ef database update

if %ERRORLEVEL% EQU 0 (
    echo Database updated successfully.
) else (
    echo Failed to update database.
)

pause
