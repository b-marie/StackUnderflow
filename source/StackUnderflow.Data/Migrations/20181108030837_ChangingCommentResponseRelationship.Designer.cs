﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackUnderflow.Data;

namespace StackUnderflow.Data.Migrations
{
    [DbContext(typeof(StackUnderflowDbContext))]
    [Migration("20181108030837_ChangingCommentResponseRelationship")]
    partial class ChangingCommentResponseRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StackUnderflow.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CommentedAt");

                    b.Property<string>("CommentedBy");

                    b.Property<bool>("IsActive");

                    b.Property<int>("ResponseId");

                    b.Property<string>("Text");

                    b.Property<int>("Votes");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("StackUnderflow.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("AskedAt");

                    b.Property<string>("AskedBy");

                    b.Property<bool>("IsActive");

                    b.Property<int>("ResponseSolutionId");

                    b.Property<string>("Text");

                    b.Property<int>("Topic");

                    b.Property<int>("Votes");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("StackUnderflow.Entities.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsSolution");

                    b.Property<int>("QuestionId");

                    b.Property<DateTimeOffset>("RespondedAt");

                    b.Property<string>("RespondedBy");

                    b.Property<string>("Text");

                    b.Property<int>("Votes");

                    b.HasKey("Id");

                    b.ToTable("Responses");
                });
#pragma warning restore 612, 618
        }
    }
}
