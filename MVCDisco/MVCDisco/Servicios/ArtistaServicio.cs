using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDisco.Models;

namespace MVCDisco.Servicios
{

    public class ArtistaServicio
    {
        TP20142CEntities1 db = new TP20142CEntities1();

        public List<Artista> BuscarArtistas()
        {
            return db.Artista.ToList();
        }

    }
}