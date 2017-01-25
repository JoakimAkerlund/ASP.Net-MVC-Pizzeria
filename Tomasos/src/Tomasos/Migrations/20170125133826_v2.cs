using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tomasos.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ShoppingCartDetails",
                newName: "ShoppingCartDetailsID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Dish",
                newName: "DishID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartDetailsID",
                table: "ShoppingCartDetails",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DishID",
                table: "Dish",
                newName: "ID");
        }
    }
}
