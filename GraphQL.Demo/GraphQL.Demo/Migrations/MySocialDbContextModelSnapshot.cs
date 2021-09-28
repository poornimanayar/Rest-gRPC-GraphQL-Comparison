﻿// <auto-generated />
using GraphQL.Demo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQL.Demo.Migrations
{
    [DbContext(typeof(MySocialDbContext))]
    partial class MySocialDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("GraphQL.Demo.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommenterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("StoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CommenterId");

                    b.HasIndex("StoryId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommenterId = 4,
                            Description = "Welcome to Hogwarts, Harry!",
                            StoryId = 7
                        });
                });

            modelBuilder.Entity("GraphQL.Demo.Models.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("StoryOwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StoryOwnerId");

                    b.ToTable("Stories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Life at Privet Drive is not that great!",
                            StoryOwnerId = 1,
                            Title = "Life at Privet Drive"
                        },
                        new
                        {
                            Id = 2,
                            Description = "I get a letter from Hogwarts, I am surprised!",
                            StoryOwnerId = 1,
                            Title = "I get a letter from Hogwarts"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Uncle Vernon tore the letter which came from Hogwarts",
                            StoryOwnerId = 1,
                            Title = "Uncle Vernon tore the letter"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The house is flooded with letters from Hogwarts",
                            StoryOwnerId = 1,
                            Title = "Many more letters arrive"
                        },
                        new
                        {
                            Id = 5,
                            Description = "We go to an island to escape from the letters",
                            StoryOwnerId = 1,
                            Title = "We go to an island"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Hagrid, the gamekeeper of Hogwarts, turns up with my birthday cake and a letter from Hogwarts",
                            StoryOwnerId = 1,
                            Title = "Hagrid turns up"
                        },
                        new
                        {
                            Id = 7,
                            Description = "I just got to know from Hagrid that I am a wizard!",
                            StoryOwnerId = 1,
                            Title = "I am a WIZARD!"
                        },
                        new
                        {
                            Id = 8,
                            Description = "I visit DiagonAlley to purchase essentials for my school",
                            StoryOwnerId = 1,
                            Title = "I visit DiagonAlley"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Lord Voldemort is back",
                            StoryOwnerId = 10,
                            Title = "I am back"
                        });
                });

            modelBuilder.Entity("GraphQL.Demo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Headline")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Headline = "The boy who lived",
                            Name = "Harry Potter"
                        },
                        new
                        {
                            Id = 2,
                            Headline = "Super Auror",
                            Name = "Ronald Weasley"
                        },
                        new
                        {
                            Id = 3,
                            Headline = "Books",
                            Name = "Hermione Granger"
                        },
                        new
                        {
                            Id = 4,
                            Headline = "Headmaster, Hogwarts",
                            Name = "Albus Dumbledore"
                        },
                        new
                        {
                            Id = 5,
                            Headline = "The boy who lived",
                            Name = "Neville Longbottom"
                        },
                        new
                        {
                            Id = 6,
                            Headline = "Gryffindor",
                            Name = "Professor Minerva McGonagall"
                        },
                        new
                        {
                            Id = 7,
                            Headline = "Proud Centaur",
                            Name = "Firenze"
                        },
                        new
                        {
                            Id = 8,
                            Headline = "Hogwarts Gamekeeper",
                            Name = "Hagrid"
                        },
                        new
                        {
                            Id = 9,
                            Headline = "The Half-Blood Prince",
                            Name = "Severus Snape"
                        },
                        new
                        {
                            Id = 10,
                            Headline = "Darkness",
                            Name = "Lord Voldemort"
                        });
                });

            modelBuilder.Entity("GraphQL.Demo.Models.Comment", b =>
                {
                    b.HasOne("GraphQL.Demo.Models.User", "Commenter")
                        .WithMany()
                        .HasForeignKey("CommenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphQL.Demo.Models.Story", "Story")
                        .WithMany()
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commenter");

                    b.Navigation("Story");
                });

            modelBuilder.Entity("GraphQL.Demo.Models.Story", b =>
                {
                    b.HasOne("GraphQL.Demo.Models.User", "StoryOwner")
                        .WithMany()
                        .HasForeignKey("StoryOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoryOwner");
                });
#pragma warning restore 612, 618
        }
    }
}
