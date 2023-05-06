using COINEXEN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COINEXEN.Repository.Contexts.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasData
                (
                    new Category { Id = 1, Name = "1-Category", Description = "1-Category-Description" },
                    new Category { Id = 2, Name = "2-Category", Description = "2-Category-Description" },
                    new Category { Id = 3, Name = "3-Category", Description = "3-Category-Description" }
                );
        }
    }
}
