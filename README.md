# QuizApp

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
  
  Repositories are responsible for data access and manipulation. The context, aka the data, is accessed through the `QuizAppDbContext` class. Repositories stand between the context and the services.
  
  Services contain business logic and act as a gateway between repositories and controllers. For example, `GameService` is responsible for the core game logic. It also handles errors that could potentially occur while playing by utilizing custom exceptions.

  In this solution, the model component consists of two repositories, one for questions (`QuestionRepository`) and the other one for players (`PlayerRepository`), alongside with three services: `GameService`, `QuestionService` and `PlayerService`. Each of these elements implement an interface, consequently supporting loose coupling and resulting in maintainable code.

### **View**
  
  The view component is whats actually presented to the client, in other words, the user interface, but is also responsible for sending data submitted by the user to controllers. Views receive view models, which play a fundamental role in displaying all the necessary data.

  In the current solution, the view component consists of pages for the home (home page and privacy policy), the game (quiz and results), the questions (adding and displaying the questions) and the players (adding and displaying the players), while also being responsible for displaying the general layout and visualizing errors.
  
### **Controller**
  
  Lastly, the controller component is responsible for handling HTTP requests sent from the view, utilizing services to perform specific actions and catching exceptions, while also providing the view with view models. This layer acts as a middleman between the model and the view.

  This solution utilizes a total of four controllers, `HomeController` being responsible for the home page and occured errors, `GameController` displaying the actual quiz, `QuestionController` managing the questions and `PlayerController` managing the players.
  
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
