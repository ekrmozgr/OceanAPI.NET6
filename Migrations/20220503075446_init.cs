using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanAPI.NET6.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyContacts",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContacts", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "CourseLevels",
                columns: table => new
                {
                    CourseLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ECourseLevel = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLevels", x => x.CourseLevelId);
                });

            migrationBuilder.CreateTable(
                name: "FaqCategories",
                columns: table => new
                {
                    FAQCategoryId = table.Column<int>(type: "int", nullable: false),
                    FaqCategory = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqCategories", x => x.FAQCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategorys = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ERole = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Faq",
                columns: table => new
                {
                    FAQId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FAQCategoryId = table.Column<int>(type: "int", nullable: false),
                    FaqCategory = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faq", x => x.FAQId);
                    table.ForeignKey(
                        name: "FK_Faq_FaqCategories_FAQCategoryId",
                        column: x => x.FAQCategoryId,
                        principalTable: "FaqCategories",
                        principalColumn: "FAQCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Baskets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseHourDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseMinuteDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductCategory = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    CourseLevelId = table.Column<int>(type: "int", nullable: false),
                    CourseLevel = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketProducts",
                columns: table => new
                {
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProducts", x => new { x.BasketId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BasketProducts_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompanyContacts",
                columns: new[] { "CompanyId", "Address", "CompanyName", "Email", "PhoneNo" },
                values: new object[] { 1, "Deneme Adres", "Ocean", "deneme@outlook.com", "5076275287" });

            migrationBuilder.InsertData(
                table: "CourseLevels",
                columns: new[] { "CourseLevelId", "ECourseLevel" },
                values: new object[,]
                {
                    { 1, "BASLANGIC" },
                    { 2, "ORTA" },
                    { 3, "ILERI" }
                });

            migrationBuilder.InsertData(
                table: "FaqCategories",
                columns: new[] { "FAQCategoryId", "FaqCategory" },
                values: new object[,]
                {
                    { 1, "ABOUT_OUR_ONLINE_COURSES" },
                    { 2, "ENROLMENT_PROCESS" },
                    { 3, "ACCOUNT_ACCESS" },
                    { 4, "PAYMENT" },
                    { 5, "COMMUNITY_SUPPORT" },
                    { 6, "OTHER" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryId", "ProductCategorys" },
                values: new object[,]
                {
                    { 1, "BULUT" },
                    { 2, "DEVOPS" },
                    { 3, "ERP" },
                    { 4, "OYUN_TASARIMI_GELISTIRME" },
                    { 5, "AG_TEKNOLOJILERI" },
                    { 6, "SIBER_GUVENLIK" },
                    { 7, "UI_UX_TASARIMI" },
                    { 8, "VERI_BILIMI" },
                    { 9, "BACK_END_DEVELOPER" },
                    { 10, "FRONT_END_DEVELOPER" },
                    { 11, "FULL_STACK_DEVELOPER" },
                    { 12, "GAME_DEVELOPER" },
                    { 13, "MOBILE_DEVELOPER" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "ERole" },
                values: new object[,]
                {
                    { 1, "USER" },
                    { 2, "INSTRUCTOR" },
                    { 3, "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "MobilePhone", "Name", "Password", "Role", "Surname" },
                values: new object[] { 1, "ekrem@outlook", "5076275287", "eko", "Ekrem123.", "ADMIN", "ozgur" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "UserId", "Price", "ProductCount" },
                values: new object[] { 1, 0m, 0 });

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "FAQId", "Answer", "FAQCategoryId", "FaqCategory", "Question" },
                values: new object[,]
                {
                    { 1, "Deneme", 1, "ABOUT_OUR_ONLINE_COURSES", "Deneme" },
                    { 2, "Deneme", 2, "ENROLMENT_PROCESS", "Deneme" },
                    { 3, "Deneme", 3, "ACCOUNT_ACCESS", "Deneme" },
                    { 4, "Deneme", 4, "PAYMENT", "Deneme" },
                    { 5, "Deneme", 5, "COMMUNITY_SUPPORT", "Deneme" },
                    { 6, "Deneme", 6, "OTHER", "Deneme" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_ProductId",
                table: "BasketProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_FAQCategoryId",
                table: "Faq",
                column: "FAQCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketProducts");

            migrationBuilder.DropTable(
                name: "CompanyContacts");

            migrationBuilder.DropTable(
                name: "CourseLevels");

            migrationBuilder.DropTable(
                name: "Faq");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "FaqCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
