<h1> CRNForum </h1>
CRNForum is implementation of fullstack website to find, store and comment car plates.

<h2>Introduction</h2>
CRNForum is designed mainly for car enthusiasts to make a place to leave some opinion about other cars and its drivers.

<h2>Technologies</h2>
This project utilizes the following technologies:
<br>
- <strong>C# (ASP.NET Core)</strong>: Used for the server-side implementation, following Domain-Driven Design (DDD) principles and Onion Architecture.
<br>
- <strong>NUnit && Shouldy</strong>: Server-side unit tests.
<br>
- <strong>Blazor WebAssembly</strong>: Employed for the front-end development.

<h2>Project Structure</h2>
"back" folder contains server-side implementation with the useage of Onion Architecture. <br>

<strong>Core Domain:</strong> <br>
Contains core business logic and domain entities.<br>
<br>
<strong>Application Services:</strong> <br>
Orchestrates interactions between the domain layer and external interfaces/APIs.<br>
Coordinates the execution of business rules.<br>
<br>
<strong>Infrastructure:</strong><br>
Handles external concerns such as database access and infrastructure-specific code.<br>
Contains IoC containers.<br>
<br>
<strong>API:</strong><br>
Represents the external interfaces or APIs through which the application interacts with the outside world.<br>
<br>
<strong>Tests:</strong><br>
Contains unit tests.<br>
<br>
"Front" folder contains client-side implementation (very basic implementation).
<h2>Usage</h2>
To make it work on your local enviroment you need to change Appsettings.Json to match your data.<br>
"TokenOptions" Section should be deserialized to TokenSettings class.<br>
"Sql" Section should be deserialized to SqlConnectionSettings class.
