# StudyPulse — Smart Student Planner

**Final Project — Introduction to Functional Programming**

**Developed by:** Matiullah Zaman  
**University:** Astana IT University (AITU)  
**Project Type:** Individual Final Project  
**Programming Language:** C#  
**Framework:** .NET 10 / ASP.NET Core Blazor

---

## 1. Project Overview

StudyPulse is an interactive web application designed to help university students organize assignments, manage deadlines, create personalized study schedules, and track academic progress.

The application uses C# and Functional Programming principles to process assignments, calculate urgency scores, and recommend which tasks students should complete first.

StudyPulse provides a simple, modern, and user-friendly interface to help students improve their study organization and time management.

## 2. Project Objectives

The main objectives of StudyPulse are:

- Develop an interactive web application using C# and Blazor.
- Implement assignment creation, editing, deletion, and completion.
- Apply Functional Programming principles to task processing.
- Create an urgency-based assignment recommendation system.
- Generate personalized study schedules.
- Track academic progress using analytics.
- Provide deadline reminders.
- Save assignment data persistently.
- Validate core functionality using automated unit tests.

## 3. Main Features

### Dashboard

Displays an overview of academic activities, including:

- Total assignments
- Completed and pending assignments
- Overall completion percentage
- Upcoming deadlines
- High-priority tasks
- Smart study recommendations

### Assignment Management

Students can:

- Add new assignments
- Edit existing assignments
- Delete assignments
- Mark assignments as completed
- Set deadlines and priorities
- Add subjects and descriptions
- Estimate required study time
- Search, filter, and sort assignments

### Smart Study Planner

The planner automatically recommends assignments based on their deadlines, priorities, and estimated workload.

Students can enter their available study hours and preferred session duration to generate a personalized study schedule.

### Study Analytics

Provides information about:

- Assignment completion percentage
- Completed and pending tasks
- Task distribution by priority
- Subject performance
- Estimated remaining study hours
- Upcoming deadlines

### Reminders and Deadlines

Helps students identify:

- Overdue assignments
- Assignments due today
- Upcoming deadlines

Reminders are displayed inside the application.

### Settings

Allows students to customize:

- Student profile information
- Daily study hours
- Preferred study session duration
- Default assignment priority
- Reminder preferences
- Light and dark themes

## 4. Technologies Used

| Technology | Purpose |
|---|---|
| C# | Main programming language |
| .NET 10 | Application platform |
| ASP.NET Core Blazor | Interactive web interface |
| LINQ | Filtering, sorting, and processing data |
| HTML | Web page structure |
| CSS | Styling and responsive design |
| Bootstrap | Interface components and layouts |
| JavaScript | Theme and browser settings |
| System.Text.Json | JSON serialization and storage |
| xUnit | Automated unit testing |
| Visual Studio Code | Development environment |

## 5. Functional Programming Implementation

StudyPulse demonstrates Functional Programming concepts through the `PlannerEngine.cs` service.

### Pure Functions

Calculation methods use explicit inputs to produce predictable results without modifying the supplied task objects.

Examples include:

- `CompletionPercentage()`
- `PriorityValue()`
- `UrgencyScore()`

### Lambda Expressions

Lambda expressions are used to filter, transform, and organize assignments.

```csharp
task => !task.IsCompleted
```

### Higher-Order Functions

Functions that accept other functions as parameters.

Implemented methods:

- `FilterTasks()`
- `MapTasks()`

### Function Composition

The `Compose()` method combines smaller functions into a single transformation.

### Pipelines

The `Pipe()` method passes a value through a transformation function.

### Immutable Transformations

The `WithCompletion()` method creates a new task object with an updated completion status without modifying the original task.

### Aggregation

The `AggregateTasks()` method uses a reducer function to combine task values.

### LINQ

LINQ methods such as `Where()`, `Select()`, `Sum()`, `Count()`, and `OrderByDescending()` support functional-style data processing.

**Note:** StudyPulse combines Functional Programming techniques with conventional C# application development.

## 6. Smart Recommendation Algorithm

StudyPulse uses an urgency-based recommendation algorithm to help students decide which assignments to complete first.

The algorithm considers:

1. **Deadline:** How soon an assignment must be completed.
2. **Priority:** High, Medium, or Low.
3. **Estimated Workload:** The approximate time required.

The application calculates an urgency score, ranks incomplete assignments, and uses the results to support study planning.

The planner also considers the student's available daily study hours and preferred study session duration.

This is a rule-based recommendation algorithm, not a machine-learning system.

## 7. Project Structure

