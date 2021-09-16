using DataAccess.Data;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class QueriesFunciones
    {
        public List<Funciones> GetAllFunciones()
        {
            using (var context = new CineContext())
            {
                return context.Funciones.ToList();
            }
        }
    }
}
