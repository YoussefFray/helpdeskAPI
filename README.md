# HelpDesk Back-End Application

This is the documentation for the back-end of the HelpDesk application. The HelpDesk application is a service center designed to assist users with their hardware and software problems. It provides IT support to ensure the smooth operation of computer equipment within a company.

## Technology Stack

The HelpDesk back-end application is built using the following technologies:

- Programming Language: C#
- Framework: .NET Core API
- Database: SQL Server

## Database Schema

The application's database schema consists of the following tables:

### User

- `UserId`: The unique identifier for a user.
- `FirstName`: The first name of the user.
- `LastName`: The last name of the user.
- `Email`: The email address of the user.
- `Password`: The password associated with the user's account.

### Technician

- `TechnicianId`: The unique identifier for a technician.
- `FirstName`: The first name of the technician.
- `LastName`: The last name of the technician.
- `Email`: The email address of the technician.
- `Password`: The password associated with the technician's account.

### Complaint

- `ComplaintId`: The unique identifier for a complaint.
- `UserId`: The foreign key referencing the `UserId` in the `User` table.
- `UniqueCode`: A unique code associated with the complaint.
- `Description`: A description of the complaint.
- `Status`: The status of the complaint (e.g., pending, resolved).
- `Approved`: Indicates whether the complaint has been approved.

### ActionCorrective

- `ActionId`: The unique identifier for an action.
- `ComplaintId`: The foreign key referencing the `ComplaintId` in the `Complaint` table.
- `TechnicianId`: The foreign key referencing the `TechnicianId` in the `Technician` table.
- `Description`: A description of the corrective action taken.

## Functionality

The HelpDesk application's back-end provides the following functionality:

- User Management: Users can be created with their corresponding personal information, including their first name, last name, email, and password.
- Technician Management: Technicians can be created with their respective details, including their first name, last name, email, and password.
- Complaint Management: Users can submit complaints with a unique code, description, and status. The complaints can be associated with a specific user and marked as approved or pending.
- ActionCorrective Management: Technicians can take corrective actions for specific complaints by providing a description of the action taken.

## Installation and Setup

To set up and run the HelpDesk back-end application, follow these steps:

1. Install the latest version of .NET Core SDK on your machine.
2. Clone the repository to your local machine.
3. Open the project in your preferred integrated development environment (IDE).
4. Configure the database connection by updating the connection string in the application's configuration files.
5. Run the database migrations to create the necessary tables and relationships.
6. Build the application to restore dependencies and compile the code.
7. Start the application using the configured development server or deploy it to a production server.

## API Documentation

The back-end API endpoints and their corresponding functionalities are documented separately. Please refer to the API documentation for detailed information on the available routes, request/response formats, and authentication (if applicable).

## Contributors

- [Youssef fray]: [yousseffray001@gmail.com]
 

Feel free to reach out to any of the contributors listed for assistance or further information.
 
