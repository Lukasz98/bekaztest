using System;
using System.Collections.Generic;
using WymianaKsiazek.Api.Database.Entities;

namespace WymianaKsiazek.Api.Database.Entities
{
    public class BookEntity
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public long CategoryId { get; set; } //

        public string Isbn { get; set; } //

        public virtual ICollection<OfferEntity> Offers { get; set; }

        public virtual CategoryEntity Category { get; set; }
        public BookEntity()
        {
            Offers = new List<OfferEntity>();
        }
    }
}
