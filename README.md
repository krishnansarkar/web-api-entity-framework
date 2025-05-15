## Quick Info

CRUD API made with .Net 8 and Entity Framework.
MS SQL Database.
Containerized through Docker.

## Supported CRUD Operations:

### GET /api/Employee

    Function: Gets all employees.
    Return: All employees

### POST /api/Employee

    Function: Creates a new employee.
    Body: {
        "firstName": "string",
        "lastName": "string",
        "email": "string",
        "phoneNumber": "string",
        "salary": decimal
    }

### GET /api/Employee/{id}

    Function: Gets a specific employee.

### PUT /api/Employee/{id}

    Function: Modifies a specific employee.
    Body: {
        "firstName": "string",
        "lastName": "string",
        "email": "string",
        "phoneNumber": "string",
        "salary": decimal
    }

### DELETE /api/Employee/{id}

    Function: Deletes a specific employee.
