using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawTrack.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldIsDefaultToClientType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "ClientTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ClientTypes");
             
        }
    }
}
