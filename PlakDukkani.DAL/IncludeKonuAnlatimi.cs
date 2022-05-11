using Microsoft.EntityFrameworkCore;
using PlakDukkani.DAL.Concrete.Context;
using PlakDukkani.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani.DAL
{
    class IncludeKonuAnlatimi

    {
        public IncludeKonuAnlatimi()
        {
            PlakDukkaniDbContext context = new PlakDukkaniDbContext();
            //lazy loading yok 
            List<Album> albums = context.Albums.Include(a => a.Artist).Include(a => a.Genre).ToList();        
            string fullNAme = albums[0].Artist.FullName;


            var numbers = new int[] { 1, 2, 3, 4 };
            int c = 5;
            var result = numbers.Aggregate(c, (a, b) => a * b);
            //5
            //1 * 2
            //2 * 3
            //6 * 4
            //24

            //includes {a=>a.Artist, a=>a.Genre}
            //seed = context.Albums. 

            //query= context.Albums.Include(a=>a.Artist)
            //context.Albums.Include(a=>a.Artist).Include(a=>a.Genre);
        }
    }
}
