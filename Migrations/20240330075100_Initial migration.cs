﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodMenuApp.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => new { x.DishId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_DishIngredients_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "data:image/jpeg;base64,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", "Chicken", 7.7999999999999998 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tomato Sauce" },
                    { 2, "Chicken" }
                });

            migrationBuilder.InsertData(
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
