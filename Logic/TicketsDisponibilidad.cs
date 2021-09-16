using DataAccess.Data;
using System.Linq;

namespace Logic
{
    public class TicketsDisponibilidad
    {
        public int TicketsDisponibles(int funcionID)
        {
            using(var context = new CineContext())
            {
                var funcion = context.Funciones.Find(funcionID);
                var sala = context.Salas.Find(funcion.SalaId);

                return sala.Capacidad - context.Tickets.Where(F => F.FuncionId == funcionID).Count();
            }
        }
    }
}
