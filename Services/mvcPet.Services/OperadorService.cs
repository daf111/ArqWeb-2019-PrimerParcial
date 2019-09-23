using mvcPet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvcPet.Entities;
using mvcPet.Business;

namespace mvcPet.Services
{
    public class OperadorService : IOperadorService
    {
        public Operador Add(Operador entity)
        {
            var bc = new OperadorComponent();
            return bc.Add(entity);
        }

        public void Edit(Operador entity)
        {
            var bc = new OperadorComponent();
            bc.Edit(entity);
        }

        public Operador Find(int id)
        {
            var bc = new OperadorComponent();
            return bc.Find(id);
        }

        public void Remove(Operador entity)
        {
            var bc = new OperadorComponent();
            bc.Remove(entity);
        }

        public List<Operador> ToList()
        {
            var bc = new OperadorComponent();
            return bc.ToList();
        }
    }
}
