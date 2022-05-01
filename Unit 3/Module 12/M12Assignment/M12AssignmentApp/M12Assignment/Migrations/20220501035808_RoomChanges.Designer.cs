﻿// <auto-generated />
using M12Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace M12Assignment.Migrations
{
    [DbContext(typeof(RoomContext))]
    [Migration("20220501035808_RoomChanges")]
    partial class RoomChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("M12Assignment.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            Description = "You are in a room with exits to the North, East, South, and West.",
                            X = 0,
                            Y = 0
                        },
                        new
                        {
                            RoomId = 2,
                            Description = "You are in a room with an exit to the West.",
                            X = 1,
                            Y = 0
                        },
                        new
                        {
                            RoomId = 3,
                            Description = "You are in a room with an exit to the South.",
                            X = 0,
                            Y = 1
                        },
                        new
                        {
                            RoomId = 4,
                            Description = "You are in a room with an exit to the East.",
                            X = -1,
                            Y = 0
                        },
                        new
                        {
                            RoomId = 5,
                            Description = "You are in a room with an exit to the North.",
                            X = 0,
                            Y = -1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
