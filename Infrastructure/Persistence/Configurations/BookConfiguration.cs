using Domain.Entities.BookEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            ConfigureateBooksTable(builder);
        }

        private void ConfigureateBooksTable(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsMany(x => x.Reviews, rb =>
            {
                rb.WithOwner().HasForeignKey("BookId");

            });

            builder.OwnsMany(x => x.Ratings, rb =>
            {
                rb.WithOwner().HasForeignKey("BookId");
                rb.HasKey("Id", "BookId");

            });
        }
    }
}
