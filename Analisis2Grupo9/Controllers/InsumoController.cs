using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Analisis2Grupo9.Models;
using Analisis2Grupo9.Models.TableViewsModels;
using Analisis2Grupo9.Models.ViewModels;

namespace Analisis2Grupo9.Controllers
{
    public class InsumoController : Controller
    {
        // GET: Insumo
        public ActionResult Index()
        {
            List<InsumosTableViewModel> lst = null;

            using (analisis2_2022Entities db = new analisis2_2022Entities()) {
                lst = (from d in db.Insumo
                       where d.id_insumo == 1
                       orderby d.id_insumo
                       select new InsumosTableViewModel
                       {
                           codigo = d.codigo,
                           descripcion = d.descripcion,
                           cantidad = (int)d.cantidad,

                       }).ToList();

            }

            return View(lst);
        }
        [HttpGet]
        public ActionResult Add() {
            return View();

        }

        [HttpPost]
        public ActionResult add(InsumoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                Insumo oInsumo = new Insumo();
                oInsumo.id_insumo = model.id_insumo;
                oInsumo.id_categoria_insumo = model.id_categoria_insumo;
                oInsumo.codigo = model.codigo;
                oInsumo.descripcion = model.descripcion;
                oInsumo.cantidad = model.cantidad;
                oInsumo.estado = model.estado;

                db.Insumo.Add(oInsumo);

                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Insumo/"));
        }


        public ActionResult Edit(int id) {

            InsumoEditViewModel model = new InsumoEditViewModel();

            using (var db = new analisis2_2022Entities()) {

                var oInsumo = db.Insumo.Find(id);
                model.id_categoria_insumo = (int)oInsumo.id_categoria_insumo;
                model.codigo = oInsumo.codigo;
                model.descripcion = oInsumo.descripcion;
                model.cantidad = (int)oInsumo.cantidad;
                model.estado = (int)oInsumo.estado;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(InsumoEditViewModel model) {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities()) {
                var oInsumo = db.Insumo.Find(model.id_insumo);
                oInsumo.id_categoria_insumo = model.id_categoria_insumo;
                oInsumo.codigo = model.codigo;
                oInsumo.descripcion = model.descripcion;
                oInsumo.cantidad = model.cantidad;
                oInsumo.estado = model.estado;

                db.Entry(oInsumo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Insumo/"));
        }



        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var db = new analisis2_2022Entities())
            {
                var oInsumo = db.Insumo.Find(id);
                oInsumo.id_insumo = id;
                

                db.Entry(oInsumo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

    }
}