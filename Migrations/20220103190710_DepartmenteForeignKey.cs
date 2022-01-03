using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudASPNEW.CORE.Migrations
{
    public partial class DepartmenteForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecordeVendas_vendedor_vendedorId",
                table: "RecordeVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_vendedor_Depa_DepartmentId",
                table: "vendedor");

            migrationBuilder.RenameColumn(
                name: "vendedorId",
                table: "RecordeVendas",
                newName: "VendedorId");

            migrationBuilder.RenameIndex(
                name: "IX_RecordeVendas_vendedorId",
                table: "RecordeVendas",
                newName: "IX_RecordeVendas_VendedorId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "vendedor",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordeVendas_vendedor_VendedorId",
                table: "RecordeVendas",
                column: "VendedorId",
                principalTable: "vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vendedor_Depa_DepartmentId",
                table: "vendedor",
                column: "DepartmentId",
                principalTable: "Depa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecordeVendas_vendedor_VendedorId",
                table: "RecordeVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_vendedor_Depa_DepartmentId",
                table: "vendedor");

            migrationBuilder.RenameColumn(
                name: "VendedorId",
                table: "RecordeVendas",
                newName: "vendedorId");

            migrationBuilder.RenameIndex(
                name: "IX_RecordeVendas_VendedorId",
                table: "RecordeVendas",
                newName: "IX_RecordeVendas_vendedorId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "vendedor",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_RecordeVendas_vendedor_vendedorId",
                table: "RecordeVendas",
                column: "vendedorId",
                principalTable: "vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vendedor_Depa_DepartmentId",
                table: "vendedor",
                column: "DepartmentId",
                principalTable: "Depa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
