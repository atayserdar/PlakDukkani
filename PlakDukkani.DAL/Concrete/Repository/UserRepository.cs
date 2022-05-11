using PlakDukkani.Core.DataAccess.EntityFramework;
using PlakDukkani.DAL.Abstract;
using PlakDukkani.DAL.Concrete.Context;
using PlakDukkani.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlakDukkani.DAL.Concrete.Repository
{
    class UserRepository : EFRepositoryBase<User, PlakDukkaniDbContext>, IUserDAL
    {
        public UserRepository(PlakDukkaniDbContext context) : base(context)
        {
        }
    }
}
