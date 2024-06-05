using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messenger.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMessengerSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PictureBlobUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreationTS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationTS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccount_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Thread",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatorAccountId = table.Column<long>(type: "bigint", nullable: false),
                    IsGroup = table.Column<bool>(type: "bit", nullable: false),
                    CreationTS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thread", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thread_UserAccount_CreatorAccountId",
                        column: x => x.CreatorAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserContact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAccountId = table.Column<long>(type: "bigint", nullable: false),
                    ContactUserAccountId = table.Column<long>(type: "bigint", nullable: false),
                    IsFriends = table.Column<bool>(type: "bit", nullable: false),
                    CreationTS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContact_UserAccount_ContactUserAccountId",
                        column: x => x.ContactUserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserContact_UserAccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAccountId = table.Column<long>(type: "bigint", nullable: false),
                    Theme = table.Column<bool>(type: "bit", nullable: false),
                    CreationTS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_UserAccount_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    MessageThreadId = table.Column<long>(type: "bigint", nullable: false),
                    SenderUserAccountId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Thread_MessageThreadId",
                        column: x => x.MessageThreadId,
                        principalTable: "Thread",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Message_UserAccount_SenderUserAccountId",
                        column: x => x.SenderUserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThreadMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadMemberUserAccountId = table.Column<long>(type: "bigint", nullable: false),
                    ThreadId = table.Column<long>(type: "bigint", nullable: false),
                    MemberRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreadMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThreadMember_Thread_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "Thread",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThreadMember_UserAccount_ThreadMemberUserAccountId",
                        column: x => x.ThreadMemberUserAccountId,
                        principalTable: "UserAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MessageAttachment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MessageId = table.Column<long>(type: "bigint", nullable: false),
                    BlobUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageAttachment_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_MessageThreadId",
                table: "Message",
                column: "MessageThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderUserAccountId",
                table: "Message",
                column: "SenderUserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageAttachment_MessageId",
                table: "MessageAttachment",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Thread_CreatorAccountId",
                table: "Thread",
                column: "CreatorAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ThreadMember_ThreadId",
                table: "ThreadMember",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_ThreadMember_ThreadMemberUserAccountId",
                table: "ThreadMember",
                column: "ThreadMemberUserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_UserId",
                table: "UserAccount",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserContact_ContactUserAccountId",
                table: "UserContact",
                column: "ContactUserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContact_UserAccountId",
                table: "UserContact",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserAccountId",
                table: "UserSettings",
                column: "UserAccountId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageAttachment");

            migrationBuilder.DropTable(
                name: "ThreadMember");

            migrationBuilder.DropTable(
                name: "UserContact");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Thread");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
