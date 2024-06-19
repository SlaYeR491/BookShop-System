using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BookShop.Specifications
{
    public class CustomerDiscussionRoomEntityTypeConfiguration : IEntityTypeConfiguration<CustomerRoom>
    {
        public void Configure(EntityTypeBuilder<CustomerRoom> builder)
        {
            builder
                .HasKey(a => new { a.CustomerId, a.RoomId });

            builder
                .HasOne(a => a.Account)
                .WithMany(a => a.DiscussionRooms)
                .HasForeignKey(a => a.CustomerId)
                .HasPrincipalKey(a => a.Id);

            builder
                .HasOne(a => a.Room)
                .WithMany(a => a.Customers)
                .HasForeignKey(a => a.RoomId)
                .HasPrincipalKey(a => a.Id);
        }
    }
}
