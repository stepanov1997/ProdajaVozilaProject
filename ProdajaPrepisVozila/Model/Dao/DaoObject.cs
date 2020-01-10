using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdajaPrepisVozila.Model.Bridge;

namespace ProdajaPrepisVozila.Model.Dao
{
    class DaoObject<T> : IDao<T>
    {
        public IStorage<T> StorageMode { get; set; }

        public DaoObject(IStorage<T> storageMode)
        {
            StorageMode = storageMode;
        }

        public void Delete(T t) => StorageMode.Delete(t);
        public T Get(long id) => StorageMode.Get(id);
        public List<T> GetAll() => StorageMode.GetAll();
        public void Save(T t) => StorageMode.Save(t);
        public void Update(T t, params string[] @params) => StorageMode.Update(t, @params);
    }
}
