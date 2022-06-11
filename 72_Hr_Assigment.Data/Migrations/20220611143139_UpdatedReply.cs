using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _72_Hr_Assigment.Data.Migrations
{
    public partial class UpdatedReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Replies",
                newName: "OwnerId");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_OwnerId",
                table: "Replies",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comment_OwnerId",
                table: "Replies",
                column: "OwnerId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comment_OwnerId",
                table: "Replies");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Replies_OwnerId",
                table: "Replies");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Replies",
                newName: "CommentId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Replies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
