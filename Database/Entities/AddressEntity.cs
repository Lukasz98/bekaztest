using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WymianaKsiazek.Api.Database.Entities
{
    public class AddressEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<OfferEntity> Offers { get; set; }

        public AddressEntity()
        {
            Offers = new List<OfferEntity>();
        }
    }
}
