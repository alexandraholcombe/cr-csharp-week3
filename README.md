# Hair Salon CRM

#### _Customer Relationship Manager for Hair Salon_

#### By _**Alexandra Holcombe**_

## Description

This website will take a string and a word from a user, then count the number of times that word occurs inside of the string.

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

## Specifications

**The GetAll method for the Stylist class will return an empty list if there are no entries in the Stylist table**
* Example Input: N/A, automatically loads on home page
* Example Output: empty list

**The Equals method for the Stylist class will return true if the Stylist in local memory matches the Stylist pulled from the database.**
* Example Input:  
        > Local: "Elizabeth", id is 10  
        > Database: "Elizabeth", id is 10  
* Example Output: `true`

**The GetAll method for the Stylist class will return all stylist entries in the database in the form of a list.**
* Example Input:  
        > "Elizabeth", id is 10  
        > "Katie", id is 11  
* Example Output: `{Elizabeth object}, {Katie object}`

**The Save method for the Stylist class will save new Stylists to the database.**
* Example Input:  
    \> New stylist: "Jennifer"
* Example Output: no return value

**The Save method for the Stylist class will assign an id to each new instance of the Stylist class.**
* Example Input:  
    \> New stylist: "Jennifer", `local id: 0`  
* Example Output:  
    \> "Jennifer", `database-assigned id`  

**The Find method for the Stylist class will return the Stylist as defined in the database**
* Example Input: "Jennifer"
* Example Output: "Jennifer", `database-assigned id`

**The GetClients method for the Stylist class will return a list of all Clients with a stylist_id that matches the Stylist's id property.**
* Example Input: "Jennifer"
* Example Output: `{List of Jennifer's Clients}`

**The user can click on any stylist in the Stylists list to view a new page with a list of the stylist's clients**
* Example Input: *jennifer clicky*
* Example Output: "Rebecca, Nicole, Claire"



## Support and contact details

Please contact Allie Holcombe at alexandra.holcombe@gmail.com with any questions, concerns, or suggestions.

## Technologies Used

This web application uses:
* Nancy
* Mono
* DNVM
* C#
* Razor

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Alexandra Holcombe_**
