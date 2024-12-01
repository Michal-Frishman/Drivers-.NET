using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.IRepository
{
    public interface IRepository<T>
    {
        List<T> GetAllData();
        T GetByIdData(int id);
        bool AddData(T t);
        bool UpdateData(int id, T value);
        bool RemoveItemFromData(int id);
    }
}
