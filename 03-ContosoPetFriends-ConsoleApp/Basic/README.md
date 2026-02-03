## Contoso PetFriends – Classic C# Implementation (Basic)

This project is a **classic C# console application** based on the Microsoft Learn *Contoso PetFriends* exercises.  
It focuses on practicing **fundamental C# concepts** through a structured, menu-driven application.

This version intentionally uses **imperative logic and basic data structures** to provide a clear and readable baseline before any modernization or refactoring.

---

### 🎯 Objectives

- Practice arrays, loops, and conditional branching in C#.
- Store and manipulate structured data using a two-dimensional array.
- Validate user input for both numeric and textual values.
- Implement a menu-driven console workflow.
- Build a complete, working application following Microsoft Learn guidelines.

---

### 📊 Key Features

- **Pet Records Management**  
  Stores pet information including ID, species, age, nickname, physical description, and personality.

- **Interactive Menu System**  
  Allows users to list pets, add new animals, edit existing data, and search by characteristics.

- **Input Validation**  
  Ensures required fields are completed and numeric values (such as age) are valid.

- **Data Completion Checks**  
  Identifies missing or incomplete information and prompts the user to update it.

- **Species-Based Search**  
  Displays cats or dogs matching a user-provided keyword found in descriptions.

---

### 💻 Technical Implementation

This version uses a **classic C# approach**, including:

- A two-dimensional `string[,]` array for runtime data storage.
- Explicit control flow with `for`, `while`, and `do / while` loops.
- Conditional logic using `if / else` and `switch` statements.
- Console-based user interaction with defensive input handling.

The goal is **clarity and correctness**, not optimization.

---

### 🚀 Quick Start

Ensure you have the .NET SDK installed, then run:

```bash
dotnet run
```