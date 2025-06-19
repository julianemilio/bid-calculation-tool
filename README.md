# Bid Calculation Tool

A web application to calculate the total cost of a vehicle at an auction, considering dynamic fees based on vehicle type and price.

## 🔧 Tech Stack

- **Backend:** .NET 8 Web API (C#)
- **Frontend:** Vue.js 3 + Tailwind CSS
- **Testing:** xUnit, Moq
- **Build Tool:** Vite

## 📦 Project Structure

```
BidCalculationTool/
├── bid-calculation-backend/       # .NET Web API backend
│   ├── Application/               # Application layer (CQRS, handlers)
│   ├── Domain/                    # Business models and calculators
│   ├── Infrastructure/            # Empty, only for the future.
│   └── WebAPI/                    # API controllers and startup
├── bid-calculation-frontend/      # Vue.js 3 frontend
│   ├── api/                       # Axios HTTP client
│   ├── components/                # Reusable UI components
│   └── views/                     # Main page UI
```

## 📈 Features

- Enter **base price** of the vehicle
- Select **vehicle type**: Common or Luxury
- Display individual **fees**:
  - Basic buyer fee (10% with min/max)
  - Seller's special fee
  - Association fee (based on tiers)
  - Storage fee (fixed $100)
- Total price updates **automatically** with any change

## 🧮 Fee Calculation Rules

| Fee                | Common                                                                     | Luxury                 |
| ------------------ | -------------------------------------------------------------------------- | ---------------------- |
| Basic Buyer Fee    | 10%, min $10, max $50                                                      | 10%, min $25, max $200 |
| Special Seller Fee | 2% of base price                                                           | 4% of base price       |
| Association Fee    | $5 if $1-$500<br>$10 if $501-$1000<br>$15 if $1001-$3000<br>$20 if > $3000 | Same as Common         |
| Storage Fee        | $100 fixed                                                                 | $100 fixed             |

## 🖼️ UI Preview

![Descripción de la imagen](/image.png)

> The user interface is styled using Tailwind CSS for a clean and modern look. It features gradient text labels, dark theme inputs, and instant feedback on calculations.

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js & npm](https://nodejs.org/)
- [Vue CLI (optional)](https://cli.vuejs.org/)

### Backend

```bash
cd bid-calculation-backend
dotnet build
dotnet test
dotnet run --project WebAPI
```

### Frontend

```bash
cd bid-calculation-frontend
npm install
npm run dev
```

---

## 🧪 Testing

Unit tests have been implemented for:

- Fee calculators (BasicFee, SpecialFee, AssociationFee, StorageFee)
- Application layer (use cases)

**Running Tests**

```bash
cd bid-calculation-backend/tests
dotnet test
```

---

## Running Tests

| Vehicle Price | Type   | Basic Fee | Special Fee | Association Fee | Storage Fee | Total         |
| ------------- | ------ | --------- | ----------- | --------------- | ----------- | ------------- |
| $398.00       | Common | $39.80    | $7.96       | $5.00           | $100.00     | $550.76       |
| $501.00       | Common | $50.00    | $10.02      | $10.00          | $100.00     | $671.02       |
| $57.00        | Common | $10.00    | $1.14       | $5.00           | $100.00     | $173.14       |
| $1,800.00     | Luxury | $180.00   | $72.00      | $15.00          | $100.00     | $2,167.00     |
| $1,100.00     | Common | $50.00    | $22.00      | $15.00          | $100.00     | $1,287.00     |
| $1,000,000.00 | Luxury | $200.00   | $40,000.00  | $20.00          | $100.00     | $1,040,320.00 |

## 📌 Notes

This application was developed as part of a coding challenge. For production-readiness:

- Add authentication/authorization
- Add proper error handling/logging
- Add responsive layout
- Improve frontend testing (e.g., with Vitest or Cypress)

## 📎 License

MIT License.

---

Made with ❤️ by [Julian Osorio](https://www.linkedin.com/in/julian-emilio-osorio-larroche-574591150/)
