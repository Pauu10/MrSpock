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
    public class AlbumController : Controller
    {
        private TP20142CEntities1 db = new TP20142CEntities1();

        //
        // GET: /Album/

        public ActionResult Index()
        {
            var album = db.Album.Include(a => a.Artista).Include(a => a.Usuarios);
            return View(album.ToList());
        }

        //
        // GET: /Album/Details/5

        public ActionResult Details(int id = 0)
        {
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // GET: /Album/Create

        public ActionResult Create()
        {
            ViewBag.IdArtista = new SelectList(db.Artista, "IdArtista", "NombreCompleto");
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        //
        // POST: /Album/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Album.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdArtista = new SelectList(db.Artista, "IdArtista", "NombreCompleto", album.IdArtista);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", album.IdUsuario);
            return View(album);
        }

        //
        // GET: /Album/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdArtista = new SelectList(db.Artista, "IdArtista", "NombreCompleto", album.IdArtista);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", album.IdUsuario);
            return View(album);
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdArtista = new SelectList(db.Artista, "IdArtista", "NombreCompleto", album.IdArtista);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", album.IdUsuario);
            return View(album);
        }

        //
        // GET: /Album/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // POST: /Album/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Album.Find(id);
            db.Album.Remove(album);
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