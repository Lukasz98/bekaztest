using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WymianaKsiazek.Api.Database.Entities;

namespace WymianaKsiazek.Api.Models
{
    public class UserMP
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserOffersMP> Offers { get; set; }
    }
}
