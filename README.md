# SchoolManagement Project

## Prerequisites
- .NET 8 SDK
- SQL Server 
- Visual Studio 2022 or VS Code
- Git

## Setup Instructions
git clone https://github.com/sam856/SchoolManage.git
cd SchoolManagment

Open `appsettings.json` and update the connection string:
{
  "ConnectionStrings": {
    "dbcontext": "Server=db33499.public.databaseasp.net; Database=db33499; User Id=db33499; Password=***8; Encrypt=True; TrustServerCertificate=True;"
  }
}

dotnet restore
dotnet build

## Database Migration Commands
dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet ef migrations script -o migration.sql

## Running the Project
dotnet run

Swagger UI: https://localhost:<PORT>/swagger

## Git Ignore
.vs/
bin/
obj/
*.user
*.suo
*.log

## Git Commands
git branch
git add .
git commit -m "Your commit message"
git remote add origin https://github.com/sam856/SchoolManage.git
git push -u origin master


##Swagger Api production
 http://schoolmanage.runasp.net/swagger/index.html



 
