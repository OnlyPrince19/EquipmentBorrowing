# Equipment Borrowing System

A console-based application built using Clean/Onion Architecture principles in .NET. This project focuses on establishing a clean, layered application structure — without databases or user interfaces — as part of Laboratory Activity 1: From Requirements to Application Structure.

## Part A: System Analysis

### Actors

- **Student**: Wants to request equipment, view available equipment, and return items.
- **Lab Administrator / System**: Validates rules, processes requests, and tracks item availability.

### Major Use Cases

1. **Borrow Equipment** (Primary focus)
2. **Return Equipment**
3. **Search/View Available Equipment**

### Domain Concepts

- **Student**: Holds ID, name, status (is allowed to borrow), and active borrowing count. Does NOT handle database fetching or UI rendering.
- **Equipment**: Holds ID, name, and availability status. Does NOT track student history.
- **Borrowing**: Holds Student ID, Equipment ID, borrow date, expected return date, and status (Active or Returned). Does NOT handle UI validation messages.

## Architecture

The solution follows Clean/Onion Architecture, with dependencies flowing inward:

```
EquipmentBorrowing.ConsoleApp
        |
        v
EquipmentBorrowing.Infrastructure --> EquipmentBorrowing.Application --> EquipmentBorrowing.Domain
```

- **EquipmentBorrowing.Domain**: Core models (`Student`, `Equipment`, `Borrowing`, `BorrowingStatus`) with no external dependencies.
- **EquipmentBorrowing.Application**: Repository interfaces (`IStudentRepository`, `IEquipmentRepository`, `IBorrowingRepository`) and the `BorrowEquipmentService`, which contains the core borrowing business logic.
- **EquipmentBorrowing.Infrastructure**: In-memory repository implementations (`InMemoryStudentRepository`, `InMemoryEquipmentRepository`, `InMemoryBorrowingRepository`) used for testing without a real database.
- **EquipmentBorrowing.ConsoleApp**: Entry point that wires everything together and runs sample borrowing scenarios.

## Running the Project

1. Open `EquipmentBorrowing.sln` in Visual Studio.
2. Set `EquipmentBorrowing.ConsoleApp` as the startup project.
3. Press `F5` to build and run.

The console output demonstrates three scenarios:
- A successful borrow request.
- A rejected request from an ineligible student.
- A rejected request for equipment that is already unavailable.