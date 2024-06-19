using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BookShop.Specifications
{
    public class RoomDetialEntityTypeConfiguration : IEntityTypeConfiguration<RoomDetail>
    {
        public void Configure(EntityTypeBuilder<RoomDetail> builder)
        {
            builder
                .HasOne(a => a.Customer)
                .WithMany(a => a.Messages)
                .HasForeignKey(a => a.CustomerId)
                .HasPrincipalKey(a => a.Id);
            builder
                .HasOne(a => a.Room)
                .WithMany(a => a.Details)
                .HasForeignKey(a => a.RoomId)
                .HasPrincipalKey(a => a.Id);
        }
    }
}
