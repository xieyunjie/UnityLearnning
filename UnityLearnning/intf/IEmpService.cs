using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLearnning.intf
{
    public interface IEmpService
    {
        void printUnityOfWork();

        void printValue();

        void IncreaseValue();
        void printNewUnitOfWork();

        void printParams(string param1, int param2, DateTime? n, string j = null);
        void printParams(ParamCls objParam);
    }
}
