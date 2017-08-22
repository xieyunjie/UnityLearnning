using Microsoft.Practices.Unity.InterceptionExtension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLearnning
{
    public class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        public bool WillExecute
        {
            get
            {
                return true;
            }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            System.Diagnostics.Trace.WriteLine("Invoke Invoke Invoke");
            for (var i = 0; i < input.Arguments.Count; i++)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("{0}: {1}", input.Arguments.ParameterName(i), JsonConvert.SerializeObject(input.Arguments[i])));
            }

            IMethodReturn result = getNext()(input, getNext);
            return result;
        }
    }
}
