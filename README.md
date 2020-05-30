# Typical Southern Foods
Typical Southern Foods is a sample application built using ASP.NET, Oracle 18c Database and Entity Framework.

## Philosophy of Javier Cañon

* KISS by design and programming. An acronym for "keep it simple, stupid" or "keep it stupid simple", is a design principle. The KISS principle states that most systems work best if they are kept simple rather than made complicated; therefore, simplicity should be a key goal in design, and unnecessary complexity should be avoided. Variations on the phrase include: "Keep it simple, silly", "keep it short and simple", "keep it simple and straightforward", "keep it small and simple", or "keep it stupid simple".
* Select the best tools for the job, use tools that take less time to finish the job.
* Productivity over complexity and avoid unnecessary complexity for elegant or beauty code.
* Computers are machines, more powerful every year, give them hard work, concentrate on being productive.
* Often people, especially computer engineers, focus on the machines. They think, "By doing this, the machine will run fast. By doing this, the machine will run more effectively. By doing this, the machine will something, something, something..." They are focusing on machines. But in fact we need to focus on humans, on how humans care about doing programming or operating the application of the machines. We are the masters. They are the slaves. [Yukihiro Matsumoto].

## Features

✅ HTML5 JavaScript Responsive Web Development
✅ MVC  

### Clean Architecture

✅ **Application Layer**: This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

✅ **Common Layer**: This will contain all cross-cutting concerns.

✅ **Domain Layer**: This will contain all entities, enums, exceptions, types and logic specific to the domain. The Entity Framework related classes are abstract, and should be considered in the same light as .NET. For testing, use an InMemory provider such as InMemory or SqlLite.

✅ **Infrastructure Layer**: This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

✅ **Persistence Layer**: When you use relational databases such as SQL Server, Oracle, or PostgreSQL, a recommended approach is to implement the persistence layer based on Entity Framework (EF). EF supports LINQ and provides strongly typed objects for your model, as well as simplified persistence into your database.

✅ **UI Layer's**: MVC software design pattern. Commonly used for developing user interfaces which divides the related program logic into three interconnected elements. This is done to separate internal representations of information from the ways information is presented to and accepted from the user. This kind of pattern is used for designing the layout of the page.

## Screenshoots

## Getting Started

Use these instructions to get the project up and running.

### Prerequisites

You will need the following tools:

* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (version 16.6 or later)
* [.NET 4.8](https://dotnet.microsoft.com/download)
* [DevExpress 20.1.3](https://www.devexpress.com/)
* [Oracle Database Server](https://www.oracle.com/downloads/)
* [Oracle Data Access Components - .NET](https://www.oracle.com/database/technologies/net-downloads.html)

### Setup
Follow these steps to get your development environment set up:

1.   Install Oracle Database Server if needed
2.   Install Oracle Data Access Components for .NET
3.   Install DevExpress Framework id needed
4.   From Visual Studio, [restore NuGet packages](https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore-troubleshooting)
5.   Build and run.

## Technologies

* .NET 4.8
* ASP.NET MVC 5 
* Razor 3
* Blazor .NET Core 3.1
* ASP.NET 4.8 Webforms
* Entity Framework 6
* Oracle RDBMS 18c
* Bootstrap 4
* JQuery 3.5
* HTML5


## License

This project is licensed under the MIT LICENSE - see the [LICENSE.md](/LICENSE.md) file for details.

---
Made with ❤️ by **[Javier Cañon](https://javiercanon.com)**.
