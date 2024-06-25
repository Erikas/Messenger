using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messenger.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ChangeTS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 5, 29, 19, 36, 42, 493, DateTimeKind.Utc).AddTicks(6413))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChangeTS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 5, 29, 19, 36, 42, 496, DateTimeKind.Utc).AddTicks(5449))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangeTS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 5, 29, 19, 36, 42, 494, DateTimeKind.Utc).AddTicks(2882))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactBook_User_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NickName = table.Column<string>(type: "TEXT", nullable: true),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCreator = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChatId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangeTS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 5, 29, 19, 36, 42, 495, DateTimeKind.Utc).AddTicks(9242))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participant_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContactBookId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangeTS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 5, 29, 19, 36, 42, 494, DateTimeKind.Utc).AddTicks(8919))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_ContactBook_ContactBookId",
                        column: x => x.ContactBookId,
                        principalTable: "ContactBook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contact_User_ContactUserId",
                        column: x => x.ContactUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    ChatId = table.Column<int>(type: "INTEGER", nullable: false),
                    SenderParticipantId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangeTS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 5, 29, 19, 36, 42, 495, DateTimeKind.Utc).AddTicks(4536))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Participant_SenderParticipantId",
                        column: x => x.SenderParticipantId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MessageId = table.Column<int>(type: "INTEGER", nullable: false),
                    StorageLocation = table.Column<string>(type: "TEXT", nullable: false),
                    ChangeTS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 5, 29, 19, 36, 42, 493, DateTimeKind.Utc).AddTicks(3498))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_MessageId",
                table: "Attachment",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ContactBookId",
                table: "Contact",
                column: "ContactBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ContactUserId_ContactBookId",
                table: "Contact",
                columns: new[] { "ContactUserId", "ContactBookId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactBook_OwnerUserId",
                table: "ContactBook",
                column: "OwnerUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_ChatId",
                table: "Message",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderParticipantId",
                table: "Message",
                column: "SenderParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ChatId",
                table: "Participant",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_UserId_ChatId",
                table: "Participant",
                columns: new[] { "UserId", "ChatId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "ContactBook");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
