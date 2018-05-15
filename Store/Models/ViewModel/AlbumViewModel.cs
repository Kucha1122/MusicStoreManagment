using Store.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ViewModel
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public IEnumerable<Band> Bands { get; set; }
    }
}
