﻿// <auto-generated />
using System;
using MCV.Models.DBnhom6;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DBnhom6TT))]
    [Migration("20231102140545_tttn")]
    partial class tttn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MCV.Models.Account", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MCV.Models.Address", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("AccountId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("MCV.Models.Brand", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            id = new Guid("e45d58da-6a80-4e1e-8d9e-d7ebfb1f2646"),
                            Status = true,
                            name = "Adidas"
                        },
                        new
                        {
                            id = new Guid("268f2def-ebb5-4a5f-a639-d6b98ab69130"),
                            Status = true,
                            name = "Nike"
                        });
                });

            modelBuilder.Entity("MCV.Models.Cart", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("AccountId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("MCV.Models.CartDetail", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("ShoeDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("CartId");

                    b.HasIndex("ShoeDetailId");

                    b.ToTable("CartDetail");
                });

            modelBuilder.Entity("MCV.Models.Category", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            id = new Guid("a8346b54-746f-4faa-9671-ef77a3d39812"),
                            Status = true,
                            name = "Đế thấp"
                        },
                        new
                        {
                            id = new Guid("f57e63dc-3625-4a46-98fc-39af9a63a96d"),
                            Status = true,
                            name = "Đế vừa"
                        },
                        new
                        {
                            id = new Guid("16948774-676c-4819-9e1f-712c1f8ec153"),
                            Status = true,
                            name = "Đế cao"
                        });
                });

            modelBuilder.Entity("MCV.Models.Color", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Color");

                    b.HasData(
                        new
                        {
                            id = new Guid("755fb6cc-a370-4012-b65c-0586374ab789"),
                            Status = true,
                            name = "Trắng"
                        },
                        new
                        {
                            id = new Guid("ac8c0d6d-db54-4450-a098-2269158683aa"),
                            Status = true,
                            name = "Vàng xanh"
                        },
                        new
                        {
                            id = new Guid("68c59dd2-a26e-476a-a00f-080316f79c9b"),
                            Status = true,
                            name = "Xanh đen"
                        },
                        new
                        {
                            id = new Guid("296f2955-05b1-4655-8b78-147915786084"),
                            Status = true,
                            name = "Đỏ đen"
                        },
                        new
                        {
                            id = new Guid("608017b7-b707-48fc-95c7-b66253b01ed6"),
                            Status = true,
                            name = "Đỏ"
                        },
                        new
                        {
                            id = new Guid("bad353af-7c04-4eb3-8651-721a5ed0ff97"),
                            Status = true,
                            name = "Cam"
                        },
                        new
                        {
                            id = new Guid("744abed9-7232-4ebd-beb5-c22c4b8b5990"),
                            Status = true,
                            name = "Vàng"
                        },
                        new
                        {
                            id = new Guid("e51be330-4f1b-4bcf-97f1-bfab6556fc21"),
                            Status = true,
                            name = "Xanh Lục"
                        },
                        new
                        {
                            id = new Guid("e08f84e6-2caa-4ba2-b790-916ff4ecd111"),
                            Status = true,
                            name = "Xanh Lục Đậm"
                        },
                        new
                        {
                            id = new Guid("243e84a6-8fa2-45e8-a490-147e7d6d2b90"),
                            Status = true,
                            name = "Tràm"
                        },
                        new
                        {
                            id = new Guid("5e167aa4-8c70-4ae1-a00b-546f6820e2f1"),
                            Status = true,
                            name = "Tím"
                        },
                        new
                        {
                            id = new Guid("97f7b8a9-71be-4fc1-af4d-a716d8224c5a"),
                            Status = true,
                            name = "Trắng cam"
                        },
                        new
                        {
                            id = new Guid("a3414d2f-a72f-4480-b97b-191d4120ba3e"),
                            Status = true,
                            name = "Tráng Hồng"
                        },
                        new
                        {
                            id = new Guid("7f0f7307-6059-4d51-b8c3-323b091773fc"),
                            Status = true,
                            name = "Đen"
                        });
                });

            modelBuilder.Entity("MCV.Models.Image", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ShoeDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("ShoeDetailId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("MCV.Models.Order", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccouAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("MoneyReduce")
                        .HasColumnType("real");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PaymentMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReceiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShipDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("ShipFee")
                        .HasColumnType("real");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("AccouAddressId");

                    b.HasIndex("AccountId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MCV.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("ShoeDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ShoeDetailId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("MCV.Models.PaymentMethod", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("PaymentMethod");

                    b.HasData(
                        new
                        {
                            id = new Guid("d16ac357-3ced-4c2c-bcdc-d38971214417"),
                            Method = "Thanh toán khi nhận hàng",
                            Note = "",
                            Status = true
                        },
                        new
                        {
                            id = new Guid("d16ac357-3ced-4c2c-bcdc-d38971214418"),
                            Method = "Thanh toán qua VNpay",
                            Note = "",
                            Status = true
                        },
                        new
                        {
                            id = new Guid("d16ac357-3ced-4c2c-bcdc-d38971214419"),
                            Method = "Thanh toán tại cửa hàng",
                            Note = "",
                            Status = true
                        },
                        new
                        {
                            id = new Guid("d16ac357-3ced-4c2c-bcdc-d38971214420"),
                            Method = "Thanh toán qua chuyển khoảng",
                            Note = "",
                            Status = true
                        });
                });

            modelBuilder.Entity("MCV.Models.Role", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            id = new Guid("d16ac357-3ced-4c2c-bcdc-d38971214414"),
                            Status = true,
                            name = "QuanLy"
                        },
                        new
                        {
                            id = new Guid("d16ac357-3ced-4c2c-bcdc-d38971214415"),
                            Status = true,
                            name = "NhanVien"
                        },
                        new
                        {
                            id = new Guid("d16ac357-3ced-4c2c-bcdc-d38971214416"),
                            Status = true,
                            name = "KhachHang"
                        });
                });

            modelBuilder.Entity("MCV.Models.Shoe", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceInput")
                        .HasColumnType("int");

                    b.Property<int>("PriceOutput")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("avata")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Shoe");

                    b.HasData(
                        new
                        {
                            id = new Guid("33db29f6-88a2-4eaa-ad48-d1f5437d2fdb"),
                            Code = "001",
                            PriceInput = 120,
                            PriceOutput = 150,
                            Status = true,
                            avata = "Nike_Nike-SuperRep-Cycle-2-Next-Nature_Cam(3).webp",
                            name = "Nike_Nike-SuperRep-Cycle-2"
                        },
                        new
                        {
                            id = new Guid("0f262e85-ba4f-43c2-aa33-90d6fb1a6269"),
                            Code = "002",
                            PriceInput = 130,
                            PriceOutput = 155,
                            Status = true,
                            avata = "Nike_Nike-Winflo-9_TrangCam(3).webp",
                            name = "Nike_Nike-Winflo-9"
                        },
                        new
                        {
                            id = new Guid("a03a99df-f472-4064-abd3-f8492ff4b54b"),
                            Code = "003",
                            PriceInput = 125,
                            PriceOutput = 140,
                            Status = true,
                            avata = "Nike_Nike-Zegama_Den(3).webp",
                            name = "Nike_Nike-Zegama"
                        },
                        new
                        {
                            id = new Guid("0b28726b-b6fe-4b0b-bfd1-9231009254b5"),
                            Code = "004",
                            PriceInput = 120,
                            PriceOutput = 151,
                            Status = true,
                            avata = "Nike_Nike-React-Infinity-3-Premium_BayMau(3).webp",
                            name = "Nike_Nike-React-Infinity-3"
                        },
                        new
                        {
                            id = new Guid("7a5205a3-2c0c-498e-aafe-4ca2f9940462"),
                            Code = "005",
                            PriceInput = 150,
                            PriceOutput = 170,
                            Status = true,
                            avata = "Nike_Nike-Pegasus-Turbo_Do(3).webp",
                            name = "Nike_Nike-Pegasus-Turbo"
                        },
                        new
                        {
                            id = new Guid("e720d106-8001-4407-8fca-0ad52dd6faaf"),
                            Code = "006",
                            PriceInput = 120,
                            PriceOutput = 150,
                            Status = true,
                            avata = "Nike_Nike-Metcon-8-Premium_Bac(3).webp",
                            name = "Nike_Nike-Metcon-8-Premium_Bac"
                        },
                        new
                        {
                            id = new Guid("0f1456ee-6a0d-4ece-80cb-bf09639fd843"),
                            Code = "007",
                            PriceInput = 120,
                            PriceOutput = 148,
                            Status = true,
                            avata = "Nike_Nike-Metcon-8-MF_DoDen(3).webp",
                            name = "Nike_Nike-Metcon-8-MF_DoDen"
                        },
                        new
                        {
                            id = new Guid("cfd7418a-3e1d-431f-8cc7-cf0d0fa1b5a6"),
                            Code = "008",
                            PriceInput = 120,
                            PriceOutput = 133,
                            Status = true,
                            avata = "Nike_Nike-Metcon-8-AMP_VangXam(3).webp",
                            name = "Nike_Nike-Metcon-8-AMP_VangXam"
                        },
                        new
                        {
                            id = new Guid("196f33a1-5705-4f5f-9dfa-74ba192ac260"),
                            Code = "009",
                            PriceInput = 120,
                            PriceOutput = 143,
                            Status = true,
                            avata = "Nike_Nike-Metcon-8_Xanh(3).webp",
                            name = "Nike_Nike-Metcon-8_Xanh"
                        },
                        new
                        {
                            id = new Guid("c7ae3b5a-6d06-4237-8322-d05b0ecb3782"),
                            Code = "010",
                            PriceInput = 120,
                            PriceOutput = 160,
                            Status = true,
                            avata = "Nike_Ja-1-Hunger-EP_XanhDo(3).webp",
                            name = "Nike_Ja-1-Hunger-EP_XanhDo"
                        });
                });

            modelBuilder.Entity("MCV.Models.ShoeDetail", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ColorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("ShoeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ColorId");

                    b.HasIndex("ShoeId");

                    b.HasIndex("SizeId");

                    b.ToTable("ShoeDetail");
                });

            modelBuilder.Entity("MCV.Models.Size", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Size");

                    b.HasData(
                        new
                        {
                            id = new Guid("8ed8d9f5-8054-47ad-939a-c41acddfaf11"),
                            Status = true,
                            name = "34"
                        },
                        new
                        {
                            id = new Guid("61ec9d3a-9c74-4f09-82c5-8a2ad15522dc"),
                            Status = true,
                            name = "35"
                        },
                        new
                        {
                            id = new Guid("b3fee61a-fd4b-410d-82bd-43437de1a008"),
                            Status = true,
                            name = "36"
                        },
                        new
                        {
                            id = new Guid("f11a3249-0b74-44cc-9016-0f099ff48337"),
                            Status = true,
                            name = "37"
                        },
                        new
                        {
                            id = new Guid("1065b2d6-0d33-4e9a-bb17-5b20dc42957c"),
                            Status = true,
                            name = "38"
                        },
                        new
                        {
                            id = new Guid("ecbe3baa-a979-45dd-81c9-c8060b196282"),
                            Status = true,
                            name = "39"
                        },
                        new
                        {
                            id = new Guid("63221382-5155-48d6-848b-33c28e4c1602"),
                            Status = true,
                            name = "40"
                        },
                        new
                        {
                            id = new Guid("eb53d8ae-c491-4700-be8b-ef00c1d82987"),
                            Status = true,
                            name = "41"
                        },
                        new
                        {
                            id = new Guid("a2ddc2f3-f04c-492c-9564-e01b5e00eccd"),
                            Status = true,
                            name = "42"
                        },
                        new
                        {
                            id = new Guid("c6b1b89a-3ee8-4aa0-a827-833d5850592b"),
                            Status = true,
                            name = "43"
                        });
                });

            modelBuilder.Entity("MCV.Models.Account", b =>
                {
                    b.HasOne("MCV.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MCV.Models.Address", b =>
                {
                    b.HasOne("MCV.Models.Account", "Account")
                        .WithMany("Address")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MCV.Models.Cart", b =>
                {
                    b.HasOne("MCV.Models.Account", "Account")
                        .WithMany("Carts")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MCV.Models.CartDetail", b =>
                {
                    b.HasOne("MCV.Models.Cart", "Cart")
                        .WithMany("Details")
                        .HasForeignKey("CartId");

                    b.HasOne("MCV.Models.ShoeDetail", "ShoeDetail")
                        .WithMany("Carts")
                        .HasForeignKey("ShoeDetailId");

                    b.Navigation("Cart");

                    b.Navigation("ShoeDetail");
                });

            modelBuilder.Entity("MCV.Models.Image", b =>
                {
                    b.HasOne("MCV.Models.ShoeDetail", "ShoeDetail")
                        .WithMany("Images")
                        .HasForeignKey("ShoeDetailId");

                    b.Navigation("ShoeDetail");
                });

            modelBuilder.Entity("MCV.Models.Order", b =>
                {
                    b.HasOne("MCV.Models.Address", "Addresss")
                        .WithMany("Orders")
                        .HasForeignKey("AccouAddressId");

                    b.HasOne("MCV.Models.Account", "Account")
                        .WithMany("Order")
                        .HasForeignKey("AccountId");

                    b.HasOne("MCV.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentMethodId");

                    b.Navigation("Account");

                    b.Navigation("Addresss");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("MCV.Models.OrderDetail", b =>
                {
                    b.HasOne("MCV.Models.Order", "Order")
                        .WithMany("Details")
                        .HasForeignKey("OrderId");

                    b.HasOne("MCV.Models.ShoeDetail", "ShoeDetail")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ShoeDetailId");

                    b.Navigation("Order");

                    b.Navigation("ShoeDetail");
                });

            modelBuilder.Entity("MCV.Models.ShoeDetail", b =>
                {
                    b.HasOne("MCV.Models.Brand", "Brand")
                        .WithMany("ShoeDetails")
                        .HasForeignKey("BrandId");

                    b.HasOne("MCV.Models.Category", "Category")
                        .WithMany("ShoeDetails")
                        .HasForeignKey("CategoryId");

                    b.HasOne("MCV.Models.Color", "Color")
                        .WithMany("ShoeDetails")
                        .HasForeignKey("ColorId");

                    b.HasOne("MCV.Models.Shoe", "Shoe")
                        .WithMany("ShoeDetails")
                        .HasForeignKey("ShoeId");

                    b.HasOne("MCV.Models.Size", "Size")
                        .WithMany("ShoeDetails")
                        .HasForeignKey("SizeId");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Color");

                    b.Navigation("Shoe");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("MCV.Models.Account", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Carts");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MCV.Models.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MCV.Models.Brand", b =>
                {
                    b.Navigation("ShoeDetails");
                });

            modelBuilder.Entity("MCV.Models.Cart", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("MCV.Models.Category", b =>
                {
                    b.Navigation("ShoeDetails");
                });

            modelBuilder.Entity("MCV.Models.Color", b =>
                {
                    b.Navigation("ShoeDetails");
                });

            modelBuilder.Entity("MCV.Models.Order", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("MCV.Models.PaymentMethod", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MCV.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("MCV.Models.Shoe", b =>
                {
                    b.Navigation("ShoeDetails");
                });

            modelBuilder.Entity("MCV.Models.ShoeDetail", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Images");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("MCV.Models.Size", b =>
                {
                    b.Navigation("ShoeDetails");
                });
#pragma warning restore 612, 618
        }
    }
}