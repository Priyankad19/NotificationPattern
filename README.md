# NotificationPattern

## Introduction
This sample project is to demonstarte how we can handle validations using Notification pattern instead of throwing exceptions. I wont go into details of explaining why Notification Pattern is preferred over exception for performing validation because it is very well explained in Martin Fowler's blog [Replacing Throwing Exceptions with Notification in Validations](http://martinfowler.com/articles/replaceThrowWithNotification.html). 

Please do read it to understand this project.

## About Project
This is a very simple project in which I have created index.html page which calls the add Employee API to add a new employee in in-memory list. For simplicity purpose, I have not implemented any client side validation. The page excepts the input as Name, Designation and Date of Birth and prints the response fetched from server. If validation fails then response status is "Failed" andalong with all the validation error codes.

## Building and running the Project
Clone or download the project and set **NotificationPattern.API** as the startup project and click on run.

## Implementation Details
