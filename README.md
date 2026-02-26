# TaskManagementWebAPI
# Task Management Application - Backend API (.NET Core)

## 1. Introduction
This repository contains the backend API for the Task Management Application.  
**Purpose:** To demonstrate API development, database handling, and backend logic using .NET Core.

## 2. Features
- CRUD APIs for tasks:
  - Create Task
  - Read Tasks
  - Update Task
  - Delete Task
- Search tasks by title,description,createdby

## 3. Backend Structure
- .NET Core Web API
- Folders:
  - Controllers
  - Models
  - Services
  - Data (DB context)
- Entity Framework Core (Code First approach)
- MySQL database integration

## 4. Database Design
- Table: `Tasks`
- Fields:
  - TaskTitle
  - TaskDescription
  - TaskDueDate
  - TaskStatus
  - TaskRemarks
  - CreatedOn
  - LastUpdatedOn
  - CreatedBy
  - LastUpdatedBy
- ER Diagram reference:
- 
+----------------------------------+
|            Tasks                 |
+----------------------------------+
  
| Id (PK)                                   
| TaskTitle                               
| TaskDescription                     
| TaskDueDate                         
| TaskStatus                             
| TaskRemarks                         
| CreatedOn                             
| LastUpdatedOn                     
| CreatedBy                             
| LastUpdatedBy                   
+----------------------------------

## 5. Running the API
# By Visual Studio
- Open Project in Visual Studio
- Restore nuget packages
- Build
- Run
## CMD
- dotnet restore
- dotnet build
- dotnet run
