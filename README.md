# CarService - Car Service Management System

**CarService** is a web application for car service management, developed using ASP.NET Core, CQRS, MediatR, Soft Delete and Entity Framework Core. The application allows you to manage customers, cars, services, mechanics, visits and payments.

---

## Main Business Logic

### 1. **Customers**
- Customers can register in the system and add their cars.
- Each customer has the following data:
  - First and last name
  - Phone
  - Email
  - Address
  - Registration date
- Customers can have multiple cars.

### 2. **Cars**
- Cars belong to customers and have the following data:
  - Brand
  - Model
  - Year of manufacture
  - License plate
  - Color
  - Date of last inspection
- Each car can have a history of visits to the car service.

### 3. **Services**
- Services provided by a car service have the following data:
  - Service name
  - Description
  - Base price
  - Duration
- Services are grouped by category (e.g., "Engine", "Brakes", "Suspension").

### 4. **Workers**
- Workers are car service employees who perform services. They have the following data:
  - First and last name
  - Specialization
  - Date hired
  - Phone
  - Email
  - Salary
- Mechanics can be busy or available to perform work.

### 5. **Visits**
- A visit is a customer's record of a car service. Visits have the following data:
  - Visit start and end date
  - Status
  - Total cost
- Each visit is associated with a customer, a car, and services.

### 6. **Payments**
- Payments are made for visits. They have the following data:
  - Amount
  - Payment date
  - Payment method
  - Status
  - Currency

### 7. **Feedbacks**
- Customers can leave reviews about visits. Reviews contain:
  - Rating (1 to 5)
  - Comment
  - Feedback date

---

## Technologies

- **Backend**: ASP.NET Core, CQRS, MediatR, Soft Delete Patern
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
