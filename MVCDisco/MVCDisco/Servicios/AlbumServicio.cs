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

    //Metodo que obtiene todoso los albumes
            public List<Album> BuscarTodoAlbum()
            {
                return db.Album.ToList();
            }
        }
    
}