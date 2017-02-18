using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        List<CartLines> lineCollection = new List<CartLines>();

        public void AddItem(Product product, int quantity)
        {
            CartLines item = lineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);
            if (item == null)
            {
                lineCollection.Add(new CartLines {Product = product, Quantity = quantity});
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            lineCollection.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(p => p.Quantity * p.Product.Price);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public List<CartLines> Lines { get { return lineCollection; } }
    }

    public class CartLines
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
