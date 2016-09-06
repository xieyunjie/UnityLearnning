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

    }
}
