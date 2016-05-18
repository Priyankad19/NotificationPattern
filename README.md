# NotificationPattern

## Introduction
This sample project is to demonstarte how we can handle validations using Notification pattern instead of throwing exceptions. I wont go into details of explaining why Notification Pattern is preferred over exception for performing validation because it is very well explained in Martin Fowler's blog [Replacing Throwing Exceptions with Notification in Validations](http://martinfowler.com/articles/replaceThrowWithNotification.html). 

Please do read it to understand this project.

## About Project
This is a very simple project in which I have created index.html page which calls the add Employee API to add a new employee in in-memory list. For simplicity purpose, I have not implemented any client side validation. The page excepts the input as Name, Designation and Date of Birth and prints the response fetched from server. If there are any validation errors returned from server then the response will print the failure status along with all the validation error codes.

## Building and running the Project
Clone or download the project and set **NotificationPattern.API** as the startup project and click on run.

## Implementation Details of NotificationPattern
The major implementation is in ManageEmployee class. I have used Optional and Either type for implementation of this pattern. Since there is no default support of Optional & Either in C# as of now I have implemented it on my own in [cSharp.Monads](https://github.com/Priyankad19/cSharp.Monads) project and used that library here.

Implementation is simple. In the add method first we call the Validation method on entity which performs all the validation. If the notifications object is empty then I call the add method to add the employee in repository and return the Right value in Either. But if there are any validation errors then I populate those in notiification object and return that as Left value of either.

Finally in the EmployeeController I am using the apply method over either and pass two functions. Left function which will be executed if Left value is present and the right function which will be executed if right value is present. And the implementation is done.
