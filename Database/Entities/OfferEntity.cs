using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WymianaKsiazek.Api.Database.Entities
{
    public class OfferEntity
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public string Content { get; set; }
        public long AddressId { get; set; } 
        public DateTime CreatedOn { get; set; } 
        public DateTime UpdatedOn { get; set; } 
        public string UserId { get; set; }
        public Boolean Type { get; set; }
        public decimal Price { get; set; } //cos mu sie typ nie zgadza
        


        public virtual AddressEntity Address { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual BookEntity Book { get; set; }

        public OfferEntity()
        {
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
        }

        public static implicit operator OfferEntity(BookEntity v)
        {
            throw new NotImplementedException();
        }
    }
}
