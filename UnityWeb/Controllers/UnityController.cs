using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityLearnning.intf;
using Microsoft.Practices.Unity;
using UnityLearnning.impl;
using UnityLearnning;

namespace UnityWeb.Controllers
{
    public class UnityController : Controller
    {
        private IEmpService empSvc = null;
        public UnityController(IEmpService vc)
        {
            this.empSvc = UnityLearnning.UContainer.Instanst.Resolve<IEmpService>();
        }
        // GET: Unity
        public ActionResult Index()
        {
            return View();
        }

        public string GetHash()
        {
            this.empSvc.printUnityOfWork();
            System.Diagnostics.Trace.WriteLine("this.empSvc hashcode:" + this.empSvc.GetHashCode());

            var e = UnityLearnning.UContainer.Instanst.Resolve<IEmpService>();
            System.Diagnostics.Trace.WriteLine("e hashcode:" + e.GetHashCode());
            e.printUnityOfWork();

            return string.Format("controller hash:{0}, empsvc hash:{1}", this.GetHashCode().ToString(),this.empSvc.GetHashCode()) ;

        }

        public string GetHash2()
        {
           var e = UnityLearnning.UContainer.Instanst.Resolve<EmpService>();
            return string.Format("controller hash:{0}, empsvc hash:{1}", this.GetHashCode().ToString(), e.GetHashCode());
        }

        public string GetHash3()
        {
            System.Diagnostics.Trace.WriteLine("this.empSvc hashcode:" + this.empSvc.GetHashCode());

            var e = UnityLearnning.UContainer.Instanst.Resolve<IEmpService>();
            System.Diagnostics.Trace.WriteLine("e hashcode:" + e.GetHashCode());

            var e2 = UnityLearnning.UContainer.Instanst.Resolve<IEmpService>();
            System.Diagnostics.Trace.WriteLine("e2 hashcode:" + e2.GetHashCode());


            e.printUnityOfWork();
            e2.printUnityOfWork();
            empSvc.printUnityOfWork();

            return string.Format("controller hash:{0}, empsvc hash:{1}", this.GetHashCode().ToString(), e.GetHashCode());
        }

        public string PrintParams()
        {
            this.empSvc.printParams("111", 22, DateTime.Now);
            ParamCls par = new ParamCls()
            {
                CreateTime = DateTime.Now.AddDays(10),
                Name = "alexxie"
            };

            this.empSvc.printParams(par);
            return "ok";

        }

    }
}