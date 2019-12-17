using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobileItems",
                columns: table => new
                {
                    MobileItemsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileName = table.Column<string>(nullable: true),
                    MobilePrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileItems", x => x.MobileItemsId);
                });

            migrationBuilder.CreateTable(
                name: "AccessoryItems",
                columns: table => new
                {
                    AccessoryItemsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessoryName = table.Column<string>(nullable: true),
                    AccessoryPrice = table.Column<int>(nullable: false),
                    MobileItemsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryItems", x => x.AccessoryItemsId);
                    table.ForeignKey(
                        name: "FK_AccessoryItems_MobileItems_MobileItemsId",
                        column: x => x.MobileItemsId,
                        principalTable: "MobileItems",
                        principalColumn: "MobileItemsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryItems_MobileItemsId",
                table: "AccessoryItems",
                column: "MobileItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoryItems");

            migrationBuilder.DropTable(
                name: "MobileItems");
        }
    }
}
