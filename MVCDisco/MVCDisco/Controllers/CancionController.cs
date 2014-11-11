using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDisco.Models;

namespace MVCDisco.Controllers
{
    public class CancionController : Controller
    {
        private TP20142CEntities1 db = new TP20142CEntities1();

        //
        // GET: /Cancion/

        public ActionResult Index()
        {
            var cancion = db.Cancion.Include(c => c.Album).Include(c => c.Usuarios);
            return View(cancion.ToList());
        }

        //
        // GET: /Cancion/Details/5

        public ActionResult Details(int id = 0)
        {
            Cancion cancion = db.Cancion.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            return View(cancion);
        }

        //
        // GET: /Cancion/Create

        public ActionResult Create()
        {
            ViewBag.IdAlbum = new SelectList(db.Album, "IdAlbum", "Nombre");
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre");
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
                db.Cancion.Add(cancion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAlbum = new SelectList(db.Album, "IdAlbum", "Nombre", cancion.IdAlbum);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", cancion.IdUsuario);
            return View(cancion);
        }

        //
        // GET: /Cancion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cancion cancion = db.Cancion.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAlbum = new SelectList(db.Album, "IdAlbum", "Nombre", cancion.IdAlbum);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", cancion.IdUsuario);
            return View(cancion);
        }

        //
        // POST: /Cancion/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cancion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAlbum = new SelectList(db.Album, "IdAlbum", "Nombre", cancion.IdAlbum);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", cancion.IdUsuario);
            return View(cancion);
        }

        //
        // GET: /Cancion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cancion cancion = db.Cancion.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            return View(cancion);
        }

        //
        // POST: /Cancion/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cancion cancion = db.Cancion.Find(id);
            db.Cancion.Remove(cancion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}