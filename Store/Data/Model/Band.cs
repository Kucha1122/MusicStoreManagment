using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.Model
{
    public class Band
    {
        public int BandId { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string BandName { get; set; }
        [MinLength(6),MaxLength(200)]
        public string BandDescription { get; set; }


        public virtual ICollection<Album> Albums { get; set; }
    }
}
