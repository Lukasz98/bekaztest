using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WymianaKsiazek.Api.Models
{
    public class UserOffersMP
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Boolean Type { get; set; }
        public decimal Price { get; set; }
        public virtual AddressMP Address { get; set; }
        public virtual BookMP Book { get; set; }
    }
}
