# AddressBook

Prerequisites:
* Install the .NET Core 2.1 or above SDK.
* Install Visual Studio 2017 v15.7 or above.
* Install Blazor.
* Download and install MongoDB community edition.

Steps to Run:
* Create a folder at C:\. Name it: AddressBookData
* On windows, open command prompt and type : mongod --dbpath C:\AddressBookData
* Open another command shell instance. Connect to the default test database by running the following command: mongo
* Run the following in a command shell: use AddressBookData
* Create a Addresses collection using following command: db.createCollection('Addresses')
* Create a Countries collection using following command: db.createCollection('Countries')
* Open the project in Visual Studio and run.

Swagger Access: https://localhost:44319/swagger/index.html

