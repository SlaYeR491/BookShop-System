using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BookShop.Specifications
{
    public class CustomerBooksListEntityTypeConfiguration : IEntityTypeConfiguration<CustomerBook>
    {
        public void Configure(EntityTypeBuilder<CustomerBook> builder)
        {
            builder
                .HasKey(a => new { a.BookId, a.CustomerId });

            builder
            .HasOne(a => a.Book)
            .WithMany(a => a.CustomerBooksList)
            .HasForeignKey(f => f.BookId);

            builder
            .HasOne(a => a.Account)
            .WithMany(a => a.CustomerBooksList)
            .HasForeignKey(f => f.CustomerId);
        }
    }
}
