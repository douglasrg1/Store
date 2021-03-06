using System;
using FluentValidator;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{

    public class Product : Entity
    {
        public Product(Guid id,string title, string description, string image, decimal price, decimal quantityOnHand)
        :base(id.ToString())
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }
        public Product(string title, string description, string image, decimal price, decimal quantityOnHand)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }


        public void DecreaseQuantity(decimal quantity)
        {
            QuantityOnHand -= quantity;
        }

    }
}