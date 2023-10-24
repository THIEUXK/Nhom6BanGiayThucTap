using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class a : Migration
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
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    avata = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Status = table.Column<bool>(type: "bit", nullable: false)
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
                        name: "FK_Order_Address_AccouAddressId",
                        column: x => x.AccouAddressId,
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
                    { new Guid("d9b39c70-576a-4dba-9bc3-ffd3a37daea0"), true, "Nike" },
                    { new Guid("f969603c-faf3-43aa-a1cb-7e3c95f2f7a8"), true, "Adidas" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("7fc75f8b-cf13-472c-8339-cbc535ceab41"), true, "Đế thấp" },
                    { new Guid("8f9249a1-87c1-4a5e-a113-54f2cd1a94e3"), true, "Đế cao" },
                    { new Guid("91e4730d-3bf2-4874-960f-d41625390068"), true, "Đế vừa" }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("09542299-9fa2-49e6-be55-0704449c7b1d"), true, "Đỏ" },
                    { new Guid("149347ed-334d-4add-a4e4-adf7a49b5b83"), true, "Trắng cam" },
                    { new Guid("3929944e-06ae-411a-8b21-acf94ac679f5"), true, "Xanh Lục" },
                    { new Guid("3b6de8b6-62c7-4822-959b-4f94a7b665f2"), true, "Vàng" },
                    { new Guid("427664e7-8f6b-40df-806b-ff4dc2952679"), true, "Xanh Lục Đậm" },
                    { new Guid("4ede5c90-692f-4993-b7bc-9a5f408bf263"), true, "Trắng" },
                    { new Guid("6a78a332-84f8-4c8a-8967-7afc79273fe3"), true, "Cam" },
                    { new Guid("6daf6980-4711-4ac4-8f14-aa703fa16d4e"), true, "Vàng xanh" },
                    { new Guid("885a4d00-1f9d-4e9b-b1a9-08ba43f0656b"), true, "Tràm" },
                    { new Guid("8eda6c69-caac-4529-8ada-6923c9c51b13"), true, "Đỏ đen" },
                    { new Guid("cbaaeca1-c028-4e58-9903-71e185a8be8f"), true, "Xanh đen" },
                    { new Guid("cdcbfc88-10f9-46e4-a881-fe37b2e7a5d9"), true, "Tím" },
                    { new Guid("db506394-70f5-4645-8a0c-e3e81f4b3979"), true, "Đen" },
                    { new Guid("e44a3bc6-ded6-4805-b51f-518f46a399d3"), true, "Tráng Hồng" }
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
                columns: new[] { "id", "Status", "avata", "name" },
                values: new object[,]
                {
                    { new Guid("3aca2cad-f2b7-45a4-bf49-362b2411de61"), true, "", "Nike_Nike-Zegama_Den" },
                    { new Guid("3f30ffd5-c728-4c30-91ca-9d250316a500"), true, "", "NIke_Nike-Zoom-Bella-6-Premium_Trang" },
                    { new Guid("6b9c1d94-08f2-4f89-8713-16fc0b58f728"), true, "", "Nike_Nike-Pegasus-Turbo_Do" },
                    { new Guid("71a84f34-f805-40d0-9e2c-8110433962dd"), true, "", "Nike_Nike-SuperRep-Cycle-2-Next-Nature_Cam" },
                    { new Guid("72c73a32-40c3-4ee7-a40b-b751796aaeee"), true, "", "Adidas_X9000-KARLIE-KLOSS_Trang" },
                    { new Guid("8832b161-9230-41c7-ab51-f4335b79946f"), true, "", "Nike_Nike-Winflo-9_TrangCam" },
                    { new Guid("a1208e73-ffdd-4035-8ecf-f5a7fde8b89e"), true, "", "Nike_Nike-Metcon-8-MF_DoDen" },
                    { new Guid("b679e154-9606-4121-82fc-4b202ca84c03"), true, "", "Nike_Nike-Metcon-8-FlyEase_DenXanh" },
                    { new Guid("e15e69cb-1737-419d-a4d2-0651b5fd6987"), true, "", "Nike_Nike-Metcon-8-AMP_VangXam" },
                    { new Guid("ea56bf4d-770f-40b6-8189-94f21b7739ba"), true, "", "Adidas_ULTRABOOST-20_HongTrang" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("60a40a93-f52f-4b7c-b652-2e091a8a8f94"), true, "42" },
                    { new Guid("7ab87e35-bb3b-49c4-9a6f-04994200a37a"), true, "39" },
                    { new Guid("aad5226f-1c2e-4862-b152-d24c60f5d960"), true, "37" },
                    { new Guid("b5165034-41cf-406c-ac04-c979b5c5819a"), true, "40" },
                    { new Guid("b68dc7af-1323-4382-a8f5-f8fb5df429c2"), true, "41" },
                    { new Guid("cb480d98-b088-4080-a16e-a77f6d1b35f1"), true, "38" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("e27c5c4a-fd38-424e-87c0-366ae7217d41"), true, "43" },
                    { new Guid("ef27421e-0cc2-43c6-bc19-88281d6f40ea"), true, "35" },
                    { new Guid("fe454829-5663-4d1c-951a-12ea1708c91a"), true, "36" },
                    { new Guid("fe65aac8-aa0c-4692-b084-e44937e79c36"), true, "34" }
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
                name: "IX_Order_AccouAddressId",
                table: "Order",
                column: "AccouAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AccountId",
                table: "Order",
                column: "AccountId");

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
