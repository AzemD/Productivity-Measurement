using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produktiviteti.Migrations
{
    public partial class initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainTableViewModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainTableViewModel",
                columns: table => new
                {
                    Main_Table_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipi_KerkesesKerkesaId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Emri_Pergjigja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KerkesaId = table.Column<int>(type: "int", nullable: true),
                    PergjigjaId = table.Column<int>(type: "int", nullable: false),
                    data_sot = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ora = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainTableViewModel", x => x.Main_Table_Id);
                    table.ForeignKey(
                        name: "FK_MainTableViewModel_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MainTableViewModel_Tipi_Kerkeses_Tipi_KerkesesKerkesaId",
                        column: x => x.Tipi_KerkesesKerkesaId,
                        principalTable: "Tipi_Kerkeses",
                        principalColumn: "KerkesaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainTableViewModel_Tipi_KerkesesKerkesaId",
                table: "MainTableViewModel",
                column: "Tipi_KerkesesKerkesaId");

            migrationBuilder.CreateIndex(
                name: "IX_MainTableViewModel_userId",
                table: "MainTableViewModel",
                column: "userId");
        }
    }
}
