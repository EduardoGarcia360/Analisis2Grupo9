using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Analisis2Grupo9.Models;
using Analisis2Grupo9.Models.TableModels;
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
                       join ci in db.Categoria_Insumo
                            on d.id_categoria_insumo equals ci.id_categoria_insumo
                       where d.estado == 1
                       orderby d.id_insumo
                       select new InsumosTableViewModel
                       {
                           id_insumo = d.id_insumo,
                           id_categoria_insumo = (int)d.id_categoria_insumo,
                           categoriaNombre = ci.nombre,
                           codigo = d.codigo,
                           descripcion = d.descripcion,
                           cantidad = (int)d.cantidad,
                           estado = (int)d.estado
                       }).ToList();

            }

            return View(lst);
        }

        [HttpGet]
        public ActionResult Add() {
            ViewBag.categorias = getCategorias();
            return View();
        }

        [HttpPost]
        public ActionResult add(InsumoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.categorias = getCategorias();
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                Insumo oInsumo = new Insumo();
                oInsumo.id_categoria_insumo = model.id_categoria_insumo;
                oInsumo.codigo = model.codigo;
                oInsumo.descripcion = model.descripcion;
                oInsumo.cantidad = model.cantidad;
                oInsumo.estado = 1;

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
            ViewBag.categorias = getCategorias();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(InsumoEditViewModel model) {

            if (!ModelState.IsValid)
            {
                ViewBag.categorias = getCategorias();
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
                oInsumo.estado = 0;
                

                db.Entry(oInsumo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

        private List<CategoriaInsumoTableModel> getCategorias()
        {
            List<CategoriaInsumoTableModel> lst = null;

            using (var db = new analisis2_2022Entities())
            {
                lst = (from c in db.Categoria_Insumo
                       where c.estado == 1
                       select new CategoriaInsumoTableModel
                       {
                           id_categoria_insumo = c.id_categoria_insumo,
                           nombre = c.nombre
                       }).ToList();
            }

            return lst;
        }

    }
}