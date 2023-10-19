﻿// <auto-generated />
using System;
using MCV.Models.DBnhom6;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DBnhom6TT))]
    partial class DBnhom6TTModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            id = new Guid("2febf0ff-2347-4cee-acde-96940b343b1e"),
                            Status = true,
                            name = "Adidas"
                        },
                        new
                        {
                            id = new Guid("53697492-abf4-4544-9802-d82d316425d2"),
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
                            id = new Guid("500d048c-963b-43af-a290-cea1970a130b"),
                            Status = true,
                            name = "Đế thấp"
                        },
                        new
                        {
                            id = new Guid("b505a13c-6914-4178-851c-8bdfa71ab8bc"),
                            Status = true,
                            name = "Đế vừa"
                        },
                        new
                        {
                            id = new Guid("d7037625-a90c-4b5c-84ba-03a512c77a7b"),
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
                            id = new Guid("c8a074cf-69e1-40a0-9d2c-69151aa70dc5"),
                            Status = true,
                            name = "Trắng"
                        },
                        new
                        {
                            id = new Guid("fb426068-94a7-4246-bb2f-8cea64b0737c"),
                            Status = true,
                            name = "Vàng xanh"
                        },
                        new
                        {
                            id = new Guid("34001aa7-5733-41a2-8c0e-f793037e81cb"),
                            Status = true,
                            name = "Xanh đen"
                        },
                        new
                        {
                            id = new Guid("3c45994c-4efc-4946-a5e6-563eb65ae714"),
                            Status = true,
                            name = "Đỏ đen"
                        },
                        new
                        {
                            id = new Guid("e8a8a19f-f105-4370-9e60-4e639644b099"),
                            Status = true,
                            name = "Đỏ"
                        },
                        new
                        {
                            id = new Guid("0cc930cc-8412-4d51-9691-034b772c9b36"),
                            Status = true,
                            name = "Cam"
                        },
                        new
                        {
                            id = new Guid("fd3d5d39-d4e0-438a-a78a-19e52e499f95"),
                            Status = true,
                            name = "Vàng"
                        },
                        new
                        {
                            id = new Guid("42835cc5-f3b1-4dc0-843a-3623e0b77098"),
                            Status = true,
                            name = "Xanh Lục"
                        },
                        new
                        {
                            id = new Guid("767a7af0-92d5-459c-b043-7d25ea6d8a15"),
                            Status = true,
                            name = "Xanh Lục Đậm"
                        },
                        new
                        {
                            id = new Guid("27468919-2ebd-4559-91c4-9121fea0e52f"),
                            Status = true,
                            name = "Tràm"
                        },
                        new
                        {
                            id = new Guid("83de9e15-2302-46b7-858c-ba0f86251743"),
                            Status = true,
                            name = "Tím"
                        },
                        new
                        {
                            id = new Guid("eda15776-349a-4843-870a-e852b3a37d63"),
                            Status = true,
                            name = "Trắng cam"
                        },
                        new
                        {
                            id = new Guid("ab7a20b5-f0a7-4a0f-b1d9-3e7fb5660de4"),
                            Status = true,
                            name = "Tráng Hồng"
                        },
                        new
                        {
                            id = new Guid("767b172d-f7d8-4238-82b3-1f7d0c7f1f36"),
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

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Shoe");

                    b.HasData(
                        new
                        {
                            id = new Guid("6d3d1527-ce36-47c7-8623-63e64bce3d49"),
                            Status = true,
                            name = "Adidas_X9000-KARLIE-KLOSS_Trang"
                        },
                        new
                        {
                            id = new Guid("bcc88bf2-bb71-41c5-bb9c-2cc9d08a0ef1"),
                            Status = true,
                            name = "Nike_Nike-Metcon-8-AMP_VangXam"
                        },
                        new
                        {
                            id = new Guid("e636d87d-df34-461a-ae01-ccab7295ffa5"),
                            Status = true,
                            name = "Nike_Nike-Metcon-8-FlyEase_DenXanh"
                        },
                        new
                        {
                            id = new Guid("bb2d0ff9-d273-4e00-9254-520cad94c466"),
                            Status = true,
                            name = "Nike_Nike-Metcon-8-MF_DoDen"
                        },
                        new
                        {
                            id = new Guid("963ddd07-f532-48d5-8034-5f563683e6bd"),
                            Status = true,
                            name = "Nike_Nike-Pegasus-Turbo_Do"
                        },
                        new
                        {
                            id = new Guid("cfdf6846-ef76-4ecc-9908-a4ed661084b5"),
                            Status = true,
                            name = "Nike_Nike-SuperRep-Cycle-2-Next-Nature_Cam"
                        },
                        new
                        {
                            id = new Guid("ed0c51e6-5a98-4490-8dbc-6136bd60ebd9"),
                            Status = true,
                            name = "Nike_Nike-Zegama_Den"
                        },
                        new
                        {
                            id = new Guid("7cb4ae5f-ab67-41c7-8f24-6ad1cc07edd7"),
                            Status = true,
                            name = "NIke_Nike-Zoom-Bella-6-Premium_Trang"
                        },
                        new
                        {
                            id = new Guid("5c823513-0f62-4350-a093-4545d1b0c0a0"),
                            Status = true,
                            name = "Nike_Nike-Winflo-9_TrangCam"
                        },
                        new
                        {
                            id = new Guid("04dfc24d-057a-4e76-9b14-be25f29453d4"),
                            Status = true,
                            name = "Adidas_ULTRABOOST-20_HongTrang"
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

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ColorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PriceInput")
                        .HasColumnType("int");

                    b.Property<int>("PriceOutput")
                        .HasColumnType("int");

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
                            id = new Guid("de76d368-79c1-452d-93fd-020f38e10161"),
                            Status = true,
                            name = "34"
                        },
                        new
                        {
                            id = new Guid("1919c7af-efac-4a65-b008-7e50c95b82ee"),
                            Status = true,
                            name = "35"
                        },
                        new
                        {
                            id = new Guid("928d540a-29a4-4aae-b587-17f2ac79dc63"),
                            Status = true,
                            name = "36"
                        },
                        new
                        {
                            id = new Guid("a5bf16ea-bcd5-4ca6-bb3e-e83e284339d4"),
                            Status = true,
                            name = "37"
                        },
                        new
                        {
                            id = new Guid("dd3532a7-b4f6-401f-ae96-7508123fa171"),
                            Status = true,
                            name = "38"
                        },
                        new
                        {
                            id = new Guid("5f66ccb7-855f-4784-b460-33e657bedeee"),
                            Status = true,
                            name = "39"
                        },
                        new
                        {
                            id = new Guid("6c203013-92d9-4624-b660-f1fa76dfe0b5"),
                            Status = true,
                            name = "40"
                        },
                        new
                        {
                            id = new Guid("4168e94c-1ba4-41b1-a498-0c963d1e7954"),
                            Status = true,
                            name = "41"
                        },
                        new
                        {
                            id = new Guid("5a81b524-e30d-4af1-b097-76ea7ee3d2d6"),
                            Status = true,
                            name = "42"
                        },
                        new
                        {
                            id = new Guid("5bf7b718-8494-43bb-b6ab-aa8645f7db7a"),
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
