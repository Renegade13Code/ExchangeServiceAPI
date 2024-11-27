# **Currency Exchange API**

This is a simple API that provides currency exchange functionalities, converting one currency into another using real-time exchange rates from an external API.

## **Features**

- Convert currencies from one type to another.
- Fetch exchange rates for various currencies.
- Handle multiple currencies with different exchange rates.

## **Prerequisites**

- **.NET 8 SDK** or later
- **Docker** installed on your machine
- **Postman** or **Swagger** (for testing the API)
- **External API Key** for the exchange rate service (if applicable)

## **Getting Started**

### **Clone the Repository**

Clone the repository to your local machine:

```bash
git clone https://github.com/yourusername/currency-exchange-api.git
```

### **Building and Running the API in Docker**

To build and run the API using Docker, follow these steps:

1. **Build the Docker image**:

   From the root of your project, run the following command to build the Docker image:

   ```bash
   docker build -t currency-exchange-api .
   ```

   This command uses the `Dockerfile` in the project directory to create the image. The `-t` flag tags the image with the name `currency-exchange-api`.

2. **Run the Docker container**:

   After the build is complete, you can run the Docker container with the following command:

   ```bash
   docker run -d -p 5001:8080 currency-exchange-api
   ```

   This command starts the container in detached mode (`-d`), maps port `5001` on your local machine to port `8080` inside the container.

3. **Verify the API is running**:

   Open your browser or use **Postman** and the postman collection provided to verify that the API is running. By default, it should be accessible at:

   ```
   http://localhost:5001
   ```

### **Testing the API**

You can test the API using **Postman**

- **Postman**: Import the collection provided in the repository or manually create requests to test the endpoints.

## **Caveats**

1. **API Key Management**: If you're using a third-party exchange rate API, ensure your API key is properly managed. Do not hard-code the key directly into the source code. Use environment variables or a configuration management service for production environments.
   
3. **Handling Errors**: Ensure proper error handling in case of network failures, invalid currencies, or other edge cases. Consider implementing retry logic or default error messages where appropriate.

4. **Rate Limiting**: If your external API has rate limits (e.g., X requests per minute/hour), ensure your service handles those gracefully, perhaps with rate-limiting mechanisms or queuing requests.

## **Future Improvements**

1. **Caching Exchange Rates**: The API could benefit from caching exchange rates to reduce the number of requests to the external API and improve performance. Consider using a caching layer like Redis.

2. **Unit and Integration Testing**: Although the core functionality is tested, further integration tests with the external exchange rate API could ensure robustness. Integration tests should be added as well.

3. **User Authentication and Authorization**: For enhanced security, add authentication and authorization mechanisms, such as JWT (JSON Web Tokens), to protect API endpoints from unauthorized access. This will only be applied to endpoints that need to be authenticated.

5. **Rate Limiting and Throttling**: Implement rate limiting on the API to ensure fair usage, especially if it's exposed to many clients.

6. **Logging and Monitoring**: Add logging (e.g., Serilog or NLog) and monitoring (e.g., Prometheus, Application Insights) to keep track of usage patterns, performance issues, and errors.

7. **HTTPS Cert**: Update the application to redirect to https and update the docker file to make use of tooling to generate and store cert on container.

