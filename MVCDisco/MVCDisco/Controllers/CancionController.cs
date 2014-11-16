using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDisco.Models;

namespace MVCDisco.Controllers
{
    public class CancionController : Controller
    {

        TP20142CEntities1 db = new TP20142CEntities1();
        //
        // GET: /Cancion/

        public ActionResult Index()
        {
            ViewBag.IdAlbum = new SelectList(db.Album, "IdAlbum", "Nombre");
            var cancion = from n in db.Cancion
                          orderby n.Nombre
                          select n;
             
            return View(cancion.ToList());
        }

   

        //
        // GET: /Cancion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cancion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cancion cancion)
        {

            if (ModelState.IsValid)
            {
                cancion.IdUsuario = 4;
                cancion.FechaCreacion = DateTime.Now;
                
                db.Cancion.Add(cancion);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(cancion);
            
        }

        //
        // GET: /Cancion/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Cancion/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cancion/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cancion/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
