# SGICU Web Application for Student and Course Management

## Overview
The SGICU Web Application is a comprehensive system designed for educational institutions to manage student information, course enrollments, and administration tasks. This web-based platform, developed in ASP.NET, provides a seamless interface for students and administrators to interact with the university's database efficiently.

## Features

### Student Portal (`etudiant.aspx`)
- **Login Authentication**: Secure login system to ensure data protection.
- **Personal Dashboard**: Displays student's information including enrolled courses, program details, and session.
- **Course Management**: Allows students to enroll in courses, view their current courses, and drop courses within a permissible timeframe.
- **Validation Records**: Students can view their validated courses and prerequisites, ensuring they meet the criteria for advanced courses.

### Admin Portal (`admin.aspx`)
- **Course Creation and Management**: Admins can add new courses, including details like course number, title, prerequisites, session, and program association.
- **Edit and Delete Courses**: Functionalities to modify or remove existing courses from the system.
- **Enrollment Oversight**: Admins can view and manage course enrollments and student registrations.

### Core Functionality
- **Entity Framework**: Utilizes `sgicuEntities` for ORM-based database interactions.
- **LINQ Queries**: Efficient data retrieval with LINQ for querying the database.
- **Session Management**: Secure handling of user sessions for maintaining state across different web pages.
- **Error Handling**: Implements user feedback for actions like failed login attempts, enrollment restrictions, and successful operations.

## Technologies Used
- ASP.NET for building the web application.
- C# for server-side logic.
- HTML and CSS for structuring and styling the web pages.
- SQL Server for database management.

## Getting Started
To run this application:
1. Clone the repository.
2. Set up a SQL Server database and configure the connection string in the `web.config` file.
3. Build and run the application in a compatible IDE (like Visual Studio).

---

Feel free to customize this description according to the specifics of your project and its broader context.
