using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdajaVozilaApp.Model.Dao
{
    interface IDao<T>
    {
        void Delete(T t);
        T Get(int id);
        List<T> GetAll();
        void Save(T t);
        void Update(T t, params string[] @params);
    }
}
