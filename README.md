#   Technical Test: 

The objective of this technical test is to assess your technical capabilities in designing and implementing an API using the .NET language, connecting to a database using Entity Framework, following a Domain-Driven Design (DDD) architecture, test-driven development (TDD), and documentation using OpenAPI/Swagger.

## Problem Description

You are required to build an API to manage a to-do list application. The API should allow users to create, update, and delete tasks, as well as get a list of tasks and mark them as completed.

The API should follow a DDD-based architecture, dividing the application into well-defined logical layers such as domain, application, and presentation. The TDD approach should be used to guide the coding, writing unit tests before implementing the functionality.

##  Technical Requirements

    1. Use the .NET language version 6 or higher to implement the API.
    2. Connect the API to a database using Entity Framework to perform CRUD operations related to tasks. You can choose a database compatible with Entity Framework, such as SQL Server or PostgreSQL.
    3. Design the application architecture following DDD principles, separating the layers of domain, application, and presentation. Use appropriate design patterns for each layer.
    4. Use the TDD approach to guide the implementation of the API. Write unit tests before implementing each functionality. The tests should cover main use cases and error cases.
    5. Document the API using OpenAPI/Swagger. Generate documentation automatically from the API source code and ensure it is up-to-date and accurate.

##  Required Functionalities

The API should support the following operations:

    1. Create a task: Allow users to create a new task by providing a title and a description. The created task should have an initial state such as "pending" or similar.
    2. Update a task: Allow users to update the title, description, and/or state of an existing task. Updating only pending tasks is allowed.
    3. Delete a task: Allow users to delete an existing task. Deleting only pending tasks is allowed.
    4. Get a list of tasks: Allow users to get a list of all available tasks, including their title, description, and state.
    5. Mark a task as completed: Allow users to mark a task as completed, changing its state to "completed" or similar.

##  Deliverables

You must provide the complete source code of the API, including unit tests, the necessary configuration for the database connection, and the documentation generated by Swagger.

##  Evaluation

You will be evaluated based on the following criteria:

    1. Design and structure of the API, including adherence to DDD principles.
    2. Correct implementation of the required functionalities.
    3. Adequate test coverage using TDD.
    4. Successful database connection and correct usage of Entity Framework.
    5. Complete and accurate documentation generated by Swagger.

> Good luck! I hope you enjoy designing and building your API with FastAPI.