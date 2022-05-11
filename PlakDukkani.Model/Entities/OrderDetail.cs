using System;
using System.Collections.Generic;
using System.Text;

namespace PlakDukkani.Model.Entities
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int AlbumID { get; set; }
        public short Quantity { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Album.Price * Quantity * (1 - Album.Discount);
            }
        }
        public Order Order { get; set; }
        public Album Album { get; set; }
    }
}
