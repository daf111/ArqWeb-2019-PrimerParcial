using mvcPet.Data;
using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Business
{
    public class OperadorComponent
    {
        public List<Operador> ToList()
        {
            var odac = new OperadorDAC();
            return odac.Read();
        }

        public Operador Find(int id)
        {
            var odac = new OperadorDAC();
            return odac.ReadBy(id);
        }

        public Operador Add(Operador entity)
        {
            var odac = new OperadorDAC();
            var result = odac.Create(entity);
            return result;
        }

        public void Edit(Operador entity)
        {
            var odac = new OperadorDAC();
            odac.Update(entity);
        }

        public void Remove(Operador entity)
        {
            var odac = new OperadorDAC();
            odac.Delete(entity.Id);
        }
    }
}
