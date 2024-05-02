# QuizApp

**A quiz application implementing the MVC (Model-View-Controller) architectural design pattern.**

## Technologies

- .NET 8.0
- Entity Framework Core
- ASP.NET Core
- SQL Server

## Overview

The MVC design pattern divides the application into three layers: the model, the view and the controller. Each layer has its own responsibility and contributes to the overall functionality of the application, making the solution as modular as possible.

* **Model**

  The model layer consists of repositories and services.
  
  Repositories are responsible for data access and manipulation. The context, aka the data, is accessed via the `QuizAppDbContext` class. Repositories stand between the context and the services.
  
  Services contain business logic and act as a gateway between repositories and controllers. For example, `GameService`, which implements the `IGameService` interface, is responsible for the core game logic. It also handles errors that could potentially occur while playing by utilizing custom exceptions.

  In the current solution, the model layer consists of two repositories, one for questions (`QuestionRepository`) and the other one for players (`PlayrRepository`), alongside with three services: `GameService`, `QuestionService` and `PlayerService`. Each of these components implement an interface which helps create more loose and maintainable code.

* **View**
  
  The view layer is whats actually presented to the client, in other words, the user interface, but is also responsible for sending data submitted by the user to controllers. Views receive view models, which play a fundamental role in displaying the necessary data.

  In this solution, the layer consists of pages for the home, the game, the questions and the players.
  
* **Controller**
  
  Lastly, the controller layer is responsible for handling HTTP requests sent from the view, utilizing services to perform specific actions while also providing the view with view models. This layer acts as a middleman between the model and the view.
  
## Database Schema

![QuizAppDatabaseSchema](https://github.com/meetandro/QuizApp/assets/132354578/cdcc8b81-4f67-4305-be66-3249594c7641)

## UI

![QuizAppHome](https://github.com/meetandro/QuizApp/assets/132354578/8752e701-4212-4719-ae79-5a001c85b940)

## Installation

To run the application locally, you'll need to have the [.NET SDK](https://dotnet.microsoft.com/en-us/download) and [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) installed beforehand, alongside with a database named `QuizApp`.

* **Start by cloning the repository:**

  ```bash
  $ git clone https://github.com/meetandro/QuizApp.git
  ```
  
  ```bash
  $ cd QuizApp
  ```

  Alternatively, you can download the repository as a ZIP file and extract it.

* **Next, modify the server name in `appsettings.json`:**

  ```json
  "ConnectionStrings": {
    "QuizAppDb": "Server=localhost;Database=QuizApp;Trusted_Connection=True;TrustServerCertificate=True"
  },
  ```
  
  Replace `localhost` with your server name, which you can get by executing the query in SQL Server:
  
  ```sql server
  SELECT @@SERVERNAME;
  ```
  
  The server name may vary depending on the instance of your SQL Server. For example, if you're using the express version, you'll need to input the following:
  
  ```json
  "ConnectionStrings": {
    "QuizAppDb": "Server=localhost\\SQLEXPRESS;Database=QuizApp;Trusted_Connection=True;TrustServerCertificate=True"
  },
  ```

* **Finally, you can run the application:**

  ```bash
  $ dotnet run
  ```

  The application will run locally on `localhost:7279`.
