# Section 01: Inventory Management System (Arrays & LINQ)

This project demonstrates a professional approach to data processing in C#, comparing traditional legacy methods with modern functional programming techniques.

## 🎯 Objectives
* Manage e-commerce product data using **Parallel Arrays**.
* Refactor the system using **Object-Oriented Programming (OOP)**.
* Perform advanced data analytics using **LINQ** (Language Integrated Query).

## 📊 Key Features
* **Inventory Analysis**: Automated total value and average stock calculations.
* **Smart Monitoring**: Real-time "Stock Out" alerts and reorder threshold detection.
* **Advanced Statistics**: Identification of top-performing products (Price/Quantity) using `MaxBy`.

## 💻 Technical Implementation
The project features a dual-implementation within the `InventoryManagement` namespace:

1. **Legacy Approach (`RunBasicCSharp`)**: 
   * Uses indexed loops (`for`, `foreach`) and parallel arrays.
   * Demonstrates fundamental algorithmic logic and manual accumulation.
   
2. **Modern Approach (`RunModernCSharp`)**: 
   * Uses `List<Product>` and **LINQ**.
   * Highlights clean, readable, and maintainable code using Lambda expressions.



## 🚀 Quick Start
Ensure you have the .NET SDK installed, then run:
```bash
dotnet run
```