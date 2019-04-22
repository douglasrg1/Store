
using System;
using System.Collections.Generic;
using Store.Domain.StoreContext.Enums;
using System.Linq;
using FluentValidator;

namespace Store.Domain.StoreContext.Entities
{

    public class Order : Notifiable
    {
        private readonly ICollection<OrderItem> _itens;
        private readonly ICollection<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            NumberOrder = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _itens = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string NumberOrder { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IEnumerable<OrderItem> OrderItens { get { return _itens; } }
        public IEnumerable<Delivery> Deliveries { get { return _deliveries; } }

        public void Additem(OrderItem item)
        {
            _itens.Add(item);
        }
        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }

        public void PlaceOrder()
        {
            if (_itens.Count == 0)
                AddNotification("Order", "Este pedido n�o possui produtos");

        }
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        public void Ship()
        {
            var delivery = new Delivery(DateTime.Now.AddDays(5));
            _deliveries.Add(delivery);
            var cont = 1;

            foreach (var item in _itens)
            {
                if (cont == 5)
                {
                    cont = 1;
                    _deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                cont ++;
            }

            _deliveries.ToList().ForEach(x=> x.Ship());

        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x=>x.Cancel());
        }

    }
}