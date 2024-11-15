# Quizly

**A quiz application implementing the MVC (Model-View-Controller) architectural design pattern.**

## Technologies

- .NET 8.0
- Entity Framework Core
- ASP.NET Core
- SQL Server

## Architecture Overview

The MVC design pattern divides the solution into three components: the model, the view and the controller, with each component having its own responsibility and contributing to the overall functionality of the application, making the solution as modular as possible.

### **Model**

  The model component is implemeneted via repositories and services.
  
  Repositories are responsible for data access and manipulation. The context, aka the data, is accessed through the `QuizlyDbContext` class. Repositories stand between the context and the services.
  
  Services contain business logic and act as a gateway between repositories and controllers. For example, `GameService` is responsible for the core game logic. It also handles errors that could potentially occur while running the application by utilizing custom exceptions.

  In this solution, the model component consists of two repositories, one for the questions (`QuestionRepository`) and the other one for the players (`PlayerRepository`), along with three services: `GameService`, `QuestionService` and `PlayerService`. Each of these elements implement an interface, consequently supporting loose coupling and resulting in maintainable code.

### **View**
  
  The view component is whats actually presented to the client, in other words, the user interface, but is also responsible for sending data submitted by the user to controllers. Views receive view models, which play a fundamental role in displaying all the necessary data.

  In the current solution, the view component consists of views for the home (`Index` and `Privacy`), the game (`Quiz` and `Result`), the questions (`Questions` and `AddQuestion`) and the players (`Players` and `AddPlayer`), while also being responsible for displaying the general layout (`_Layout`) and visualizing errors (`Error`).
  
### **Controller**
  
  Lastly, the controller component is responsible for handling HTTP requests sent from the view, utilizing services to perform specific actions and catch exceptions, while also providing the view with view models. This component acts as a middleman between the model and the view.

  This solution utilizes a total of four controllers, `HomeController` being responsible for the home page and errors occurred, `GameController` displaying the actual quiz, `QuestionController` managing the questions and `PlayerController` managing the players.
  
## Database Schema

![QuizAppDatabaseSchema](https://github.com/meetandro/QuizApp/assets/132354578/cdcc8b81-4f67-4305-be66-3249594c7641)

## UI

| Home | Quiz | Result | Error |
|------|------|--------|-------|
| ![Home](https://github.com/user-attachments/assets/f46feb84-e7e2-43b5-bf04-7f2706e2c8b0) | ![Quiz](https://github.com/meetandro/QuizApp/assets/132354578/0339b3d9-6d71-4c9e-8c0e-a893474a8c16) | ![Result](https://github.com/meetandro/QuizApp/assets/132354578/8a772f27-1f6d-43d6-a02b-3c3f5905049f) | ![Error](https://github.com/meetandro/QuizApp/assets/132354578/9ad5c4aa-77c4-46fe-a8d0-4f23c42a5475) |

| Questions | Add Question | Players | Add Player |
|-----------|--------------|---------|------------|
| ![Questions](https://github.com/meetandro/QuizApp/assets/132354578/75a9cb07-5580-4ccc-97a7-6c58cd6ffd5f) | ![Add Question](https://github.com/meetandro/QuizApp/assets/132354578/0737fce9-21f5-4cea-b0cc-37694766f0d7) | ![Players](https://github.com/meetandro/QuizApp/assets/132354578/34e2d819-0f33-4434-a2ea-2c7bf1572061) | ![Add Player](https://github.com/meetandro/QuizApp/assets/132354578/8f73bb58-2278-43c9-ba22-06c0e01165ff) |

## Installation

To run the application locally, you'll need to have the [.NET SDK](https://dotnet.microsoft.com/en-us/download) and [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) installed beforehand, along with a database named `Quizly`.

- **Start by cloning the repository:**

  ```bash
  git clone https://github.com/meetandro/Quizly.git
  ```
  
  ```bash
  cd Quizly
  ```

  Alternatively, you can download the repository as a ZIP file and extract it.

- **Next, modify the server name in `appsettings.json`:**

  ```json
  "ConnectionStrings": {
    "QuizlyDb": "Server=localhost;Database=Quizly;Trusted_Connection=True;TrustServerCertificate=True"
  },
  ```
  
  Replace `localhost` with your server name, which you can get by executing the query in SQL Server:
  
  ```sql server
  SELECT @@SERVERNAME;
  ```

- **Finally, you can run the application locally on `localhost:7279`:**

  ```bash
  dotnet run
  ```
