using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UnityLearnning;
using UnityLearnning.impl;
using UnityLearnning.intf;

namespace UnityWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles); 

            //UContainer.Instanst.RegisterType<IUnityOfWork, UnityOfWork>(new PerThreadLifetimeManager()); 
            //UContainer.Instanst.RegisterType<IEmpService, EmpService>(new PerThreadLifetimeManager());

            //Bootstrapper.Initialize();
        }
    }
}
