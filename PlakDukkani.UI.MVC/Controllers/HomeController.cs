using Microsoft.AspNetCore.Mvc;
using PlakDukkani.BLL.Abstract;
using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.ViewModel.AlbumViewModels;
using PlakDukkani.ViewModel.Constraints;
using System.Collections.Generic;

namespace PlakDukkani.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        //SOLID D => Dependency Inversion 
        //Dependency Injection Pattern 
        //Ctor Dep Injection 
        IAlbumBLL albumService;
        public HomeController(IAlbumBLL albumService)
        {
            this.albumService = albumService;
        }

        //IAlbumBLL albumservice = new AlbumService();
        public IActionResult Index()
        {
            ResultService<List<SingleAlbumVM>> albumResult = albumService.GetSingleAlbums();
            if (!albumResult.HasError)
            {
                return View(albumResult.Data);
            }
            else
            {
                ViewBag.Message = albumResult.Errors[0].ErrorMessage;
                return View();
            }
        }

        public IActionResult AlbumDetail(int id)
        {
            ResultService<AlbumDetailVM> result = albumService.GetAlbumById(id);
            if (result.HasError) 
            {
                ViewBag.Message = AlbumMessage.idHatasi;
                return View();
            }         
            return View(result.Data);
        }
        public IActionResult AlbumStore()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
