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
                    { new Guid("78ca7f85-4f41-4f64-9192-40cd744fd1c5"), true, "Adidas" },
                    { new Guid("bf2e479e-4688-4d90-817e-278cef6a1e9e"), true, "Nike" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("13879ab6-03ac-4770-bb71-d1a16cec5cdb"), true, "Đế vừa" },
                    { new Guid("b2a472f2-5d21-489d-9727-81e80c2abb8b"), true, "Đế thấp" },
                    { new Guid("fa3dc767-3bdc-416f-ba14-865797f5014d"), true, "Đế cao" }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("16620522-4585-49e7-baba-8b313f04014f"), true, "Tím" },
                    { new Guid("42b6a353-9797-440f-89bb-3c3c2613a037"), true, "Trắng cam" },
                    { new Guid("44645e7e-1d1c-4a27-8b53-aea58e6ea4cb"), true, "Tráng Hồng" },
                    { new Guid("47ab32ca-87b2-40de-85fe-3171a10e943e"), true, "Đen" },
                    { new Guid("5ea806eb-dfff-4bed-9bea-de151ad9b256"), true, "Đỏ" },
                    { new Guid("63b98fad-4716-4f18-b026-12ebbb4f9fb6"), true, "Vàng xanh" },
                    { new Guid("74fa3999-2293-4082-a37a-6028f7d8ef86"), true, "Xanh đen" },
                    { new Guid("76544509-f525-4121-995a-cddb1e69f945"), true, "Xanh Lục" },
                    { new Guid("7aa822d7-67ff-4889-bcda-44594fc0d3d5"), true, "Tràm" },
                    { new Guid("aba13838-9209-4460-9e64-a422dacd6b7c"), true, "Xanh Lục Đậm" },
                    { new Guid("c508d955-2b7a-431d-acbd-4bc1b56e0292"), true, "Đỏ đen" },
                    { new Guid("f02db20a-789d-4a0f-b9eb-4d237acaeb73"), true, "Cam" },
                    { new Guid("f0d56ceb-be5a-4382-bd5d-00578fe6fd2f"), true, "Vàng" },
                    { new Guid("ff628d0c-7be0-47b5-aea8-0908a43889dc"), true, "Trắng" }
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
                columns: new[] { "id", "Code", "PriceInput", "PriceOutput", "Status", "avata", "name" },
                values: new object[,]
                {
                    { new Guid("06a9bd9c-6004-4c48-bba6-87e03ce79f9a"), "005", 150, 170, true, "Nike_Nike-Pegasus-Turbo_Do(3).webp", "Nike_Nike-Pegasus-Turbo" },
                    { new Guid("167f6b83-ba95-47f8-81bd-fa0e38024408"), "001", 120, 150, true, "Nike_Nike-SuperRep-Cycle-2-Next-Nature_Cam(3).webp", "Nike_Nike-SuperRep-Cycle-2" },
                    { new Guid("2cc3fa26-83db-4ac0-8e00-4fa9c27278be"), "003", 125, 140, true, "Nike_Nike-Zegama_Den(3).webp", "Nike_Nike-Zegama" },
                    { new Guid("4931d60a-3219-4344-a317-5f5916a7f9ba"), "008", 120, 133, true, "Nike_Nike-Metcon-8-AMP_VangXam(3).webp", "Nike_Nike-Metcon-8-AMP_VangXam" },
                    { new Guid("5a1100f7-edc4-4bd4-ad43-4a1e13b1cf0a"), "006", 120, 150, true, "Nike_Nike-Metcon-8-Premium_Bac(3).webp", "Nike_Nike-Metcon-8-Premium_Bac" },
                    { new Guid("934171ae-c61a-411a-b92a-45cde60efae3"), "010", 120, 160, true, "Nike_Ja-1-Hunger-EP_XanhDo(3).webp", "Nike_Ja-1-Hunger-EP_XanhDo" },
                    { new Guid("98dcb961-5643-4a6b-b8dd-8c4428d1ff70"), "002", 130, 155, true, "Nike_Nike-Winflo-9_TrangCam(3).webp", "Nike_Nike-Winflo-9" },
                    { new Guid("a33dcaf0-0a00-4364-9dfe-95df68f0d9bd"), "007", 120, 148, true, "Nike_Nike-Metcon-8-MF_DoDen(3).webp", "Nike_Nike-Metcon-8-MF_DoDen" },
                    { new Guid("b9acbf78-96d7-4e2e-8f47-a2ea515169a4"), "009", 120, 143, true, "Nike_Nike-Metcon-8_Xanh(3).webp", "Nike_Nike-Metcon-8_Xanh" },
                    { new Guid("c707835c-efa4-414d-80dc-6ddea9dedf02"), "004", 120, 151, true, "Nike_Nike-React-Infinity-3-Premium_BayMau(3).webp", "Nike_Nike-React-Infinity-3" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("02cbadc1-780b-42d0-a173-f701b24f4983"), true, "39" },
                    { new Guid("47c30eb0-6366-4de7-b4e9-90eeb532ad05"), true, "43" },
                    { new Guid("4ab097ed-1bc2-4730-8b58-6d4f8273274f"), true, "40" },
                    { new Guid("5681a5ac-d016-4e00-ab49-4e9f1bda3a12"), true, "36" },
                    { new Guid("5fa3469c-8ed0-489f-99d6-7775324be806"), true, "42" },
                    { new Guid("74e25b7f-e91d-4e39-94a3-d9e669ae0f4d"), true, "35" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("7ede1fbd-a32a-4dff-9a7f-b47d4465e6b1"), true, "34" },
                    { new Guid("8b6e770d-6532-467b-80a0-4e91b5a3cf9c"), true, "41" },
                    { new Guid("93a4d540-b890-4374-80fe-d434b04196be"), true, "37" },
                    { new Guid("a8c94660-5361-4b62-832f-b0b665e4e6d9"), true, "38" }
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
