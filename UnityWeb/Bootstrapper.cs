using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace UnityWeb
{
    public static class Bootstrapper
    {
        //private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        //{
        //    var container = new UnityContainer();
        //    var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
        //    container.LoadConfiguration(section);
        //    return container;
        //});

        //public static IUnityContainer Initialize()
        //{
        //    var container = GetConfiguredContainer();
        //    DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        //    var resolver = new UnityDependencyResolver(GetConfiguredContainer());
        //    GlobalConfiguration.Configuration.DependencyResolver = resolver;

        //    return container;
        //}

        //public static IUnityContainer GetConfiguredContainer()
        //{
        //    return container.Value;
        //}
    }
}