using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BookShop.Specifications
{
    public class PaymentBookEntityTypeConfiguration : IEntityTypeConfiguration<PaymentBook>
    {
        public void Configure(EntityTypeBuilder<PaymentBook> builder)
        {
            builder
               .HasOne(x => x.Book)
               .WithOne(x => x.Payment)
               .HasForeignKey<PaymentBook>(f => f.BookId)
               .HasPrincipalKey<Book>(p => p.Id);

            builder
                .HasOne(x => x.Payment)
                .WithMany(x => x.books)
                .HasForeignKey(f => f.PaymentId)
                .HasPrincipalKey(p => p.Id);

            builder
                .HasKey(p => new { p.PaymentId, p.BookId});
        }
    }
}
