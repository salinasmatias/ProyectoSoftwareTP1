using DataAccess.Data;
using DataAccess.Models;
using System;
using System.Linq;

namespace Logic
{
    public class RegistrarFunciones
    {
        public string RegistrarFuncion(int PeliculaID, int SalaID, DateTime Fecha, TimeSpan Horario) 
        {
            var funcion = new Funciones
            {
                PeliculaId = PeliculaID,
                SalaId = SalaID,
                Fecha = Fecha,
                Horario = Horario
            };

            if (ValidarFuncion(funcion))
            {
                using(var context = new CineContext())
                {
                    context.Add(funcion);
                    context.SaveChanges();
                }
                return "Se ha registrado la función exitosamente";
            }
            else
            {
                return "Ha ocurrido un problema al registrar la función. Asegurese de que los datos ingresados sean correctos y que la función a ingresar no se superponga con otra";
            }
        }

        private bool ValidarFuncion(Funciones funcion)
        {
            using(var context = new CineContext())
            {
                var funciones = context.Funciones.Where(F => F.SalaId == funcion.SalaId && F.Fecha.Date == funcion.Fecha.Date).ToList();
                var duracionFuncion = new TimeSpan(2, 30, 0);

                foreach (var F in funciones)
                {
                    if ((funcion.Horario.Value - F.Horario.Value).Duration() < duracionFuncion)
                        return false;
                }
                return true;
            }
        }
    }
}
