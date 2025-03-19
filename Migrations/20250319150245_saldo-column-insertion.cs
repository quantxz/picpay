using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace picpay_simplificado.Migrations
{
    /// <inheritdoc />
    public partial class saldocolumninsertion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "saldo",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "saldo",
                table: "Usuarios");
        }
    }
}
