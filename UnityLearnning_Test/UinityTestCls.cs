using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnityLearnning_Test
{
    [TestFixture]
    public class UinityTestCls
    {

        [Test]
        public void TestTransientLifetime()
        {
            UnityLearnning.UnityCls.TransientLifetimeManager();
        }

        [Test]
        public void TestPreThreadLifetime()
        {
            UnityLearnning.UnityCls.PerThreadLifetimeManager();
        }

    }
}
