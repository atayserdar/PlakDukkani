using PlakDukkani.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlakDukkani.Model.Entities
{
    public class Genre:BaseEntity
    {
        public Genre()
        {
            IsActive = true;
            Albums = new HashSet<Album>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
