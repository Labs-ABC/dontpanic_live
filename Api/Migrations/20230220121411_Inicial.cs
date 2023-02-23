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
						Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Equations", x => x.Id);
					});

			migrationBuilder.InsertData(
					table: "Equations",
					columns: new[] { "Value" },
					values: new object[,]
					{
										{ "4*11-2" },
										{ "50-8*2" },
										{ "182-63" },
										{ "21*2-0" },
										{ "10*4+2" },
										{ "42+0+0" },
										{ "000042" },
										{ "42*1-0" },
										{ "21*2+0" },
										{ "21+021" },
										{ "066-24" },
										{ "33+9+0" },
										{ "14*3+0" },
										{ "7*6-00" }
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
