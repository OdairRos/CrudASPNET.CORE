using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudASPNEW.CORE.Migrations
{
    public partial class OtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BaseSalary = table.Column<double>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendedor_Depa_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Depa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecordeVendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Quantia = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    vendedorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordeVendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordeVendas_vendedor_vendedorId",
                        column: x => x.vendedorId,
                        principalTable: "vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordeVendas_vendedorId",
                table: "RecordeVendas",
                column: "vendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_vendedor_DepartmentId",
                table: "vendedor",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordeVendas");

            migrationBuilder.DropTable(
                name: "vendedor");
        }
    }
}
