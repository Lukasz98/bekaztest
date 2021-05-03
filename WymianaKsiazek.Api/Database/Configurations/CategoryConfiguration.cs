using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WymianaKsiazek.Api.Database.Entities;

namespace WymianaKsiazek.Api.Database.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<OfferEntity>
    {
        public void Configure(EntityTypeBuilder<OfferEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
