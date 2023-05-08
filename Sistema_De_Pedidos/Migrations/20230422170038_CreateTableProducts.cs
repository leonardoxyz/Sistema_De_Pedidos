﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_De_Pedidos.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productQuantity = table.Column<int>(type: "int", nullable: false),
                    productValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
