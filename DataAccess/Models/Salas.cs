using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Salas
    {
        public Salas()
        {
            Funciones = new HashSet<Funciones>();
        }

        public int SalaId { get; set; }
        public int Capacidad { get; set; }

        public virtual ICollection<Funciones> Funciones { get; set; }
    }
}
