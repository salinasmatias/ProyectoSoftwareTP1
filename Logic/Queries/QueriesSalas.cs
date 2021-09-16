using DataAccess.Data;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class QueriesSalas
    {
        public List<Salas> GetAllSalas()
        {
            using(var context = new CineContext())
            {
                return context.Salas.ToList();
            }
        }
    }
}
