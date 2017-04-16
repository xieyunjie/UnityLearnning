using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using UnityLearnning.impl;
using UnityLearnning.intf;

namespace UnityLearnning
{
    public  class UnityCls
    {

        public static void TransientLifetimeManager()
        {
            UContainer.Instanst.RegisterType<IUnityOfWork, UnityOfWork>(new TransientLifetimeManager());
            UContainer.Instanst.RegisterType<IEmpDao, EmpDao>(new TransientLifetimeManager());
            UContainer.Instanst.RegisterType<IEmpService, EmpService>(new ContainerControlledLifetimeManager());


            Console.WriteLine(UContainer.Instanst.Resolve<IEmpService>().GetHashCode());
            Console.WriteLine(UContainer.Instanst.Resolve<IEmpService>().GetHashCode());
            UContainer.Instanst.Resolve<IEmpService>().IncreaseValue();

            var empService = UContainer.Instanst.Resolve<IEmpService>();
            empService.printUnityOfWork();
            empService.IncreaseValue();
            empService.printValue();

            UContainer.Instanst.Resolve<IEmpService>().printUnityOfWork();
            UContainer.Instanst.Resolve<IEmpService>().IncreaseValue();
            UContainer.Instanst.Resolve<IEmpService>().printValue();

            Console.WriteLine(UContainer.Instanst.Resolve<IEmpDao>().GetHashCode());
            Console.WriteLine(UContainer.Instanst.Resolve<IEmpDao>().GetHashCode());

            Console.WriteLine(UContainer.Instanst.Resolve<IUnityOfWork>().GetHashCode());
            Console.WriteLine(UContainer.Instanst.Resolve<IUnityOfWork>().GetHashCode());

        }

        public static void PerThreadLifetimeManager()
        {
            UContainer.Instanst.RegisterType<IUnityOfWork, UnityOfWork>(new PerThreadLifetimeManager());
            UContainer.Instanst.RegisterType<IEmpDao, EmpDao>(new PerThreadLifetimeManager());
            UContainer.Instanst.RegisterType<IEmpService, EmpService>(new PerThreadLifetimeManager());

            Console.WriteLine("EmpS hascode:" + UContainer.Instanst.Resolve<IEmpService>().GetHashCode());

            var empService = UContainer.Instanst.Resolve<IEmpService>();
            empService.printUnityOfWork();
            UContainer.Instanst.Resolve<IEmpService>().IncreaseValue();
            UContainer.Instanst.Resolve<IEmpService>().printValue();

            UContainer.Instanst.Resolve<IEmpService>().printUnityOfWork();

            Console.WriteLine("EmpD hascode:" + UContainer.Instanst.Resolve<IEmpDao>().GetHashCode());

            Console.WriteLine("UnityOfWork hascode:" + UContainer.Instanst.Resolve<IUnityOfWork>().GetHashCode());



            var thread = new Thread(new ThreadStart(Sub_Thread));
            thread.Start();
        }


        public static void Sub_Thread()
        {
            Console.WriteLine("Sub s ## " + UContainer.Instanst.Resolve<IEmpService>().GetHashCode());

            var empService = UContainer.Instanst.Resolve<IEmpService>();
            empService.printUnityOfWork();
            empService.IncreaseValue();
            empService.printValue();

            UContainer.Instanst.Resolve<IEmpService>().printUnityOfWork();

            Console.WriteLine("Sub d ## " + UContainer.Instanst.Resolve<IEmpDao>().GetHashCode());

            Console.WriteLine("Sub u ## " + UContainer.Instanst.Resolve<IUnityOfWork>().GetHashCode());
        }

        public static void PreThreadMixSingleton()
        {
            UContainer.Instanst.RegisterType<IEmpTowService, EmpTowService>(new ContainerControlledLifetimeManager());
            UContainer.Instanst.RegisterType<IUnityOfWork, UnityOfWork>(new PerThreadLifetimeManager());

            var empService = UContainer.Instanst.Resolve<IEmpTowService>();

            Console.WriteLine("EmpS hascode:" + empService.GetHashCode());
            Console.WriteLine("UnityOfWork hascode:" + UContainer.Instanst.Resolve<IUnityOfWork>().GetHashCode());

            empService.printUnityOfWork();
             
            var thread = new Thread(new ThreadStart(Sub_Mix));
            thread.Start();

        }

        public static void SingletonMixTransient()
        {
            UContainer.Instanst.RegisterType<IEmpTowService, EmpTowService>(new PerResolveLifetimeManager());
            UContainer.Instanst.RegisterType<IUnityOfWork, UnityOfWork>(new PerResolveLifetimeManager());

            var empService = UContainer.Instanst.Resolve<IEmpTowService>(); 

            Console.WriteLine("EmpS hascode:" + empService.GetHashCode()); 
            Console.WriteLine("UnityOfWork hascode:" + UContainer.Instanst.Resolve<IUnityOfWork>().GetHashCode());

            empService.printUnityOfWork();
             
            var thread = new Thread(new ThreadStart(Sub_Mix));
            thread.Start(); 
        }

        public static void SingletonMixTransient2()
        {
            UContainer.Instanst.RegisterType<IEmpTowService, EmpTowService>(new PerThreadLifetimeManager()); 
            UContainer.Instanst.RegisterType<IEmpThreeService, EmpThreeService>(new PerThreadLifetimeManager());
            UContainer.Instanst.RegisterType<IUnityOfWork, UnityOfWork>(new TransientLifetimeManager());

            var empService = UContainer.Instanst.Resolve<IEmpTowService>();

            Console.WriteLine("EmpS hascode:" + empService.GetHashCode()); 
            var empThreeService = UContainer.Instanst.Resolve<IEmpThreeService>();
            Console.WriteLine("EmpT hascode:" + empThreeService.GetHashCode());

            Console.WriteLine("UnityOfWork hascode:" + UContainer.Instanst.Resolve<IUnityOfWork>().GetHashCode());

            empService.printUnityOfWork();
            empThreeService.printUnityOfWork();

            var thread = new Thread(new ThreadStart(Sub_Mix));
            thread.Start();
        }

        private static void Sub_Mix()
        {
            var empService = UContainer.Instanst.Resolve<IEmpTowService>();

            Console.WriteLine("Sub EmpS hascode:" + empService.GetHashCode());
            Console.WriteLine("Sub UnityOfWork hascode:" + UContainer.Instanst.Resolve<IUnityOfWork>().GetHashCode());

            empService.printUnityOfWork();
        }
    }
}
