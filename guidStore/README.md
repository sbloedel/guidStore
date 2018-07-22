# guidStore
Sample web API using .NET Core that stores GUIDs in a database

## Prerequisites
Make sure to install the following prerequisites:
* .NET Core
* Visual Studio Code (or your favorite editor)

## How to get setup?
Execute the following commands from a Terminal window.  You can also use Visual Studio Code to debug the application.

To make sure all the prerequisites are installed, run:
```bash
dotnet restore
```

To start the web service, run:
```bash
dotnet run
```

## How to execute the web methods locally
Here are the web endpoints that you can run from Postman:

POST https://localhost:5001/api/guid/{id} - Creates a guid record with id as the value for the guid.

REQUEST BODY: 
```
{
  "expire": "1427736345",
  "user": "My company"
}
```
POST https://localhost:5001/api/guid - Creates a guid record with a randomly generated guid and an expiration 30 days from today.

REQUEST BODY:
```
{
  "user": "My company"
}
```

GET https://localhost:5001/api/guid/{id} - Retrieves the guid record

PUT https://localhost:5001/api/guid/{id} - Updates the guid record w/ a new expiration date.
REQUEST BODY:
```
{
  "expire": "1427736345"
}
```

DELETE https://localhost:5001/api/guid/{id} - Deletes the record 

## Todo
* Install .NET Core and Visual Studio Code (complete)
* Create a GitHub repository (complete)
* Create a brand new .NET Core Web API project (complete)
* Create all the web methods POST, GET, PUT, DELETE (complete)
* Add info to a database (SqlLite) (complete)
* Add some basic error handling (i.e. validate guid, expiration) (complete)
* Add some basic unit testing (complete)
* Add some basic swagger documentation (complete)
* Add caching mechanism using Redis
* Flesh out unit testing and documentation
