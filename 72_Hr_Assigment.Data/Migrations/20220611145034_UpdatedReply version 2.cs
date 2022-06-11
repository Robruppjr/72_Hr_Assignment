using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _72_Hr_Assigment.Data.Migrations
{
    public partial class UpdatedReplyversion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comment_OwnerId",
                table: "Replies");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Replies",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_OwnerId",
                table: "Replies",
                newName: "IX_Replies_CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comment_CommentId",
                table: "Replies",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comment_CommentId",
                table: "Replies");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Replies",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_CommentId",
                table: "Replies",
                newName: "IX_Replies_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comment_OwnerId",
                table: "Replies",
                column: "OwnerId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
