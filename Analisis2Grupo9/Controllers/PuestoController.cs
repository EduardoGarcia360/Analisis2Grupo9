using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Analisis2Grupo9.Models;
using Analisis2Grupo9.Models.ViewModels;
using Analisis2Grupo9.Models.TableModels;

namespace Analisis2Grupo9.Controllers
{
    public class PuestoController : Controller
    {
        // GET: Puesto
        public ActionResult Index()
        {
            List<PuestoTableModel> lst = null;
            using (analisis2_2022Entities db = new analisis2_2022Entities())
            {
                lst = (from p in db.Puesto
                       where p.estado == 1
                      select new PuestoTableModel
                      {
                          IdPuesto = p.id_puesto,
                          Codigo = p.codigo,
                          Nombre = p.nombre,
                          Estado = (int)p.estado
                      }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Add() { return View(); }

        [HttpPost]
        public ActionResult Add(PuestoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                Puesto puesto = new Puesto();
                puesto.codigo = model.Codigo;
                puesto.nombre = model.Nombre;
                puesto.estado = 1;

                db.Puesto.Add(puesto);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Puesto/"));
        }

        [HttpGet]
        public ActionResult Edit(int IdPuesto) 
        {
            EditPuestoViewModel model = new EditPuestoViewModel();

            using (var db = new analisis2_2022Entities())
            {
                var oPuesto = db.Puesto.Find(IdPuesto);

                model.IdPuesto = oPuesto.id_puesto;
                model.Codigo = oPuesto.codigo;
                model.Nombre = oPuesto.nombre;
                
            }

            return View(model); 
        }

        [HttpPost]
        public ActionResult Edit(EditPuestoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                var oPuesto = db.Puesto.Find(model.IdPuesto);

                oPuesto.codigo = model.Codigo;
                oPuesto.nombre = model.Nombre;

                db.Entry(oPuesto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Puesto/"));
        }

        [HttpPost]
        public ActionResult Delete(int IdPuesto)
        {
            using (var db = new analisis2_2022Entities())
            {
                var oPuesto = db.Puesto.Find(IdPuesto);

                oPuesto.estado = 0;


                db.Entry(oPuesto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}