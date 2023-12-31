﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPGClash.Infrastucture.Repositories;

#nullable disable

namespace RPGClash.Infrastucture.Migrations
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20231106112110_initial_migration")]
    partial class initial_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RPGClash.Domain.Characters.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AllreadyMadeMove")
                        .HasColumnType("bit");

                    b.Property<int>("BasicHealingPoint")
                        .HasColumnType("int");

                    b.Property<int>("BasicHeatPoint")
                        .HasColumnType("int");

                    b.Property<int>("CurrentHealth")
                        .HasColumnType("int");

                    b.Property<int>("CurrentMana")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTaunted")
                        .HasColumnType("bit");

                    b.Property<int>("TauntedTargetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TauntedTargetId");

                    b.ToTable("Character");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Character");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.CharacterAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActionKey")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.GameState", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<int>("Player1Id")
                        .HasColumnType("int");

                    b.Property<int>("Player2Id")
                        .HasColumnType("int");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("GameStates");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("DoneWithMoves")
                        .HasColumnType("bit");

                    b.Property<int>("GameStateId")
                        .HasColumnType("int");

                    b.Property<string>("GameStateId1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameStateId1");

                    b.HasIndex("UserId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<int?>("Player1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Player2Id")
                        .HasColumnType("int");

                    b.Property<bool>("Vacant")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRankId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserRankId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.UserRank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserRanks");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.DbCharacter", b =>
                {
                    b.HasBaseType("RPGClash.Domain.Characters.Character");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasIndex("PlayerId");

                    b.HasDiscriminator().HasValue("DbCharacter");
                });

            modelBuilder.Entity("RPGClash.Domain.Characters.Character", b =>
                {
                    b.HasOne("RPGClash.Domain.Characters.Character", "TauntedTarget")
                        .WithMany()
                        .HasForeignKey("TauntedTargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TauntedTarget");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.GameState", b =>
                {
                    b.HasOne("RPGClash.Domain.Entities.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RPGClash.Domain.Entities.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RPGClash.Domain.Entities.User", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Player1");

                    b.Navigation("Player2");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.Player", b =>
                {
                    b.HasOne("RPGClash.Domain.Entities.GameState", "GameState")
                        .WithMany()
                        .HasForeignKey("GameStateId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RPGClash.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameState");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.Room", b =>
                {
                    b.HasOne("RPGClash.Domain.Entities.User", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RPGClash.Domain.Entities.User", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Player1");

                    b.Navigation("Player2");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.User", b =>
                {
                    b.HasOne("RPGClash.Domain.Entities.User", null)
                        .WithMany("Friends")
                        .HasForeignKey("UserId");

                    b.HasOne("RPGClash.Domain.Entities.UserRank", "UserRank")
                        .WithMany("Users")
                        .HasForeignKey("UserRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRank");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.DbCharacter", b =>
                {
                    b.HasOne("RPGClash.Domain.Entities.Player", null)
                        .WithMany("Characters")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.Player", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.User", b =>
                {
                    b.Navigation("Friends");
                });

            modelBuilder.Entity("RPGClash.Domain.Entities.UserRank", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
