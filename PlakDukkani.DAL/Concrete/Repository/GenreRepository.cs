using PlakDukkani.Core.DataAccess.EntityFramework;
using PlakDukkani.DAL.Abstract;
using PlakDukkani.DAL.Concrete.Context;
using PlakDukkani.Model.Entities;

namespace PlakDukkani.DAL.Concrete.Repository
{
    class GenreRepository : EFRepositoryBase<Genre, PlakDukkaniDbContext>, IGenreDAL
    {
        public GenreRepository(PlakDukkaniDbContext context) : base(context)
        {
        }
    }
}
