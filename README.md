# Food Waste Prevention Manager

## Project Overview  
This is a web-based application built using ASP.NET Core MVC with Entity Framework. It allows users to post leftover food and others to apply to pick it up. The application connects food donors (like restaurants) with receivers (like charities or community members). It uses role-based access and has a clean, user-friendly layout.

## Repository Contents  
- Developed code with implementation of Identity, role-based views, and CRUD functionality  
- Includes SQL queries, testing notes, and screenshots  
- Covers all major standards for database, media, and programming outcomes

## Requirements  
- Windows 10 or above  
- Visual Studio 2022  
- .NET 6.0 or later  

## How to Operate  

### Clone Repository and Database Setup  
- Clone the repository  
- Open the solution in Visual Studio  
- Run `update-database` in the Package Manager Console to apply migrations  

### Building and Running the Application  
- Build the solution in Visual Studio  
- Launch in your browser (Google Chrome recommended)
- Register and log in as a user  
- Run the InitialStartupQuery to load dummy data

## Creating Records  

**Post Food:**  
- Navigate to the “FoodPosts” section and click “Create New”  
- Fill out details like name, quantity, price, best-before date, and image  

**Apply for Food:**  
- Navigate to a food post and click “Apply”  
- Enter earliest/latest pickup and quantity requested  

## Contact Information  
**Developer Name:** Vatsal Dave  
**Email:** ac121655@avcol.school.nz
