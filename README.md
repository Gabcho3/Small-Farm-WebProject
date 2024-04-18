# Small-Farm-WebProject
This project is a C# web application based on **MVC structure** made for **ASP.NET Advanced** module which is part of my **Software University (SoftUni)** education.
- "SmallFarm" is a C# web application designed to connect small manufacturers with potential clients. The platform provides a marketplace where manufacturers can showcase their products and reach a wider audience, while clients can browse and purchase products directly from the manufacturers.

## Features
- **User Authentication**: Secure user authentication system allows manufacturers and clients to sign up and log in;
- **Search and Filters**: Clients can search for products based on categories, keywords, price limits and sorting, making it easy to find specific items;
- **Request System**: Users can send requests for becoming manufacturers which could be approved/disapproved by the admin of the application;
- **Product Listings**: Manufacturers can create listings for their products, including descriptions, images, available quantity and price information;
- **Order System**: Manufacturers can manage orders and update its statuses.

## Technologies used
- .Net Core 6.0
- ASP.NET Core
- Enity Framework Core
- MS SQL Server
- NUnit and Moq
- HTML, CSS, Bootstrap
- JS

## Users
There are 3 types of users with different access to the application's functionality:
- Guest: logged in user. Guests can only see listed products, add them in their cart and order them;
- Manufacturer: The seller in the application. Manufacturers can add products, manage them. They can also see their orders and manage them;
- Administrator: He can approve/disapprove requests of becoming manufacturer and delete manufacturers if needed.

## Test credentials
You can test the application with pre-seeded data using the following credentials:

- **Guest:**
  * Email: guest @gmail.com
  * Password: guest123

- **Manufacturer:**
  * Email: manu @gmail.com
  * Password: manufacturer123

- **Administrator:**
  * Email: admin @gmail.com
  * Password: admin123

## Database Diagram
![Screenshot 2024-04-18 221433](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/7e303494-5b4b-4535-a3ac-de9e800a7eed)

# Functionality
## User Registration and Log in
On these pages you can register or log in.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/2b268618-163c-42e0-aae4-d5d718f4dd3b)
![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/ed6eb5c3-767c-4c1b-b547-bf915166876a)

## Home page
On this page you can see informration about platfom and also some top products. By clicking on product it redirects you to [Features](#features).

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/ebe71a23-9d6e-44da-ace9-ae6c911ddfb5)

