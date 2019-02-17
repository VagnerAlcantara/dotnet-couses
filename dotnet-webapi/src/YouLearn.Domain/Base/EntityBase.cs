using prmToolkit.NotificationPattern;
using System;

namespace YouLearn.Domain.Base
{
    public abstract class EntityBase : Notifiable
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
    }
}
