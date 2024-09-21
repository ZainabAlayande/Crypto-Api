# Crypto API

## Overview
The **Crypto API** is a RESTful service that provides real-time information about various cryptocurrencies. It allows users to fetch details such as price, market capitalization, and trading volume for different cryptocurrencies.

## Features
- Fetch all cryptocurrencies
- Retrieve specific cryptocurrency details by ID

## API Endpoints

### 1. Get All Cryptocurrencies
- **Endpoint:** `GET /api/cryptos`
- **Description:** Retrieves a list of all cryptocurrencies with their details.
- **Response:**
    - Status: 200 OK
    - Content: 
    ```json
    {
        "status": "success",
        "message": "Data fetched successfully.",
        "data": [
            {
                "id": "bitcoin",
                "rank": "1",
                "symbol": "BTC",
                "name": "Bitcoin",
                "supply": "19757015",
                "maxSupply": "21000000",
                "marketCapUsd": "1249296361387.56",
                "volumeUsd24Hr": "10384722868.35",
                "priceUsd": "63233.05",
                "changePercent24Hr": "0.38",
                "vwap24Hr": "63022.28",
                "explorer": "https://blockchain.info/"
            },
            ...
        ]
    }
    ```

### 2. Get Cryptocurrency by ID
- **Endpoint:** `GET /api/cryptos/{id}`
- **Description:** Retrieves details of a specific cryptocurrency by its ID.
- **Response:**
    - Status: 200 OK (if found)
    - Content: 
    ```json
    {
        "status": "success",
        "message": "Data fetched successfully.",
        "data": {
            "id": "bitcoin",
            "rank": "1",
            "symbol": "BTC",
            "name": "Bitcoin",
            ...
        }
    }
    ```
    - Status: 404 Not Found (if not found)
    - Content: 
    ```json
    {
        "status": "error",
        "message": "Crypto not found.",
        "data": null
    }
    ```

## Testing the API with Swagger
The Crypto API integrates Swagger for easy testing of the endpoints. To test the API:

1. Run the application using the command:
   ```bash
   dotnet run
   ```
2. Open your web browser and navigate to https://localhost:5041/swagger
3. You will see the Swagger UI, where you can test all available endpoints.

## Installation
To set up the project locally:

1. Clone the repository:
```
git clone https://github.com/yourusername/crypto-api.git
cd crypto-api
```
2. Restore dependencies:
```
dotnet restore

```
3. Run the application:
```
dotnet run

```

## Testing
The project includes unit tests to verify the functionality of the services and controllers. To run the tests, use the command:
```
dotnet test

```




