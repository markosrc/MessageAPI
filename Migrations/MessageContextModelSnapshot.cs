﻿// <auto-generated />
using System;
using MessageAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MessageAPI.Migrations
{
    [DbContext(typeof(MessageContext))]
    partial class MessageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MessageAPI.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("MessageAPI.Models.Osoba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmailId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailId")
                        .IsUnique()
                        .HasFilter("[EmailId] IS NOT NULL");

                    b.ToTable("Osobe");
                });

            modelBuilder.Entity("MessageAPI.Models.Poruka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmailOdId")
                        .HasColumnType("int");

                    b.Property<int?>("EmailPremaId")
                        .HasColumnType("int");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailOdId");

                    b.HasIndex("EmailPremaId");

                    b.ToTable("Poruke");
                });

            modelBuilder.Entity("MessageAPI.Models.Osoba", b =>
                {
                    b.HasOne("MessageAPI.Models.Email", "Email")
                        .WithOne("Osoba")
                        .HasForeignKey("MessageAPI.Models.Osoba", "EmailId");

                    b.Navigation("Email");
                });

            modelBuilder.Entity("MessageAPI.Models.Poruka", b =>
                {
                    b.HasOne("MessageAPI.Models.Email", "EmailOd")
                        .WithMany()
                        .HasForeignKey("EmailOdId");

                    b.HasOne("MessageAPI.Models.Email", "EmailPrema")
                        .WithMany()
                        .HasForeignKey("EmailPremaId");

                    b.Navigation("EmailOd");

                    b.Navigation("EmailPrema");
                });

            modelBuilder.Entity("MessageAPI.Models.Email", b =>
                {
                    b.Navigation("Osoba");
                });
#pragma warning restore 612, 618
        }
    }
}
