using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WymianaKsiazek.Api.Database.Entities;

namespace WymianaKsiazek.Api.Database.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<OfferEntity>
    {
        public void Configure(EntityTypeBuilder<OfferEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Offers);
            builder.HasOne(x => x.Book).WithMany(x => x.Offers);
            builder.HasOne(x => x.Address).WithMany(x => x.Offers);

        }
    }
}
