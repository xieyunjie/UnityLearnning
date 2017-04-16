using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityLearnning.intf;
using Microsoft.Practices.Unity;

namespace UnityLearnning.impl
{
    public class EmpThreeService : IEmpThreeService
    {
        private IUnityOfWork _unityOfWork = null;

        public EmpThreeService(IUnityOfWork u)
        {
            _unityOfWork = u;
        }

        public void printUnityOfWork()
        {
            Console.WriteLine(string.Format("EmpTowService:{0} UnityOfWork {1}", this.GetHashCode(), this._unityOfWork.GetHashCode()));
        }
    }
}
