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
                    { new Guid("6a4feba6-f155-411b-9fd6-cff1ddde1a8e"), true, "Adidas" },
                    { new Guid("b1aff0eb-336c-43f5-b658-b6c9d8c4f21e"), true, "Nike" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("340e131d-d3a7-47d8-b117-4a05a44fa008"), true, "Đế cao" },
                    { new Guid("6320197a-13ac-4601-9768-05eb5ec8b401"), true, "Đế thấp" },
                    { new Guid("887c2e65-c156-4e64-b830-26670f5c0674"), true, "Đế vừa" }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("2831fe07-67a5-4cc4-8bb7-fb45a2fe2c54"), true, "Xanh Lục" },
                    { new Guid("3a10b55c-765c-4b4b-811e-a79b7c80e676"), true, "Cam" },
                    { new Guid("439399bb-e1e1-42c8-9fc0-a8803455cb83"), true, "Tráng Hồng" },
                    { new Guid("785a9417-b1e2-4b0b-92ce-db49526260e0"), true, "Xanh Lục Đậm" },
                    { new Guid("7a6e6394-44a4-4985-87b9-eaa5435ae66c"), true, "Tràm" },
                    { new Guid("829b0947-dd9a-4440-8da0-14ddc4948ae8"), true, "Trắng" },
                    { new Guid("85c7407c-1b0e-48a8-ac47-0e306fcbd050"), true, "Đỏ đen" },
                    { new Guid("dd77232c-da64-41a6-be31-378d889644b9"), true, "Vàng xanh" },
                    { new Guid("e0a1e5d9-557a-4851-810a-af642ca44dbb"), true, "Đỏ" },
                    { new Guid("e78d290c-b547-4b80-9b00-e4a850b77f1e"), true, "Tím" },
                    { new Guid("e87ff215-982f-481e-91f8-fd31149d8cd4"), true, "Đen" },
                    { new Guid("e8cbca86-1f6c-49d9-a326-78272d5e16e0"), true, "Trắng cam" },
                    { new Guid("edd9ea3b-bf43-4c9b-acb0-ef32587120cc"), true, "Xanh đen" },
                    { new Guid("f55d6af7-39e4-4b89-95b4-6b512ca5c719"), true, "Vàng" }
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
                    { new Guid("03c39215-523a-44e5-b586-f1d025a02bea"), "008", 3000000, 3200000, true, "Nike_Nike-Metcon-8-AMP_VangXam(3).webp", "Nike_Nike-Metcon-8-AMP_VangXam" },
                    { new Guid("0b416ecc-e827-4baf-8f97-750caac01728"), "002", 3000000, 3400000, true, "Nike_Nike-Winflo-9_TrangCam(3).webp", "Nike_Nike-Winflo-9" },
                    { new Guid("1c6f834a-2987-4d28-be07-888175ec4584"), "006", 3000000, 2990000, true, "Nike_Nike-Metcon-8-Premium_Bac(3).webp", "Nike_Nike-Metcon-8-Premium_Bac" },
                    { new Guid("24d1d71c-3d30-433b-9a0f-d5945418f3f4"), "010", 3000000, 3600000, true, "Nike_Ja-1-Hunger-EP_XanhDo(3).webp", "Nike_Ja-1-Hunger-EP_XanhDo" },
                    { new Guid("3d153f93-0e7e-4ed3-beda-5e29b44fdad2"), "004", 3000000, 3110000, true, "Nike_Nike-React-Infinity-3-Premium_BayMau(3).webp", "Nike_Nike-React-Infinity-3" },
                    { new Guid("84682ae5-2f73-43a3-961c-ced6565c607b"), "001", 3000000, 3300000, true, "Nike_Nike-SuperRep-Cycle-2-Next-Nature_Cam(3).webp", "Nike_Nike-SuperRep-Cycle-2" },
                    { new Guid("91fbdf58-7d0f-430e-98a1-e8c8dcb89397"), "005", 3000000, 3000000, true, "Nike_Nike-Pegasus-Turbo_Do(3).webp", "Nike_Nike-Pegasus-Turbo" },
                    { new Guid("c67e6edd-3be1-4abd-83e6-9cc3e7b28fce"), "007", 3000000, 3400000, true, "Nike_Nike-Metcon-8-MF_DoDen(3).webp", "Nike_Nike-Metcon-8-MF_DoDen" },
                    { new Guid("d02b7592-f37b-4ad5-80ab-658e53f9494e"), "009", 3000000, 31500000, true, "Nike_Nike-Metcon-8_Xanh(3).webp", "Nike_Nike-Metcon-8_Xanh" },
                    { new Guid("f4296231-408d-48ea-bb08-d3867a4d93e9"), "003", 3000000, 3550000, true, "Nike_Nike-Zegama_Den(3).webp", "Nike_Nike-Zegama" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[,]
                {
                    { new Guid("17a0bfd5-5052-4150-99a4-c7f52d82dfde"), true, "42" },
                    { new Guid("25e5ce7d-55e5-486d-a650-1194fcf8d283"), true, "39" },
                    { new Guid("5d86302a-0edd-458c-9191-ee7162cfb5e9"), true, "37" },
                    { new Guid("74db191f-4239-4139-9403-197b49993030"), true, "36" },
                    { new Guid("7a6e1a09-4ed8-4461-bfad-e064763977ac"), true, "34" },
                    { new Guid("b0cca01f-0e02-4ee6-bfdc-d23daa95b3f3"), true, "43" },
                    { new Guid("b45f80c6-3cd3-44f0-9003-ef4a7cc9425d"), true, "41" },
                    { new Guid("c6edadac-d7a4-4863-bdec-dc5650fd110c"), true, "40" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[] { new Guid("cd124ad1-f2ef-451d-8f47-a5846d12a82c"), true, "38" });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "id", "Status", "name" },
                values: new object[] { new Guid("fe9c1147-251a-4b32-896c-c8d3058cf1ce"), true, "35" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "id", "Avatar", "Email", "Name", "Password", "RoleId", "Status" },
                values: new object[] { new Guid("7548a2e1-80ad-445c-b404-358e35ea4b18"), "", "duysata@gmail.com", "thieuxkhahl", "thieuxkhahl", new Guid("d16ac357-3ced-4c2c-bcdc-d38971214416"), true });

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
