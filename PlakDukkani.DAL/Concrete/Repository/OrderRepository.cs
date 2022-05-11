using PlakDukkani.Core.DataAccess.EntityFramework;
using PlakDukkani.DAL.Abstract;
using PlakDukkani.DAL.Concrete.Context;
using PlakDukkani.Model.Entities;

namespace PlakDukkani.DAL.Concrete.Repository
{
    class OrderRepository : EFRepositoryBase<Order, PlakDukkaniDbContext>, IOrderDAL
    {
        public OrderRepository(PlakDukkaniDbContext context) : base(context)
        {
        }
    }
}
