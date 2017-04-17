using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using UnityLearnning;
using UnityLearnning.intf;
using UnityLearnning.impl;
using System.Configuration;
using System.IO;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace UnityWeb.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            //var container = new UnityContainer();
            //RegisterTypes(container);
            //return container;
            RegisterTypes(UContainer.Instanst);
            return UContainer.Instanst;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            //container.RegisterType<IUnityOfWork, UnityOfWork>(new PerRequestLifetimeManager());
            //container.RegisterType<IEmpService, EmpService>(new PerRequestLifetimeManager());


            //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap()
            //{
            //    ExeConfigFilename = System.AppDomain.CurrentDomain.BaseDirectory + "unity.config"
            //};
            //Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            //UnityConfigurationSection unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
            //container.LoadConfiguration(unitySection, "mvcContainer");

            container.AddNewExtension<Interception>();
            container.RegisterType<IUnityOfWork, UnityOfWork>(new PerRequestLifetimeManager());
            //加入拦截器，则在Resolve时，相当于每次生成一次对象，此时对象hashcode是不一致的。
            //但，使用Resolve对象执行方法时，unity拦截器会重新按设定的规则生成执行对象，然后使用该对象执行方法。
            //则Resolve对象与执行方法对象是不一致的。
            container.RegisterType<IEmpService, EmpService>(new PerRequestLifetimeManager(),new Interceptor<InterfaceInterceptor>(),new InterceptionBehavior<LoggingInterceptionBehavior>());
            //container.RegisterType<IEmpService, EmpService>(new ContainerControlledLifetimeManager(), new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>());

        }
    }
}
