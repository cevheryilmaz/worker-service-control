# worker-service-control

## General info
We provided Microsoft service check system and service running in an instant at synchronously stopped and similar situations.

## Technologies
Project is created with:
* C#(Worker Service System)


## Setup
To run this project, install it locally:

```
$ [Project Path] and open within Visual Studio
$ change serviceName parameter in the Worker.cs
$ Build and Debug/Run from within Visual Studio
$ dotnet publish -o C:\path\to\project\pubfolder
$ open cmd
$ C:\Windows\System32\sc create MyServiceName binPath=C:\path\to\project\pubfolder\MyProjectName.exe
```
