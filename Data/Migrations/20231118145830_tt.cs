using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class tt : Migration
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
                    avata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceInput = table.Column<int>(type: "int", nullable: false),
                    PriceOutput = table.Column<int>(type: "int", nullable: false)
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
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiaBan = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    tienShip = table.Column<float>(type: "real", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipFee = table.Column<float>(type: "real", nullable: false),
                    TotalMoney = table.Column<float>(type: "real", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
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
                    { new Guid("45b2d467-0634-4ce6-9298-01c07c2d6f82"), true, "Adidas" },
                    { new Guid("d3cbcba0-73f8-4295-aa7c-b2208d7fcad9"), true, "Nike" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("0668e8a1-6f94-4afc-a1a2-716488128bba"), true, "Đế thấp" },
                    { new Guid("0eaeade3-a27f-4c74-afce-9a14b6944e64"), true, "Đế vừa" },
                    { new Guid("55ba7467-2f48-4eba-ae7b-ab691c59da45"), true, "Đế cao" }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("012dd629-4cf9-447c-b838-cd767ae5a82b"), true, "Trắng cam" },
                    { new Guid("0d7074b2-5008-4eda-af6b-ff2c505d4d62"), true, "Tràm" },
                    { new Guid("2b8873a7-89ff-46bc-a699-9ab8bd0c595b"), true, "Tráng Hồng" },
                    { new Guid("4061ba03-13ad-4a91-9f9c-9a041c1cd7b1"), true, "Vàng xanh" },
                    { new Guid("73456525-75f5-4443-b465-ec54248e4fe4"), true, "Vàng" },
                    { new Guid("7763205f-deb5-4bd3-8f0d-3b8dacd703a9"), true, "Đỏ đen" },
                    { new Guid("802470b6-386f-4f35-aca5-f38ee6cd34a7"), true, "Xanh đen" },
                    { new Guid("8c40240f-70fc-4976-85a6-cd02cf5cdb95"), true, "Tím" },
                    { new Guid("9b88fc4e-9e9f-4264-9357-1e19f74d7727"), true, "Đen" },
                    { new Guid("9fce743f-f11c-4d01-851c-27e8eebd023a"), true, "Trắng" },
                    { new Guid("ca52e5fd-2e88-47d1-b8e7-9954dff60aea"), true, "Đỏ" },
                    { new Guid("dfc4a6d3-0506-442f-bdf4-990ec3f20bb4"), true, "Xanh Lục" },
                    { new Guid("eeac6e1b-de30-4561-9118-42f4eca0fdba"), true, "Xanh Lục Đậm" },
                    { new Guid("f1b7528d-4df6-4308-a091-fbfe98834b88"), true, "Cam" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "id", "Method", "Note", "Status" },
                values: new object[,]
                {
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214417"), "Thanh toán khi nhận hàng", "", true },
                    { new Guid("d16ac357-3ced-4c2c-bcdc-d38971214418"), "Thanh toán qua VNpay", "", true }
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
                columns: new[] { "id", "Code", "PriceInput", "PriceOutput", "Status", "avata", "name" },
                values: new object[,]
                {
                    { new Guid("19c737e1-a84b-493f-b44c-2257c346aad4"), "005", 3000000, 3000000, true, "Nike_Nike-Pegasus-Turbo_Do(3).webp", "Nike_Nike-Pegasus-Turbo" },
                    { new Guid("266eac83-9d5c-45f6-ac0c-7658e89c443e"), "006", 3000000, 2990000, true, "Nike_Nike-Metcon-8-Premium_Bac(3).webp", "Nike_Nike-Metcon-8-Premium_Bac" },
                    { new Guid("54921a0d-4b49-40e1-bb3d-1579cb20469f"), "001", 3000000, 3300000, true, "Nike_Nike-SuperRep-Cycle-2-Next-Nature_Cam(3).webp", "Nike_Nike-SuperRep-Cycle-2" },
                    { new Guid("61a33159-5685-4f3a-89de-7151263d09a8"), "007", 3000000, 3400000, true, "Nike_Nike-Metcon-8-MF_DoDen(3).webp", "Nike_Nike-Metcon-8-MF_DoDen" },
                    { new Guid("6241602c-5231-4553-80a7-890912e31e22"), "003", 3000000, 3550000, true, "Nike_Nike-Zegama_Den(3).webp", "Nike_Nike-Zegama" },
                    { new Guid("636726d5-6562-4a80-9798-663b11ffd04c"), "004", 3000000, 3110000, true, "Nike_Nike-React-Infinity-3-Premium_BayMau(3).webp", "Nike_Nike-React-Infinity-3" },
                    { new Guid("add9c573-e889-490b-bfbb-f3ed77f6c2fe"), "008", 3000000, 3200000, true, "Nike_Nike-Metcon-8-AMP_VangXam(3).webp", "Nike_Nike-Metcon-8-AMP_VangXam" },
                    { new Guid("ba1234c1-b18a-4cc2-86cf-6ffdfdb02b8e"), "002", 3000000, 3400000, true, "Nike_Nike-Winflo-9_TrangCam(3).webp", "Nike_Nike-Winflo-9" },
                    { new Guid("caf12adb-d776-4b66-97ff-d8bdc3dd0f5f"), "010", 3000000, 3600000, true, "Nike_Ja-1-Hunger-EP_XanhDo(3).webp", "Nike_Ja-1-Hunger-EP_XanhDo" },
                    { new Guid("f076293e-be0e-4704-b7f5-6feac2f1afb8"), "009", 3000000, 31500000, true, "Nike_Nike-Metcon-8_Xanh(3).webp", "Nike_Nike-Metcon-8_Xanh" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("3afb7ecd-d06a-41e2-a460-8488bde3017e"), true, "43" },
                    { new Guid("49ec3432-6cf0-4a62-adf3-ace5a38782fd"), true, "35" },
                    { new Guid("5567a5af-368d-4b0b-b575-d6bcf837752b"), true, "42" },
                    { new Guid("77e85425-aabf-4273-a016-39e232e24703"), true, "41" },
                    { new Guid("85921c5b-259e-47b4-8baa-2036168f56b7"), true, "34" },
                    { new Guid("ba9d8aab-79fd-4888-9668-c4fa46d2c8ff"), true, "36" },
                    { new Guid("d1e128c6-03f0-4be9-a5af-cbfcd6397c96"), true, "39" },
                    { new Guid("da194347-5dbf-493b-9aa7-d21ec9403ac8"), true, "40" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[] { new Guid("db8cd3e2-834b-4292-944b-ea09461ead4f"), true, "37" });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[] { new Guid("e1e8df4b-b774-4787-bc48-e41600e53d3f"), true, "38" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "id", "Avatar", "Email", "Name", "Password", "RoleId", "Status" },
                values: new object[] { new Guid("f069d24c-968f-47d2-b747-957cc071e9a8"), "", "duysata@gmail.com", "thieuxkhahl", "thieuxkhahl", new Guid("d16ac357-3ced-4c2c-bcdc-d38971214416"), true });

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
