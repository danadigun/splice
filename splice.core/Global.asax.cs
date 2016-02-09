using splice.core.Repository.data;
using splice.core.Repository.data.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace splice.core
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();

            //initialize and create tables with unit of work
            new UnitOfWork(DataSource.sqlConnectionString);
        }

    }
}