```text
StudyPulse/
├── App_Data/
│   └── assignments.json
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   ├── Models/
│   │   ├── StudyTask.cs
│   │   └── services/
│   │       ├── PlannerEngine.cs
│   │       └── TaskStore.cs
│   ├── Pages/
│   │   ├── Home.razor
│   │   ├── Tasks.razor
│   │   ├── Planner.razor
│   │   ├── Analytics.razor
│   │   ├── Reminders.razor
│   │   └── Settings.razor
│   ├── App.razor
│   └── Routes.razor
├── wwwroot/
│   ├── js/
│   │   └── studyPulseSettings.js
│   ├── lib/
│   └── app.css
├── Program.cs
├── appsettings.json
├── StudyPulse.csproj
└── README.md
```

The automated test project, `StudyPulse.Tests`, is stored separately from the main application directory.

## 8. Installation and Running Instructions

### Requirements

- .NET 10 SDK
- Visual Studio Code or another compatible IDE
- A modern web browser

### Step 1 — Open the Project

Open the `StudyPulse` folder in Visual Studio Code.

### Step 2 — Open the Terminal

Open the integrated terminal.

### Step 3 — Restore Dependencies

```bash
dotnet restore
```

### Step 4 — Build the Project

```bash
dotnet build
```

### Step 5 — Run the Application

```bash
dotnet run
```

### Step 6 — Open StudyPulse

Open the local address displayed in the terminal.

For the tested development configuration:

```text
http://localhost:5025
```

The application should now be available in your browser.

To stop the application, press `Ctrl + C` in the terminal.

## 9. Data Storage

StudyPulse uses JSON file storage to save assignments.

The `TaskStore.cs` service manages the following operations:

- `GetAll()` — Reads saved assignments.
- `Add()` — Adds a new assignment.
- `Update()` — Updates an existing assignment.
- `Delete()` — Removes an assignment.
- `Save()` — Serializes and writes assignments to JSON.

Assignment data is stored in:

```text
App_Data/assignments.json
```

This allows assignments to remain available after restarting the application.

The service uses `lock` to coordinate operations within the same `TaskStore` instance.

## 10. Automated Testing

StudyPulse uses the **xUnit** testing framework to verify core Functional Programming methods.

### Test Results

| Result | Count |
|---|---:|
| Total Tests | 13 |
| Passed | 13 |
| Failed | 0 |
| Skipped | 0 |

The tests verify:

- Completion percentage calculations
- Empty task handling
- Overdue assignment detection
- Upcoming deadline detection
- Priority value calculations
- Study-time conversion
- Task recommendation and sorting
- Exclusion of completed tasks
- Immutable task transformations
- Higher-order filtering
- Task title transformations
- Aggregation

### Running the Tests

Open the `StudyPulse.Tests` directory in a terminal and execute:

```bash
dotnet test
```

All 13 tests passed during development.

## 11. Application Architecture

StudyPulse separates responsibilities into three main areas:

**Model Layer**

`StudyTask.cs` defines assignment information such as title, subject, deadline, priority, estimated study time, and completion status.

**Service Layer**

`PlannerEngine.cs` performs calculations, Functional Programming transformations, and task recommendations.

`TaskStore.cs` handles persistent assignment storage.

**Presentation Layer**

Blazor `.razor` components display information and allow users to interact with the application.

This separation makes the code easier to understand, maintain, and test.

## 12. How to Use StudyPulse

1. Start the application.
2. Open **My Tasks**.
3. Create an assignment with a title, subject, deadline, priority, and estimated study time.
4. Open **Smart Study Planner**.
5. Enter available daily study hours and preferred session duration.
6. Click **Generate Study Plan**.
7. Review the recommended assignments and generated schedule.
8. Mark assignments as completed after finishing them.
9. Open **Analytics** to track academic progress.
10. Use **Reminders** to check upcoming deadlines.

## 13. Future Improvements

Potential future improvements include:

- User authentication
- Individual student accounts
- Email and push notifications
- Calendar integration
- Cloud database storage
- Advanced scheduling algorithms
- More extensive automated testing

## 14. Conclusion

StudyPulse demonstrates the practical application of C# and Functional Programming principles in a student productivity application.

The project combines assignment management, smart task recommendations, personalized study planning, academic analytics, persistent data storage, and automated testing.

The goal of StudyPulse is to help students stay organized, manage their study time effectively, and make better academic planning decisions.

---

## Author

**Matiullah Zaman**  
Astana IT University (AITU)  
Introduction to Functional Programming  
Individual Final Project — 2026

**Project:** StudyPulse — Smart Student Planner
