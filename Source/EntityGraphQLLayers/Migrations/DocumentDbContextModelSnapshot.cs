﻿// <auto-generated />
using System;
using EntityGraphQLLayers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityGraphQLLayers.Migrations
{
    [DbContext(typeof(DocumentDbContext))]
    partial class DocumentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("EntityGraphQLLayers.Models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttachmentType")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("EntityGraphQLLayers.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DocumentType")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("EntityGraphQLLayers.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EntityGraphQLLayers.Models.Attachment", b =>
                {
                    b.HasOne("EntityGraphQLLayers.Models.Document", null)
                        .WithMany("Attachments")
                        .HasForeignKey("DocumentId");
                });

            modelBuilder.Entity("EntityGraphQLLayers.Models.Document", b =>
                {
                    b.HasOne("EntityGraphQLLayers.Models.Project", null)
                        .WithMany("Documents")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("EntityGraphQLLayers.Models.Document", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("EntityGraphQLLayers.Models.Project", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
