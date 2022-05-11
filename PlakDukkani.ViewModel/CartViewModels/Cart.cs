using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlakDukkani.ViewModel.CartViewModels
{
    public class Cart //sepet
    {
        private static Dictionary<int, CartItem> sepet = new Dictionary<int, CartItem>();

        public List<CartItem> GetCartItems => sepet.Values.ToList();
        public void Add(CartItem item) 
        {
            if (sepet.ContainsKey(item.ID)) 
            {
                sepet[item.ID].Quantity += item.Quantity;
                return;
            }
            sepet.Add(item.ID, item);
        }

        public void Update(int id, short quantity) 
        {
            if (sepet.ContainsKey(id)) 
            {
                sepet[id].Quantity = quantity;
            }
        }

        public void Delete(int id) 
        {
            if (sepet.ContainsKey(id)) 
            {
                sepet.Remove(id);
            }
        }

        public int TotalQuantity => sepet.Values.Sum(a => a.Quantity);
    }
}
