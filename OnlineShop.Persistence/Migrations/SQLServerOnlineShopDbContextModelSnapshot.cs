﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Persistence.Db.SqlServer;

#nullable disable

namespace OnlineShop.Persistence.Migrations
{
    [DbContext(typeof(SQLServerOnlineShopDbContext))]
    partial class SQLServerOnlineShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineShop.Domain.Models.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardDataHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.BuyItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductPropertyValuesInventoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductPropertyValuesInventoryId");

                    b.ToTable("BuyItems");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CartId")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BankAccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("YearOfProduction")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.ProductPropertyValuesInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPropertyValuesInventories");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartId")
                        .IsUnique()
                        .HasFilter("[CartId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("OnlineShop.Domain.Relations.CategoryProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PropertyId");

                    b.ToTable("CategoryProperties");
                });

            modelBuilder.Entity("OnlineShop.Domain.Relations.ProductPropertyValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductPropertyValuesInventoryId")
                        .HasColumnType("int");

                    b.Property<int?>("PropertyValueId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductPropertyValuesInventoryId");

                    b.HasIndex("PropertyValueId");

                    b.ToTable("ProductPropertyValue");
                });

            modelBuilder.Entity("OnlineShop.Domain.Relations.PropertyValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ValueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("ValueId");

                    b.ToTable("PropertyValues");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.BankAccount", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.User", "User")
                        .WithMany("BankAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.BuyItem", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Cart", "Cart")
                        .WithMany("BuyItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Domain.Models.ProductPropertyValuesInventory", "ProductPropertyValuesInventory")
                        .WithMany("BuyItems")
                        .HasForeignKey("ProductPropertyValuesInventoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("ProductPropertyValuesInventory");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Order", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Cart", "Cart")
                        .WithOne("Order")
                        .HasForeignKey("OnlineShop.Domain.Models.Order", "CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Payment", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.BankAccount", "BankAccount")
                        .WithMany("Payments")
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnlineShop.Domain.Models.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("OnlineShop.Domain.Models.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("BankAccount");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Product", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.ProductPropertyValuesInventory", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Product", "Product")
                        .WithMany("ProductPropertyValuesInventories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Review", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.User", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Cart", "Cart")
                        .WithOne("User")
                        .HasForeignKey("OnlineShop.Domain.Models.User", "CartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("OnlineShop.Domain.Relations.CategoryProperty", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Category", "Category")
                        .WithMany("CategoryProperties")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OnlineShop.Domain.Models.Property", "Property")
                        .WithMany("CategoryProperties")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Category");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("OnlineShop.Domain.Relations.ProductPropertyValue", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.ProductPropertyValuesInventory", "ProductPropertyValuesInventory")
                        .WithMany("ProductPropertyValues")
                        .HasForeignKey("ProductPropertyValuesInventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Domain.Relations.PropertyValue", "PropertyValue")
                        .WithMany("ProductPropertyValues")
                        .HasForeignKey("PropertyValueId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ProductPropertyValuesInventory");

                    b.Navigation("PropertyValue");
                });

            modelBuilder.Entity("OnlineShop.Domain.Relations.PropertyValue", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Property", "Property")
                        .WithMany("PropertyValues")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnlineShop.Domain.Models.Value", "Value")
                        .WithMany("PropertyValues")
                        .HasForeignKey("ValueId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Property");

                    b.Navigation("Value");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.BankAccount", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Cart", b =>
                {
                    b.Navigation("BuyItems");

                    b.Navigation("Order")
                        .IsRequired();

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Category", b =>
                {
                    b.Navigation("CategoryProperties");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Order", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Product", b =>
                {
                    b.Navigation("ProductPropertyValuesInventories");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.ProductPropertyValuesInventory", b =>
                {
                    b.Navigation("BuyItems");

                    b.Navigation("ProductPropertyValues");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Property", b =>
                {
                    b.Navigation("CategoryProperties");

                    b.Navigation("PropertyValues");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.User", b =>
                {
                    b.Navigation("BankAccounts");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Value", b =>
                {
                    b.Navigation("PropertyValues");
                });

            modelBuilder.Entity("OnlineShop.Domain.Relations.PropertyValue", b =>
                {
                    b.Navigation("ProductPropertyValues");
                });
#pragma warning restore 612, 618
        }
    }
}
