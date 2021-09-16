using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Funciones
    {
        public Funciones()
        {
            Tickets = new HashSet<Tickets>();
        }

        public int FuncionId { get; set; }
        public int PeliculaId { get; set; }
        public int SalaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan? Horario { get; set; }

        public virtual Peliculas Pelicula { get; set; }
        public virtual Salas Sala { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
