﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Milyoncu.Dal;

#nullable disable

namespace Milyoncu.Dal.Migrations
{
    [DbContext(typeof(MilyoncuContext))]
    partial class MilyoncuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Milyoncu.Entity.Concrete.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("TicketQuantity")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("TicketPrice")
                        .HasColumnType("int");

                    b.Property<int>("TicketQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("TicketPrice")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Error")
                        .HasColumnType("bit");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.Event", b =>
                {
                    b.HasOne("Milyoncu.Entity.Concrete.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Milyoncu.Entity.Concrete.Category", null)
                        .WithMany("Events")
                        .HasForeignKey("EventId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.Ticket", b =>
                {
                    b.HasOne("Milyoncu.Entity.Concrete.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Milyoncu.Entity.Concrete.Basket", null)
                        .WithMany("Ticket")
                        .HasForeignKey("TicketId");

                    b.HasOne("Milyoncu.Entity.Concrete.Event", null)
                        .WithMany("Tickets")
                        .HasForeignKey("TicketId");

                    b.HasOne("Milyoncu.Entity.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.User", b =>
                {
                    b.HasOne("Milyoncu.Entity.Concrete.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.Wallet", b =>
                {
                    b.HasOne("Milyoncu.Entity.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.Basket", b =>
                {
                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Milyoncu.Entity.Concrete.Event", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
