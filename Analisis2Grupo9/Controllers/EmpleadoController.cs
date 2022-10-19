﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Analisis2Grupo9.Models;
using Analisis2Grupo9.Models.TableModels;
using Analisis2Grupo9.Models.ViewModels;

namespace Analisis2Grupo9.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoTableModel> lst = null;
            using (var db = new analisis2_2022Entities())
            {
                lst = (from e in db.Empleado
                       join p in db.Puesto
                       on e.id_puesto equals p.id_puesto
                       select new EmpleadoTableModel
                       {
                           IdEmpleado = e.id_empleado,
                           IdPuesto = (int)e.id_puesto,
                           Puesto = p.nombre,
                           Codigo = e.codigo,
                           Nombre = e.nombre,
                           Apellido = e.apellido,
                           Usuario = e.usuario
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Add() { return View(); }

        [HttpPost]
        public ActionResult Add(EmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                Empleado empleado = new Empleado();

                empleado.id_puesto = model.IdPuesto;
                empleado.codigo = model.Codigo;
                empleado.nombre = model.Nombre;
                empleado.apellido = model.Apellido;
                empleado.usuario = model.Usuario;
                empleado.password = model.Password;

                db.Empleado.Add(empleado);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Empleado/"));
        }

        [HttpGet]
        public ActionResult Edit(int IdEmpleado) 
        {
            EditEmpleadoViewModel model = new EditEmpleadoViewModel();

            using(var db = new analisis2_2022Entities())
            {
                var oEmpleado = db.Empleado.Find(IdEmpleado);

                model.IdEmpleado = oEmpleado.id_empleado;
                model.IdPuesto = (int)oEmpleado.id_puesto;
                model.Codigo = oEmpleado.codigo;
                model.Nombre = oEmpleado.nombre;
                model.Apellido = oEmpleado.apellido;
                model.Usuario = oEmpleado.usuario;
                model.Password = oEmpleado.password;
            }
            return View(model); 
        }

        [HttpPost]
        public ActionResult Edit(EditEmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new analisis2_2022Entities())
            {
                var oEmpleado = db.Empleado.Find(model.IdEmpleado);

                oEmpleado.id_puesto = model.IdPuesto;
                oEmpleado.codigo = model.Codigo;
                oEmpleado.nombre = model.Nombre;
                oEmpleado.apellido = model.Apellido;
                oEmpleado.usuario = model.Usuario;
                oEmpleado.password = model.Password;

                db.Entry(oEmpleado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Empleado/"));
        }
    }
}