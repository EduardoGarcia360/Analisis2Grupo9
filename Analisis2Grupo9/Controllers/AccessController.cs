using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Analisis2Grupo9.Models;

namespace Analisis2Grupo9.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (analisis2_2022Entities db = new analisis2_2022Entities())
                {
                    var lst = from emp in db.Empleado where emp.usuario == user && emp.password == password select emp;
                    if (lst.Count() > 0)
                    {
                        Session["User"] = lst.First();
                        return Content("1");
                    } 
                    else
                    {
                        return Content("Usuario invalido");
                    }
                }
                    
            }
            catch (Exception e)
            {
                return Content("Error: " + e.Message);
            }
        }
    }
}