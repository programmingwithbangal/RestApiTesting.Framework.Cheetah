# RestApiTesting.Framework.Cheetah  <img src ="RestApiTesting.Framework.Cheetah/images/cheetah.jpg" width=99>
This is a RESTful API testing Framework using C#, .NET Core, xUnit, Specflow BDD test framework, HttpClient and Fluent Assertions to test JSONPlaceholder REST API.

## Specflow  <img src ="RestApiTesting.Framework.Cheetah/images/specflow.png" width=99>
Use SpecFlow to define, manage and automatically execute human-readable acceptance tests in .NET projects. Writing easily understandable tests is a cornerstone of the BDD paradigm and also helps build up a living documentation of your system. https://specflow.org/

## Target framework  <img src ="RestApiTesting.Framework.Cheetah/images/netcore.png" width=50>
.NET Core 2.1

## JSONPlaceholder  <img src ="RestApiTesting.Framework.Cheetah/images/JSONPlaceholder.jpg" width=99>
JSONPlaceholder is a free online REST API that you can use whenever you need some fake data. It's great for tutorials, testing new libraries, sharing code examples.
https://jsonplaceholder.typicode.com/

## Routes Tested
The following HTTP methods are tested:
* GET
* POST
* PUT
* PATCH
* DELETE

## HttpClient
HttpClient class provides a base class for sending/receiving the HTTP requests/responses from a URL. It is a supported async feature of .NET framework. HttpClient is able to process multiple concurrent requests. It is a layer over HttpWebRequest and HttpWebResponse. All methods with HttpClient are asynchronous.
https://docs.microsoft.com/en-us/uwp/api/windows.web.http.httpclient

## Assertions <img src ="RestApiTesting.Framework.Cheetah/images/fluentassertions.png" width=99>
Fluent Assertions is used for validation.
https://fluentassertions.com/ 

## Integrated Development Environment
Microsoft Visual Studio IDE is used to develop this Framework.

### Visual Studio Extensions
* Extensions => Manage Extensions => Search and Install SpecFlow for Visual Studio
<img src ="RestApiTesting.Framework.Cheetah/images/specflowextension.png" width=350>

### Build Solution
* Build => Build Solution
<img src ="RestApiTesting.Framework.Cheetah/images/build.png" width=350>

### Run Tests
* Test => Windows => Test Explorer => Run All
<img src ="RestApiTesting.Framework.Cheetah/images/testexplorer.png" width=500>

### Run Tests with Command Prompt/Windows PowerShell
* Open Folder in File Explorer: ..\RestApiTesting.Framework.Cheetah\bin\Debug\netcoreapp2.1
* Open Command Prompt/Windows PowerShell
* Run "dotnet vstest RestApiTesting.Framework.Cheetah.dll"
