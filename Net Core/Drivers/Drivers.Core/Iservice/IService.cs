using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Iservice
{
    public interface IService<T>
    {
        List<T> GetList();
        T GetById(int id);
        bool Update(int id, T value);
        bool Delete(int id);
        bool Add(T value);
    }
}
