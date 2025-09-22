using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace userSide.Migrations
{
    /// <inheritdoc />
    public partial class imgProductssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "img",
                table: "products",
                newName: "imagePhoto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imagePhoto",
                table: "products",
                newName: "img");
        }
    }
}
