# ASP.NET Core Todo API (A Frontend/TypeScript Dev's Journey into .NET)

> A lightweight, clean-architecture in-memory Todo RESTful API built with **ASP.NET Core Web API** (.NET 10). Designed as a hands-on learning lab to map backend C#/.NET concepts directly to TypeScript, React, and Node/Express mental models.

---

## 💡 Motivation: Why this Project?

As a frontend developer working extensively with **TypeScript**, **React**, and **Node.js/Express**, I frequently heard developers say:
> *"TypeScript feels almost like C#."*  
> *"TypeScript was created by Anders Hejlsberg (the lead architect of C#) at Microsoft to give frontend developers a C#-like structured, strongly-typed developer experience with a smaller learning curve."*

I wanted to test this claim myself. Instead of jumping straight into complex enterprise boilerplate, I set out to build a pure, foundational Web API from scratch breaking down each building block, understanding how OOP principles actually shape backend architecture, and comparing every line with its Express/TypeScript counterpart.

**The verdict?** The rumors were true. Concepts like interfaces, generics, access modifiers, and type safety feel right at home coming from TypeScript. But ASP.NET Core takes it further with **runtime type safety**, built-in **Dependency Injection (IoC)**, and a battle-tested **HTTP middleware & routing pipeline**.

---

## 🛠️ What We Built (Step-by-Step Evolution)

Here is a summary of the progression and concepts implemented across the project:

### 1. Project Initialization & Git Hygiene
- Initialized Git with a standard .NET `.gitignore` to keep ephemeral build artifacts (`bin/`, `obj/`) strictly untracked.
- Configured local development ports (`http://localhost:3001`).

### 2. Basic Architecture & Request Pipeline
- Removed default template clutter (`WeatherForecast`).
- Explored `Program.cs` and understood the fundamental duality of ASP.NET Core:
  - **Service Registration (`builder.Services`)**: The Dependency Injection (DI) registry.
  - **Middleware Pipeline (`app.Use...` / `app.Map...`)**: The sequential request execution chain (analogous to Express `app.use()`).
- Added a basic `GET /api/health` endpoint using controller inheritance (`ControllerBase`).

### 3. Domain Model & Encapsulation
- Created `TodoItem` model with core properties: `Id`, `Title`, `IsDone`, and `CreatedAt`.
- Implemented **Encapsulation** using `{ get; private set; }` on `CreatedAt` to protect audit timestamps from unauthorized external modification.

### 4. Separation of Concerns & Dependency Injection (DI)
- Refactored logic out of `TodosController` into a dedicated service: `TodoService`.
- Replaced tight coupling (`new TodoService()`) with **Constructor Injection**.
- Registered `TodoService` as a **Singleton** to maintain an in-memory data store across requests without resetting.

### 5. Abstraction & Polymorphism (Dependency Inversion)
- Introduced the `ITodoService` interface defining the contract (**WHAT**) rather than implementation (**HOW**).
- Refactored `TodosController` to depend purely on `ITodoService` (the **D** in **SOLID**).
- Demonstrated polymorphism by swapping concrete implementations via DI configuration without touching a single line of controller code.

### 6. Full RESTful CRUD Operations
Built a complete suite of standard REST endpoints with route constraints and clean HTTP status code conventions:

| HTTP Verb | Endpoint | Description | Success Code | Error Code |
| :--- | :--- | :--- | :--- | :--- |
| **GET** | `/api/health` | Server heartbeat & UTC timestamp | `200 OK` | - |
| **GET** | `/api/todos` | List all todos | `200 OK` | - |
| **GET** | `/api/todos/{id:int}` | Get single todo by integer ID | `200 OK` | `404 Not Found` |
| **POST** | `/api/todos` | Create a new todo item | `201 Created` (`Location` header) | `400 Bad Request` |
| **PUT** | `/api/todos/{id:int}` | Update title & completion status | `204 No Content` | `404 Not Found` |
| **DELETE** | `/api/todos/{id:int}` | Remove todo by ID | `204 No Content` | `404 Not Found` |

---

## 🧠 Key Takeaways: TypeScript/Node vs. C#/.NET

| Concept | Node.js / TypeScript | C# / ASP.NET Core |
| :--- | :--- | :--- |
| **Typing System** | Compile-time only (erased at runtime). | Strong runtime typing + compile-time checking. |
| **Interface** | Disappears in JS output. Cannot be used at runtime. | Real runtime entity; DI container resolves implementations via interfaces. |
| **Dependency Injection** | Usually manual imports or 3rd-party libs (Inversify, NestJS). | First-class citizen built directly into the framework core. |
| **Routing** | Functional/imperative (`router.get('/path', handler)`). | Declarative attribute-based routing (`[Route]`, `[HttpGet]`). |
| **Web Server** | Node.js built-in `http` event loop. | **Kestrel**: High-performance, multi-threaded web server. |
| **Immutability** | `Readonly<T>`, `Object.freeze()`. | Native `record` types with value-based equality. |

---

## 🚀 Running & Testing

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/) (or .NET 8 LTS)

### Run the API
```bash
dotnet restore
dotnet run
```
The server will start listening at: `http://localhost:3001`

### Test with REST Client (`.http`)
The repository includes an interactive [net-basic-todo.http](net-basic-todo.http) test file. If you use VS Code (with REST Client extension) or Antigravity IDE, simply open the file and click **Send Request** above any block to test live endpoints:
- Health check
- CRUD flows (Create → Read → Update → Delete)
- Idempotency & edge cases (e.g., deleting twice, non-existing IDs)

### Test via cURL
```bash
# 1. Health check
curl -i http://localhost:3001/api/health

# 2. Get all todos
curl -i http://localhost:3001/api/todos

# 3. Create a todo
curl -i -X POST http://localhost:3001/api/todos \
  -H "Content-Type: application/json" \
  -d '{"title":"Explore Entity Framework Core","isDone":false}'
```
