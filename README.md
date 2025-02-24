# .NET 8 Web API

This API implements all the essential functionalities outlined in the accompanying documentation, adhering to the principles of clean architecture for maintainable and scalable design.

To test this API locally, connect it to a local SQL Server, install the necessary dependencies, and Use Swagger to expose an interactive UI for testing the API endpoints:

Implemented:

- **CRUD Operations**: supports full CRUD (Create, Read, Update, Delete) functionality for managing Companies, Contacts, and Countries. Each entity has dedicated endpoints for seamless data manipulation.
- **Unit tests**: Comprehensive unit tests have been implemented to verify the correctness and reliability of the API functionality.
- **Logging and error handling**: Robust logging and error handling mechanisms are in place to facilitate efficient tracking and debugging of issues.
- **Lambda expressions**: Lambda expressions are utilized throughout the application where appropriate, enhancing code readability and efficiency.



### Example response: GET Contact with Company and Country

**Request:** `http://localhost:5434/api/v1/Contact/GetContactEditMCompanyAndCountry`

**Response Body:**
```json
[
    {
        "id": 1,
        "contactName": "FirstContact",
        "companyId": [2, 3],
        "companyName": "Apple",
        "countryId": [3],
        "countryName": "Japan"
    },
    {
        "id": 2,
        "contactName": "AnotherOne",
        "companyId": [1, 4],
        "companyName": "Microsoft",
        "countryId": [1, 2],
        "countryName": "USA"
    }
]
```
Also fixed issues in the code for retrieving .txt files from a directory and appending text. Improved error handling, file operations, and readability for robust functionality.

