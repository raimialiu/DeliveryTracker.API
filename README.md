# DeliveryTracker.API
DeliveryTrackingService
The Test was written in Asp.Net Core 3.1 and repository is hosted on Github.

Steps to Run the Code
pre-requisite
Asp.Net Core 3.1
C# (at least 7.0)
an IDE or Editor(Visual Studio Code) or any terminal (provided dotnet cli has been added to path)
1). Clone the repository to your desired directory
2). a) Through terminal, 
        i) navigate to the directory where you clone the repo to,
        ii) run dotnet restore, to restore the project and its dependencies
        iii) run dotnet build to build first
        iv) run dotnet run to run it with defualt 5000 as port. Note, if you have any other application making use of port 5000, 
            then you will need to run the code like dis dotnet run --port <any_port_of_your_choice>
         v) step iv will launch your default browser, and by default swagger will be open, if it did not open then you go to /index of the app url in the browser
         vi) after step v, you will see several endpoints that you test to run the code
     b) Through IDE (Visual Studio or Rider or Mono Develop or Visual Studio for Mac)
     i) Go to the folder where you clone the repo
     ii) open folder of the repo and double click on the solution file.
     iii) from step iii, it will automatically open the project in the default app (i.e. visual studio if you have it installed or rider..etc)
     iv) as soon as the IDE open, give it a few minute to automatically, load and restore the project
     v). You can now click on launch or start debugging (open Debug menu and click on start debugging).
     vi) It should launch a browser, then available endpoint will come out.
     
     
  3) To run the Test.
  you can either navigate to the project directory on command line and run dotnet test to run the test or open it on IDE and run the test appropriately
  
  
  Thanks
  
  Aliu Raimi Tunde
  07064265908
  raimialiu428@gmail.com
