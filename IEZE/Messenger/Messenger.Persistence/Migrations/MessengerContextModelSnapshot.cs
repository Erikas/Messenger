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
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Messenger.Persistence.Entities.ChatThread", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserID");

                    b.ToTable("Threads");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Friendship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.HasKey("Id");

                    b.HasIndex("FriendsUserID1");

                    b.HasIndex("FriendsUserID2");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1200)
                        .HasColumnType("nvarchar(1200)");

                    b.Property<int>("SenderUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ThreadID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SenderUserID");

                    b.HasIndex("ThreadID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.MessageAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AttachmentName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AttachmentURL")
                        .IsRequired()
                        .HasMaxLength(1200)
                        .HasColumnType("nvarchar(1200)");

                    b.Property<int>("MessageID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UploadedByUserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageID");

                    b.HasIndex("UploadedByUserID");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ThreadParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ParticipantType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ThreadID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ThreadID");

                    b.HasIndex("UserID");

                    b.ToTable("ThreadParticipants");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(1200)
                        .HasColumnType("nvarchar(1200)");

                    b.Property<DateTime?>("BirthDate")
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

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ProfilePicture")
                        .IsRequired()
                        .HasMaxLength(1200)
                        .HasColumnType("varbinary(1200)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Setting1")
                        .HasColumnType("bit");

                    b.Property<string>("Setting2")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastActiveAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserStatuses");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ChatThread", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.User", "User")
                        .WithMany("ChatThread")
                        .HasForeignKey("CreatedByUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Friendship", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.User", "FriendId1")
                        .WithMany("FriendshipUser1")
                        .HasForeignKey("FriendsUserID1")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.User", "FriendId2")
                        .WithMany("FriendshipUser2")
                        .HasForeignKey("FriendsUserID2")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FriendId1");

                    b.Navigation("FriendId2");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Message", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.User", "User")
                        .WithMany("Message")
                        .HasForeignKey("SenderUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.ChatThread", "ChatThread")
                        .WithMany("Message")
                        .HasForeignKey("ThreadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatThread");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.MessageAttachment", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.Message", "Message")
                        .WithMany("MessageAttachment")
                        .HasForeignKey("MessageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.User", "User")
                        .WithMany("MessageAttachment")
                        .HasForeignKey("UploadedByUserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ThreadParticipant", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.ChatThread", "ChatThread")
                        .WithMany("ThreadParticipant")
                        .HasForeignKey("ThreadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.User", "User")
                        .WithMany("ThreadParticipant")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
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
                    b.Navigation("Message");

                    b.Navigation("ThreadParticipant");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Message", b =>
                {
                    b.Navigation("MessageAttachment");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.User", b =>
                {
                    b.Navigation("ChatThread");

                    b.Navigation("FriendshipUser1");

                    b.Navigation("FriendshipUser2");

                    b.Navigation("Message");

                    b.Navigation("MessageAttachment");

                    b.Navigation("ThreadParticipant");

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
