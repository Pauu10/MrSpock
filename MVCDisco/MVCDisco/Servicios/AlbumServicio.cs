using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDisco.Models;

namespace MVCDisco.Servicios
{
    public class AlbumServicio
    {
         TP20142CEntities1 db = new TP20142CEntities1();
         
        //Metodo obtiene una lista de albums ordenada por nombre
         public List<Album> OrdenarAlbumPorNombre() {
             return (from n in db.Album orderby n.Nombre select n).ToList();
            }

    //Metodo que obtiene todoso los albumes
            public List<Album> BuscarTodoAlbum()
            {
                return db.Album.ToList();
            }

            //Metodo que crea Album
            public bool CrearAlbum(Album album)
            {
                album.FechaCreación = DateTime.Now;
                db.Album.Add(album);
                db.SaveChanges();
                return true;
            }

            public bool BorrarAlbum(int id) {
                List<Cancion> cancion = db.Cancion.ToList();
                List<Album> album = db.Album.ToList();

                var can = from a in db.Cancion where a.IdAlbum == id select a;
                var alb = from c in db.Album where c.IdAlbum == id select c;


                foreach (var ca in can)
                {
                    db.Cancion.Remove(ca);
                }

                foreach (var all in alb)
                {
                    db.Album.Remove(all);
                }
                db.SaveChanges();
                return true;
            }

        }
    
}