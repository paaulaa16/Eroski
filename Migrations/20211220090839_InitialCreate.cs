﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiEroski.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eroski",
                columns: table => new
                {
                    Seccion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ticket = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eroski", x => x.Seccion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eroski");
        }
    }
}
