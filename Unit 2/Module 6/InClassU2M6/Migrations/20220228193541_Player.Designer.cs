﻿// <auto-generated />
using InClassU2M6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InClassU2M6.Migrations
{
    [DbContext(typeof(ChessContext))]
    [Migration("20220228193541_Player")]
    partial class Player
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InClassU2M6.Models.Chess", b =>
                {
                    b.Property<int>("ChessID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Moves")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChessID");

                    b.ToTable("Chess");

                    b.HasData(
                        new
                        {
                            ChessID = 1,
                            Moves = "1.e4",
                            Name = "King's Pawn"
                        },
                        new
                        {
                            ChessID = 2,
                            Moves = "1.e4 c5",
                            Name = "Sicilian Defense"
                        },
                        new
                        {
                            ChessID = 3,
                            Moves = "1.e4 e5 2.Nf3 Nc6 3.Bc4 ",
                            Name = "Italian Game"
                        });
                });

            modelBuilder.Entity("InClassU2M6.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerID");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerID = 1,
                            Name = "Magnus Carlson"
                        },
                        new
                        {
                            PlayerID = 2,
                            Name = "Ian Nepomniachtchi"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
