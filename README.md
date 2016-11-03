# OTP Challenge

## The Challenge
The input of the program should allow us to:
	•	Generate the password for any given username.
	•	Validate the OTP by sending a username and password.
	•	Every generated password should expire after 30 seconds.

## Doc
	I created two presentation projects:
		•	Presnetation.Admin:
			•	You can manage USERS;
			•	You can view LOGS;
		•	Presentation.client
			•	You can generate Passwords for registred users;
			•	You can test the password on LOGIN page;

## Running
	•	Configure ConnectionString on:
		•	Presentation.Admin;
		•	Presentation.Client;
		•	Infra.Data.Test;

	•	Run command: Update-Database on:
		•	Presentation.Admin;
		•	Infra.Data;

## Testing
	•	The project has more than 10 unit tests;

## Dependencies
	- .NET 4.5.2
	- EntityFramework
	- Asp.Net MVC
	- Angular
	- Simple Injector
	- AutoMapper

## Next Features
- Implement logs
- Improve tests
- Improve Interface
