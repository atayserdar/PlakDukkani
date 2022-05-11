using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.Model.Entities;
using PlakDukkani.ViewModel.AlbumViewModels;
using PlakDukkani.ViewModel.CartViewModels;
using System.Collections.Generic;

namespace PlakDukkani.BLL.Abstract
{
    public interface IAlbumBLL : IBaseBLL<Album>
    {
        ResultService<List<SingleAlbumVM>> GetSingleAlbums();
        ResultService<AlbumDetailVM> GetAlbumById(int id);
        ResultService<CartItem> GetCartById(int id);
    }
}
