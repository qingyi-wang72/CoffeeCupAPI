# CoffeeCupAPI

This is a project about making a web api which can provide coffee cups according to the user's requests. It is built in the context of an e-commerce management dashboard where administrators can perform basic CRUD operations on coffee cup products.

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

### Prerequisties

### Installation

### Database Usage

### Run Locally

### Test Locally

• [Back to ToC](#-table-of-contents) •







## Project Highlights

### Technologies

Technologies that have been used for designing and developing the web API.
- **AutoMapper**
- **AutoMapper**

Technologies that have been used for testing the web API.
- **Mock**

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
```

### Response

- 200
    ```json
    
    ```

- 400
    ```json
    
    ```

- 404
    ```json
    Coffee cup with id {id} not found.
    ```

    ```json
    Coffee cups not found.
    ```

- 500
    ```json
    Internal Server Error.
    ```

• [Back to ToC](#-table-of-contents) •







## Unit Testing

This project 

• [Back to ToC](#-table-of-contents) •






