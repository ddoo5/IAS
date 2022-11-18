﻿// <auto-generated />
using IAS.DB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IAS.Migrations
{
    [DbContext(typeof(DbDocsContext))]
    [Migration("20221114064829_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("IAS.Models.DocumentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("TEXT")
                        .HasColumnName("content");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("IAS.Models.WordDocumentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("DocumentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("documentid");

                    b.Property<int>("WordId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("wordid");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("WordId");

                    b.HasIndex("WordId", "DocumentId")
                        .IsUnique();

                    b.ToTable("WordDocuments");
                });

            modelBuilder.Entity("IAS.Models.WordsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.HasIndex("Text")
                        .IsUnique();

                    b.ToTable("Words");
                });

            modelBuilder.Entity("IAS.Models.WordDocumentModel", b =>
                {
                    b.HasOne("IAS.Models.DocumentModel", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IAS.Models.WordsModel", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Word");
                });
#pragma warning restore 612, 618
        }
    }
}
