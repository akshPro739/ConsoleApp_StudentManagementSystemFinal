

# Student Record Management System

## Overview

Student Record Management System is a web application developed using ASP.NET Core MVC, ADO.NET, SQL Server, and Stored Procedures.

The application provides role-based access for:

* Invigilator (Admin)
* Student

Invigilators can manage student records, while students can view only their own academic records.

---

## Features

### Authentication & Authorization

* User Login
* Role-Based Access Control
* Admin Dashboard
* Logout Functionality

### Student Management

* Create Student Record
* Display All Students
* View Student Details
* Edit Student Marks
* Disable (Soft Delete) Student Records
* Search Students

### Student Features

* View Own Academic Record
* View Total Marks
* View Percentage

### Validation

* Name maximum length: 30 characters
* Marks range: 1 to 100
* Server-side validation using Data Annotations

---

## Technologies Used

* ASP.NET Core MVC
* C#
* ADO.NET
* SQL Server
* Stored Procedures
* Bootstrap 5
* HTML, CSS, JavaScript

---

## Database Setup

### Create Database

```sql
CREATE DATABASE StudentRecordDB;
```

Use:

```sql
USE StudentRecordDB;
```

### Create Tables

* TblRoles
* TblStudents
* TblUsers

### Create Stored Procedures

* sp_AuthenticateUser
* sp_GetAllStudents
* sp_GetStudentById
* sp_InsertStudent
* sp_UpdateStudent
* sp_DeleteStudent
* sp_GetStudentByUserId

---

## Update Connection String

Open:

```text
appsettings.json
```

Update:

```json
"ConnectionStrings": {
  "ConnStr": "Server=YOUR_SERVER_NAME\\SQLEXPRESS;Database=StudentRecordDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Replace:

```text
YOUR_SERVER_NAME
```

with your SQL Server instance name.

---

## Running the Application

1. Open the solution in Visual Studio.
2. Restore NuGet packages.
3. Execute the database scripts.
4. Update the connection string.
5. Build the solution.
6. Run the application.

---

## Default Login Credentials

### Admin

```text
Username : admin
Password : admin123
```

### Student

```text
Username : rahul
Password : rahul123
```

(Modify according to your database records.)

---

## Project Structure

```text
Controllers
│
├── AccountController
├── StudentsController
│
Models
│
├── Student
├── User
├── Role
│
Repository
│
├── IStudentRepository
├── StudentRepositoryImpl
├── IUserRepository
├── UserRepositoryImpl
│
Services
│
├── IStudentService
├── StudentServiceImpl
├── IUserService
├── UserServiceImpl
│
Views
│
├── Account
├── Students
└── Shared
```

---

## Additional Features Implemented

* Role-Based Navigation
* Soft Delete (Disable Student Records)
* Search Functionality
* Computed Total Marks
* Computed Percentage

---

## Author

Machine Test Submission

Student Record Management System using ASP.NET Core MVC and ADO.NET.
