using System;
using FluentValidator;
using FluentValidator.Validation;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{

    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;

            AddNotifications(new ValidationContract()
            .Requires()
            .IsLowerOrEqualsThan(0,quantity,"Quantidade","Quantidade do produto não pode ser menor ou igual a 0")
            .IsNotNull(price,"Price","O valor do produto não pode ser nulo")
            .IsNotNull(product,"Product","O campo do produto não pode ser nulo")
            );

            if(quantity > product.QuantityOnHand)
                AddNotification("OrderItem",$"Quantidade do produto {product.Title} indisponivel");

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }

    }
}