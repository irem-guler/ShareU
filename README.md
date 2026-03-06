# ShareU – University Note Sharing Platform

ShareU is a desktop application developed with **C# Windows Forms and Microsoft SQL Server** that allows university students to upload, share and download course notes.

The goal of this project is to provide a simple platform where students from different universities can share academic materials and help each other.

---

## Technologies Used

* C# (.NET Framework)
* Windows Forms
* Microsoft SQL Server
* ADO.NET
* Git & GitHub

---

## Features

* User registration and login system
* Upload course notes (PDF, DOCX, etc.)
* Store files directly in SQL Server database using **VARBINARY**
* Filter notes by **university** and **subject**
* Download notes uploaded by other students
* Simple Windows Forms user interface

---

## Database

The database schema is included in the repository.

Run the SQL script located in:

```
/db/schema.sql
```

to create the required tables in SQL Server.

Create a database named:

```
denemeproje2
```

and run the script before starting the application.

---

## Configuration

Update the connection string in the project if your SQL Server instance name is different.

Example connection string:

```
Data Source=.\MSSQLSERVER02;
Initial Catalog=denemeproje2;
Integrated Security=True;
TrustServerCertificate=True
```

---

## Running the Project

1. Clone the repository

```
git clone https://github.com/irem-guler/ShareU4.git
```

2. Open the solution file in Visual Studio

```
ShareU4.sln
```

3. Build and run the project.

---

## Author

İrem Güler
Software Engineering Student
