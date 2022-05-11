using Microsoft.Extensions.DependencyInjection;
using PlakDukkani.BLL.Abstract;
using PlakDukkani.BLL.Concrete;
using PlakDukkani.DAL.Concrete.DependencyInjection;

namespace PlakDukkani.BLL.Concrete.DependencyInjection
{
    public static class EFContextBLL
    {
        //extension Metot
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopeDAL();
            services.AddScoped<IAlbumBLL, AlbumService>();
            services.AddScoped<IArtistBLL, ArtistService>();
            services.AddScoped<IUserBLL, UserService>();
            services.AddScoped<IGenreBLL, GenreService>();
            services.AddScoped<IOrderBLL, OrderService>();
        }
    }
}
