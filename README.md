# CoffeeCupAPI

This is a task about creating a coffee cup as an object and making a web api which serves coffee cups based on uers' requests.

## Table of Content
- [Entity Definition](#Entity-Definition)
- [API Endpoints Definition](#API-Endpoints-Definition)
- [POST/PUT request body format](#POST/PUT-request-body-format)

## Entity Definition

### CoffeeCup
- **Id**: product id `int`
- **Name**: product name `string`
- **Color**: product color `string`
- **Material**: product material `string`
- **Description**: product description `string`
- **Stock**: inventory of products `int`
- **Price**: individual product price `float`

## API Endpoints Definition

- [Create a coffee cup](#Create-a-coffee-cup)
- [List a coffee cup](#List-a-coffee-cup)
- [List all the coffee cups](#List-all-the-coffee-cups)
- [Update a coffee cup](#Update-a-coffee-cup)
- [Delete a coffee cup](#Delete-a-coffee-cup)

### Create a coffee cup
Create a new coffee cup product.

```js
POST /api/CoffeeCups
```

##### Parameters 
See [POST/PUT request body format](#POST/PUT-request-body-format)

##### Response
- **Code**: 200
- **Content**:
    ```json
    {
    "data": [
        {
        "id": 6,
        "name": "Recyclable cup",
        "color": "Green",
        "material": "Plastic",
        "description": "vulputate odio ut enim blandit volutpat maecenas volutpat blandit aliquam",
        "stock": 5,
        "price": 5.99
        }
        /* ... more data */
    ],
    "success": true,
    "message": "Successfully add a coffee cup"
    }
    ```

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
- **Content**:
    ```js
    {
    "data": {
        "id": 6,
        "name": "Recyclable cup",
        "color": "Green",
        "material": "Plastic",
        "description": "vulputate odio ut enim blandit volutpat maecenas volutpat blandit aliquam",
        "stock": 5,
        "price": 5.99
    },
    "success": true,
    "message": "Successfully get the coffee cup with id 6"
    }
    ```

###### Error Response
- **Code**: 404
- **Content**:
    ```json
    {
    "data": null,
    "success": false,
    "message": "GET error: coffeeCup with id 10 not found"
    }
    ```

### List all the coffee cups
List all the coffee cups.

```js
GET /api/CoffeeCups
```

##### Parameters 
None

##### Response
- **Code**: 200
- **Content**:
    ```js
    {
    "data": [
        {
        "id": 3,
        "name": "Bunny Cup",
        "color": "White",
        "material": "Ceramic",
        "description": "convallis convallis tellus id interdum velit laoreet id donec ultrices",
        "stock": 200,
        "price": 4.99
        },
        /* ... more data */
    ],
    "success": true,
    "message": "Successfully get all the coffee cups"
    }
    ```

### Update a coffee cup
Update the corresponding coffee cup by the given id.

```js
PUT /api/CoffeeCups/:id
```

##### Parameters 
- **Id**: product id `int` _(required)_

See [POST/PUT request body format](#POST/PUT-request-body-format)

##### Response
###### Success response
- **Code**: 200
- **Content**:
    ```json
    {
    "data": [
        {
        "id": 6,
        "name": "Recyclable cup",
        "color": "Green",
        "material": "Plastic",
        "description": "vulputate odio ut enim blandit volutpat maecenas volutpat blandit aliquam",
        "stock": 5,
        "price": 3.99
        }
        /* ... more data */
    ],
    "success": true,
    "message": "Successfully update the coffee cup with id 6"
    }
    ```

###### Error response
- **Code**: 404
- **Content**:
    ```json
    {
    "data": null,
    "success": false,
    "message": "PUT error: coffeeCup with id 10 not found"
    }
    ```

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
- **Content**:
    ```json
    {
    "data": [
        {
        "id": 3,
        "name": "Bunny Cup",
        "color": "White",
        "material": "Ceramic",
        "description": "convallis convallis tellus id interdum velit laoreet id donec ultrices",
        "stock": 200,
        "price": 4.99
        }
        /* ... more data */
    ],
    "success": true,
    "message": "Successfully detele a coffee cup with id 6"
    }
    ```

###### Error response
- **Code**: 404
- **Content**:
    ```json
    {
    "data": null,
    "success": false,
    "message": "DELETE error: coffeeCup with id 10 not found"
    }
    ```


## POST/PUT request body format

```json
{
  "name": "Recyclable cup",
  "color": "Green",
  "material": "Plastic",
  "description": "vulputate odio ut enim blandit volutpat maecenas volutpat blandit aliquam",
  "stock": 5,
  "price": 5.99
}
```
