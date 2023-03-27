# CoffeeCupAPI

The project uses TDD to build a web api which can provide coffee cups according to the user's requests. It is built in the context of an e-commerce management dashboard where administrators can perform basic CRUD operations on coffee cup products.

## Table of ontents
- [Getting Started](#Getting-Started)
- [Project Highlights](#Project-Highlights)
- [Entity Definition](#Entity-Definition)
- [API Endpoints Definition](#API-Endpoints-Definition)
    - [Create a coffee cup](#Create-a-coffee-cup)
    - [List a coffee cup](#List-a-coffee-cup)
    - [List all the coffee cups](#List-all-the-coffee-cups)
    - [Update a coffee cup](#Update-a-coffee-cup)
    - [Delete a coffee cup](#Delete-a-coffee-cup)
- [Examples of Request/Response](#Examples-of-Request/Response)
- [HTTP Status Code Summary](#HTTP-Status-Code-Summary)
- [Unit Testing](#Unit-Testing)

## Getting Started
Use these instructions to run and test the project locally.

### Tools
- Visual Studio Code for Mac
- .NET 7.0

### Installation
1. Clone the repository
2. At the root directory, restore the required packages by running:
    ```csharp
    dotnet restore
    ```
3. Build the solution by running:
    ```csharp
    dotnet build
    ```
4. At the CoffeeCupAPI directory, launch the project by running:
    ```csharp
    cd CoffeeCupAPI
    dotnet run
    ```
    Launch http://localhost:5002/swagger/index.html in your browser to view the Swagger UI.
5. At the CoffeeCupAPI.Tests directory, test the project by running:
    ```csharp
    cd CoffeeCupAPI.Tests
    dotnet test
    ```
### Database Usage

After completing the Installation process, the project is able to run locally using an In-Memory Database. If you would like to use a presistent database, follow these instructions before launching the project.

1. Since the connection string contains sensitive information that needs to be protected, secret your connection string using the Secret Manage tool.
    - Eable the Secret Manager by running:
        ```csharp
        dotnet user-secrets init
        ```
    - Create a secret connection string by running:
        ```csharp
        dotnet user-secrets set ConnectionStrings:CoffeeCupContext "<yourConnectionStrings>"
        ```
2. Update the _program.cs_ file.
    ```csharp
    // register the context (in-memory database)
    // builder.Services.AddDbContext<CoffeeCupContext>(
    //     options => options.UseInMemoryDatabase("CoffeeCupsDb"));

    // register the context (presistent database)
    builder.Services.AddDbContext<CoffeeCupContext>(
        options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("CoffeeCupContext")));
    ```
3. Add the first migration named InitalCrete.
    ```csharp
    dotnet ef migrations add InitialCreate
    ```
4. Create your database and schema from the migration.
    ```csharp
    dotnet ef database update
    ```

• [Back to ToC](#-table-of-contents) •







## Project Highlights

- Use **Entity Framework** to store data presistantly, retrieve data and implement mapping between the CoffeeCup entity and the database table.
- Use **AutoMapper** to implement mapping between DTOs and the CoffeeCup entity.
- Use **Moq** to perform unit testing and create mocks representing each injected services.

- Use **design principle** such as **dependency inversion principle** to decouple the high level and low level modules.
- Use **design pattern** such as **MVC**, **dependency Injection**, logging, validation, and exception handling. 

• [Back to ToC](#-table-of-contents) •







## Entity Definition

### CoffeeCup
- **Id**: product id `int`
- **Name**: product name `string`
- **Color**: product color `string`
- **Material**: product material `string`
- **Description**: product description `string`
- **Stock**: inventory of products `int`
- **Price**: individual product price `float`

• [Back to ToC](#-table-of-contents) •







## API Endpoints Definition

### Create a coffee cup
Create a new coffee cup product.

```js
POST /api/CoffeeCups
```

##### Parameters 

See [Examples of Request/Response](#Examples-of-Request/Response)

##### Response
###### Success response
- **Code**: 200
- **Content**: return a list of CoffeeCup objects including the CoffeeCup just created.

###### Error response
- **Code**: 400/404/500
- **Content**: throw an error message; see [Examples of Request/Response](#Examples-of-Request/Response). 








### List a coffee cup
List the corresponding coffee cup by the given id.

```js
GET /api/CoffeeCups/:id
```

##### Parameters 
- **Id**: product id `int` _(required)_

##### Response
###### Success response
- **Code**: 200
- **Content**: return a CoffeeCup object with the given id.

###### Error response
- **Code**: 404/500
- **Content**: throw an error message; see [Examples of Request/Response](#Examples-of-Request/Response). 








### List all the coffee cups
List all the coffee cups.

```js
GET /api/CoffeeCups
```

##### Parameters 
None

##### Response
###### Success response
- **Code**: 200
- **Content**: return a list of CoffeeCup objects.

###### Error response
- **Code**: 404/500
- **Content**: throw an error message; see [Examples of Request/Response](#Examples-of-Request/Response). 







### Update a coffee cup
Update the corresponding coffee cup by the given id.

```js
PUT /api/CoffeeCups/:id
```

##### Parameters 
- **Id**: product id `int` _(required)_

See [Examples of Request/Response](#Examples-of-Request/Response)

##### Response
###### Success response
- **Code**: 200
- **Content**: return a list of CoffeeCup objects including the CoffeeCup just updated.

###### Error response
- **Code**: 400/404/500
- **Content**: throw an error message; see [Examples of Request/Response](#Examples-of-Request/Response). 








### Delete a coffee cup
Delete the corresponding coffee cup by the given id.

```js
Delete /api/CoffeeCups/:id
```

##### Parameters 
- **Id**: product id `int` _(required)_

##### Response
###### Success response
- **Code**: 200
- **Content**: return a list of CoffeeCup objects excluding the CoffeeCup just deleted.

###### Error response
- **Code**: 404/500
- **Content**: throw an error message; see [Examples of Request/Response](#Examples-of-Request/Response). 

• [Back to ToC](#-table-of-contents) •






## HTTP Status Code Summary

This project involves the HTTP status codes listed below to indicate the success or failure of the API request.

|   Code    |   Explanation     |
| --------- | ----------------- |
|       `200` - OK          |   Everything was working as expected.  |
|   `400` - Bad Request     |   The request was unexpected because a required parameter was missing or an invalid parameter was raised by the client.  |
|   `404` - Not Found       |   The requested resource could not be found.   |
|   `500` - Internal Server Error   |   Something went wrong and the server does not know how to handle it.   |    

• [Back to ToC](#-table-of-contents) •








## Examples of Request/Response

### Request 

```json
{
  "name": "Bunny cup",
  "color": "White",
  "material": "Ceramic",
  "description": "",
  "stock": 200,
  "price": 3.99
}
```

### Response

- Status code `200`
    ```json
    [
        {
            "id": 3,
            "name": "Bunny Cup",
            "color": "White",
            "material": "Ceramic",
            "description": "convallis convallis tellus id interdum velit laoreet id donec ultrices",
            "stock": 200,
            "price": 4.99
        },
        // ... more data
    ]
    ```

- Status code `400`
    ```json
    {
        "errors": {
            "Name": [
                "The Name field is required."
            ],
            "Price": [
                "The field Price must be between 0 and 3.4028234663852886E+38."
            ]
        }
    }
    ```

- Status code `404`
    - A CoffeeCup with _Id_ does not exist in the database.
        ```json
        Coffee cup with id {id} not found.
        ```
    - There is an empty CoffeeCup list in the database.
        ```json
        Coffee cups not found.
        ```

- Status code `500`
    ```json
    Internal Server Error.
    ```

• [Back to ToC](#-table-of-contents) •







## Unit Testing
The unit testing for the web API considers 6 test cases based on different scenarios.
    - Tests if the _GetCoffeeCups_ action succeeds and returns a status code of `200`.
    - Tests if the _AddCoffeeCup_ action fails on invalid user input and returns a status code of `400`.
    - Tests if the _GetCoffeeCups_ action fails and returns a status code of `404`.
    - Tests if the _GetCoffeeCups_ action fails with an Internal server error and returns a status code of `500`.
    - Tests if the _GetCoffeeCups_ action succeeds and returns a list of CoffeeCup.
    - Tests if the _GetCoffeeCup_ action succeeds and returns a CoffeeCup with the _Id_ requeted by the user.

• [Back to ToC](#-table-of-contents) •






