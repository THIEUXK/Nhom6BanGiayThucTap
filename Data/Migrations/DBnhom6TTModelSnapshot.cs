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

                    b.HasData(
                        new
                        {
                            id = new Guid("7548a2e1-80ad-445c-b404-358e35ea4b18"),
                            Avatar = "",
                            Email = "duysata@gmail.com",
                            Name = "thieuxkhahl",
                            Password = "thieuxkhahl",
                            RoleId = new Guid("d16ac357-3ced-4c2c-bcdc-d38971214416"),
                            Status = true
                        });
                });

            modelBuilder.Entity("MCV.Models.Address", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ward")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("tienShip")
                        .HasColumnType("real");

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
                            id = new Guid("6a4feba6-f155-411b-9fd6-cff1ddde1a8e"),
                            Status = true,
                            name = "Adidas"
                        },
                        new
                        {
                            id = new Guid("b1aff0eb-336c-43f5-b658-b6c9d8c4f21e"),
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
                            id = new Guid("6320197a-13ac-4601-9768-05eb5ec8b401"),
                            Status = true,
                            name = "Đế thấp"
                        },
                        new
                        {
                            id = new Guid("887c2e65-c156-4e64-b830-26670f5c0674"),
                            Status = true,
                            name = "Đế vừa"
                        },
                        new
                        {
                            id = new Guid("340e131d-d3a7-47d8-b117-4a05a44fa008"),
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
                            id = new Guid("829b0947-dd9a-4440-8da0-14ddc4948ae8"),
                            Status = true,
                            name = "Trắng"
                        },
                        new
                        {
                            id = new Guid("dd77232c-da64-41a6-be31-378d889644b9"),
                            Status = true,
                            name = "Vàng xanh"
                        },
                        new
                        {
                            id = new Guid("edd9ea3b-bf43-4c9b-acb0-ef32587120cc"),
                            Status = true,
                            name = "Xanh đen"
                        },
                        new
                        {
                            id = new Guid("85c7407c-1b0e-48a8-ac47-0e306fcbd050"),
                            Status = true,
                            name = "Đỏ đen"
                        },
                        new
                        {
                            id = new Guid("e0a1e5d9-557a-4851-810a-af642ca44dbb"),
                            Status = true,
                            name = "Đỏ"
                        },
                        new
                        {
                            id = new Guid("3a10b55c-765c-4b4b-811e-a79b7c80e676"),
                            Status = true,
                            name = "Cam"
                        },
                        new
                        {
                            id = new Guid("f55d6af7-39e4-4b89-95b4-6b512ca5c719"),
                            Status = true,
                            name = "Vàng"
                        },
                        new
                        {
                            id = new Guid("2831fe07-67a5-4cc4-8bb7-fb45a2fe2c54"),
                            Status = true,
                            name = "Xanh Lục"
                        },
                        new
                        {
                            id = new Guid("785a9417-b1e2-4b0b-92ce-db49526260e0"),
                            Status = true,
                            name = "Xanh Lục Đậm"
                        },
                        new
                        {
                            id = new Guid("7a6e6394-44a4-4985-87b9-eaa5435ae66c"),
                            Status = true,
                            name = "Tràm"
                        },
                        new
                        {
                            id = new Guid("e78d290c-b547-4b80-9b00-e4a850b77f1e"),
                            Status = true,
                            name = "Tím"
                        },
                        new
                        {
                            id = new Guid("e8cbca86-1f6c-49d9-a326-78272d5e16e0"),
                            Status = true,
                            name = "Trắng cam"
                        },
                        new
                        {
                            id = new Guid("439399bb-e1e1-42c8-9fc0-a8803455cb83"),
                            Status = true,
                            name = "Tráng Hồng"
                        },
                        new
                        {
                            id = new Guid("e87ff215-982f-481e-91f8-fd31149d8cd4"),
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

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PayDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PaymentMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReceiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ShipDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("ShipFee")
                        .HasColumnType("real");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalMoney")
                        .HasColumnType("real");

                    b.Property<bool>("is_delete")
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
                            id = new Guid("84682ae5-2f73-43a3-961c-ced6565c607b"),
                            Code = "001",
                            PriceInput = 3000000,
                            PriceOutput = 3300000,
                            Status = true,
                            avata = "Nike_Nike-SuperRep-Cycle-2-Next-Nature_Cam(3).webp",
                            name = "Nike_Nike-SuperRep-Cycle-2"
                        },
                        new
                        {
                            id = new Guid("0b416ecc-e827-4baf-8f97-750caac01728"),
                            Code = "002",
                            PriceInput = 3000000,
                            PriceOutput = 3400000,
                            Status = true,
                            avata = "Nike_Nike-Winflo-9_TrangCam(3).webp",
                            name = "Nike_Nike-Winflo-9"
                        },
                        new
                        {
                            id = new Guid("f4296231-408d-48ea-bb08-d3867a4d93e9"),
                            Code = "003",
                            PriceInput = 3000000,
                            PriceOutput = 3550000,
                            Status = true,
                            avata = "Nike_Nike-Zegama_Den(3).webp",
                            name = "Nike_Nike-Zegama"
                        },
                        new
                        {
                            id = new Guid("3d153f93-0e7e-4ed3-beda-5e29b44fdad2"),
                            Code = "004",
                            PriceInput = 3000000,
                            PriceOutput = 3110000,
                            Status = true,
                            avata = "Nike_Nike-React-Infinity-3-Premium_BayMau(3).webp",
                            name = "Nike_Nike-React-Infinity-3"
                        },
                        new
                        {
                            id = new Guid("91fbdf58-7d0f-430e-98a1-e8c8dcb89397"),
                            Code = "005",
                            PriceInput = 3000000,
                            PriceOutput = 3000000,
                            Status = true,
                            avata = "Nike_Nike-Pegasus-Turbo_Do(3).webp",
                            name = "Nike_Nike-Pegasus-Turbo"
                        },
                        new
                        {
                            id = new Guid("1c6f834a-2987-4d28-be07-888175ec4584"),
                            Code = "006",
                            PriceInput = 3000000,
                            PriceOutput = 2990000,
                            Status = true,
                            avata = "Nike_Nike-Metcon-8-Premium_Bac(3).webp",
                            name = "Nike_Nike-Metcon-8-Premium_Bac"
                        },
                        new
                        {
                            id = new Guid("c67e6edd-3be1-4abd-83e6-9cc3e7b28fce"),
                            Code = "007",
                            PriceInput = 3000000,
                            PriceOutput = 3400000,
                            Status = true,
                            avata = "Nike_Nike-Metcon-8-MF_DoDen(3).webp",
                            name = "Nike_Nike-Metcon-8-MF_DoDen"
                        },
                        new
                        {
                            id = new Guid("03c39215-523a-44e5-b586-f1d025a02bea"),
                            Code = "008",
                            PriceInput = 3000000,
                            PriceOutput = 3200000,
                            Status = true,
                            avata = "Nike_Nike-Metcon-8-AMP_VangXam(3).webp",
                            name = "Nike_Nike-Metcon-8-AMP_VangXam"
                        },
                        new
                        {
                            id = new Guid("d02b7592-f37b-4ad5-80ab-658e53f9494e"),
                            Code = "009",
                            PriceInput = 3000000,
                            PriceOutput = 31500000,
                            Status = true,
                            avata = "Nike_Nike-Metcon-8_Xanh(3).webp",
                            name = "Nike_Nike-Metcon-8_Xanh"
                        },
                        new
                        {
                            id = new Guid("24d1d71c-3d30-433b-9a0f-d5945418f3f4"),
                            Code = "010",
                            PriceInput = 3000000,
                            PriceOutput = 3600000,
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

                    b.Property<int>("GiaBan")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("ShoeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

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
                            id = new Guid("7a6e1a09-4ed8-4461-bfad-e064763977ac"),
                            Status = true,
                            name = "34"
                        },
                        new
                        {
                            id = new Guid("fe9c1147-251a-4b32-896c-c8d3058cf1ce"),
                            Status = true,
                            name = "35"
                        },
                        new
                        {
                            id = new Guid("74db191f-4239-4139-9403-197b49993030"),
                            Status = true,
                            name = "36"
                        },
                        new
                        {
                            id = new Guid("5d86302a-0edd-458c-9191-ee7162cfb5e9"),
                            Status = true,
                            name = "37"
                        },
                        new
                        {
                            id = new Guid("cd124ad1-f2ef-451d-8f47-a5846d12a82c"),
                            Status = true,
                            name = "38"
                        },
                        new
                        {
                            id = new Guid("25e5ce7d-55e5-486d-a650-1194fcf8d283"),
                            Status = true,
                            name = "39"
                        },
                        new
                        {
                            id = new Guid("c6edadac-d7a4-4863-bdec-dc5650fd110c"),
                            Status = true,
                            name = "40"
                        },
                        new
                        {
                            id = new Guid("b45f80c6-3cd3-44f0-9003-ef4a7cc9425d"),
                            Status = true,
                            name = "41"
                        },
                        new
                        {
                            id = new Guid("17a0bfd5-5052-4150-99a4-c7f52d82dfde"),
                            Status = true,
                            name = "42"
                        },
                        new
                        {
                            id = new Guid("b0cca01f-0e02-4ee6-bfdc-d23daa95b3f3"),
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
