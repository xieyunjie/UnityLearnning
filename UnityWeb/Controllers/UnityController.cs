using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityLearnning.intf;
using Microsoft.Practices.Unity;
using UnityLearnning.impl;

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
            empSvc.printUnityOfWork();
            empSvc.printNewUnitOfWork();
            return string.Format("controller hash:{0}, empsvc hash:{1}", this.GetHashCode().ToString(),this.empSvc.GetHashCode()) ;
        }

        public string GetHash2()
        {
           var e = UnityLearnning.UContainer.Instanst.Resolve<EmpService>();
            return string.Format("controller hash:{0}, empsvc hash:{1}", this.GetHashCode().ToString(), e.GetHashCode());
        }

    }
}