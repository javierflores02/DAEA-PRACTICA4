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
    public class LibroController : Controller
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
            return View(contexto.LIBRO.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LIBRO nuevaLibro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.LIBRO.Add(nuevaLibro);
                    contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(nuevaLibro);
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

            LIBRO LibroEditar = contexto.LIBRO.Find(id);

            if (LibroEditar == null)
                return HttpNotFound();

            return View(LibroEditar);
        }

        [HttpPost]
        public ActionResult Edit(LIBRO LibroEditar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.Entry(LibroEditar).State = EntityState.Modified;
                    contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(LibroEditar);
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

            LIBRO LibroEliminar = contexto.LIBRO.Find(id);

            if (LibroEliminar == null)
                return HttpNotFound();

            return View(LibroEliminar);
        }

        [HttpPost]
        public ActionResult Delete(int? id, LIBRO Libro1)
        {
            try
            {
                LIBRO LibroEliminar = new LIBRO();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    LibroEliminar = contexto.LIBRO.Find(id);

                    if (LibroEliminar == null)
                        return HttpNotFound();

                    contexto.LIBRO.Remove(LibroEliminar);
                    contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(LibroEliminar);
            }
            catch
            {
                return View();
            }
        }
    }
}