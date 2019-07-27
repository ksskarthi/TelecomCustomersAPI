/*

Application:

Application created usring .Net 4.7 framework to meet the below requirements: 

The system must be able to:
•	Get all phone numbers
•	Get all phone numbers of a single customer
•	Add a new phone number to a customer’s account
•	Activate a phone number. 

Sample data,
https://telecomapi.azurewebsites.net/api/Customers/GetCustomers
https://telecomapi.azurewebsites.net/api/Customers/GetCustomer?CustomerId=2
https://telecomapi.azurewebsites.net/api/Customers/AddCutomerPhoneNumber?CustomerId=2&PhoneNumber=04938394238&Active=true
https://telecomapi.azurewebsites.net/api/Customers/UpdateCutomerPhoneNumber?CustomerId=2&PhoneNumber=04938394238&Active=false

TelecomCustomersAPI - API library to get the Telecom customers with their phone numbers
TelecomDataServices - Database services to connect with Telecom db to perform the db operations.


4 API methods exposed, methods and details as below,

GetCustomers -	Get all cusotmers data from database

GetCustomer -	Get specific customer based on the customer id. 
				It takes customer id as int type and return the customer. If customer not found it returns null.

AddCutomerPhoneNumber - Add new phone number to the customer records.
						It takes customerid(int), phone number(string) and active(boolean) status as input and return the added customer.
						Initial check will be performed with existing customer records to ensure phonenumber already exist or not, if exist it will udpate the phone number status
						through UpdateCutomerPhoneNumber method and return the udpated customer.

UpdateCutomerPhoneNumber - Update the phone number status from the existing customer record.
							It takes customerid(int), phone number(string) and active(boolean) status as input and return the updated customer.
							Initial check will be performed with existing customer records to ensure phonenumber with same status already exist or not.


Database:

hosted in Azure environment with below details.
server name : testcustomerscccountserver.database.windows.net
database name :   TelecomDB
tables used : 
Customers -
	-	Fields: Id as auto increment, primary key, Title, FirstName, LastName 
	-	this table is to save customers details.

CustomerPhoneNumbers - 
	-	Fields: ID as auto increment, primary key, CustomerID referencing parent table Customers table as foreign key, PhoneNumber, Active
	-	this table used to save customer phone numbers.

Stored procedures used:

GetCustomerDetails			- To get all customer with their phone numbers from Customers and CustomerPhoneNumbers table.
AddCustomerPhoneNumber		- To add new customer phone number to the CustomerPhoneNumbers table.
UpdateCustomerPhoneNumber	- To update the existing customer phone number from CustomerPhoneNumbers table.


*/