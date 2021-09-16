using DataAccess.Data;
using DataAccess.Models;
using System;
using System.Linq;

namespace Logic
{
    public class TicketsVentas
    {
        public string Vender(int funcionID, string usuario)
        {
            using (var context = new CineContext())
            {
                var funcion = context.Funciones.Find(funcionID);
                var sala = context.Salas.Find(funcion.SalaId);
                
                if(context.Tickets.Where(F => F.FuncionId == funcionID).Count() < sala.Capacidad) 
                {
                    Tickets ticket = new Tickets
                    {
                        TicketId = Guid.NewGuid(),
                        FuncionId = funcionID,
                        Usuario = usuario
                    };
                    context.Add(ticket);
                    context.SaveChanges();

                    return "La venta se ha completado exitósamente.";
                }
                else
                {
                    return "Ocurrió un problema al intentar completar la transacción: No hay más tickets disponibles para esta función";
                }
            }
        }
    }
}
