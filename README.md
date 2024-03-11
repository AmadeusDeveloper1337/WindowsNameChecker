# WindowsNameChecker
My first and simple project that performs the functions of parental control
## About
This project contains 3 parts.
1. Server
2. Admin panel(teacher panel)
3. Student build.
   
The server is written in python (flask). On the server itself, there is a check for program activity, etc. The admin panel is necessary to configure the program itself. StudentBuild is in startup on computers that our control needs ;)

## Algorithm
It's very simple! We just check every word in the name of the open windows for their presence in the blacklist on the server. If we find a match, we close the process
