using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlakDukkani.BLL.Abstract;
using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.ViewModel.Constraints;
using PlakDukkani.ViewModel.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlakDukkani.UI.MVC.Controllers
{
    //TODO: Session Araştır 
    //Sepet Viewı oluştur 
    public class UserController : Controller
    {
        IUserBLL userService;
        public UserController(IUserBLL userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserCreateVM user)
        {
            if (ModelState.IsValid)
            {
                ResultService<UserCreateVM> resultService = userService.Insert(user);
                return RedirectToAction(nameof(Login));
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult ActivedUser(Guid id)
        {
            ResultService<bool> result = userService.ActivedUser(id);
            if (result.Data)
            {
                return RedirectToAction(nameof(Login), nameof(UserController));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (Request.Cookies["cookie"] != null)
            {
                string bilgi = Request.Cookies["cookie"];
                string[] bilgiParcasi = bilgi.Split("|");
                UserLoginVM userLogin = new UserLoginVM();
                userLogin.Email = bilgiParcasi[0];
                userLogin.Password = bilgiParcasi[1];
                userLogin.IsRemember = true;
                return View(userLogin);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginVM user)
        {
            if (user.IsRemember)
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(10);

                Response.Cookies.Append("cookie", user.Email + "|" + user.Password, cookieOptions);
            }
            else
            {
                //Cookie nasıl silinir.
            }
            if (ModelState.IsValid)
            {
                ResultService<bool> result = userService.CheckUserForLogin(user.Email, user.Password);
                if (result.HasError)
                {
                    ViewBag.Message = UserMessage.LoginMessage;
                }
                else
                {
                    return RedirectToAction(nameof(Index), "Home");
                }
            }
            return View();

        }
    }
}
