using Analisis2Grupo9.Models.TableModels;
using Analisis2Grupo9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Analisis2Grupo9.Models.ViewModels;

namespace Analisis2Grupo9.Controllers
{
    public class GestionTicketController : Controller
    {
        // GET: GestionTicket
        public ActionResult Index()
        {
            List<AdminTicketTableModel> tickets = null;
            int idEmpleadoUsuario = Convert.ToInt16(Session["IdUsuario"]);

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
                           where t.id_empleado_asignacion == idEmpleadoUsuario
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
            GestionTicketViewModel model = new GestionTicketViewModel();
            ViewBag.seguimientos = getTicketSeguimiento(IdTicket);

            using (var db = new analisis2_2022Entities())
            {
                var toTicket = db.Ticket.Find(IdTicket);
                model.idTicket = toTicket.id_ticket;
                model.idTicketMostrar = toTicket.id_ticket;
                model.TituloTicket = toTicket.titulo;
                model.DescripcionTicket = toTicket.descripcion;
                model.idEstadoTicket = (int)toTicket.id_estado_ticket;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(GestionTicketViewModel model)
        {
            int idEmpleadoUsuario = Convert.ToInt16(Session["IdUsuario"]);

            using (var db = new analisis2_2022Entities())
            {
                var toTicket = db.Ticket.Find(model.idTicket);
                Ticket_Seguimiento oSeguimiento = new Ticket_Seguimiento();

                oSeguimiento.id_ticket = model.idTicket;
                oSeguimiento.id_empleado = idEmpleadoUsuario;
                oSeguimiento.fecha_seguimiento = DateTime.Now;
                oSeguimiento.descripcion_seguimiento = model.DescripcionSeguimiento;
                oSeguimiento.fecha_inicio_seguimiento = model.HoraInicio;
                oSeguimiento.fecha_fin_seguimiento = model.HoraFinal;

                db.Ticket_Seguimiento.Add(oSeguimiento);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/GestionTicket/"));
        }

        private List<GestionTicketTableModel> getTicketSeguimiento(int idTicket)
        {
            List<GestionTicketTableModel> ticketSeguimiento = null;

            int idEmpleadoUsuario = Convert.ToInt16(Session["IdUsuario"]);

            using (var db = new analisis2_2022Entities())
            {
                ticketSeguimiento = (from ts in db.Ticket_Seguimiento
                             where ts.id_ticket == idTicket
                             where ts.id_empleado == idEmpleadoUsuario
                             select new GestionTicketTableModel
                             {
                                 fecha_seguimiento = (DateTime)ts.fecha_seguimiento,
                                 descripcion_seguimiento = ts.descripcion_seguimiento,
                                 fecha_inicio_seguimiento = (DateTime)ts.fecha_inicio_seguimiento,
                                 fecha_fin_seguimiento = (DateTime)ts.fecha_fin_seguimiento
                             }
                    ).ToList();
            }

            return ticketSeguimiento;
        }

        [HttpPost]
        public ActionResult Finalizar(int idTicket)
        {
            using (var db = new analisis2_2022Entities())
            {
                var oPuesto = db.Ticket.Find(idTicket);

                oPuesto.id_estado_ticket = 3;


                db.Entry(oPuesto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}