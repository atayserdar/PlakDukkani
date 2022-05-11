using Microsoft.Extensions.DependencyInjection;
using PlakDukkani.DAL.Abstract;
using PlakDukkani.DAL.Concrete.Context;
using PlakDukkani.DAL.Concrete.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani.DAL.Concrete.DependencyInjection
{
    public static class EFContextDAL
    {
        public static void AddScopeDAL(this IServiceCollection services)
        {
            services.AddDbContext<PlakDukkaniDbContext>();
            services.AddScoped<IAlbumDAL, AlbumRepository>();
            services.AddScoped<IArtistDAL, ArtistRepository>();
            services.AddScoped<IGenreDAL, GenreRepository>();
            services.AddScoped<IOrderDAL, OrderRepository>();
            services.AddScoped<IUserDAL, UserRepository>();
        }
    }
}
