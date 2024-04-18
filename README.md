# Small-Farm-WebProject
This project is a C# web application based on **MVC structure** made for **ASP.NET Advanced** module which is part of my **Software University (SoftUni)** education.
- **"SmallFarm"** is a C# web application designed to connect small manufacturers with potential clients. The platform provides a marketplace where manufacturers can showcase their products and reach a wider audience, while clients can browse and purchase products directly from the manufacturers.

## Features
- **User Authentication**: Secure user authentication system allows manufacturers and clients to sign up and log in;
- **Search and Filters**: Clients can search for products based on categories, keywords, price limits and sorting, making it easy to find specific items;
- **Request System**: Users can send requests for becoming manufacturers which could be approved/disapproved by the admin of the application;
- **Product Listings**: Manufacturers can create listings for their products, including descriptions, images, available quantity and price information;
- **Order System**: Manufacturers can manage orders and update its statuses.

## Technologies used 
- **.Net Core 6.0**
- **ASP.NET Core**
- **Enity Framework Core**
- **MS SQL Server**
- **NUnit and Moq**
- **HTML, CSS, Bootstrap**
- **JS**

## Users
There are 3 types of users with different access to the application's functionality:
- **Guest:** logged in user. Guests can only see listed products, add them in their cart and order them;
- **Manufacturer:** The seller in the application. Manufacturers can add products, manage them. They can also see their orders and manage them;
- **Administrator:** He can approve/disapprove requests for becoming manufacturer and delete manufacturers if needed.

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

## Table of contents
- [User Registration and Log in](#user-registration-and-log-in)
- [Home page](#home-page)
- [All products page](#all-products-page)
- [Product details page](#product-details-page)
- [Cart page](#cart-page)
- [Order page](#order-page)
- [Rquest page](#order-page)
- [Manufacturer page](#manufacturer-page)
- [Add product page](#add-product-page)
- [My products page](#my-products-page)
- [Manufacturer orders page](#manufacturer-orders-page)
- [Admin page](#admin-page)
- [All requests page](#all-requests-page)
- [All manufacturers page](#all-manufacturers-page)
- [Custom Error pages](#custom-error-pages)

## User Registration and Log in
On these pages you can register or log in.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/2b268618-163c-42e0-aae4-d5d718f4dd3b)
![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/ed6eb5c3-767c-4c1b-b547-bf915166876a)

[Back to table of contents](#table-of-contents)

## Home page
On this page you can see informration about platfom and also some top products. By clicking on product it redirects you to [product details](#product-details-page).

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/ebe71a23-9d6e-44da-ace9-ae6c911ddfb5)

[Back to table of contents](#table-of-contents)

## All products page
On this page you can see all products. You can search product by categories or search term from navigation bar, price limit or sorting. There is also pagination.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/7a2a250e-a68b-4b13-8806-7dccdfe416cc)

[Back to table of contents](#table-of-contents)

## Product details page
On this page you can see all details about product. Changing quantity it calculates the total price. You can add product to [cart](#cart-page). You can also see the list of other products from manufacturer.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/f784b26f-a93e-4971-93cb-149a1ce28b08)

[Back to table of contents](#table-of-contents)

## Cart page
On this page you can see the cart information with order info in the right with button for [placing the order](#order-page). In the top right corner you can see the number of products in your cart.
You can also remove product from cart.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/1a45e674-0b2a-49d8-bce0-c65b7dfae2d6)

[Back to table of contents](#table-of-contents)

## Order page
On this page you can see all of your orders. You receive a notification in bottom right when ordering a product. When order is confirmed by manufacturer it will display "Confirmed for delivery!" under "Ordered on".

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/a69c3624-d0dc-4ae8-9bce-b2d023ddd1a7)

[Back to table of contents](#table-of-contents)

## Request page
On this page you can sen a request for becoming manufacturer and admin will [approve/disapprove](#all-requests-page) it.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/a34a6458-bb08-4866-8519-4aac595619fc)

[Back to table of contents](#table-of-contents)

## Manufacturer page
This page is almost the same as [home page](#home-page) but it contains manufacturer panel in navigation bar. With this panel manufacturer can manage products and orders.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/2471d739-e29a-479f-b84a-dc580cf91797)

[Back to table of contents](#table-of-contents)

## Add product page
On this page manufacturer can add product with all details needed. As there is still no uploading image system, manufacturer have to provide image url for product.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/e842926e-a7f2-45e8-83c7-e3a4c3fe8ea9)

[Back to table of contents](#table-of-contents)

## My products page
On this page the manufacturer can manage his products. When product is not available it will appear red.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/fec03cfc-b1b4-4d74-873b-c6efd476e208)

[Back to table of contents](#table-of-contents)

## Manufacturer orders page
On this page manufacturer can see all not confirmed orders informartion. Manufacturer must confirm order by clicking the button.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/4a01e67c-360d-4c24-a834-206f624bec15)

[Back to table of contents](#table-of-contents)

## Admin page
This page is almost the same as [home page](#home-page) but it contains admin panel in navigation bar. With this panel admin can manage requests and manufacturers.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/375f34ee-67ce-4d01-b440-5cb031a2760e)

[Back to table of contents](#table-of-contents)

## All requests page
On this page admin can approve/disapprove requests by users who want to become a manufacturer on the platform. By clicking right and left arrows you can see other requests.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/34bbc17f-b02e-470a-99e7-c152e4a89529)

[Back to table of contents](#table-of-contents)

## All manufacturers page
On this page admin can only delete manufacturers if needed.

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/8baa5781-793a-464f-9920-9de37e2d931b)

[Back to table of contents](#table-of-contents)

## Custom Error pages
These pages provide option to redirect to [the home page](#home-page).

![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/7fe51a39-442a-45f9-be22-cf312cfaa42f)
![image](https://github.com/Gabcho3/Small-Farm-WebProject/assets/109502170/a076459b-d9fa-4d21-9e7d-a8e3697f694b)

[Back to table of contents](#table-of-contents)
