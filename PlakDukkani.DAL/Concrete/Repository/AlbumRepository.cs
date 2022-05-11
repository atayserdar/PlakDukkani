using PlakDukkani.Core.DataAccess.EntityFramework;
using PlakDukkani.DAL.Abstract;
using PlakDukkani.DAL.Concrete.Context;
using PlakDukkani.Model.Entities;

namespace PlakDukkani.DAL.Concrete.Repository
{
    class AlbumRepository : EFRepositoryBase<Album, PlakDukkaniDbContext>, IAlbumDAL
    {
        public AlbumRepository(PlakDukkaniDbContext context) : base(context)
        {
        }       
    }
}
