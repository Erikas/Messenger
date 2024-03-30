﻿// <auto-generated />
using System;
using Messenger.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Messenger.Persistence.Migrations
{
    [DbContext(typeof(MessengerContext))]
    partial class MessengerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Messenger.Persistence.Entities.Attachment", b =>
                {
                    b.Property<int>("AttachmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttachmentID"));

                    b.Property<string>("AttachmentName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AttachmentURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MessageID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UploadedByUserID")
                        .HasColumnType("int");

                    b.HasKey("AttachmentID");

                    b.HasIndex("MessageID");

                    b.HasIndex("UploadedByUserID");

                    b.ToTable("Attachments", (string)null);
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ChatThread", b =>
                {
                    b.Property<int>("ThreadID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThreadID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedByUserID")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsGroup")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ThreadID");

                    b.HasIndex("CreatedByUserID");

                    b.ToTable("Threads", (string)null);
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Friendship", b =>
                {
                    b.Property<int>("FriendshipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FriendshipID"));

                    b.Property<int>("FriendsUserID1")
                        .HasColumnType("int");

                    b.Property<int>("FriendsUserID2")
                        .HasColumnType("int");

                    b.Property<DateTime>("FriendshipStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FriendshipStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FriendshipID");

                    b.HasIndex("FriendsUserID1");

                    b.HasIndex("FriendsUserID2");

                    b.ToTable("Friends", (string)null);
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageID"));

                    b.Property<int?>("ChatThreadThreadID")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SenderUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ThreadID")
                        .HasColumnType("int");

                    b.HasKey("MessageID");

                    b.HasIndex("ChatThreadThreadID");

                    b.HasIndex("SenderUserID");

                    b.HasIndex("ThreadID");

                    b.ToTable("Messages", (string)null);
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ThreadParticipant", b =>
                {
                    b.Property<int>("ThreadParticipantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThreadParticipantID"));

                    b.Property<int?>("ChatThreadThreadID")
                        .HasColumnType("int");

                    b.Property<string>("ParticipantType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ThreadID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ThreadParticipantID");

                    b.HasIndex("ChatThreadThreadID");

                    b.HasIndex("ThreadID");

                    b.HasIndex("UserID");

                    b.ToTable("ThreadParticipants", (string)null);
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserID");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserProfile", b =>
                {
                    b.Property<int>("ProfileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileID"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ProfileID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserProfile", (string)null);
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserSettings", b =>
                {
                    b.Property<int>("SettingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SettingID"));

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Setting1")
                        .HasColumnType("bit");

                    b.Property<string>("Setting2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("SettingID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserSettings", (string)null);
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserStatus", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusID"));

                    b.Property<DateTime>("LastActiveAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("StatusID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserStatus", (string)null);
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Attachment", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.Message", "Message")
                        .WithMany("Attachments")
                        .HasForeignKey("MessageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.User", "UploadedByUser")
                        .WithMany()
                        .HasForeignKey("UploadedByUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("UploadedByUser");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ChatThread", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Friendship", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.User", "User1")
                        .WithMany()
                        .HasForeignKey("FriendsUserID1")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.User", "User2")
                        .WithMany()
                        .HasForeignKey("FriendsUserID2")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Message", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.ChatThread", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatThreadThreadID");

                    b.HasOne("Messenger.Persistence.Entities.User", "SenderUser")
                        .WithMany()
                        .HasForeignKey("SenderUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.ChatThread", "ChatThread")
                        .WithMany()
                        .HasForeignKey("ThreadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatThread");

                    b.Navigation("SenderUser");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ThreadParticipant", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.ChatThread", null)
                        .WithMany("Participants")
                        .HasForeignKey("ChatThreadThreadID");

                    b.HasOne("Messenger.Persistence.Entities.ChatThread", "ChatThread")
                        .WithMany()
                        .HasForeignKey("ThreadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatThread");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserProfile", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("Messenger.Persistence.Entities.UserProfile", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserSettings", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.User", "User")
                        .WithOne("UserSettings")
                        .HasForeignKey("Messenger.Persistence.Entities.UserSettings", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserStatus", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.User", "User")
                        .WithOne("UserStatus")
                        .HasForeignKey("Messenger.Persistence.Entities.UserStatus", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ChatThread", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Message", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.User", b =>
                {
                    b.Navigation("UserProfile")
                        .IsRequired();

                    b.Navigation("UserSettings")
                        .IsRequired();

                    b.Navigation("UserStatus")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
