using PlakDukkani.BLL.Abstract;
using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.DAL.Abstract;
using PlakDukkani.Model.Entities;
using PlakDukkani.ViewModel.AlbumViewModels;
using PlakDukkani.ViewModel.CartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlakDukkani.BLL.Concrete
{
    public class AlbumService : IAlbumBLL
    {
        IAlbumDAL albumDAL;
        public AlbumService(IAlbumDAL albumDAL)
        {
            this.albumDAL = albumDAL;
        }

        public ResultService<AlbumDetailVM> GetAlbumById(int id)
        {
            ResultService<AlbumDetailVM> result = new ResultService<AlbumDetailVM>();
            Album album = albumDAL.Get(a => a.ID == id && a.Continued && a.IsActive, a => a.Artist, a => a.Genre);
            if (album == null)
            {
                result.AddError("Null Hatası", "id ile uyumlu Album yok");
                return result;
            }
            result.Data = new AlbumDetailVM()
            {
                ID = album.ID,
                Title = album.Title,
                GenreName = album.Genre.Name,
                ArtistFullName = album.Artist.FullName,
                Discount = album.Discount,
                AlbumArtUrl = album.AlbumArtUrl,
                Price = album.Price
            };
            return result;
        }

        public ResultService<CartItem> GetCartById(int id)
        {
            ResultService<CartItem> result = new ResultService<CartItem>();
            Album album = albumDAL.Get(a => a.ID == id && a.Continued && a.IsActive);
            if (album == null)
            {
                result.AddError("Null Hatası", "id ile uyumlu Album yok");
                return result;
            }
            result.Data = new CartItem()
            {
                ID = album.ID,
                Title = album.Title,
                Discount = album.Discount,
                Price = album.Price
            };
            return result;
        }

        public ResultService<List<SingleAlbumVM>> GetSingleAlbums()
        {
            ResultService<List<SingleAlbumVM>> resultService = new ResultService<List<SingleAlbumVM>>();
            try
            {
                List<SingleAlbumVM> singleAlbums = albumDAL.GetAll(a => a.IsActive && a.Continued, a => a.Artist, a => a.Genre)
                        .OrderByDescending(a => a.CreatedDate).Take(12)
                        .Select(album => new SingleAlbumVM
                        {
                            ID = album.ID,
                            FullName = album.Artist.FullName,
                            AlbumArtUrl = album.AlbumArtUrl,
                            Price = album.Price,
                            Title = album.Title
                        }).ToList();
                resultService.Data = singleAlbums;
            }
            catch (Exception ex)
            {
                resultService.AddError("exception", ex.Message);
            }

            return resultService;
        }
    }
}
