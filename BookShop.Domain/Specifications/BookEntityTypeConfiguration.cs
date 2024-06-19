using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
namespace BookShop.Specifications
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            
            builder
                .HasData(
                [
                    new Book()
                    {
                        Id = 1,
                        Title = "Wizards",
                        Description = "Other specified joint disorders, unspecified ankle and foot",
                        Code = 64541,
                        Author = "Anaïs",
                        Price = 34,
                        Quantity = 564
                    },
                    new Book()
                    {
                        Id = 2,
                        Title = "Arbor, The",
                        Description = "Foreign body on external eye, part unsp, right eye, init",
                        Code = 489645,
                        Author = "Josée",
                        Price = 16,
                        Quantity = 70
                    },
                    new Book()
                    {
                        Id = 3,
                        Title = "Il Capitano",
                        Description = "Complete placenta previa with hemorrhage, unsp trimester",
                        Code = 65949,
                        Author = "Garçon",
                        Price = 94,
                        Quantity = 652
                    }
                ]);
        }
    }
}
