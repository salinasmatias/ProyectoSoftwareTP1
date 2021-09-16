using DataAccess.Data;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class PeliculasInfo
    {
        public List<Peliculas> GetPeliculas()
        {
            using(var context = new CineContext())
            {
                return context.Peliculas.ToList();
            }
        }

        public Peliculas GetPeliculaByTitle(string title)
        {
            using(var context = new CineContext())
            {
                return context.Peliculas.SingleOrDefault(Pelicula => Pelicula.Titulo == title);
            }
        }

        public Peliculas GetPeliculaById(int id)
        {
            using (var context = new CineContext())
            {
                return context.Peliculas.Find(id);
            }
        }
    }
}
