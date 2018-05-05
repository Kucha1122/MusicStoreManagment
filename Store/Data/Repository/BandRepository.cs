using Microsoft.EntityFrameworkCore;
using Store.Data.Interfaces;
using Store.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.Repository
{
    public class BandRepository : Repository<Band>, IBandRepository
    {
        public BandRepository(StoreDbContext context) : base(context)
        {
                
        }
        public IEnumerable<Band> GetAllWithAlbums()
        {
            return _context.Bands.Include(a => a.Albums);
        }

        public Band GetWithAlbums(int id)
        {
            return _context.Bands
                .Where(a => a.BandId == id)
                .Include(a => a.Albums)
                .FirstOrDefault();
        }
    }
}
