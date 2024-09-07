# dotnet_project
api dotnet in mvc architecture

## Mise en place de l'envirronnement
Dans un envirronnement windows une fois que gitbash shell est installer
nano ~/.bashrc
alias code='"/c/Program Files/Microsoft Visual Studio/2022/Community/Common7/ID>
source ~/.bashrc
code .

## mise en place de connexion ssh via power shell
click droit sur powershell execution en tant qu'admin
puis taper la commande :  Add-WindowsCapability -Online -Name OpenSSH.Client*

## Installation sur Node.js & Npm & Nvm
https://learn.microsoft.com/fr-fr/windows/dev-environment/javascript/nodejs-on-windows#install-nvm-windows-nodejs-and-npm

=> Dans powershell install 
 nvm install latest

 NB **install node version**
 .nvm list available
 .nvm install <version>
 .nvm use <version>

=> utilise npm inclu avec node.js ou yarn:
npm install --global yarn

##Installation sql server : 

https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
Download SSMS
Download SQL Server Management Studio (SSMS) 20.2
