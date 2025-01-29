/**
 * Both the Request Handler Library and the Unit of Work Library 
 * are developed by Mohammad Hafijur Rahman
 * This code is part of both the Request Handler Library and 
 * Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

using Autofac;
using AutoMapper;
using Common;
using Common.Contract.Messaging;
using Core.DB;
using Core.Handler.Car;
using Core.Handler.User;
using Core.LIB;

namespace Core.IoC
{
    public class CoreContainer
    {
        public static void Bind(ContainerBuilder builder)
        {
            // LIB (request handler library)
            builder.RegisterType<ResponseFactory>().As<IResponseFactory>();
            builder.RegisterType<HandlerCaller>().As<IHandlerCaller>();
            builder.RegisterType<RequestHandlerFactory>().As<IRequestHandlerFactory>();


            // CoreService
            builder.RegisterType<CoreService>().As<ICoreService>();


            // DB
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>();
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();
            builder.RegisterType<LogicFactory>().As<ILogicFactory>();
            builder.RegisterType<MapperFactory>().As<IMapperFactory>();


            // AutoMapper
            builder.Register(c =>
            {
                // Create AutoMapper configuration
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfile()); // Add your AutoMapper profiles here
                });

                // Create IMapper instance using the configuration
                return configuration.CreateMapper();
            }).As<IMapper>().SingleInstance(); // Register as a singleton since IMapper is usually reused.


            // Integrations


            // All handlers
            builder.RegisterType<GetUserHandler>().As<RequestHandler<GetUserReq, GetUserResp>>(); 
            builder.RegisterType<AddCarHandler>().As<RequestHandler<AddCarReq, AddCarResp>>();
            builder.RegisterType<GetAllCarHandler>().As<RequestHandler<GetAllCarReq, GetAllCarResp>>();
        }
    }
}
