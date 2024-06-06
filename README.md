# DebtMasterAPI
A monolithic web API built with .NET 8.0 for efficient debt management. It uses MS SQL for data storage, providing endpoints for recording debts, tracking payments, managing user accounts and checking debts.

## Role-Based Access Control

## Token Validity

The access token provided upon successful authentication is valid for 5 days. After this period, users will need to re-authenticate to obtain a new token.

### Admin 
#### Admin Access
Admins have access to all methods:

CreateUser

GetUserById

GetAllUsers

UpdateUser

DeleteUser

AddDebt

GetDebts

GetDebtsByUserId

GetTotalDebt

### User
#### User Access
Users have access to the following methods:

GetDebtsByUserId

GetTotalDebt

GetUserById

All these User methods are accessed using a token and GUID.
