using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.Model
{
    public class Album
    {
        public int AlbumId { get; set; }
        [Required(ErrorMessage = "Tytuł jest wymagany!"), MinLength(3), MaxLength(50)]
        public string Title { get; set; }
        [DataType(DataType.ImageUrl)]
        public string AlbumArtUrl { get; set; }
        [MinLength(6),MaxLength(250)]
        public string AlbumDescription { get; set; }
        public int AlbumPrice { get; set; }

        public virtual Band Band { get; set; }
        public int BandId { get; set; }

        public virtual Customer Borrower { get; set; }
        public int BorrowerId { get; set; }
    }
}
