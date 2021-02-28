using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Volvo.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(10)", nullable: false),
                    IsPermitidoCadastro = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caminhoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnoFabricacao = table.Column<short>(type: "smallint", nullable: false),
                    AnoModelo = table.Column<short>(type: "smallint", nullable: false),
                    Chassi = table.Column<string>(type: "varchar(17)", nullable: false),
                    ModeloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caminhoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caminhoes_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Id", "IsPermitidoCadastro", "Nome" },
                values: new object[,]
                {
                    { new Guid("c2482af3-101e-4e7f-9db0-727169994fb3"), true, "FH" },
                    { new Guid("f67b0e15-68f9-4528-b546-de09d0034bef"), true, "FM" },
                    { new Guid("d6f57506-96b4-4422-946e-5bdf2103ee2a"), false, "FMX" },
                    { new Guid("03b7333a-3aa0-48c3-85d5-a72279cde5d5"), false, "FHX" }
                });

            migrationBuilder.InsertData(
                table: "Caminhoes",
                columns: new[] { "Id", "AnoFabricacao", "AnoModelo", "Chassi", "ModeloId" },
                values: new object[] { new Guid("922e05b8-fb2f-4c41-8e7a-0b09a6d07a2f"), (short)2021, (short)2021, "398A4ch95b9PX8897", new Guid("c2482af3-101e-4e7f-9db0-727169994fb3") });

            migrationBuilder.CreateIndex(
                name: "IX_Caminhoes_ModeloId",
                table: "Caminhoes",
                column: "ModeloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caminhoes");

            migrationBuilder.DropTable(
                name: "Modelos");
        }
    }
}
