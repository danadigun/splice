using Funq;
using ServiceStack.Configuration;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.OrmLite;
using splice.core.Repository.data.DataSource;
using ServiceStack.ServiceInterface;
using System.Configuration;

namespace splice.core
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("Splice.core", typeof(SpliceServices).Assembly) { }
        public override void Configure(Container container)
        {
            SetConfig(new EndpointHostConfig { ServiceStackHandlerFactoryPath = "api.ashx" });

            //------Configure Authentication API-------//
            var appSettings = new AppSettings();

            //Default route: /auth/{provider}
            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                new IAuthProvider[] {
                        new CredentialsAuthProvider(appSettings), 
                        new FacebookAuthProvider(appSettings), 
                        new TwitterAuthProvider(appSettings), 
                        new BasicAuthProvider(appSettings),                    

                    }));

            //Default route: /register
            Plugins.Add(new RegistrationFeature());

            //Requires ConnectionString configured in Web.Config
            var connectionString = ConfigurationManager.ConnectionStrings["SpliceDb"].ConnectionString;
            //var connectionString = DataSource.sqlConnectionString;

            //---NOTE: Install ServiceStack.OrmLite.SqlServer for this to always work.
            container.Register<IDbConnectionFactory>(c =>
               new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider));

            container.Register<IUserAuthRepository>(c =>
                new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

            var authRepo = (OrmLiteAuthRepository)container.Resolve<IUserAuthRepository>();


            //Run this Only once
            //authRepo.DropAndReCreateTables();
            authRepo.CreateMissingTables();

            if (authRepo.GetUserAuthByUserName("daniel.adigun@digitalforte.ng") == null)
            {
                var userAuth = new UserAuth
                {
                    UserName = null,
                    Email = "daniel.adigun@digitalforte.ng",
                    FirstName = "Administrator",
                    LastName = " ",
                    RefId = new Random().Next(),
                    Roles = new List<string> { "Admin" }
                };
                authRepo.CreateUserAuth(userAuth, "pass");
            }
            

        }
    }
}