using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Specifications
{
    public class AdminAccountEntityTypeConfiguration : IEntityTypeConfiguration<AdminAccount>
    {
        public void Configure(EntityTypeBuilder<AdminAccount> builder)
        {

            builder
                .HasData(
                [
                    new AdminAccount { Id = 1, UserName = "Ahmed", Password = "�\r\u0017�Ⱥ�\u0006������-��\u0019�\u001en�\u0006\t��t\u001c&N" },
                    new AdminAccount { Id = 2, UserName = "Mohamed", Password = "���9�\"C\t�N�}�pT��\u001d��گ \u001c\u0001�\u0001��3-�" }
                ]);
            
        }
    }
}
