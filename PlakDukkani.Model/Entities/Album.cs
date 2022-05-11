using PlakDukkani.Core.Entity;
using System.Collections.Generic;

namespace PlakDukkani.Model.Entities
{
    public class Album : BaseEntity
    {
        public Album()
        {
            OrderDetails = new HashSet<OrderDetail>();
            IsActive = true;
        }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public string AlbumArtUrl { get; set; }
        public bool Continued { get; set; } = true;
        public decimal Discount { get; set; } 
        public int ArtistID { get; set; }
        public int GenreID { get; set; }
        public Artist Artist { get; set; }
        public Genre Genre { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

}
