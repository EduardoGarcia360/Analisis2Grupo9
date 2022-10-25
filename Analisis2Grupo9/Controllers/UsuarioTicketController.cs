using Analisis2Grupo9.Models;
using Analisis2Grupo9.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Analisis2Grupo9.Models.ViewModels;
using System.Security.Cryptography;

namespace Analisis2Grupo9.Controllers
{
    public class UsuarioTicketController : Controller
    {
        // GET: UsuarioTicket
        public ActionResult Index()
        {
            List<TicketTableModel> tickets = null;
            int idEmpleadoUsuario = Convert.ToInt16(Session["IdUsuario"]);
            
            using (var db = new analisis2_2022Entities())
            {
                tickets = (from t in db.Ticket
                           join ct in db.Categoria_Ticket
                                on t.id_categoria_ticket equals ct.id_categoria_ticket
                           join et in db.Estado_Ticket
                                on t.id_estado_ticket equals et.id_estado_ticket
                           join ea in db.Empleado
                                on t.id_empleado_asignacion equals ea.id_empleado
                           into EmpleadoAsignado from pea in EmpleadoAsignado.DefaultIfEmpty() // left join
                           where t.id_empleado_solicitud == idEmpleadoUsuario
                           select new TicketTableModel
                           {
                               IdTicket = t.id_ticket,
                               Titulo = t.titulo,
                               Descripcion = t.descripcion,
                               IdCategoriaTicket = (int)t.id_categoria_ticket,
                               CategoriaTicketDesc = ct.nombre,
                               IdEstadoTicket = (int)t.id_estado_ticket,
                               EstadoTicketDesc = et.nombre,
                               FechaSolicitud = (DateTime)t.fecha_solicitud,
                               NombreEmpleadoAsignado = pea.nombre,
                               ApellidoEmpleadoAsignado = pea.apellido
                           }
                        ).ToList();
            }

            return View(tickets);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.categorias = getCategorias();
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddTicketViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.categorias = getCategorias();
                return View(model);
            }

            int idEmpleadoUsuario = Convert.ToInt16(Session["IdUsuario"]);
            using (var db = new analisis2_2022Entities())
            {
                Ticket ticket = new Ticket();

                ticket.id_empleado_solicitud = idEmpleadoUsuario;
                ticket.id_categoria_ticket = model.IdCategoria;
                ticket.id_estado_ticket = 1; // estado pendiente
                ticket.fecha_solicitud = DateTime.Now;
                ticket.titulo = model.Titulo.Trim();
                ticket.descripcion = model.Descripcion.Trim();

                db.Ticket.Add(ticket);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/UsuarioTicket/"));
        }

        private List<CategoriaTicketTableModel> getCategorias()
        {
            List<CategoriaTicketTableModel> categorias = null;

            using (var db = new analisis2_2022Entities())
            {
                categorias = (from c in db.Categoria_Ticket
                              where c.estado == 1
                              select new CategoriaTicketTableModel
                              {
                                  IdCategoriaTicket = c.id_categoria_ticket,
                                  Nombre = c.nombre
                              }).ToList();
            }

            return categorias;
        }
    }
}