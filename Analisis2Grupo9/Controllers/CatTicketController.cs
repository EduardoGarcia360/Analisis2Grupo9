using Analisis2Grupo9.Models;
using Analisis2Grupo9.Models.TableModels;
using Analisis2Grupo9.Models.TableViewsModels;
using Analisis2Grupo9.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;

namespace Analisis2Grupo9.Controllers
{
    public class CatTicketController : Controller
    {
        // GET: CatTicket
        public ActionResult Index()
        {
            List<categoriaTicketTableModel> lst = null;
            using (analisis2_2022Entities db = new analisis2_2022Entities())
            {
                lst = (from d in db.Categoria_Ticket
                       where d.estado == 1
                       orderby d.id_categoria_ticket
                       select new categoriaTicketTableModel
                       {
                           Codigo = d.codigo,
                           Nombre = d.nombre,
                           Estado = (int)d.estado,
                           IdCategoriaTicket = d.id_categoria_ticket
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

        [HttpGet]
        public ActionResult Edit(int idCategoriaTicket)
        {
            EditcatTicket model = new EditcatTicket();

            using (var db = new analisis2_2022Entities())
            {
                var oCatTicket = db.Categoria_Ticket.Find(idCategoriaTicket);
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
                var oCatTicket = db.Categoria_Ticket.Find(model.idCategoriaTicket);
                oCatTicket.estado = model.Estado;
                oCatTicket.nombre = model.Nombre;
                oCatTicket.codigo = model.Codigo;

                db.Entry(oCatTicket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/CatTicket/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            

            using (var db = new analisis2_2022Entities())
            {
                var oCatTicket = db.Categoria_Ticket.Find(Id);
                oCatTicket.estado = 3;
                

                db.Entry(oCatTicket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }


    }
}
