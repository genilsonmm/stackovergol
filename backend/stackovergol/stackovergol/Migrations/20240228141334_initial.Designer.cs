﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using stackovergol.Data;

#nullable disable

namespace stackovergol.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240228141334_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("stackovergol.Data.Entity.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Fhase")
                        .HasColumnType("int");

                    b.Property<int>("GolLeft")
                        .HasColumnType("int");

                    b.Property<int>("GolRight")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TeamLeftId")
                        .HasColumnType("int");

                    b.Property<int>("TeamRightId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("TeamLeftId");

                    b.HasIndex("TeamRightId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("stackovergol.Data.Entity.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsMember")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("stackovergol.Data.Entity.PlayerMatchStatistic", b =>
                {
                    b.Property<int>("PlayerMatchStatisticId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Gols")
                        .HasColumnType("int");

                    b.Property<int>("Losers")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Winners")
                        .HasColumnType("int");

                    b.HasKey("PlayerMatchStatisticId");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerMatchStatistic");
                });

            modelBuilder.Entity("stackovergol.Data.Entity.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("TeamId");

                    b.HasIndex("MatchId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("stackovergol.Data.Entity.Match", b =>
                {
                    b.HasOne("stackovergol.Data.Entity.Team", "TeamLeft")
                        .WithMany()
                        .HasForeignKey("TeamLeftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("stackovergol.Data.Entity.Team", "TeamRight")
                        .WithMany()
                        .HasForeignKey("TeamRightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamLeft");

                    b.Navigation("TeamRight");
                });

            modelBuilder.Entity("stackovergol.Data.Entity.Player", b =>
                {
                    b.HasOne("stackovergol.Data.Entity.Team", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("stackovergol.Data.Entity.PlayerMatchStatistic", b =>
                {
                    b.HasOne("stackovergol.Data.Entity.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("stackovergol.Data.Entity.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("stackovergol.Data.Entity.Team", b =>
                {
                    b.HasOne("stackovergol.Data.Entity.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("stackovergol.Data.Entity.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
