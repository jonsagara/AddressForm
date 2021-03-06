## What is this?
This is an implementation of a mailing address form that explores handling of U.S. and international addresses.
It uses Data Annotations and unobtrusive jQuery validation to validate the fields. Validation rules change
based on the selected country.

### U.S. addresses

![Address form validating a U.S. address](https://raw.github.com/jonsagara/AddressForm/master/docs/images/form-showing-validation.png)

### Canadian addresses

![Address form validating a Canadian address](https://raw.github.com/jonsagara/AddressForm/master/docs/images/form-showing-validation-ca.png)

### Addresses for all other countries

![Address form validating all other addresses](https://raw.github.com/jonsagara/AddressForm/master/docs/images/form-showing-validation-other.png)


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

* Visual Studio 2015
* ASP.NET MVC 5.2.3
* Entity Framework 6.1.3
* Bootstrap 3.3.5
* jQuery 2.1.4
* jQuery Validation 1.14.0
* Microsoft jQuery Unobtrusive Validation 3.2.3
* Json.NET 7.0.1
* AutoMapper 4.0.4

These packages are not minimum required versions. I'm positive you can adapt the code to work with any reasonably recent version of the above.

Credits
---
I implemented AddressForm based on this [User Experience Stack Exchange question](http://ux.stackexchange.com/questions/6556/best-pattern-for-international-address-forms).