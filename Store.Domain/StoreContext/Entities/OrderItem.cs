using System;
using FluentValidator;

namespace Store.Domain.StoreContext.Entities
{

    public class OrderItem : Notifiable
    {
        public OrderItem(Product product, decimal quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;

            if(quantity > product.QuantityOnHand)
                AddNotification("OrderItem",$"Quantidade do produto {product.Title} indisponivel");

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }

    }
}