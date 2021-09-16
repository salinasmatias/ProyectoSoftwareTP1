using System;

namespace DataAccess.Models
{
    public class Tickets
    {
        public Guid TicketId { get; set; }
        public int FuncionId { get; set; }
        public string Usuario { get; set; }

        public virtual Funciones Funcion { get; set; }
    }
}
