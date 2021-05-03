using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WymianaKsiazek.Api.Database.Entities;

namespace WymianaKsiazek.Api.Database.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Category).WithMany(x => x.Books);


        }
    }
}
