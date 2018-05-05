using Store.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.Interfaces
{
    public interface IBandRepository : IRepository<Band>
    {
        IEnumerable<Band> GetAllWithAlbums();
        Band GetWithAlbums(int id);
    }
}
