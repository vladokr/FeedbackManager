# Feedback Manager

Provides a REST Api for players to give feedbacks about their game experiances. 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

* Microsoft Visual Studio 2017
* Nunit 3 Test Adapter – VS 2017 extension
* Spell Checker - VS 2017 extension
* SQL Managment Studio
* SQL Server - at least Express 2008 or higher
* GitBash for Windows
* Internet Information Server - for deployment
* Postman - for consuming the API

### Installing

* Clone the repository to a local directory
* With VS 2017 open the solution file (.sln)
* Run a build and verify that there are no errors

### Seting up the Database

* Execute create_model.sql to create the data model 
* Execute insert_sample_data.sql to create some test data

### Configuration

* Set the database connection string inside the FM.WebApi\Web.config file
* Use username="FeedbackManager" and password="@fGm1ND1#"
```
connectionString="Data Source=VLADO\SQLEXPRESS;Initial Catalog=feedback_manager;User ID=FeedbackManager;Password=@fGm1ND1#"/>
```

## Running the tests

You can run the tests using the Test Explorer inside VS 2017. To see the tests in the Test Explorer first build the solution.

## Deployment

* Build the solution in a Release mode
* Navigate on the WebApi project and execute Publish to a local folder
* Copy the content from the folder to the Server and place them inside a IIS directory
* Verify that the connection string is correct
* Set the log4net path in Web.Config and verify the IIS process has permissions to write to that path 

### Consuming REST API

In every HTTP Request Header the following data must be set:

```
content-type: application/json
authorization: Basic V1_0D06C23E-9FC1-472F-B042-6B96B9CE2FDF
x-userlogin: Ubi-UserId
x-userpassword: 5678hygr
```

Here are some examples of how to consume the API.

## Store a Feedback

This operation is only allowed to a user with Role=PLAYER. The user can post a feedback only for himself.
```
POST http://localhost/feedbacks/A2F4394C-86D5-4554-87AC-7BCBBB68E7D8
{"Rating":"2", "Comment":"My First Feedback"}
```

## Get Feedbacks

Get last 15 Feedbacks with rating higher or equal than 2. 
This operation is only allowed to a user with Role=OPERATOR.
```
GET http://localhost:49562/feedbacks/rating/2
```

### Documentation

For more detailed architecture and design overview please check the PDF document inside the Documentation folder.

### Author

* **Vlado Kragujevski** 

### License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details