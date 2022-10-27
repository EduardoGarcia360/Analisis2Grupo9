using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Analisis2Grupo9.Models;
using Analisis2Grupo9.Models.TableModels;
using Analisis2Grupo9.Models.ViewModels;

namespace Analisis2Grupo9.Controllers
{
    public class CategoriaInsumoController : Controller
    {
        // GET: CategoriaInsumo
        public ActionResult Index()
        {
            List<CategoriaInsumoTableModel> lst = null;
            using (analisis2_2022Entities db = new analisis2_2022Entities())
            {
                lst = (from d in db.Categoria_Insumo
                       where d.estado == 1
                       orderby d.id_categoria_insumo
                       select new CategoriaInsumoTableModel
                       {
                           id_categoria_insumo = d.id_categoria_insumo,
                           codigo = d.codigo,
                           nombre = d.nombre,
                           estado = d.estado
                       }).ToList();

            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CategoriaInsumoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                Categoria_Insumo cIn = new Categoria_Insumo();
                cIn.nombre = model.nombre;
                cIn.codigo = model.codigo;
                cIn.estado = 1;

                db.Categoria_Insumo.Add(cIn);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/CategoriaInsumo/"));
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EditCategoriaInsumoViewModel model = new EditCategoriaInsumoViewModel();
            using (var db = new analisis2_2022Entities())
            {
                var cIn = db.Categoria_Insumo.Find(Id);
                model.codigo = cIn.codigo;
                model.nombre = cIn.nombre;
                model.id_categoria_insumo = cIn.id_categoria_insumo;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoriaInsumoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                var cIn = db.Categoria_Insumo.Find(model.id_categoria_insumo);
                cIn.codigo = model.codigo;
                cIn.nombre = model.nombre;

                db.Entry(cIn).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/CategoriaInsumo/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {

            using (var db = new analisis2_2022Entities())
            {
                var cIn = db.Categoria_Insumo.Find(Id);
                cIn.estado = 0;

                db.Entry(cIn).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }
    }
}