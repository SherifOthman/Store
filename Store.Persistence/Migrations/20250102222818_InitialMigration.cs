using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHashed = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GovernorateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Users_LastModifiedByUserId",
                        column: x => x.LastModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AssignedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishLisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishLisits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressDetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDigital = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInventories_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductInventories_Users_LastModifiedByUserId",
                        column: x => x.LastModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shippings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shippings_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shippings_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductInventoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiscountValue = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DiscountTypeId = table.Column<int>(type: "int", nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Discounts_DiscountTypes_DiscountTypeId",
                        column: x => x.DiscountTypeId,
                        principalTable: "DiscountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discounts_ProductInventories_ProductInventoryId",
                        column: x => x.ProductInventoryId,
                        principalTable: "ProductInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductInventoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ProductInventoryId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductInventories_ProductInventoryId",
                        column: x => x.ProductInventoryId,
                        principalTable: "ProductInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeValues",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    ProductInventoryId = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeValues", x => new { x.ProductInventoryId, x.AttributeId });
                    table.ForeignKey(
                        name: "FK_ProductAttributeValues_ProductAttributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "ProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductAttributeValues_ProductInventories_ProductInventoryId",
                        column: x => x.ProductInventoryId,
                        principalTable: "ProductInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventoryImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductInventoryId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DisplayOreder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventoryImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInventoryImages_ProductInventories_ProductInventoryId",
                        column: x => x.ProductInventoryId,
                        principalTable: "ProductInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    ProductInventoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => new { x.ShoppingCartId, x.ProductInventoryId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ProductInventories_ProductInventoryId",
                        column: x => x.ProductInventoryId,
                        principalTable: "ProductInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishListItems",
                columns: table => new
                {
                    WishListId = table.Column<int>(type: "int", nullable: false),
                    ProductInventoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListItems", x => new { x.WishListId, x.ProductInventoryId });
                    table.ForeignKey(
                        name: "FK_WishListItems_ProductInventories_ProductInventoryId",
                        column: x => x.ProductInventoryId,
                        principalTable: "ProductInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishListItems_WishLisits_WishListId",
                        column: x => x.WishListId,
                        principalTable: "WishLisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Governorates",
                columns: new[] { "Id", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 1, "القاهرة", "Cairo" },
                    { 2, "الجيزة", "Giza" },
                    { 3, "الأسكندرية", "Alexandria" },
                    { 4, "الدقهلية", "Dakahlia" },
                    { 5, "البحر الأحمر", "Red Sea" },
                    { 6, "البحيرة", "Beheira" },
                    { 7, "الفيوم", "Fayoum" },
                    { 8, "الغربية", "Gharbiya" },
                    { 9, "الإسماعلية", "Ismailia" },
                    { 10, "المنوفية", "Menofia" },
                    { 11, "المنيا", "Minya" },
                    { 12, "القليوبية", "Qaliubiya" },
                    { 13, "الوادي الجديد", "New Valley" },
                    { 14, "السويس", "Suez" },
                    { 15, "اسوان", "Aswan" },
                    { 16, "اسيوط", "Assiut" },
                    { 17, "بني سويف", "Beni Suef" },
                    { 18, "بورسعيد", "Port Said" },
                    { 19, "دمياط", "Damietta" },
                    { 20, "الشرقية", "Sharkia" },
                    { 21, "جنوب سيناء", "South Sinai" },
                    { 22, "كفر الشيخ", "Kafr Al sheikh" },
                    { 23, "مطروح", "Matrouh" },
                    { 24, "الأقصر", "Luxor" },
                    { 25, "قنا", "Qena" },
                    { 26, "شمال سيناء", "North Sinai" },
                    { 27, "سوهاج", "Sohag" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "PasswordHashed", "PhoneNumber", "PhoneNumberConfirmed" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "admin@example.com", false, "Saman", false, "Kaream", false, null, "123", "", false },
                    { 2, 0, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "customer@example.com", false, "Sherif", false, "Ali", false, null, "123", "", false }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "GovernorateId", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 1, 1, "15 مايو", "15 May" },
                    { 2, 1, "الازبكية", "Al Azbakeyah" },
                    { 3, 1, "البساتين", "Al Basatin" },
                    { 4, 1, "التبين", "Tebin" },
                    { 5, 1, "الخليفة", "El-Khalifa" },
                    { 6, 1, "الدراسة", "El darrasa" },
                    { 7, 1, "الدرب الاحمر", "Aldarb Alahmar" },
                    { 8, 1, "الزاوية الحمراء", "Zawya al-Hamra" },
                    { 9, 1, "الزيتون", "El-Zaytoun" },
                    { 10, 1, "الساحل", "Sahel" },
                    { 11, 1, "السلام", "El Salam" },
                    { 12, 1, "السيدة زينب", "Sayeda Zeinab" },
                    { 13, 1, "الشرابية", "El Sharabeya" },
                    { 14, 1, "مدينة الشروق", "Shorouk" },
                    { 15, 1, "الظاهر", "El Daher" },
                    { 16, 1, "العتبة", "Ataba" },
                    { 17, 1, "القاهرة الجديدة", "New Cairo" },
                    { 18, 1, "المرج", "El Marg" },
                    { 19, 1, "عزبة النخل", "Ezbet el Nakhl" },
                    { 20, 1, "المطرية", "Matareya" },
                    { 21, 1, "المعادى", "Maadi" },
                    { 22, 1, "المعصرة", "Maasara" },
                    { 23, 1, "المقطم", "Mokattam" },
                    { 24, 1, "المنيل", "Manyal" },
                    { 25, 1, "الموسكى", "Mosky" },
                    { 26, 1, "النزهة", "Nozha" },
                    { 27, 1, "الوايلى", "Waily" },
                    { 28, 1, "باب الشعرية", "Bab al-Shereia" },
                    { 29, 1, "بولاق", "Bolaq" },
                    { 30, 1, "جاردن سيتى", "Garden City" },
                    { 31, 1, "حدائق القبة", "Hadayek El-Kobba" },
                    { 32, 1, "حلوان", "Helwan" },
                    { 33, 1, "دار السلام", "Dar Al Salam" },
                    { 34, 1, "شبرا", "Shubra" },
                    { 35, 1, "طره", "Tura" },
                    { 36, 1, "عابدين", "Abdeen" },
                    { 37, 1, "عباسية", "Abaseya" },
                    { 38, 1, "عين شمس", "Ain Shams" },
                    { 39, 1, "مدينة نصر", "Nasr City" },
                    { 40, 1, "مصر الجديدة", "New Heliopolis" },
                    { 41, 1, "مصر القديمة", "Masr Al Qadima" },
                    { 42, 1, "منشية ناصر", "Mansheya Nasir" },
                    { 43, 1, "مدينة بدر", "Badr City" },
                    { 44, 1, "مدينة العبور", "Obour City" },
                    { 45, 1, "وسط البلد", "Cairo Downtown" },
                    { 46, 1, "الزمالك", "Zamalek" },
                    { 47, 1, "قصر النيل", "Kasr El Nile" },
                    { 48, 1, "الرحاب", "Rehab" },
                    { 49, 1, "القطامية", "Katameya" },
                    { 50, 1, "مدينتي", "Madinty" },
                    { 51, 1, "روض الفرج", "Rod Alfarag" },
                    { 52, 1, "شيراتون", "Sheraton" },
                    { 53, 1, "الجمالية", "El-Gamaleya" },
                    { 54, 1, "العاشر من رمضان", "10th of Ramadan City" },
                    { 55, 1, "الحلمية", "Helmeyat Alzaytoun" },
                    { 56, 1, "النزهة الجديدة", "New Nozha" },
                    { 57, 1, "العاصمة الإدارية", "Capital New" },
                    { 58, 2, "الجيزة", "Giza" },
                    { 59, 2, "السادس من أكتوبر", "Sixth of October" },
                    { 60, 2, "الشيخ زايد", "Cheikh Zayed" },
                    { 61, 2, "الحوامدية", "Hawamdiyah" },
                    { 62, 2, "البدرشين", "Al Badrasheen" },
                    { 63, 2, "الصف", "Saf" },
                    { 64, 2, "أطفيح", "Atfih" },
                    { 65, 2, "العياط", "Al Ayat" },
                    { 66, 2, "الباويطي", "Al-Bawaiti" },
                    { 67, 2, "منشأة القناطر", "ManshiyetAl Qanater" },
                    { 68, 2, "أوسيم", "Oaseem" },
                    { 69, 2, "كرداسة", "Kerdasa" },
                    { 70, 2, "أبو النمرس", "Abu Nomros" },
                    { 71, 2, "كفر غطاطي", "Kafr Ghati" },
                    { 72, 2, "منشأة البكاري", "Manshiyet Al Bakari" },
                    { 73, 2, "الدقى", "Dokki" },
                    { 74, 2, "العجوزة", "Agouza" },
                    { 75, 2, "الهرم", "Haram" },
                    { 76, 2, "الوراق", "Warraq" },
                    { 77, 2, "امبابة", "Imbaba" },
                    { 78, 2, "بولاق الدكرور", "Boulaq Dakrour" },
                    { 79, 2, "الواحات البحرية", "Al Wahat Al Baharia" },
                    { 80, 2, "العمرانية", "Omraneya" },
                    { 81, 2, "المنيب", "Moneeb" },
                    { 82, 2, "بين السرايات", "Bin Alsarayat" },
                    { 83, 2, "الكيت كات", "Kit Kat" },
                    { 84, 2, "المهندسين", "Mohandessin" },
                    { 85, 2, "فيصل", "Faisal" },
                    { 86, 2, "أبو رواش", "Abu Rawash" },
                    { 87, 2, "حدائق الأهرام", "Hadayek Alahram" },
                    { 88, 2, "الحرانية", "Haraneya" },
                    { 89, 2, "حدائق اكتوبر", "Hadayek October" },
                    { 90, 2, "صفط اللبن", "Saft Allaban" },
                    { 91, 2, "القرية الذكية", "Smart Village" },
                    { 92, 2, "ارض اللواء", "Ard Ellwaa" },
                    { 93, 3, "ابو قير", "Abu Qir" },
                    { 94, 3, "الابراهيمية", "Al Ibrahimeyah" },
                    { 95, 3, "الأزاريطة", "Azarita" },
                    { 96, 3, "الانفوشى", "Anfoushi" },
                    { 97, 3, "الدخيلة", "Dekheila" },
                    { 98, 3, "السيوف", "El Soyof" },
                    { 99, 3, "العامرية", "Ameria" },
                    { 100, 3, "اللبان", "El Labban" },
                    { 101, 3, "المفروزة", "Al Mafrouza" },
                    { 102, 3, "المنتزه", "El Montaza" },
                    { 103, 3, "المنشية", "Mansheya" },
                    { 104, 3, "الناصرية", "Naseria" },
                    { 105, 3, "امبروزو", "Ambrozo" },
                    { 106, 3, "باب شرق", "Bab Sharq" },
                    { 107, 3, "برج العرب", "Bourj Alarab" },
                    { 108, 3, "ستانلى", "Stanley" },
                    { 109, 3, "سموحة", "Smouha" },
                    { 110, 3, "سيدى بشر", "Sidi Bishr" },
                    { 111, 3, "شدس", "Shads" },
                    { 112, 3, "غيط العنب", "Gheet Alenab" },
                    { 113, 3, "فلمينج", "Fleming" },
                    { 114, 3, "فيكتوريا", "Victoria" },
                    { 115, 3, "كامب شيزار", "Camp Shizar" },
                    { 116, 3, "كرموز", "Karmooz" },
                    { 117, 3, "محطة الرمل", "Mahta Alraml" },
                    { 118, 3, "مينا البصل", "Mina El-Basal" },
                    { 119, 3, "العصافرة", "Asafra" },
                    { 120, 3, "العجمي", "Agamy" },
                    { 121, 3, "بكوس", "Bakos" },
                    { 122, 3, "بولكلي", "Boulkly" },
                    { 123, 3, "كليوباترا", "Cleopatra" },
                    { 124, 3, "جليم", "Glim" },
                    { 125, 3, "المعمورة", "Al Mamurah" },
                    { 126, 3, "المندرة", "Al Mandara" },
                    { 127, 3, "محرم بك", "Moharam Bek" },
                    { 128, 3, "الشاطبي", "Elshatby" },
                    { 129, 3, "سيدي جابر", "Sidi Gaber" },
                    { 130, 3, "الساحل الشمالي", "North Coast/sahel" },
                    { 131, 3, "الحضرة", "Alhadra" },
                    { 132, 3, "العطارين", "Alattarin" },
                    { 133, 3, "سيدي كرير", "Sidi Kerir" },
                    { 134, 3, "الجمرك", "Elgomrok" },
                    { 135, 3, "المكس", "Al Max" },
                    { 136, 3, "مارينا", "Marina" },
                    { 137, 4, "المنصورة", "Mansoura" },
                    { 138, 4, "طلخا", "Talkha" },
                    { 139, 4, "ميت غمر", "Mitt Ghamr" },
                    { 140, 4, "دكرنس", "Dekernes" },
                    { 141, 4, "أجا", "Aga" },
                    { 142, 4, "منية النصر", "Menia El Nasr" },
                    { 143, 4, "السنبلاوين", "Sinbillawin" },
                    { 144, 4, "الكردي", "El Kurdi" },
                    { 145, 4, "بني عبيد", "Bani Ubaid" },
                    { 146, 4, "المنزلة", "Al Manzala" },
                    { 147, 4, "تمي الأمديد", "tami al'amdid" },
                    { 148, 4, "الجمالية", "aljamalia" },
                    { 149, 4, "شربين", "Sherbin" },
                    { 150, 4, "المطرية", "Mataria" },
                    { 151, 4, "بلقاس", "Belqas" },
                    { 152, 4, "ميت سلسيل", "Meet Salsil" },
                    { 153, 4, "جمصة", "Gamasa" },
                    { 154, 4, "محلة دمنة", "Mahalat Damana" },
                    { 155, 4, "نبروه", "Nabroh" },
                    { 156, 5, "الغردقة", "Hurghada" },
                    { 157, 5, "رأس غارب", "Ras Ghareb" },
                    { 158, 5, "سفاجا", "Safaga" },
                    { 159, 5, "القصير", "El Qusiar" },
                    { 160, 5, "مرسى علم", "Marsa Alam" },
                    { 161, 5, "الشلاتين", "Shalatin" },
                    { 162, 5, "حلايب", "Halaib" },
                    { 163, 5, "الدهار", "Aldahar" },
                    { 164, 6, "دمنهور", "Damanhour" },
                    { 165, 6, "كفر الدوار", "Kafr El Dawar" },
                    { 166, 6, "رشيد", "Rashid" },
                    { 167, 6, "إدكو", "Edco" },
                    { 168, 6, "أبو المطامير", "Abu al-Matamir" },
                    { 169, 6, "أبو حمص", "Abu Homs" },
                    { 170, 6, "الدلنجات", "Delengat" },
                    { 171, 6, "المحمودية", "Mahmoudiyah" },
                    { 172, 6, "الرحمانية", "Rahmaniyah" },
                    { 173, 6, "إيتاي البارود", "Itai Baroud" },
                    { 174, 6, "حوش عيسى", "Housh Eissa" },
                    { 175, 6, "شبراخيت", "Shubrakhit" },
                    { 176, 6, "كوم حمادة", "Kom Hamada" },
                    { 177, 6, "بدر", "Badr" },
                    { 178, 6, "وادي النطرون", "Wadi Natrun" },
                    { 179, 6, "النوبارية الجديدة", "New Nubaria" },
                    { 180, 6, "النوبارية", "Alnoubareya" },
                    { 181, 7, "الفيوم", "Fayoum" },
                    { 182, 7, "الفيوم الجديدة", "Fayoum El Gedida" },
                    { 183, 7, "طامية", "Tamiya" },
                    { 184, 7, "سنورس", "Snores" },
                    { 185, 7, "إطسا", "Etsa" },
                    { 186, 7, "إبشواي", "Epschway" },
                    { 187, 7, "يوسف الصديق", "Yusuf El Sediaq" },
                    { 188, 7, "الحادقة", "Hadqa" },
                    { 189, 7, "اطسا", "Atsa" },
                    { 190, 7, "الجامعة", "Algamaa" },
                    { 191, 7, "السيالة", "Sayala" },
                    { 192, 8, "طنطا", "Tanta" },
                    { 193, 8, "المحلة الكبرى", "Al Mahalla Al Kobra" },
                    { 194, 8, "كفر الزيات", "Kafr El Zayat" },
                    { 195, 8, "زفتى", "Zefta" },
                    { 196, 8, "السنطة", "El Santa" },
                    { 197, 8, "قطور", "Qutour" },
                    { 198, 8, "بسيون", "Basion" },
                    { 199, 8, "سمنود", "Samannoud" },
                    { 200, 9, "الإسماعيلية", "Ismailia" },
                    { 201, 9, "فايد", "Fayed" },
                    { 202, 9, "القنطرة شرق", "Qantara Sharq" },
                    { 203, 9, "القنطرة غرب", "Qantara Gharb" },
                    { 204, 9, "التل الكبير", "El Tal El Kabier" },
                    { 205, 9, "أبو صوير", "Abu Sawir" },
                    { 206, 9, "القصاصين الجديدة", "Kasasien El Gedida" },
                    { 207, 9, "نفيشة", "Nefesha" },
                    { 208, 9, "الشيخ زايد", "Sheikh Zayed" },
                    { 209, 10, "شبين الكوم", "Shbeen El Koom" },
                    { 210, 10, "مدينة السادات", "Sadat City" },
                    { 211, 10, "منوف", "Menouf" },
                    { 212, 10, "سرس الليان", "Sars El-Layan" },
                    { 213, 10, "أشمون", "Ashmon" },
                    { 214, 10, "الباجور", "Al Bagor" },
                    { 215, 10, "قويسنا", "Quesna" },
                    { 216, 10, "بركة السبع", "Berkat El Saba" },
                    { 217, 10, "تلا", "Tala" },
                    { 218, 10, "الشهداء", "Al Shohada" },
                    { 219, 11, "المنيا", "Minya" },
                    { 220, 11, "المنيا الجديدة", "Minya El Gedida" },
                    { 221, 11, "العدوة", "El Adwa" },
                    { 222, 11, "مغاغة", "Magagha" },
                    { 223, 11, "بني مزار", "Bani Mazar" },
                    { 224, 11, "مطاي", "Mattay" },
                    { 225, 11, "سمالوط", "Samalut" },
                    { 226, 11, "المدينة الفكرية", "Madinat El Fekria" },
                    { 227, 11, "ملوي", "Meloy" },
                    { 228, 11, "دير مواس", "Deir Mawas" },
                    { 229, 11, "ابو قرقاص", "Abu Qurqas" },
                    { 230, 11, "ارض سلطان", "Ard Sultan" },
                    { 231, 12, "بنها", "Banha" },
                    { 232, 12, "قليوب", "Qalyub" },
                    { 233, 12, "شبرا الخيمة", "Shubra Al Khaimah" },
                    { 234, 12, "القناطر الخيرية", "Al Qanater Charity" },
                    { 235, 12, "الخانكة", "Khanka" },
                    { 236, 12, "كفر شكر", "Kafr Shukr" },
                    { 237, 12, "طوخ", "Tukh" },
                    { 238, 12, "قها", "Qaha" },
                    { 239, 12, "العبور", "Obour" },
                    { 240, 12, "الخصوص", "Khosous" },
                    { 241, 12, "شبين القناطر", "Shibin Al Qanater" },
                    { 242, 12, "مسطرد", "Mostorod" },
                    { 243, 13, "الخارجة", "El Kharga" },
                    { 244, 13, "باريس", "Paris" },
                    { 245, 13, "موط", "Mout" },
                    { 246, 13, "الفرافرة", "Farafra" },
                    { 247, 13, "بلاط", "Balat" },
                    { 248, 13, "الداخلة", "Dakhla" },
                    { 249, 14, "السويس", "Suez" },
                    { 250, 14, "الجناين", "Alganayen" },
                    { 251, 14, "عتاقة", "Ataqah" },
                    { 252, 14, "العين السخنة", "Ain Sokhna" },
                    { 253, 14, "فيصل", "Faysal" },
                    { 254, 15, "أسوان", "Aswan" },
                    { 255, 15, "أسوان الجديدة", "Aswan El Gedida" },
                    { 256, 15, "دراو", "Drau" },
                    { 257, 15, "كوم أمبو", "Kom Ombo" },
                    { 258, 15, "نصر النوبة", "Nasr Al Nuba" },
                    { 259, 15, "كلابشة", "Kalabsha" },
                    { 260, 15, "إدفو", "Edfu" },
                    { 261, 15, "الرديسية", "Al-Radisiyah" },
                    { 262, 15, "البصيلية", "Al Basilia" },
                    { 263, 15, "السباعية", "Al Sibaeia" },
                    { 264, 15, "ابوسمبل السياحية", "Abo Simbl Al Siyahia" },
                    { 265, 15, "مرسى علم", "Marsa Alam" },
                    { 266, 16, "أسيوط", "Assiut" },
                    { 267, 16, "أسيوط الجديدة", "Assiut El Gedida" },
                    { 268, 16, "ديروط", "Dayrout" },
                    { 269, 16, "منفلوط", "Manfalut" },
                    { 270, 16, "القوصية", "Qusiya" },
                    { 271, 16, "أبنوب", "Abnoub" },
                    { 272, 16, "أبو تيج", "Abu Tig" },
                    { 273, 16, "الغنايم", "El Ghanaim" },
                    { 274, 16, "ساحل سليم", "Sahel Selim" },
                    { 275, 16, "البداري", "El Badari" },
                    { 276, 16, "صدفا", "Sidfa" },
                    { 277, 17, "بني سويف", "Bani Sweif" },
                    { 278, 17, "بني سويف الجديدة", "Beni Suef El Gedida" },
                    { 279, 17, "الواسطى", "Al Wasta" },
                    { 280, 17, "ناصر", "Naser" },
                    { 281, 17, "إهناسيا", "Ehnasia" },
                    { 282, 17, "ببا", "beba" },
                    { 283, 17, "الفشن", "Fashn" },
                    { 284, 17, "سمسطا", "Somasta" },
                    { 285, 17, "الاباصيرى", "Alabbaseri" },
                    { 286, 17, "مقبل", "Mokbel" },
                    { 287, 18, "بورسعيد", "PorSaid" },
                    { 288, 18, "بورفؤاد", "Port Fouad" },
                    { 289, 18, "العرب", "Alarab" },
                    { 290, 18, "حى الزهور", "Zohour" },
                    { 291, 18, "حى الشرق", "Alsharq" },
                    { 292, 18, "حى الضواحى", "Aldawahi" },
                    { 293, 18, "حى المناخ", "Almanakh" },
                    { 294, 18, "حى مبارك", "Mubarak" },
                    { 295, 19, "دمياط", "Damietta" },
                    { 296, 19, "دمياط الجديدة", "New Damietta" },
                    { 297, 19, "رأس البر", "Ras El Bar" },
                    { 298, 19, "فارسكور", "Faraskour" },
                    { 299, 19, "الزرقا", "Zarqa" },
                    { 300, 19, "السرو", "alsaru" },
                    { 301, 19, "الروضة", "alruwda" },
                    { 302, 19, "كفر البطيخ", "Kafr El-Batikh" },
                    { 303, 19, "عزبة البرج", "Azbet Al Burg" },
                    { 304, 19, "ميت أبو غالب", "Meet Abou Ghalib" },
                    { 305, 19, "كفر سعد", "Kafr Saad" },
                    { 306, 20, "الزقازيق", "Zagazig" },
                    { 307, 20, "العاشر من رمضان", "Al Ashr Men Ramadan" },
                    { 308, 20, "منيا القمح", "Minya Al Qamh" },
                    { 309, 20, "بلبيس", "Belbeis" },
                    { 310, 20, "مشتول السوق", "Mashtoul El Souq" },
                    { 311, 20, "القنايات", "Qenaiat" },
                    { 312, 20, "أبو حماد", "Abu Hammad" },
                    { 313, 20, "القرين", "El Qurain" },
                    { 314, 20, "ههيا", "Hehia" },
                    { 315, 20, "أبو كبير", "Abu Kabir" },
                    { 316, 20, "فاقوس", "Faccus" },
                    { 317, 20, "الصالحية الجديدة", "El Salihia El Gedida" },
                    { 318, 20, "الإبراهيمية", "Al Ibrahimiyah" },
                    { 319, 20, "ديرب نجم", "Deirb Negm" },
                    { 320, 20, "كفر صقر", "Kafr Saqr" },
                    { 321, 20, "أولاد صقر", "Awlad Saqr" },
                    { 322, 20, "الحسينية", "Husseiniya" },
                    { 323, 20, "صان الحجر القبلية", "san alhajar alqablia" },
                    { 324, 20, "منشأة أبو عمر", "Manshayat Abu Omar" },
                    { 325, 21, "الطور", "Al Toor" },
                    { 326, 21, "شرم الشيخ", "Sharm El-Shaikh" },
                    { 327, 21, "دهب", "Dahab" },
                    { 328, 21, "نويبع", "Nuweiba" },
                    { 329, 21, "طابا", "Taba" },
                    { 330, 21, "سانت كاترين", "Saint Catherine" },
                    { 331, 21, "أبو رديس", "Abu Redis" },
                    { 332, 21, "أبو زنيمة", "Abu Zenaima" },
                    { 333, 21, "رأس سدر", "Ras Sidr" },
                    { 334, 22, "كفر الشيخ", "Kafr El Sheikh" },
                    { 335, 22, "وسط البلد كفر الشيخ", "Kafr El Sheikh Downtown" },
                    { 336, 22, "دسوق", "Desouq" },
                    { 337, 22, "فوه", "Fooh" },
                    { 338, 22, "مطوبس", "Metobas" },
                    { 339, 22, "برج البرلس", "Burg Al Burullus" },
                    { 340, 22, "بلطيم", "Baltim" },
                    { 341, 22, "مصيف بلطيم", "Masief Baltim" },
                    { 342, 22, "الحامول", "Hamol" },
                    { 343, 22, "بيلا", "Bella" },
                    { 344, 22, "الرياض", "Riyadh" },
                    { 345, 22, "سيدي سالم", "Sidi Salm" },
                    { 346, 22, "قلين", "Qellen" },
                    { 347, 22, "سيدي غازي", "Sidi Ghazi" },
                    { 348, 23, "مرسى مطروح", "Marsa Matrouh" },
                    { 349, 23, "الحمام", "El Hamam" },
                    { 350, 23, "العلمين", "Alamein" },
                    { 351, 23, "الضبعة", "Dabaa" },
                    { 352, 23, "النجيلة", "Al-Nagila" },
                    { 353, 23, "سيدي براني", "Sidi Brani" },
                    { 354, 23, "السلوم", "Salloum" },
                    { 355, 23, "سيوة", "Siwa" },
                    { 356, 23, "مارينا", "Marina" },
                    { 357, 23, "الساحل الشمالى", "North Coast" },
                    { 358, 24, "الأقصر", "Luxor" },
                    { 359, 24, "الأقصر الجديدة", "New Luxor" },
                    { 360, 24, "إسنا", "Esna" },
                    { 361, 24, "طيبة الجديدة", "New Tiba" },
                    { 362, 24, "الزينية", "Al ziynia" },
                    { 363, 24, "البياضية", "Al Bayadieh" },
                    { 364, 24, "القرنة", "Al Qarna" },
                    { 365, 24, "أرمنت", "Armant" },
                    { 366, 24, "الطود", "Al Tud" },
                    { 367, 25, "قنا", "Qena" },
                    { 368, 25, "قنا الجديدة", "New Qena" },
                    { 369, 25, "ابو طشت", "Abu Tesht" },
                    { 370, 25, "نجع حمادي", "Nag Hammadi" },
                    { 371, 25, "دشنا", "Deshna" },
                    { 372, 25, "الوقف", "Alwaqf" },
                    { 373, 25, "قفط", "Qaft" },
                    { 374, 25, "نقادة", "Naqada" },
                    { 375, 25, "فرشوط", "Farshout" },
                    { 376, 25, "قوص", "Quos" },
                    { 377, 26, "العريش", "Arish" },
                    { 378, 26, "الشيخ زويد", "Sheikh Zowaid" },
                    { 379, 26, "نخل", "Nakhl" },
                    { 380, 26, "رفح", "Rafah" },
                    { 381, 26, "بئر العبد", "Bir al-Abed" },
                    { 382, 26, "الحسنة", "Al Hasana" },
                    { 383, 27, "سوهاج", "Sohag" },
                    { 384, 27, "سوهاج الجديدة", "Sohag El Gedida" },
                    { 385, 27, "أخميم", "Akhmeem" },
                    { 386, 27, "أخميم الجديدة", "Akhmim El Gedida" },
                    { 387, 27, "البلينا", "Albalina" },
                    { 388, 27, "المراغة", "El Maragha" },
                    { 389, 27, "المنشأة", "almunsha'a" },
                    { 390, 27, "دار السلام", "Dar AISalaam" },
                    { 391, 27, "جرجا", "Gerga" },
                    { 392, 27, "جهينة الغربية", "Jahina Al Gharbia" },
                    { 393, 27, "ساقلته", "Saqilatuh" },
                    { 394, 27, "طما", "Tama" },
                    { 395, 27, "طهطا", "Tahta" },
                    { 396, 27, "الكوثر", "Alkawthar" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "AssignedOn" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 2, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_GovernorateId",
                table: "Cities",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CouponId",
                table: "Discounts",
                column: "CouponId",
                unique: true,
                filter: "[CouponId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_DiscountTypeId",
                table: "Discounts",
                column: "DiscountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ProductInventoryId",
                table: "Discounts",
                column: "ProductInventoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductInventoryId",
                table: "OrderItems",
                column: "ProductInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_Name",
                table: "ProductAttributes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeValues_AttributeId",
                table: "ProductAttributeValues",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_CreatedByUserId",
                table: "ProductInventories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_Id",
                table: "ProductInventories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_LastModifiedByUserId",
                table: "ProductInventories",
                column: "LastModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_ProductId",
                table: "ProductInventories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventoryImages_ProductInventoryId",
                table: "ProductInventoryImages",
                column: "ProductInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LastModifiedByUserId",
                table: "Products",
                column: "LastModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_AddressId",
                table: "Shippings",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_OrderId",
                table: "Shippings",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductInventoryId",
                table: "ShoppingCartItems",
                column: "ProductInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLisits_UserId",
                table: "WishLisits",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishListItems_ProductInventoryId",
                table: "WishListItems",
                column: "ProductInventoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductAttributeValues");

            migrationBuilder.DropTable(
                name: "ProductInventoryImages");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Shippings");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "WishListItems");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "DiscountTypes");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ProductInventories");

            migrationBuilder.DropTable(
                name: "WishLisits");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Governorates");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
