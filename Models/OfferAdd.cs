using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WymianaKsiazek.Api.Models
{
    public class OfferAdd
    {
        public string Content { get; set; }
        public decimal Price { get; set; }
        public Boolean Type { get; set; }
        public virtual BookAdd Book { get; set; }
        public long AddressId { get; set; }
    }
}
