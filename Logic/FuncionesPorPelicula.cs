using DataAccess.Data;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class FuncionesPorPelicula
    {
        public List<Funciones> GetFunciones(int id) 
        {
            using(var context = new CineContext())
            {
                return context.Funciones.Where(funcion => funcion.PeliculaId == id).ToList();
            }
        }
    }
}
