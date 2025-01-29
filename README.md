# dotnetcore_startup_with_efcore
This is startup project for dotnet core 6. Following features are ready - 
- Request Handler using Mediator pattern
- Unit Of Work pattern with Entity Framework Core.
- Repository pattern
- Logic for manaing multiple repositories
- Linq quearyable extension to make paging and sorting easy.
- Automapper for mapping DB models to contracts.
- Autofac for dependency injection


## Conceptual Model
Any request from a service (i.e., CoreSerivce - derived from ServiceBase) is handled by HandlerCaller. The HandlerCaller has the responsibility to process a request by finding a RequestHandler from the RequestHandlerFactory. The HandlerCaller then responses to that request from the ResponseFactory. 
Each RquestHandler creates a unitOfWork from the UnitOfWorkFactory to further process the request and interact with the database.
<img src="concept.jpg" />


## How to populate database
 - Go to package manager console 
 - Set the core project as default
 - Run ``` Add-Migration ``` and provide a version name
 - Run ``` Update-Database ```
 
