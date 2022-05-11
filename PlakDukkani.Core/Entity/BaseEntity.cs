using System;
using System.Collections.Generic;
using System.Text;

namespace PlakDukkani.Core.Entity
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
