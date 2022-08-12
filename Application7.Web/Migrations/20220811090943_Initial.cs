using Microsoft.EntityFrameworkCore.Migrations;

namespace Application7.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(nullable: false),
                    GuestName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(nullable: false),
                    MenuItemName = table.Column<string>(maxLength: 100, nullable: false),
                    NumberOfPlates = table.Column<short>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderMenus",
                columns: table => new
                {
                    OrderMenuId = table.Column<int>(nullable: false),
                    OrderMenuName = table.Column<string>(nullable: true),
                    GuestId = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMenus", x => x.OrderMenuId);
                    table.ForeignKey(
                        name: "FK_OrderMenus_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderMenus_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderInformation",
                columns: table => new
                {
                    OrderInformationId = table.Column<int>(nullable: false),
                    OrderMenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInformation", x => x.OrderInformationId);
                    table.ForeignKey(
                        name: "FK_OrderInformation_OrderMenus_OrderMenuId",
                        column: x => x.OrderMenuId,
                        principalTable: "OrderMenus",
                        principalColumn: "OrderMenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryId",
                table: "MenuItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInformation_OrderMenuId",
                table: "OrderInformation",
                column: "OrderMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenus_GuestId",
                table: "OrderMenus",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenus_MenuItemId",
                table: "OrderMenus",
                column: "MenuItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderInformation");

            migrationBuilder.DropTable(
                name: "OrderMenus");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
