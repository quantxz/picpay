using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace picpay_simplificado.Migrations
{
    /// <inheritdoc />
    public partial class realtransfertableinsertionupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transferences",
                columns: table => new
                {
                    TransferId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Cedente = table.Column<string>(type: "TEXT", nullable: false),
                    CpfCedente = table.Column<string>(type: "TEXT", nullable: false),
                    Beneficiario = table.Column<string>(type: "TEXT", nullable: false),
                    CpfBeneficiario = table.Column<string>(type: "TEXT", nullable: false),
                    valor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferences", x => x.TransferId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transferences");
        }
    }
}
