using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Contracts
{
    internal interface ICrudService<T>
    {
        T Get(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);    
    }
}
