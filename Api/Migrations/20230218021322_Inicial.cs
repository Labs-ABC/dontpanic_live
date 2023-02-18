using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstInput = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    SecondInput = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ThirdInput = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    FourthInput = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    FifthInput = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    SixthInput = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equations");
        }
    }
}
