using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Wedding",
                columns: table => new
                {
                    WeddingId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BrideName = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    GroomName = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wedding", x => x.WeddingId);
                    table.ForeignKey(
                        name: "FK_Wedding_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JoinedWedding",
                columns: table => new
                {
                    JoinedWeddingId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    WeddingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinedWedding", x => x.JoinedWeddingId);
                    table.ForeignKey(
                        name: "FK_JoinedWedding_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JoinedWedding_Wedding_WeddingId",
                        column: x => x.WeddingId,
                        principalTable: "Wedding",
                        principalColumn: "WeddingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JoinedWedding_UserId",
                table: "JoinedWedding",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JoinedWedding_WeddingId",
                table: "JoinedWedding",
                column: "WeddingId");

            migrationBuilder.CreateIndex(
                name: "IX_Wedding_UserId",
                table: "Wedding",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JoinedWedding");

            migrationBuilder.DropTable(
                name: "Wedding");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
