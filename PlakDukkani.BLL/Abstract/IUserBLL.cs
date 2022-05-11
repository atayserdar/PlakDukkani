using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.Model.Entities;
using PlakDukkani.ViewModel.UserViewModels;
using System;

namespace PlakDukkani.BLL.Abstract
{
    public interface IUserBLL : IBaseBLL<User>
    {
        ResultService<UserCreateVM> Insert(UserCreateVM user);
        ResultService<bool> ActivedUser(Guid guid);
        ResultService<bool> CheckUserForLogin(string email, string password);
    }
}
