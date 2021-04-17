using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecrutaTi.Domain.Entities;

namespace RecrutaTi.Repository.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.SocialNetWorks)
                .WithOne(x => x.Company)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}