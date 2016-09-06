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
