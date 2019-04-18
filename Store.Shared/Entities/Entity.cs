using System;
using FluentValidator;

namespace Store.Shared.Entities
{

    public abstract class Entity : Notifiable
    {
        public Entity(string id = null)
        {
            if(id== null)
                Id = Guid.NewGuid();
            else
                Id =Guid.Parse(id);
        }

        public Guid Id;

    }
}