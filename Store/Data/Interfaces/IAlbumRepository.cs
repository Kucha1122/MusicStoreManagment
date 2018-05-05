using Store.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.Interfaces
{
    public interface IAlbumRepository : IRepository<Album>
    {
        IEnumerable<Album> GetAllWithBand();
        IEnumerable<Album> FindWithBand(Func<Album, bool> predicate);
        IEnumerable<Album> FindWithBandAndBorrower(Func<Album, bool> predicate);
    }
}
