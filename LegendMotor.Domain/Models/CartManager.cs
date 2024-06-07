using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Domain.Models
{
    public sealed class CartManager
    {
        private static CartManager instance = null;
        private static readonly object padlock = new object();
        private List<CartItem> cartItems = new List<CartItem>();

        private CartManager()
        {
        }

        public static CartManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CartManager();
                    }
                    return instance;
                }
            }
        }

        public void AddItem(CartItem item)
        {
            if (cartItems.Exists(x => x.SparePartId == item.SparePartId))
            {
                return;
            }
            cartItems.Add(item);
        }

        public void RemoveItem(Guid sparePartId)
        {
            CartItem item = cartItems.Find(x => x.SparePartId.Equals(sparePartId));
            if (item != null)
            {
                cartItems.Remove(item);
            }
        }

        public List<CartItem> GetItems()
        {
            return cartItems;
        }

        public void Clear()
        {
            cartItems.Clear();
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (CartItem item in cartItems)
            {
                totalPrice += item.TotalPrice;
            }
            return totalPrice;
        }

        public CartItem UpdateItem(string spartPartId, int qty)
        {
            CartItem cartItem = cartItems.Find(x => x.SparePartId.Equals(spartPartId));
            if (cartItem != null)
            {
                cartItem.Quantity = qty;
            }
            return cartItem;
        }

        public void Reset()
        {
            foreach (CartItem item in cartItems)
            {
                item.Quantity = 0;
            }
        }
    }
}
