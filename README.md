## What is this?
This is an implementation of a mailing address form that explores handling of U.S. and international addresses.

![Address form validating a U.S. address](https://raw.github.com/jonsagara/AddressForm/master/docs/images/form-showing-validation.png)

## How does it work?
The following fields make up the form:

* Name
* Street Address
* Extended Address
* Locality
* Region
* PostalCode
* Country

### Labels

The form's behavior depends on which country you have selected. Here are the possible label states 
(note that the Name, Street Address, Extended Address, and Country labels never change):

| Field       | U.S.     | Canada      | Other                     |
| ----------- | -------- | ----------- | ------------------------- |
| Locality    | City     | City        | City / Town               |
| Region      | State    | Province    | State / Province / Region |
| PostalCode  | ZIP Code | Postal Code | ZIP / Postal Code         |

### Required Fields

Name, Street Address, Locality, and Country are always required. The selected Country determines whether the 
other fields are required:

| Field       | U.S.     | Canada      | Other                     |
| ----------- | -------- | ----------- | ------------------------- |
| Region      | Required | Required    | Optional                  |
| PostalCode  | Required | Required    | Optional                  |

What technologies does it use?
---
I built AddressForm with the following:

* Visual Studio 2013
* ASP.NET MVC 5.1.1
* Entity Framework 6.2.0
* Bootstrap 3.1.1
* jQuery 1.11.0
* jQuery Validation 1.11.1
* Microsoft jQuery Unobtrusive Validation 3.1.1
* Json.NET 6.0.1
* AutoMapper 3.1.1

These packages are not minimum required versions. I'm positive you can adapt the code to work with any reasonably recent version of the above.

Credits
---
I implemented AddressForm based on this [User Experience Stack Exchange question](http://ux.stackexchange.com/questions/6556/best-pattern-for-international-address-forms).