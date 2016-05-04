using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Splice.BusinessLogic.Impl;
using Splice.BusinessLogic.Interface;
using Splice.Repository.Impl;
using Splice.Repository.Interface;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Splice.Web.Api.App_Start
{
    public class ServiceActivator : IHttpControllerActivator
    {
        public ServiceActivator(HttpConfiguration configuration) { }

        public IHttpController Create(HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = ObjectFactory.Container.GetInstance(controllerType) as IHttpController;
            return controller;
        }
    }
    public static class ObjectFactory
    {
        public static ISessionFactory SessionFactory
        {
            get;
            private set;
        }
        public static ISession GetSession(IContext context)
        {
            ISessionFactory factory = context.GetInstance<ISessionFactory>();
            ISession session = null;
            if (HttpContext.Current != null)
            {
                if (NHibernate.Context.CurrentSessionContext.HasBind(factory))
                    return factory.GetCurrentSession();
                session = factory.OpenSession();
                NHibernate.Context.CurrentSessionContext.Bind(session);
            }
            else
            {
                session = factory.OpenSession();
            }
            return session;
        }
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(ConfigurationManager.ConnectionStrings["SpliceDb"].ConnectionString))
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Splice.Persistence.Nhibernate.Mapping.StockMap>())
                .Cache(x => x.Not.UseQueryCache())
                .BuildSessionFactory();
        }
        private static readonly Lazy<StructureMap.Container> _containerBuilder =
            new Lazy<StructureMap.Container>(DefaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static StructureMap.IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static StructureMap.Container DefaultContainer()
        {
            return new Container(x =>
            {
                x.For<ISessionFactory>().Singleton().Use(CreateSessionFactory());
                x.For<ISession>().Singleton().Use(context => GetSession(context));
                x.For<IStockHelper>().Use<StockHelper>();
                x.For<IExpenseHelper>().Use<ExpenseHelper>();
                x.For<ITransactionHelper>().Use<TransactionHelper>();
                x.For(typeof(IRepository<>)).Use(typeof(Repository<>));
            });           
        }
    }
}