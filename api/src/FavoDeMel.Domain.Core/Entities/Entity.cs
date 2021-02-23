﻿using Flunt.Notifications;
using System;

namespace FavoDeMel.Domain.Core.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
