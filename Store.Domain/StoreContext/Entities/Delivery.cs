
using System;
using FluentValidator;
using FluentValidator.Validation;
using Store.Domain.StoreContext.Enums;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{

    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate, Guid orderId)
        {
            OrderId = orderId;
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsGreaterOrEqualsThan(estimatedDeliveryDate,CreateDate,"EstimatedDelivery","Data estimada de entrega não pode ser menor que a data de criação")
                .IsNotNullOrEmpty(orderId.ToString(),"OrderId","A identificação do pedido a qual a entrega pertence é obrigatorio")
            );
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }
        public Guid OrderId { get; private set; }


        public void Ship()
        {
            if(Status == EDeliveryStatus.Canceled)
                AddNotification("Ship","A entrega foi cancelada e não pode ser alterado seu status");
                
            Status = EDeliveryStatus.Shipped;
        }
        public void Cancel()
        {
            Status = EDeliveryStatus.Canceled;
        }
    }
}