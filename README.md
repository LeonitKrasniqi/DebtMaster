# DebtMasterAPI
A monolithic web API built with .NET 8.0 for efficient debt management. It uses MS SQL for data storage, providing endpoints for recording debts, tracking payments, managing user accounts and checking debts. As an admin, you can create accounts and maintain records for each accounts debts and payments. As a user, you can view the debts, transactions, and activity in your personal account.

# How entities interact
![DebtMasterDb](https://github.com/LeonitKrasniqi/DebtMaster/assets/102996903/e407e33d-15c1-4f49-b8dd-388aad157999)


# Endpoints Explorer
![endpoints explorer](https://github.com/LeonitKrasniqi/DebtMaster/assets/102996903/36ff6d37-6527-4b07-b663-cd0668073ed5)


## Role-Based Access Control

## Token Validity

The access token provided upon successful authentication is valid for 5 days. After this period, users will need to re-authenticate to obtain a new token.

## Usage
### Admin Access
Admins have access to all methods:

**CreateUser**

**GetUserById**

**GetAllUsers**

**UpdateUser**

**DeleteUser**

**AddDebt**

**GetDebts**

**GetDebtsByUserId**

**GetTotalDebt**

### User Access
Users have access to the following methods:

**GetDebtsByUserId**

**GetTotalDebt**

**GetUserById**

All these User methods are accessed using a token and GUID.



## Package References

- **AutoMapper** - version 13.0.1
- **AutoMapper.Extensions.Microsoft.DependencyInjection** - version 13.0.1
- **Microsoft.AspNetCore.Authentication.JwtBearer** - version 8.0.6
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore** - version 8.0.4
- **Microsoft.AspNetCore.OpenApi** - version 8.0.4
- **Microsoft.EntityFrameworkCore.SqlServer** - version 8.0.4
- **Microsoft.EntityFrameworkCore.Tools** - version 8.0.4
- **Microsoft.IdentityModel.Tokens** - version 7.4.0
- **Swashbuckle.AspNetCore** - version 6.4.0
- **System.IdentityModel.Tokens.Jwt** - version 7.4.0

## Local Host Ports

The application is hosted in the following local host port:

- HTTPS: https://localhost:7185
