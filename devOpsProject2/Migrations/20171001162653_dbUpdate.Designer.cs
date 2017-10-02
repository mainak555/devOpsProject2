﻿// <auto-generated />
using devOpsProject2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace devOpsProject2.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20171001162653_dbUpdate")]
    partial class dbUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("devOpsProject2.Models.CD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Artists");

                    b.Property<int>("ReleaseYear");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("TotalDuration");

                    b.Property<int>("TotalTracks");

                    b.HasKey("Id");

                    b.ToTable("CD");
                });

            modelBuilder.Entity("devOpsProject2.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Authors");

                    b.Property<int?>("CDId");

                    b.Property<int>("Duration");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CDId");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("devOpsProject2.Models.Track", b =>
                {
                    b.HasOne("devOpsProject2.Models.CD")
                        .WithMany("Tracks")
                        .HasForeignKey("CDId");
                });
#pragma warning restore 612, 618
        }
    }
}
