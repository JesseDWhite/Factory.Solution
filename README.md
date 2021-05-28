# _Dr. Sillystringz Imporium_ ✨
#### _This is our 11th week project for Epicodus that covers the basics for Many-to-Many relationships and MySql._
#### By _Jesse White_
## Technologies Used
* _CSHTML_ 📝
* _CSS_ 🎨
* _C#_ 🆒
* _.NET_ 🥅
* _MySql_ 💽
* _Entity Framework_ 🎞
## Description 📜
_Dr. Sillystrinz runs a growing imporium and has many elaborate machines to show the public. Because of this, he needs some help managing his engineers on staff and what machines they can and need to work on. This progam will allow D. Sillystringz to manage his working capitol, so they can focus on bigger things._
## Setup and Use 🏗

### Prerequisites 💻

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- A text editor like [VS Code](https://code.visualstudio.com/)
- A command line interface like Terminal or GitBash to run and interact with the console app.
- [MySQL Community Server][https://dev.mysql.com/downloads/file/?id=484914]

### Installation

1. Clone the repository: `$ git clone {https://github.com/JesseDWhite/Factory.Solution}`
2. Navigate to the `{Factory.Solution}` directory on your computer
3. Open with your preferred text editor to view the code base
4. To setup a SQL database using MySQL:
   - Create an `appsettings.json` file in the `{Factory}` directory
   - Copy the text box below and paste into the `appsettings.json` file, replacing `<password>` with your MySQL password:
   ```
     {
        "ConnectionStrings": {
           "DefaultConnection": "Server=localhost;Port=3306;database=jesse_white;uid=root;pwd=<password>;"
         }
     }
   ```
   - Open your terminal and run the command: `mysql -uroot -p<mysql_password>` (replace `<mysql_password>` with your MySQL password) and select the enter key to launch MySQL servers
5. To run the console app:
 - Navigate to `{Factory.Solution/Factory}` in your command line
   - Run the commands:
     - `dotnet restore` to restore the dependencies that are listed in `{Factory.csproj}`
     - `dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0`
     - `dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2`
     - `dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0`
     - `dotnet build` to build the project and its dependencies into a set of binaries
     - `dotnet tool install --global dotnet-ef` to install EF Core tools
     - `dotnet ef migrations add Initial` and `dotnet ef database update`
   - Finally, run the command `dotnet run` to run the project!
   - Note: `dotnet run` also restores and builds the project, so you can use this single command to start the console app
6. Visit the application via web browser at: `localhost:5000/`
## Known Bugs 🐛
* _Date fields will show the time of 12:00:00._
* _Engineers are able to be added to a machine more than once._
* _The list of all machines and all engineers appears to be appending duplicates if an engineer is assigned to more that one machine._
## License ⚖
_MIT © Jesse White 2021_
## Contact Information 🤳
Jesse White _jesse.white6@gmail.com_