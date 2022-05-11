using PlakDukkani.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlakDukkani.Model.Entities
{
    public class Artist:BaseEntity
    {
        public Artist()
        {
            IsActive = true;
            Albums = new HashSet<Album>();
        }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
