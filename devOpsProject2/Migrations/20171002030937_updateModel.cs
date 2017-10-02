using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace devOpsProject2.Migrations
{
    public partial class updateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_CD_CDId",
                table: "Track");

            migrationBuilder.AlterColumn<int>(
                name: "CDId",
                table: "Track",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_CD_CDId",
                table: "Track",
                column: "CDId",
                principalTable: "CD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_CD_CDId",
                table: "Track");

            migrationBuilder.AlterColumn<int>(
                name: "CDId",
                table: "Track",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_CD_CDId",
                table: "Track",
                column: "CDId",
                principalTable: "CD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
