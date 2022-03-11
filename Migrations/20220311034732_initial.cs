using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSample.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Things",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Things", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Things",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Test1" });

            migrationBuilder.InsertData(
                table: "Things",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Test2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Things");
        }
    }
}
