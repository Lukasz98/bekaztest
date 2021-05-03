using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WymianaKsiazek.Api.Database.Entities
{
    public class CategoryEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BookEntity> Books { get; set; }

        public CategoryEntity()
        {
            Books = new List<BookEntity>();
        }
    }
}
