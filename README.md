# CoffeeCupAPI

#### Table of Content
- [Entity Definition](#Entity-Definition)
- [API Endpoints Definition](#API-Endpoints-Definition)

## Entity Definition

<details>
 <summary>CoffeeCup</summary>

##### Attributes

- **Id** `int`
_Product id_

- **Name** `string`
_Product name_

- **Color** `string`
_Product color_

- **Material** `string`
_Product material_

- **Description** `string`
_Product description_

- **Stock** `int`
_Inventory of products_

- **Price** `float`
_Individual product price_

</details>


## API Endpoints Definition

#### Create a coffee cup

<details>
 <summary><code>POST</code> <code><b>/</b></code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | None      |  required | object (JSON or YAML)   | See [POST/PUT request body format](#POST/PUT-request-body-format)  |


##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `text/plain;charset=UTF-8`        | YAML string  |
</details>


#### List existing coffee cups

<details>
 <summary><code>GET</code> <code>/</code></summary>
 List all the coffee cups.

##### Parameters

> None
##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `text/plain;charset=UTF-8`        | YAML string  |
</details>

<details>
 <summary><code>GET</code> <code>/{id}</code></summary>
 List the corresponding coffee cup by the given product ID.

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id      |  required   | int   | Product ID                         |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `text/plain;charset=UTF-8`        | YAML string  |
</details>


#### Update existing coffee cups

<details>
 <summary><code>PUT</code> <code>/{id}</code></summary>
 Update the corresponding coffee cup by the given product ID.

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id      |  required   | int                     | Product ID       |
> | None    |  required   | object (JSON or YAML)   | See [POST/PUT request body format](#POST/PUT-request-body-format)  |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `text/plain;charset=UTF-8`        | YAML string  |
</details>


#### Delete existing coffee cups

<details>
 <summary><code>DELETE</code> <code>/{id}</code></summary>
 Delete the corresponding coffee cup by the given product ID.

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | id      |  required   | int                     | Product ID       |

##### Responses

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `text/plain;charset=UTF-8`        | YAML string  |
</details>

------------------------------------------------------------------------------------------

#### POST/PUT request body format

```json
{
    "name": "Bunny Coffee Cup",
    "color": "White",
    "material": "ceramic",
    "description": "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur vehicula.",
    "stock": 10,
    "price": 14.5
}
```