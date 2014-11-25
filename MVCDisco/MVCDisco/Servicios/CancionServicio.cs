using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDisco.Models;

namespace MVCDisco.Servicios
{
    public class CancionServicio

    {
        TP20142CEntities1 db = new TP20142CEntities1();

        //Metodo obtiene una lista ordenada por nombre de canciones
        public List<Cancion> OrdenarCancionPorNombre()
        {
            return (from n in db.Cancion orderby n.Nombre select n).ToList();
        }

        //Metodo que obtiene una lista de canciones segun album
        public List<Cancion> FiltrarCancionPorAlbum(int id)
        {
            return ( from n in db.Cancion where n.Album.IdAlbum == id select n).ToList();
        }

        //Metodo que evalua si el nombre de una cancion con album exite
        public bool EvaluarCrearCancion(int id,string nombre)
        {
            var nombreCancion = (from a in db.Cancion where a.Nombre == nombre && a.IdAlbum == id select a).FirstOrDefault();
            if (nombreCancion != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //Metodo que evalua si el nombre de una sin album cancion ya exite 
        public bool EvaluarCrearCancion(string nombre)
        {
            var nombreCancion = (from a in db.Cancion where a.Nombre == nombre && a.IdAlbum == null select a).FirstOrDefault();
            if (nombreCancion != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Metodo que crea una cancion
        public bool CrearCancion(Cancion cancion)
        {
            cancion.IdUsuario = 4;
            cancion.FechaCreacion = DateTime.Now;

            db.Cancion.Add(cancion);
            db.SaveChanges();
            return true;
        }

        //Metodo que borra una cancion
        public void BorrarCancion(int id)
        {
           
            var cancion = (from a in db.Cancion where a.IdCancion == id select a).First();
            db.Cancion.Remove(cancion);
            db.SaveChanges();
        }


    }
}