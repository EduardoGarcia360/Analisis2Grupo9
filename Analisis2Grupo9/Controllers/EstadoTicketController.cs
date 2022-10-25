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
    public class EstadoTicketController : Controller
    {
        // GET: EstadoTicket
        public ActionResult Index()
        {
            List<EstadoTicketTableViewModel> lst = null;
            using (analisis2_2022Entities db = new analisis2_2022Entities())
            {
                lst = (from d in db.Estado_Ticket
                       where d.estado == 1
                       select new EstadoTicketTableViewModel
                       {
                           Nombre = d.nombre,
                           Estado = (int)d.estado,
                           idEstadoTicket = (int)d.id_estado_ticket
                       }).ToList();
            }
            return View(lst);
        }
        
        [HttpPost]
        public ActionResult AddEstadoTicket(EstadoTicket model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                Estado_Ticket oCatTicket = new Estado_Ticket();
                oCatTicket.nombre = model.Nombre;
                oCatTicket.estado = model.Estado;

                db.Estado_Ticket.Add(oCatTicket);

                db.SaveChanges();
            }
            return Redirect(Url.Content("~/EstadoTicket/"));
        }


        [HttpGet]
        public ActionResult AddEstadoTicket()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int idEstadoTicket)
        {
            EditEstadoTicket model = new EditEstadoTicket();

            using (var db = new analisis2_2022Entities())
            {
                var oCatTicket = db.Estado_Ticket.Find(idEstadoTicket);
                model.Nombre = oCatTicket.nombre;
                model.Estado = (int)oCatTicket.estado;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditEstadoTicket model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                var oCatTicket = db.Estado_Ticket.Find(model.idEstadoTicket);
                oCatTicket.estado = model.Estado;
                oCatTicket.nombre = model.Nombre;

                db.Entry(oCatTicket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/EstadoTicket/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            

            using (var db = new analisis2_2022Entities())
            {
                var oCatTicket = db.Estado_Ticket.Find(Id);
                oCatTicket.estado = 3;
                

                db.Entry(oCatTicket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}