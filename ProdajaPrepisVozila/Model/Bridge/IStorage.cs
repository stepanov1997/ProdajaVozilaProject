using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdajaPrepisVozila.Model.Bridge
{
    public interface IStorage<T>
    {
        void Delete(T t);
        T Get(long id);
        List<T> GetAll();
        void Save(T t);
        void Update(T t, params string[] @params);
    }
}
