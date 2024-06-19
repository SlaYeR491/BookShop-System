using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BookShop.Specifications
{
    public class DiscussionRoomEntityTypeConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder
                .HasOne(x => x.Book)
                .WithOne(x => x.DiscussionRoom)
                .HasForeignKey<Room>(f => f.BookId)
                .HasPrincipalKey<Book>(p => p.Id);
        }
    }
}
