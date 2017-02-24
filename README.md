# Hair Salon CRM

#### _Customer Relationship Manager for Hair Salon_

#### By _**Alexandra Holcombe**_

## Description

This website will take a string and a word from a user, then count the number of times that word occurs inside of the string.

***

## Setup/Installation Requirements

#### Create Databases
* In `SQLCMD`:  
        `> CREATE DATABASE hair_salon`  
        `> GO`  
        `> USE hair_salon`  
        `> GO`  
        `> CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));`  
        `> GO`  
        `> CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);`  
        `> GO`  

* Requires DNU, DNX, MSSQL, and Mono
* Clone to local machine
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004 in web browser of choice

***

## Specifications

### Stylist Class
================  

**The DeleteAll method for the Stylist class will delete all rows from the stylists table.**
* Example Input: none
* Example Input: nothing

**The GetAll method for the Stylist class will return an empty list if there are no entries in the Stylist table.**
* Example Input: N/A, automatically loads on home page
* Example Output: empty list

**The Equals method for the Stylist class will return true if the Stylist in local memory matches the Stylist pulled from the database.**
* Example Input:  
        > Local: "Elizabeth", id is 10  
        > Database: "Elizabeth", id is 10  
* Example Output: `true`

**The Save method for the Stylist class will save new Stylists to the database.**
* Example Input:  
\> New stylist: "Jennifer"
* Example Output: no return value

**The Save method for the Stylist class will assign an id to each new instance of the Stylist class.**
* Example Input:  
\> New stylist: "Jennifer", `local id: 0`  
* Example Output:  
\> "Jennifer", `database-assigned id`  

**The GetAll method for the Stylist class will return all stylist entries in the database in the form of a list.**
* Example Input:  
        > "Elizabeth", id is 10  
        > "Katie", id is 11  
* Example Output: `{Elizabeth object}, {Katie object}`

**The Find method for the Stylist class will return the Stylist as defined in the database.**
* Example Input: "Jennifer"
* Example Output: "Jennifer", `database-assigned id`

### Client class
================

**The DeleteAll method for the Client class will will delete all rows from the clients table.**
* Example Input: none
* Example Input: `{empty list}`

**The GetAll method for the Client class will return an empty list if there are no entries in the Client table.**
* Example Input: N/A, automatically loads on home page
* Example Output: empty list

**The Equals method for the Client class will return true if the Client in local memory matches the Client pulled from the database.**
* Example Input:  
        > Local: "Elizabeth", stylist_id is 4, id is 10  
        > Database: "Elizabeth", stylist_id is 4, id is 10  
* Example Output: `true`

**The Save method for the Client class will save new Clients to the database.**
* Example Input:  
\> New client: "Jennifer", `stylist_id`
* Example Output: no return value

**The Save method for the Client class will assign an id to each new instance of the Client class.**
* Example Input:  
\> New stylist: "Jennifer", `stylist_id`, `local id: 0`  
* Example Output:  
\> "Jennifer",  `stylist_id`, `database-assigned id`  

**The GetAll method for the Client class will return all client entries in the database in the form of a list.**
* Example Input:  
        > "Elizabeth", id is 10  
        > "Katie", id is 11  
* Example Output: `{Elizabeth object}, {Katie object}`

**The Find method for the Client class will return the Client as defined in the database.**
* Example Input: "Jennifer", `stylist_id`,
* Example Output: "Jennifer", `stylist_id`, `database-assigned id`

**The Update method for the Client class will return the Client with the new name.**
* Example Input: "Jennifer", `stylist_id`, id is 10
* Example Output: "Jenny", `stylist_id`, id is 10

**The Delete method for the Client class will return a list of Clients without the deleted Client.**
* Example Input: "Jennifer", `stylist_id`
* Example Output: "Kacey, Allison, Claire"


### Stylist && Client Classes
=========================  

**The GetClients method for the Stylist class will return a list of all Clients with a stylist_id that matches the Stylist's id property.**
* Example Input: "Jennifer"
* Example Output: `{List of Jennifer's Clients}`

### User Interface
===================  

**The user can click on any stylist in the Stylists list to view a new page with a list of the stylist's clients**
* Example Input: *jennifer clicky*
* Example Output: "Rebecca, Nicole, Claire"

**The user can add a new Stylist using the "Add Stylist" form.**
* Example Input: New Stylist: "Jennifer"
* Example Output: All stylists: "Allison, Kacey, Jennifer"

**The user can add a new client using the "Add client" form.**
* Example Input: New Client: "Rebecca", Stylist: "Elizabeth"
* Example Output: Elizabeth's clients: "Claire, Rebecca"

**The user can edit a client using a link on the client's page which will lead to a change form.**
* Example Input:  
    \> *jennifer clicky*  
    \> New name: "Jenny"  
* Example Output: "Jenny", Stylist: "Allison"

**The user can delete a client using a link on the client's page which will lead to a change form.**
* Example Input:  
    \> *jennifer clicky*  
    \> *delete clicky*  
    \> *confirmation clicky*
* Example Output: Elizabeth's clients: "Rebecca, Claire"

***

## Support and contact details

Please contact Allie Holcombe at alexandra.holcombe@gmail.com with any questions, concerns, or suggestions.

***

## Technologies Used

This web application uses:
* Nancy
* Mono
* DNVM
* C#
* Razor
* MSSQL & SSMS

***

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Alexandra Holcombe_**
