# Mitrais Web - Project Test
Example ASP.NET C# Web with Rest API, DLL Library and The Unit Test on .NET Framework 4.6

## Frontend
Build by ASP.NET C# MVC on Visual Studio 2017 (mitraisWeb folder)
1. Bootstarp 3
2. jQuery

## Backend
Build by ASP.NET C# Web API 2 on Visual Studio 2017 (mitraisWeb folder)
1. Endpoint : api/user/
2. Verb : POST for Add User and GET for List User

## Business Logic
Build by C# Library on Visual Studio 2017 (mitraisBiz folder)
1. ORM : Fluent NHibernate
2. Database : MsSQL Server 2012

## Screenshot
1. Registration Page - Validation

![alt text](https://raw.githubusercontent.com/mwawan77/mitrais/master/Registration%20-%20Mitrais%20Web%20Validation.png)

2. Registration Page - Submit

![alt text](https://raw.githubusercontent.com/mwawan77/mitrais/master/Registration%20-%20Mitrais%20Web%20Submit.png)

3. Registration Page - Validation Mobile Number

![alt text](https://raw.githubusercontent.com/mwawan77/mitrais/master/Registration%20-%20Mitrais%20Web%20Validation%20Mobile%20Number.png)

4. Registration Page - Validation Email

![alt text](https://raw.githubusercontent.com/mwawan77/mitrais/master/Registration%20-%20Mitrais%20Web%20Validation%20Email.png)

5. Postman /api/user/

![alt text](https://raw.githubusercontent.com/mwawan77/mitrais/master/Postman%20-%20RestAPI.png)

## Setup Demo
1. Attach mitraisDb.mdf to MsSQL Server 2012
2. Modify Connection String on Web.config
3. Open the Solution on Visual Studio 2017 than running it OR
4. Create an application on IIS that pointing to mitraisWeb folder
