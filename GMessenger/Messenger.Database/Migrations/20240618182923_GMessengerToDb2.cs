using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messenger.Database.Migrations
{
    /// <inheritdoc />
    public partial class GMessengerToDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Message_MessageId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Threads_TredId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_MessageReceiverId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_MessageSenderId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Message_TredId",
                table: "Messages",
                newName: "IX_Messages_TredId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_MessageSenderId",
                table: "Messages",
                newName: "IX_Messages_MessageSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_MessageReceiverId",
                table: "Messages",
                newName: "IX_Messages_MessageReceiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Messages_MessageId",
                table: "Attachments",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Threads_TredId",
                table: "Messages",
                column: "TredId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_MessageReceiverId",
                table: "Messages",
                column: "MessageReceiverId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_MessageSenderId",
                table: "Messages",
                column: "MessageSenderId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Messages_MessageId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Threads_TredId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_MessageReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_MessageSenderId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_TredId",
                table: "Message",
                newName: "IX_Message_TredId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_MessageSenderId",
                table: "Message",
                newName: "IX_Message_MessageSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_MessageReceiverId",
                table: "Message",
                newName: "IX_Message_MessageReceiverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Message_MessageId",
                table: "Attachments",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Threads_TredId",
                table: "Message",
                column: "TredId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_MessageReceiverId",
                table: "Message",
                column: "MessageReceiverId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_MessageSenderId",
                table: "Message",
                column: "MessageSenderId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
