﻿// <auto-generated />
using System;
using LorKingDom_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LorKingDom_Management_System.Migrations
{
    [DbContext(typeof(LorKingDomManagementContext))]
    [Migration("20250316130328_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LorKingDom_Management_System.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasDefaultValue("Active");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("AccountId")
                        .HasName("PK__Account__349DA586A4CD6773");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "PhoneNumber" }, "UQ__Account__85FB4E38C5B643C2")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Account__A9D105345AE8C599")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("CategoryId")
                        .HasName("PK__Category__19093A2BC5613401");

                    b.HasIndex(new[] { "Name" }, "UQ__Category__737584F67D7558EE")
                        .IsUnique();

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int")
                        .HasColumnName("PaymentMethodID");

                    b.Property<int>("ShippingMethodId")
                        .HasColumnType("int")
                        .HasColumnName("ShippingMethodID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasDefaultValue("Pending");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("OrderId")
                        .HasName("PK__Orders__C3905BAF7132AEF7");

                    b.HasIndex("AccountId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("ShippingMethodId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderDetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<decimal?>("Discount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(5, 2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("Total")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("decimal(34, 8)")
                        .HasComputedColumnSql("(([Quantity]*[UnitPrice])*((1)-[Discount]/(100)))", true);

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(12, 2)");

                    b.HasKey("OrderDetailId")
                        .HasName("PK__OrderDet__D3B9D30C6F1FA5A6");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PaymentMethodID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentMethodId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentMethodId")
                        .HasName("PK__PaymentM__DC31C1F3DB48AB8E");

                    b.HasIndex(new[] { "MethodName" }, "UQ__PaymentM__218CFB17D6D7FEA7")
                        .IsUnique();

                    b.ToTable("PaymentMethod", (string)null);
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasDefaultValue("Available");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("ProductId")
                        .HasName("PK__Product__B40CC6ED2FC03E2F");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId")
                        .HasName("PK__Role__8AFACE3AB75C199E");

                    b.HasIndex(new[] { "RoleName" }, "UQ__Role__8A2B6160875F18CA")
                        .IsUnique();

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.ShippingMethod", b =>
                {
                    b.Property<int>("ShippingMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShippingMethodID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShippingMethodId"));

                    b.Property<DateOnly?>("DateTo")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ShippingMethodId")
                        .HasName("PK__Shipping__0C783384050F4EB0");

                    b.HasIndex(new[] { "MethodName" }, "UQ__Shipping__218CFB17E04F00ED")
                        .IsUnique();

                    b.ToTable("ShippingMethod", (string)null);
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Account", b =>
                {
                    b.HasOne("LorKingDom_Management_System.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Account__Updated__534D60F1");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Order", b =>
                {
                    b.HasOne("LorKingDom_Management_System.Models.Account", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__AccountI__6EF57B66");

                    b.HasOne("LorKingDom_Management_System.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentMethodId")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__PaymentM__6FE99F9F");

                    b.HasOne("LorKingDom_Management_System.Models.ShippingMethod", "ShippingMethod")
                        .WithMany("Orders")
                        .HasForeignKey("ShippingMethodId")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__Shipping__70DDC3D8");

                    b.Navigation("Account");

                    b.Navigation("PaymentMethod");

                    b.Navigation("ShippingMethod");
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.OrderDetail", b =>
                {
                    b.HasOne("LorKingDom_Management_System.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__OrderDeta__Order__778AC167");

                    b.HasOne("LorKingDom_Management_System.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderDeta__Produ__787EE5A0");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Product", b =>
                {
                    b.HasOne("LorKingDom_Management_System.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Product__Categor__60A75C0F");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Account", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.PaymentMethod", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("LorKingDom_Management_System.Models.ShippingMethod", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
