using Analisis2Grupo9.Models;
using Analisis2Grupo9.Models.TableModels;
using Analisis2Grupo9.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Analisis2Grupo9.Controllers
{
    public class AdminTicketController : Controller
    {
        // GET: AdminTicket
        public ActionResult Index()
        {
            List<AdminTicketTableModel> tickets = null;

            using (var db = new analisis2_2022Entities())
            {
                tickets = (from t in db.Ticket
                           join ct in db.Categoria_Ticket
                                on t.id_categoria_ticket equals ct.id_categoria_ticket
                           join et in db.Estado_Ticket
                                on t.id_estado_ticket equals et.id_estado_ticket
                           join eas in db.Empleado
                                on t.id_empleado_solicitud equals eas.id_empleado
                           join ea in db.Empleado
                                on t.id_empleado_asignacion equals ea.id_empleado
                           into EmpleadoAsignado
                           from pea in EmpleadoAsignado.DefaultIfEmpty() // left join
                           select new AdminTicketTableModel
                           {
                               IdTicket = t.id_ticket,
                               IdEmpleadoSolicitud = (int)t.id_empleado_solicitud,
                               NombreEmpSoli = eas.nombre,
                               ApellidoEmpSoli = eas.apellido,
                               IdEmpleadoAsignacion = t.id_empleado_asignacion != null ? (int)t.id_empleado_asignacion : 0,
                               NombreEmpAsig = pea.nombre,
                               ApellidoEmpAsig = pea.apellido,
                               IdCategoriaTicket = (int)t.id_categoria_ticket,
                               NombreCatTicket = ct.nombre,
                               IdEstadoTicket = (int)t.id_estado_ticket,
                               NombreEstadoTicket = et.nombre,
                               FechaSolicitud = (DateTime)t.fecha_solicitud,
                               Titulo = t.titulo,
                               Descripcion = t.descripcion
                           }
                    ).ToList();
            }

            return View(tickets);
        }

        [HttpGet]
        public ActionResult Edit(int IdTicket)
        {
            ViewBag.empleados = getEmpleadoAsignacion();
            AdminTicketViewModel model = new AdminTicketViewModel();

            using (var db = new analisis2_2022Entities())
            {
                var toTicket = db.Ticket.Find(IdTicket);
                var toCategoria = db.Categoria_Ticket.Find(toTicket.id_categoria_ticket);
                var toEmpleado = db.Empleado.Find(toTicket.id_empleado_solicitud);

                model.IdTicket = toTicket.id_ticket;
                model.IdTicketMostrar = toTicket.id_ticket;
                model.Solicitado = (DateTime)toTicket.fecha_solicitud;
                model.EmpleadoSolicito = toEmpleado.nombre + " " + toEmpleado.apellido;
                model.Titulo = toTicket.titulo;
                model.Descripcion = toTicket.descripcion;
                model.Categoria = toCategoria.nombre;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AdminTicketViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.empleados = getEmpleadoAsignacion();
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                var toTicket = db.Ticket.Find(model.IdTicket);

                toTicket.id_empleado_asignacion = (int)model.IdEmpleadoAsignacion;
                toTicket.id_estado_ticket = 2; // asignado

                db.Entry(toTicket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/AdminTicket/"));
        }

        private List<EmpleadoTableModel> getEmpleadoAsignacion()
        {
            List<EmpleadoTableModel> empleados = null;

            using (var db = new analisis2_2022Entities())
            {
                empleados = (from e in db.Empleado
                             where e.id_puesto != 1
                             select new EmpleadoTableModel
                             {
                                 IdEmpleado = e.id_empleado,
                                 NombreCompleto = e.nombre + " " + e.apellido
                             }
                    ).ToList();
            }

            return empleados;
        }
    }
}