using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class ChangeTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JoinedWedding_User_UserId",
                table: "JoinedWedding");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinedWedding_Wedding_WeddingId",
                table: "JoinedWedding");

            migrationBuilder.DropForeignKey(
                name: "FK_Wedding_User_UserId",
                table: "Wedding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JoinedWedding",
                table: "JoinedWedding");

            migrationBuilder.RenameTable(
                name: "Wedding",
                newName: "Weddings");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "JoinedWedding",
                newName: "JoinedWeddings");

            migrationBuilder.RenameIndex(
                name: "IX_Wedding_UserId",
                table: "Weddings",
                newName: "IX_Weddings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JoinedWedding_WeddingId",
                table: "JoinedWeddings",
                newName: "IX_JoinedWeddings_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_JoinedWedding_UserId",
                table: "JoinedWeddings",
                newName: "IX_JoinedWeddings_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Weddings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings",
                column: "WeddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JoinedWeddings",
                table: "JoinedWeddings",
                column: "JoinedWeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_JoinedWeddings_Users_UserId",
                table: "JoinedWeddings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JoinedWeddings_Weddings_WeddingId",
                table: "JoinedWeddings",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_UserId",
                table: "Weddings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JoinedWeddings_Users_UserId",
                table: "JoinedWeddings");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinedWeddings_Weddings_WeddingId",
                table: "JoinedWeddings");

            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_UserId",
                table: "Weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JoinedWeddings",
                table: "JoinedWeddings");

            migrationBuilder.RenameTable(
                name: "Weddings",
                newName: "Wedding");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "JoinedWeddings",
                newName: "JoinedWedding");

            migrationBuilder.RenameIndex(
                name: "IX_Weddings_UserId",
                table: "Wedding",
                newName: "IX_Wedding_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JoinedWeddings_WeddingId",
                table: "JoinedWedding",
                newName: "IX_JoinedWedding_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_JoinedWeddings_UserId",
                table: "JoinedWedding",
                newName: "IX_JoinedWedding_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Wedding",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding",
                column: "WeddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JoinedWedding",
                table: "JoinedWedding",
                column: "JoinedWeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_JoinedWedding_User_UserId",
                table: "JoinedWedding",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JoinedWedding_Wedding_WeddingId",
                table: "JoinedWedding",
                column: "WeddingId",
                principalTable: "Wedding",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wedding_User_UserId",
                table: "Wedding",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
