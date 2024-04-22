﻿// <auto-generated />
using System;
using Messenger.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Messenger.Persistence.Migrations
{
    [DbContext(typeof(MessengerDbContext))]
    partial class MessengerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Messenger.Persistence.Entities.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationTS")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<long>("MessageThreadId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModificationTS")
                        .HasColumnType("datetime2");

                    b.Property<long>("SenderUserAccountId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MessageThreadId");

                    b.HasIndex("SenderUserAccountId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.MessageAttachment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AttachmentBlobUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttachmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreationTS")
                        .HasColumnType("datetime2");

                    b.Property<long>("MessageId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModificationTS")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageAttachments");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Thread", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationTS")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreationUserAccountId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsGroup")
                        .HasColumnType("bit");

                    b.Property<long>("MessageId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModificationTS")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThreadName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreationUserAccountId");

                    b.HasIndex("MessageId");

                    b.ToTable("Threads");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ThreadMember", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationTS")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationTS")
                        .HasColumnType("datetime2");

                    b.Property<long>("ThreadId")
                        .HasColumnType("bigint");

                    b.Property<long>("ThreadMemberUserAccountId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ThreadId");

                    b.HasIndex("ThreadMemberUserAccountId");

                    b.ToTable("ThreadMembers");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("CreationTS")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("ModificationTS")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PictureBlobUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationTS")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModificationTS")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserContact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ContactUserAccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationTS")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFriends")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModificationTS")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserAccountId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ContactUserAccountId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("UserContacts");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserSettings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationTS")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModificationTS")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Theme")
                        .HasColumnType("bit");

                    b.Property<long>("UserAccountId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Message", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.Thread", "Thread")
                        .WithMany("Messages")
                        .HasForeignKey("MessageThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.UserAccount", "UserAccount")
                        .WithMany("Messages")
                        .HasForeignKey("SenderUserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Thread");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.MessageAttachment", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.Message", "Message")
                        .WithMany("MessageAttachments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Thread", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.UserAccount", "UserAccount")
                        .WithMany("Threads")
                        .HasForeignKey("CreationUserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ThreadMember", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.Thread", "Thread")
                        .WithMany("ThreadMembers")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.UserAccount", "UserAccount")
                        .WithMany("ThreadMembers")
                        .HasForeignKey("ThreadMemberUserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Thread");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserAccount", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.User", "User")
                        .WithOne("UserAccount")
                        .HasForeignKey("Messenger.Persistence.Entities.UserAccount", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserContact", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.UserAccount", "ContactUserAccount")
                        .WithMany("ContactUserContacts")
                        .HasForeignKey("ContactUserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.UserAccount", "UserAccount")
                        .WithMany("UserContacts")
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactUserAccount");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserSettings", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.UserAccount", "UserAccount")
                        .WithOne("UserSettings")
                        .HasForeignKey("Messenger.Persistence.Entities.UserSettings", "UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Message", b =>
                {
                    b.Navigation("MessageAttachments");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.Thread", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("ThreadMembers");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.User", b =>
                {
                    b.Navigation("UserAccount")
                        .IsRequired();
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserAccount", b =>
                {
                    b.Navigation("ContactUserContacts");

                    b.Navigation("Messages");

                    b.Navigation("ThreadMembers");

                    b.Navigation("Threads");

                    b.Navigation("UserContacts");

                    b.Navigation("UserSettings")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
