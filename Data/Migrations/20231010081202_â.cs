using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class â : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Accounts_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ShoeDetail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ColorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceInput = table.Column<int>(type: "int", nullable: false),
                    PriceOutput = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShoeDetail_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ShoeDetail_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ShoeDetail_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ShoeDetail_Shoe_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoe",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ShoeDetail_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                    table.ForeignKey(
                        name: "FK_Address_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Carts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoeDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.id);
                    table.ForeignKey(
                        name: "FK_Image_ShoeDetail_ShoeDetailId",
                        column: x => x.ShoeDetailId,
                        principalTable: "ShoeDetail",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccouAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    ShipFee = table.Column<float>(type: "real", nullable: false),
                    MoneyReduce = table.Column<float>(type: "real", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Addresssid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Order_Address_Addresssid",
                        column: x => x.Addresssid,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Order_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShoeDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_CartDetail_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CartDetail_ShoeDetail_ShoeDetailId",
                        column: x => x.ShoeDetailId,
                        principalTable: "ShoeDetail",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoeDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_OrderDetail_ShoeDetail_ShoeDetailId",
                        column: x => x.ShoeDetailId,
                        principalTable: "ShoeDetail",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("558b2e5b-a654-4fa8-b4d2-ab3ebee1ded5"), true, "Nike" },
                    { new Guid("803fa31d-3c19-4a71-be9a-a9933eef41a3"), true, "Adidas" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("21acfbab-8f46-4dd8-bf4a-5853f12ba6b1"), true, "Đế cao" },
                    { new Guid("591de99a-e9aa-4b40-919b-1e00e8bc9f08"), true, "Đế vừa" },
                    { new Guid("a6fe6958-7860-4070-8f15-08a2e6560e59"), true, "Đế thấp" }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("0fa38a0b-8919-4e80-8004-6e32b0cc2817"), true, "Đỏ" },
                    { new Guid("14d853ce-6d1a-4bd5-9ff6-4a4492f3604b"), true, "Đỏ đen" },
                    { new Guid("2956ee8f-31ab-49f9-bfd2-2beb5da36c1e"), true, "Vàng" },
                    { new Guid("3bff2837-1983-4a82-91ec-49adb3289a19"), true, "Tráng Hồng" },
                    { new Guid("3c8f47ba-3f38-4d45-9b52-8dcf425db25f"), true, "Xanh Lục Đậm" },
                    { new Guid("44b5710a-b2ad-4749-90d5-fd03ac7c1dab"), true, "Xanh đen" },
                    { new Guid("5812313b-f0b5-4db1-872f-6557cc61379b"), true, "Xanh Lục" },
                    { new Guid("709ea84b-6f58-46d3-baff-52c1899970d2"), true, "Đen" },
                    { new Guid("7c9f6a77-cf89-427a-943c-bf0d372ed025"), true, "Vàng xanh" },
                    { new Guid("8795fa3d-aab4-43f7-a6ff-30e62a74295b"), true, "Tím" },
                    { new Guid("9036e6ad-f1e5-40e2-a3eb-85dcc55da78b"), true, "Tràm" },
                    { new Guid("aa47a77d-782c-4ba3-ac2b-ea04f95f9ac7"), true, "Trắng" },
                    { new Guid("f66bc29c-004a-4059-9d1e-809d9e4fb057"), true, "Cam" },
                    { new Guid("f9aaebd0-7828-46ed-877c-2352dfc5b487"), true, "Trắng cam" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "id", "Method", "Note", "Status" },
                values: new object[,]
                {
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214417"), "Thanh toán khi nhận hàng", "", true },
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214418"), "Thanh toán qua VNpay", "", true },
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214419"), "Thanh toán tại cửa hàng", "", true },
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214420"), "Thanh toán qua chuyển khoảng", "", true }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214414"), true, "QuanLy" },
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214415"), true, "NhanVien" },
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214416"), true, "KhachHang" }
                });

            migrationBuilder.InsertData(
                table: "Shoe",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("0db3ed50-cb51-471b-bca9-31f0575a5399"), true, "NIke_Nike-Zoom-Bella-6-Premium_Trang" },
                    { new Guid("1132c77a-8d4c-482c-945c-e7e10ad46b3c"), true, "Nike_Nike-Metcon-8-MF_DoDen" },
                    { new Guid("1eeedefa-8af6-47f2-abbe-275e8a15d030"), true, "Nike_Nike-Metcon-8-AMP_VangXam" },
                    { new Guid("37a99446-aa67-4e5b-9367-51c6dd7dd795"), true, "Adidas_X9000-KARLIE-KLOSS_Trang" },
                    { new Guid("4451531e-06d5-46b2-85da-3f58cc4a16da"), true, "Adidas_ULTRABOOST-20_HongTrang" },
                    { new Guid("467f33be-d804-444a-8a8e-a1e0ccb23dde"), true, "Nike_Nike-Metcon-8-FlyEase_DenXanh" },
                    { new Guid("4b2a1c55-2f1a-4d85-985c-9f079e8798e3"), true, "Nike_Nike-Zegama_Den" },
                    { new Guid("62e04651-5f55-42d2-97e7-5b5c84130e07"), true, "Nike_Nike-SuperRep-Cycle-2-Next-Nature_Cam" },
                    { new Guid("a761025b-dda3-4952-bd39-3a19fb0665c2"), true, "Nike_Nike-Pegasus-Turbo_Do" },
                    { new Guid("fb122078-f51d-46bf-84b0-f7d64fad6424"), true, "Nike_Nike-Winflo-9_TrangCam" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("02788047-302b-48db-89ff-92446889c4e3"), true, "43" },
                    { new Guid("2b763a78-b52d-4cd6-a701-975f95710549"), true, "41" },
                    { new Guid("34b19311-482c-4cef-b7b0-8a1bfdcc1dfb"), true, "38" },
                    { new Guid("4003dee2-2188-44a8-9be3-12801bccd8eb"), true, "34" },
                    { new Guid("9be00d69-562a-46b1-82b4-b960bdfa8a08"), true, "40" },
                    { new Guid("9c6bcead-5d8c-43c1-b0d2-818a86cf0884"), true, "35" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("c5821fd0-943f-46e0-aea3-8f669fea4315"), true, "42" },
                    { new Guid("cf583d54-6b4f-4007-b187-228b7a6daf9e"), true, "36" },
                    { new Guid("cfbe4973-b899-4158-902b-f26dde332880"), true, "37" },
                    { new Guid("fcfd172a-279d-4ae6-860b-0f097a2300ee"), true, "39" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AccountId",
                table: "Address",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_CartId",
                table: "CartDetail",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_ShoeDetailId",
                table: "CartDetail",
                column: "ShoeDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AccountId",
                table: "Carts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ShoeDetailId",
                table: "Image",
                column: "ShoeDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AccountId",
                table: "Order",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Addresssid",
                table: "Order",
                column: "Addresssid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentMethodId",
                table: "Order",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ShoeDetailId",
                table: "OrderDetail",
                column: "ShoeDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeDetail_BrandId",
                table: "ShoeDetail",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeDetail_CategoryId",
                table: "ShoeDetail",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeDetail_ColorId",
                table: "ShoeDetail",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeDetail_ShoeId",
                table: "ShoeDetail",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeDetail_SizeId",
                table: "ShoeDetail",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ShoeDetail");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Shoe");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
