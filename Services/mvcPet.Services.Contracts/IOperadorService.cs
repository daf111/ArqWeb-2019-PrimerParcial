using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Services.Contracts
{
    public interface IOperadorService
    {

        List<Operador> ToList();

        Operador Find(int id);
        
        Operador Add(Operador entity);
        
        void Edit(Operador entity);

        void Remove(Operador entity);
        
    }
}
