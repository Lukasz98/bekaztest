using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WymianaKsiazek.Api.Database.Entities;

namespace WymianaKsiazek.Api.Database
{
    public class UserEntity : IdentityUser //czy to dziedziczenie jest potrzebne? 
    {
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long AddressId { get; set; } //

        public virtual ICollection<OfferEntity> Offers { get; set; }

        public UserEntity()
        {
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
            Offers = new List<OfferEntity>();
        }
    }
}
