# Policy Service

Simple insurance policy management system built in ASP.NET Core (.NET 8).

## Use case

1. User creates a policy with number `1234` for period `1 dec 2023` to `30 nov 2024`.
2. Policy `1234` is renewed for period `1 dec 2024` to `30 nov 2025` with a premium (price) increase of 10% of the previous premium.
3. User views policy `1234` and is able to see both periods including the premium (price).

## Project Goal

The main goal of the project was to demonstrate:
- **Clean architecture** using layered structure (Domain, Application, Infrastructure, API),
- Proper **separation of concerns** and extensibility,
- Usage of **CQRS** with MediatR,
- Good **EF Core** practices and clean domain modeling,
- Scalable **Web API** design with DTOs.
