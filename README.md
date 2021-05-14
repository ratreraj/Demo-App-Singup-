# Demo-App-Singup-
Sing up demo sung .net 5

#Auther - Raj Prakash Ratre

# Follow the below steps
1) Open the solution and  change the connection string in below path 
	1.1 - DemoApp.Dal -> AppDbContext.cs
	1.2 - DemoApp.WebUI -> appsettings.json

2) Apply database migration file 
	2.1 - Go to Tools(Menu)->(Open) Package Console Manager ->(Under) -(Mneu)Nuget Package manager
	2.2 - DemoApp.Dal as statup project and also check Package Console Manager select project as DemoApp.Dal
	2.3 - Run Command on console - Update-database

3) Check Database is create or not 
	3.1) Go and login you SQL server and check thier database is create as 
	name given in connection string

4) Run project
	4.1) set a start up project as DemoApp.WebUI and run the project 

5) CRUD opration 
	5.1) we added CRUD operation
	
6) Screenshot of working application is added 
	6.1 ) Path - DemoApp.WebUI\Screen 


#Note - 
We used Json data fro country and city inside   DemoApp.Dal-Data folder

