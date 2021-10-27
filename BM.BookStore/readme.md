
## Dependency Injection
> (DI) is a pattern that can help developers decouple the different pieces of their applications.

_"Loose Coupling & High Cohesion is the Mantra for maintainability"_

### First things first, Similar but not same?
Before exploring what .NET provides to manage _dependencies_, let's understand some of the terminologies as they sound similar but could be different

-   **Dependency Inversion Principle** (DIP): **Concept** It states that _high level modules should not depend on low level modules; both should depend on abstractions._
    
-   **Inversion of Control** (IoC): **Approach** this is a way to apply the Dependency Inversion Principle. Inversion of Control is the actual mechanism that allows your higher-level components to depend on abstraction rather than the concrete implementation of lower-level components.
    
    Inversion of Control is also known as the **_Hollywood Principle_**. This name comes from the Hollywood cinema industry, where, after an audition for an actor role, usually the director says, **_don't call us, we'll call you_**.
    
-   **Dependency Injection**: **Design Pattern** this is a design pattern to implement Inversion of Control. It allows you to inject the concrete implementation of a low-level component into a high-level component.
    
-   **IoC Container**: **One of the examples,** also known as Dependency Injection (DI) Container, is a programming framework that provides you with an automatic Dependency Injection of your components.
    

ASP.NET Core supports the dependency injection (DI) software design pattern **out of the box**, which is a technique for achieving [Inversion of Control (IoC)](https://docs.microsoft.com/en-us/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#dependency-inversion) between classes and their dependencies.

Prior to .[Net Core](https://stackify.com/net-core-2-0-changes/), the only way to get DI in your applications was through the use of a framework such as [Autofac](https://autofac.org), [Ninject](http://www.ninject.org), [StructureMap](https://structuremap.github.io) and [many others.](https://github.com/danielpalme/IocPerformance) However, DI is treated as a [first-class citizen](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection) in ASP.Net Core. You can configure your container in your _Startup.ConfigureServices_ method
