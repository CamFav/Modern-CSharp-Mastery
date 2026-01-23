# Section 02: Student Grades Processing System (Arrays & LINQ)

This project demonstrates a professional approach to data processing in C#, comparing traditional legacy methods with modern functional programming techniques.

---

## 🎯 Objectives

- Process student exam and extra-credit scores using **parallel arrays and loops**.
- Refactor the solution using **Object-Oriented Programming (OOP)** principles.
- Modernize the implementation with **LINQ** for clearer intent and reduced boilerplate.
- Ensure identical results between legacy and modern implementations.

---

## 📊 Key Features

- **Grade Calculation**: Computes exam averages, extra credit impact, and overall grades.
- **Letter Grade Conversion**: Maps numeric grades to standardized letter grades (A+ → F).
- **Side-by-Side Comparison**: Direct comparison between Basic C# and Modern C# approaches.
- **Clean Output**: Tabular console report with exam score, final grade, letter grade, and bonus points.

---

## 💻 Technical Implementation

The project is implemented under the `StudentGrades` namespace and provides **two complete approaches** to solving the same problem:

### Legacy Approach (`RunBasicCSharp`)
- Uses **parallel arrays** and conditional logic.
- Relies on nested `foreach` loops and manual counters to separate exams from extra credit.
- Demonstrates traditional algorithmic thinking commonly found in legacy or introductory codebases.

### Modern Approach (`RunModernCSharp`)
- Uses a `List<Student>` and encapsulated data models.
- Applies **LINQ** (`Take`, `Skip`, `Sum`) to express intent clearly.
- Delegates responsibility to the `Student` class for letter grade conversion.
- Results in cleaner, more maintainable, and more expressive code.

---

## 🚀 Quick Start

Ensure you have the .NET SDK installed, then run:

```bash
dotnet run
```