using Microsoft.EntityFrameworkCore;
using Store.Data.Interfaces;
using Store.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(StoreDbContext context) : base(context)
        {
                
        }
        public IEnumerable<Album> FindWithBand(Func<Album, bool> predicate)
        {
            return _context.Albums
                .Include(a => a.Band)
                .Where(predicate);
        }

        public IEnumerable<Album> FindWithBandAndBorrower(Func<Album, bool> predicate)
        {
            return _context.Albums
                .Include(a => a.Band)
                .Include(a => a.Borrower)
                .Where(predicate);
        }

        public IEnumerable<Album> GetAllWithBand()
        {
            return _context.Albums.Include(a => a.Band);
        }
    }
}
