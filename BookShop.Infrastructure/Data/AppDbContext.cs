using BookShop.Data;
using BookShop.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookShop.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions op) : base(op)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PaymentBookEntityTypeConfiguration().Configure(modelBuilder.Entity<PaymentBook>());

            new DiscussionRoomEntityTypeConfiguration().Configure(modelBuilder.Entity<Room>());

            new CustomerDiscussionRoomEntityTypeConfiguration().Configure(modelBuilder.Entity<CustomerRoom>());

            new CustomerBooksListEntityTypeConfiguration().Configure(modelBuilder.Entity<CustomerBook>());

            new AdminAccountEntityTypeConfiguration().Configure(modelBuilder.Entity<AdminAccount>());

            new BookEntityTypeConfiguration().Configure(modelBuilder.Entity<Book>());

            new RoomDetialEntityTypeConfiguration().Configure(modelBuilder.Entity<RoomDetail>());

            modelBuilder.Entity<AdminAccount>().ToTable("AdminAccounts");

            modelBuilder.Entity<Book>().ToTable("Books");

            modelBuilder.Entity<CustomerAccount>().ToTable("CustomerAccounts");

            modelBuilder.Entity<CustomerBook>().ToTable("CustomerBooks");

            modelBuilder.Entity<CustomerRoom>().ToTable("CustomerRooms");

            modelBuilder.Entity<Payment>().ToTable("Payments");

            modelBuilder.Entity<PaymentBook>().ToTable("PaymentBooks");

            modelBuilder.Entity<Room>().ToTable("Rooms");

            modelBuilder.Entity<RoomDetail>().ToTable("RoomDetails");

        }
    }
}
