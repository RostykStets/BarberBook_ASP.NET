**To start coding:**
1. _Local Project Setup:_
- Open repository, branch _dev_layered_, with Visual Studio
- _Pull changes:_  
  Go to Git Changes tab in Visual Studio and press Pull button (Arrow pointed downwards)
- _Create your branch:_  
  Click New Branch  
  Select dev_layered as source  
  Name the branch as <branch_Yourname>  
  Checkout to your branch
- _You are good to go_
2. _Commiting Changes:_
- In the Git Changes tab, under the Changes section You will see a lot of changed files,  
  **SELECT ONLY THE FILES YOU CODED IN**, all of the other garbage was generated with Your VisualStudio
- After You selected changed files, write a _commit message:_  
  "<Message_Header>"  
  "<Message_Body>"  
  Short and generalized header, More details on what You worked on in the body;  
  Use Present Simple ("Add new controller" instead of "Added new controller")
- Under the Commit button, select "Commit and Push"
- Notify Andrew about your commit.
3. _Updating Your Branch:_
- Under the Git Changes tab, select _dev_layered_ branch,  
  **Continue checkout if there is no conflicts**, if there is a conflict  
  between your branch and _dev_layered_, than resolve the conflict or notify Andrew or Rostyk
- Pull the changes to _dev_layered_ branch
- Open this solution in terminal (You will find the option somewhere in the Git Changes tab)
- Run two commands:  
  git checkout <your_branch_name>  
  git merge dev_layered
- In the Git Changes tab, under the all commits, press the _sync_ button
- If succesful, Your branch should be updated to the _dev_layered_ state
4. _Build&Run:_
- Double Click on the "BarberLayered.sln" under the BarberLayered Folder to open the solution view
- Install and add (**to all 3 projects**) following NuGet Packets:  
  Npgsql  
  Npgsql.EntityFrameworkCore.PostgreSQL  
  Npgsql.EntityFrameworkCore.PostgreSQL.Design  
  Microsoft.EntityFrameworkCore  
  Microsoft.EntityFrameworkCore.Tools  
  Microsoft.Extensions.Configuration  
  Microsoft.Extensions.ConfigurationJson  
  Microsoft.AspNetCore.Identity  
  Serilog.AspNetCore  
  Serilog.Sinks.Seq  
  SonarAnalyzer.CSharp  
  Bcrypt.Net-Next  
- Edit _appsettings.json_ in PLL:  
  Change password in the connection string to your postgres password
- Find Package Manager Console and enter the following  
  Database-Update
- _You are good to go_.
