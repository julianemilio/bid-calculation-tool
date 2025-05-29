# Bid Calculation Tool

A web application to calculate the total cost of a vehicle at an auction, considering dynamic fees based on vehicle type and price. Built with Clean Architecture principles.

---

## Features

- **Fee Calculation**:
  - Basic Buyer Fee (10% of price, with min/max based on vehicle type).
  - Seller's Special Fee (2% for Common, 4% for Luxury).
  - Association Fee (tiered: $5 to $20 based on price range).
  - Fixed Storage Fee ($100).
- **Dynamic UI**: Real-time updates when inputs change (Vue.js frontend).
- **REST API**: Backend built with ASP.NET Core (or specified language).
- **Unit Tests**: Comprehensive tests for domain logic and components.

---

## Technologies Used

- **Backend**: ASP.NET Core (or language specified in job description)
- **Frontend**: Vue.js
- **Testing**: xUnit (backend), Jest (frontend)

---

## Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/yourusername/bid-calculation-tool.git
   cd bid-calculation-tool

   ```

2. **Backend Setup**:

   ```bash
   cd src/WebApi
   dotnet restore
   dotnet run
   ```

   - API runs on http://localhost:5000.

3. **Frontend Setup**:
   ```bash
   npm install
   npm run serve
   ```
   - Frontend runs on http://localhost:8080.

## Project Structure

```bash
src/
├── Domain/               # Core business logic
│   └── Vehicles/         # Fee calculators, enums, exceptions
├── Application/          # Use cases and interfaces
├── WebApi/               # REST API endpoints
│   └── Controllers/      # BidController handles /api/calculate
└── Frontend/             # Vue.js UI components
tests/                    # Unit tests
```

## Running Tests

**Backend Tests**:

```bash
cd tests/Domain.UnitTests
dotnet test
```

**Frontend Tests**:

```bash
cd src/Frontend
npm run test:unit
```
