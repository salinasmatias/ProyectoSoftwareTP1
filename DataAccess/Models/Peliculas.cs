using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Peliculas
    {
        public Peliculas()
        {
            Funciones = new HashSet<Funciones>();
        }

        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Poster { get; set; }
        public string Sinopsis { get; set; }
        public string Trailer { get; set; }

        public virtual ICollection<Funciones> Funciones { get; set; }
    }
}
