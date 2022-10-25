using Analisis2Grupo9.Models;
using Analisis2Grupo9.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;



namespace Analisis2Grupo9.Controllers
{
    public class CatTicketController : Controller
    {
        // GET: CatTicket
        public ActionResult Index()
        {
            List<catTicket> lst = null;
            using (analisis2_2022Entities db = new analisis2_2022Entities())
            {
                lst = (from d in db.Categoria_Ticket
                       where d.codigo != " "
                       select new catTicket
                       {
                           Codigo = d.codigo,
                           Nombre = d.nombre,
                           Estado = d.estado
                       }).ToList();
            }

            return View(lst);
        }


        [HttpPost]
        public ActionResult AddCat(catTicket model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                Categoria_Ticket oCatTicket = new Categoria_Ticket();
                oCatTicket.codigo = model.Codigo;
                oCatTicket.nombre = model.Nombre;
                oCatTicket.estado = model.Estado;

                db.Categoria_Ticket.Add(oCatTicket);

                db.SaveChanges();
            }
            return Redirect(Url.Content("~/CatTicket/"));
        }


        [HttpGet]
        public ActionResult AddCat()
        {
            return View();
        }

        public ActionResult Edit(string Codigo)
        {
            EditcatTicket model = new EditcatTicket();

            using (var db = new analisis2_2022Entities())
            {
                var oCatTicket = db.Categoria_Ticket.Find(Codigo);
                model.Nombre = (string)oCatTicket.nombre;
                model.Estado = (int)oCatTicket.estado;
                model.Codigo = (string)oCatTicket.codigo;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditcatTicket model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                var oCatTicket = db.Categoria_Ticket.Find(model.Codigo);
                oCatTicket.estado = model.Estado;
                if (model.Nombre != null && model.Nombre.Trim() != "")
                {
                    oCatTicket.nombre = model.Nombre;
                }
                db.Entry(oCatTicket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/CatTicket/"));
        }
    }
}