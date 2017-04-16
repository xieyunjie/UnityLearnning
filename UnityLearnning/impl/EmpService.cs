using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityLearnning.intf;
using Microsoft.Practices.Unity;

namespace UnityLearnning.impl
{
    public class EmpService : IEmpService
    {
        private IUnityOfWork _unityOfWork;

        public EmpService()
        {
            this._unityOfWork = UContainer.Instanst.Resolve<IUnityOfWork>();
        }

        public void printUnityOfWork()
        {
            Console.WriteLine(string.Format("EmpService:{0} UnityOfWork {1}",this.GetHashCode(), this._unityOfWork.GetHashCode()));
        }

        public void printNewUnitOfWork()
        {
            var u1 = UContainer.Instanst.Resolve<IUnityOfWork>();
            Console.WriteLine(string.Format("UnityOfWork 1  {0}", u1.GetHashCode()));

            var u2 = UContainer.Instanst.Resolve<IUnityOfWork>();
            Console.WriteLine(string.Format("UnityOfWork 2  {0}",u2.GetHashCode()));
        }
        private int unityValue = 0;

        public void printValue()
        {
            Console.WriteLine(string.Format("EmpService:{0} UnityValue: {1}", this.GetHashCode(), this.unityValue));
        }

        public void IncreaseValue()
        {
            this.unityValue++;
        }
    }
}
