using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    Condition = table.Column<string>(type: "TEXT", nullable: true),
                    IsFavourite = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChildName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Toys_Children_ChildName",
                        column: x => x.ChildName,
                        principalTable: "Children",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toys_ChildName",
                table: "Toys",
                column: "ChildName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "Children");
        }
    }
}
