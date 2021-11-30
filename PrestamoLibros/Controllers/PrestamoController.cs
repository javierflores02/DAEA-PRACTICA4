using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using PrestamoLibros.Models;

namespace PrestamoLibros.Controllers
{
    public class PrestamoController : Controller
    {
        // GET: Categories
        #region Contexto

        private PrestamoLibroEntities _contexto;

        public PrestamoLibroEntities contexto
        {
            set { _contexto = value; }
            get
            {
                if (_contexto == null)
                    _contexto = new PrestamoLibroEntities();
                return _contexto;
            }
        }
        #endregion

        public ActionResult Index()
        {
            return View(contexto.PRESTAMO.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PRESTAMO nuevoPrestamo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.PRESTAMO.Add(nuevoPrestamo);
                    contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(nuevoPrestamo);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            PRESTAMO PrestamoEditar = contexto.PRESTAMO.Find(id);

            if (PrestamoEditar == null)
                return HttpNotFound();

            return View(PrestamoEditar);
        }

        [HttpPost]
        public ActionResult Edit(PRESTAMO PrestamoEditar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.Entry(PrestamoEditar).State = EntityState.Modified;
                    contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(PrestamoEditar);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            PRESTAMO PrestamoEliminar = contexto.PRESTAMO.Find(id);

            if (PrestamoEliminar == null)
                return HttpNotFound();

            return View(PrestamoEliminar);
        }

        [HttpPost]
        public ActionResult Delete(int? id, PRESTAMO Prestamo1)
        {
            try
            {
                PRESTAMO PrestamoEliminar = new PRESTAMO();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    PrestamoEliminar = contexto.PRESTAMO.Find(id);

                    if (PrestamoEliminar == null)
                        return HttpNotFound();

                    contexto.PRESTAMO.Remove(PrestamoEliminar);
                    contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(PrestamoEliminar);
            }
            catch
            {
                return View();
            }
        }
    }
}