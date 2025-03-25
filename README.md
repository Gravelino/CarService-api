# CarService - Car Service Management System

**CarService** is application for car service management, developed using ASP.NET Core, CQRS, MediatR, Soft Delete and Entity Framework Core. The application allows you to manage customers, cars, services, mechanics, visits and payments.

---

## Full Business scenario

### 1. **Customer Scenarios**
- Registering a new customer
  - Command: CreateCustomerCommand
  - Process:
    - The customer provides personal data (name, phone, email)
    - The system checks the uniqueness of the email/phone
    - A new customer account is created
- Adding a customer's car
  - Command: CreateCarCommand
  - Query: GetCustomerWithCarsByIdQuery
  - Process:
     - The customer selects himself from the list
     - Enters car data (make, model)
- Viewing service history
  - Queries:
     - GetCarWithVisitHistoryQuery
     - GetVisitsByCustomerIdQuery
  - Process:
     - The customer selects his car
     - The system shows the full history of visits
     - For each visit, the following are displayed:
        - Completed services
        - Amounts spent (GetTotalPaymentsForVisitQuery)
        - Feedback (GetFeedbackByVisitQuery)

### 2. **Service Scenarios**
- Visit Schedule
   - Commands:
      - CreateVisitCommand
   - Queries:
      - GetAvailableWorkersQuery
      - GetServicesByCategoryIdQuery
   - Process:
      - Client selects services
      - System checks mechanic availability
      - Work plan is generated with cost calculation

### 3. **Financial Scenarios**
- Payment Processing
  - Commands:
    - CreatePaymentCommand
    - UpdatePaymentCommand
  - Queries:
    - GetPaymentsByVisitIdQuery
    - GetTotalPaymentsForVisitQuery
  - Process:
    - System generates invoice
    - Customer selects payment method
    - On successful payment:
      - Visit status is updated
      - Receipt is sent

### 4. **Car Service Scenarios**
- Diagnostics
  - Queries:
    - GetServiceByIdQuery
    - GetToolsForServiceQuery
  - Process:
    - Mechanic selects diagnostic type
    - System suggests required tools
    - Results are recorded in the visit

---

## Technologies

- **Backend**: ASP.NET Core, CQRS, MediatR, Soft Delete Patern
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
