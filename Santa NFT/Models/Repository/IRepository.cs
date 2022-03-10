using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_NFT.Models.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        List<T> GetAll();
        string AddOrUpdate(T t);
        string Delete(T t);

    }
}
