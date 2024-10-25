# Microservices Example

## Project Description  
This project demonstrates a simple **microservices architecture** using three APIs:  
1. **Auth API** – Uses **JWT** and **ASP.NET Identity** for authentication and authorization.  
2. **Product API** – Manages product-related operations (CRUD).  
3. **Shopping Cart API** – Handles the shopping cart operations.

These APIs are consumed by an **MVC project** through an **API Gateway** implemented with **Ocelot**.


## Prerequisites  
Make sure you have the following installed:  
- **.NET 8**
- **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server**
- **Ocelot** (for the API Gateway)

 
## How to Run
1. Clone the repository.
2. Set up the connection string in `appsettings.json`.
3. Run **all** the projects.

## Users
The system supports two types of users:

- Admin Users: Can create, update, and delete products.
- Regular Users: Can view products and manage the shopping cart.



## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
