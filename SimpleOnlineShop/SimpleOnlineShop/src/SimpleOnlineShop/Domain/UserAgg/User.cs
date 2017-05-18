using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SimpleOnlineShop.SimpleOnlineShop.Domain.AuthEntitiesAgg;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg.Events;
using SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg.RegexHelper;
using SimpleOnlineShop.SimpleOnlineShop.Infrastructure.Events;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain.UserAgg
{
    public class User : IAggregateRoot
    {
        public static User Create(string firstName, string lastName, Gender gender, string address, string email, string contactNo)
        {
            if(!RegexUtilities.IsValidContactNo(contactNo))
                throw new ArgumentException("Invalid contact number {0}", contactNo);
            if(!RegexUtilities.IsValidEmail(email))
                throw new ArgumentException("Invalid email {0}", email);
            
            var customer = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Email = email,
                ContactNo = contactNo,
                Gender = gender
            };

            DomainEvent.Raise(new UserCreated
            {
                User = customer
            });

            return customer;
        }

        protected User() { }

        public long Id { get; set; }

        public virtual string FirstName { get; private set; }
        public virtual string LastName { get; private set; }

        public virtual string Name => $"{LastName}, {FirstName}";

        public virtual Gender Gender { get; protected set; }

        public virtual string Address { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string ContactNo { get; protected set; }
    

        public virtual IList<Order> Orders { get; protected set; } = new List<Order>();
        public virtual IList<UserRole> Roles { get; protected set; } = new List<UserRole>();

        public virtual void ChangeEmail(string newEmail)
        {
            DomainEvent.Raise(new UserEmailChanged
            {
                CustomerId = Id,
                OldEmail = Email,
                NewEmail = newEmail
            });

            if (!RegexUtilities.IsValidEmail(newEmail))
                throw new ArgumentException("Invalid email {0}", nameof(newEmail));

            Email = newEmail;
        }

        public virtual void ChangeContactNo(string newNumber)
        {
            DomainEvent.Raise(new UserContactNoChanged
            {
                CustomerId = Id,
                OldContactNo = ContactNo,
                NewContactNo = newNumber
            });

            if (!RegexUtilities.IsValidContactNo(newNumber))
                throw new ArgumentException("Invalid contact number {0}", nameof(newNumber));
            ContactNo = newNumber;
        }

        public virtual void AddOrder(Order order)
        {
            DomainEvent.Raise(new UserAddedOrder
            {
                Order = order
            });
            Orders.Add(order);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}