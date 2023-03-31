/**
 * Both the Request Handler Library and the Unit of Work Library 
 * are developed by Mohammad Hafijur Rahman
 * This code is part of both the Request Handler Library and 
 * Unit of Work Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

using Autofac;
using Common;
using Common.Contract.Messaging;
using Core.DB;
using Core.DB.Mapper;
using Core.Handler.Landlord;
using Core.LIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            // Integrations



            // All mappers
            builder.RegisterType<OrganizationMapper>().As<IOrganizationMapper>();
            builder.RegisterType<UserMapper>().As<IUserMapper>();



            // All handlers
            builder.RegisterType<AddOrganizationHandler>().As<RequestHandler<AddOrganizationReq, AddOrganizationResp>>();
            builder.RegisterType<GetUserHandler>().As<RequestHandler<GetUserReq, GetUserResp>>();
        }
    }
}
