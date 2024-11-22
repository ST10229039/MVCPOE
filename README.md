# MVCPOE
Lectures claim

Project Overview
Your project will consist of the following main features:

User Roles: You will have two main roles:

Lecturers: They can input hours worked, set rates, upload files, and add descriptions.
Programming Managers: They can approve or reject claims submitted by lecturers.
Database: You will use SQL Server to store information related to claims, users, and other relevant data.

User Authentication: Implement user registration and login functionalities. You can use ASP.NET Identity or any other authentication framework.

Entities: Define entities for your application. Examples might include:

User: Stores user information (name, email, role, etc.)
Claim: Stores information about the claims submitted by lecturers (hours worked, rates, descriptions, file uploads, status, etc.)

Controllers: Create controllers to handle requests related to claims and user management.

ClaimsController: Manage claims for lecturers and programming managers.
UsersController: Handle user registration, login, 

Lecturer Submission: When a lecturer submits a claim, the application should:

Validate inputs (e.g., hours worked, rates).
Save the claim to the database with a status of Pending.
Manager Review: A programming manager should be able to:

View pending claims.
Approve or reject claims, which updates the claim’s status in the database.


Views: Implement views for different actions. Examples:

Lecturer Dashboard: A UI for lecturers to submit claims, including input fields for hours worked, rates, and file uploads.
Manager Dashboard: A UI for programming managers to review claims, with options to approve or reject them.

