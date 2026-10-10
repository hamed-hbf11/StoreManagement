# 🛒 Store Management System (C# Console Application)

A feature-rich, object-oriented Console Application built in C# following Clean Architecture principles, Separation of Concerns, and SOLID design concepts. The system allows users to manage products, handle inventory, add items to a shopping cart, process orders, and persist data using JSON files.

---

## ✨ Features

- **Product Management (CRUD)**
  - Add new products with auto-generated unique IDs.
  - View products in a clean, formatted ASCII table.
  - Search products dynamically by Name or Category.
  - Edit existing product details with fallback default values.
  - Delete products with built-in search and confirmation steps.
- **Inventory Control**
  - Search and update stock levels directly for individual products.
- **Shopping Cart System**
  - Add products to cart with automatic stock availability checks.
  - Dynamic grand total calculations.
  - Interactive View Cart and Checkout options.
- **Order Processing**
  - Real-time checkout mechanism converting cart items into completed orders.
  - Historical order logging with complete itemized breakdown and timestamps.
- **Data Persistence**
  - Full data serialization and deserialization using `System.Text.Json`.
  - Automatic JSON storage located in the `Data/` directory at the project root.

---

## 🏗️ Architecture & Project Structure

The project follows a layered architecture to maintain high readibility, modularity, and scalability:

```text
StoreManagement/
├── Data/                 # Auto-generated JSON storage files (products.json, orders.json)
├── Models/               # Domain Models & Entities
│   ├── Product.cs
│   ├── CartItem.cs
│   └── Order.cs
├── Services/             # Business Logic & Data Handling
│   ├── ProductService.cs
│   ├── CartService.cs
│   ├── OrderService.cs
│   └── StorageService.cs
└── Program.cs            # Main Entry Point & Dependency Setup
