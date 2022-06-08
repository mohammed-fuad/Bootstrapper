# Bootstrapper.Extensions.Microsoft.DependencyInjection
Is .net standard library as a solution to bootstrap implementations and register them into `Dependency Injection Container`.

## Installation

```powershell
PM > Install-Package Bootstrapper.Extensions.Microsoft.DependencyInjection
```

## How to Use?
In order to use the package you need to have implementation of `IBootstrapper` inside your project:

````c#
internal class TestBootstrapper : IBootstrapper
{
    /// <inheritdoc/>
    public IServiceCollection Initialize(IServiceCollection collection, IConfiguration configuration)
    {
        // ...
        // Register Transient, Scoped, or Singleton implementations.    
        // ...  

        return services;
    }
}
````


## Integrated in Asp.Net Core

There are two options to bootstrap inside Program.cs:

2. Automatic scanning for calling assembly:

```c#
using System.Reflection;
using Bootstrapper.Extensions.Microsoft.DependencyInjection;

//....

var builder = WebApplication.CreateBuilder(args);
//....
builder.Services.Bootstrap(builder.Configuration);
//....
```


2. Using selective assemblies:

```c#
using System.Reflection;
using Bootstrapper.Extensions.Microsoft.DependencyInjection;

//....

var builder = WebApplication.CreateBuilder(args);
//....
builder.Services.Bootstrap(builder.Configuration, typeof(ClassA).Assemlby, typeof(ClassB).Assemlby);
//....
```
