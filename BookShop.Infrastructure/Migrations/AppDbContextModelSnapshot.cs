﻿// <auto-generated />
using System;
using BookShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookShop.Data.AdminAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdminAccounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = false,
                            Password = "�\r�Ⱥ�������-���n�	��t&N",
                            UserName = "Ahmed"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = false,
                            Password = "���9�\"C	�N�}�pT����گ ���3-�",
                            UserName = "Mohamed"
                        });
                });

            modelBuilder.Entity("BookShop.Data.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Anaïs",
                            Code = 64541,
                            Description = "Other specified joint disorders, unspecified ankle and foot",
                            Price = 34m,
                            Quantity = 564,
                            Title = "Wizards"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Josée",
                            Code = 489645,
                            Description = "Foreign body on external eye, part unsp, right eye, init",
                            Price = 16m,
                            Quantity = 70,
                            Title = "Arbor, The"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Garçon",
                            Code = 65949,
                            Description = "Complete placenta previa with hemorrhage, unsp trimester",
                            Price = 94m,
                            Quantity = 652,
                            Title = "Il Capitano"
                        });
                });

            modelBuilder.Entity("BookShop.Data.CustomerAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerAccounts", (string)null);
                });

            modelBuilder.Entity("BookShop.Data.CustomerBook", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BookId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerBooks", (string)null);
                });

            modelBuilder.Entity("BookShop.Data.CustomerRoom", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("CustomerRooms", (string)null);
                });

            modelBuilder.Entity("BookShop.Data.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("BookShop.Data.PaymentBook", b =>
                {
                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Qauntity")
                        .HasColumnType("int");

                    b.HasKey("PaymentId", "BookId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("PaymentBooks", (string)null);
                });

            modelBuilder.Entity("BookShop.Data.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("BookShop.Data.RoomDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomDetails", (string)null);
                });

            modelBuilder.Entity("BookShop.Data.CustomerBook", b =>
                {
                    b.HasOne("BookShop.Data.Book", "Book")
                        .WithMany("CustomerBooksList")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.Data.CustomerAccount", "Account")
                        .WithMany("CustomerBooksList")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookShop.Data.CustomerRoom", b =>
                {
                    b.HasOne("BookShop.Data.CustomerAccount", "Account")
                        .WithMany("DiscussionRooms")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.Data.Room", "Room")
                        .WithMany("Customers")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BookShop.Data.Payment", b =>
                {
                    b.HasOne("BookShop.Data.CustomerAccount", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BookShop.Data.PaymentBook", b =>
                {
                    b.HasOne("BookShop.Data.Book", "Book")
                        .WithOne("Payment")
                        .HasForeignKey("BookShop.Data.PaymentBook", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.Data.Payment", "Payment")
                        .WithMany("books")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("BookShop.Data.Room", b =>
                {
                    b.HasOne("BookShop.Data.Book", "Book")
                        .WithOne("DiscussionRoom")
                        .HasForeignKey("BookShop.Data.Room", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookShop.Data.RoomDetail", b =>
                {
                    b.HasOne("BookShop.Data.CustomerAccount", "Customer")
                        .WithMany("Messages")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.Data.Room", "Room")
                        .WithMany("Details")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BookShop.Data.Book", b =>
                {
                    b.Navigation("CustomerBooksList");

                    b.Navigation("DiscussionRoom")
                        .IsRequired();

                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("BookShop.Data.CustomerAccount", b =>
                {
                    b.Navigation("CustomerBooksList");

                    b.Navigation("DiscussionRooms");

                    b.Navigation("Messages");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("BookShop.Data.Payment", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("BookShop.Data.Room", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
