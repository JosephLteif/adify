﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Adify.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20211221074548_m3")]
    partial class m3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Adify.Models.Ad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnalyticsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DidPass")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnalyticsId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Ad");
                });

            modelBuilder.Entity("Adify.Models.Analytics", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Analytics");
                });

            modelBuilder.Entity("Adify.Models.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnalyticsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("DurationInDays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnalyticsId");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("Adify.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Adify.Models.Click", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnalyticsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ClickedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnalyticsId");

                    b.ToTable("Click");
                });

            modelBuilder.Entity("Adify.Models.View", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnalyticsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ViewedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AnalyticsId");

                    b.ToTable("View");
                });

            modelBuilder.Entity("Adify.Models.Ad", b =>
                {
                    b.HasOne("Adify.Models.Analytics", "Analytics")
                        .WithMany()
                        .HasForeignKey("AnalyticsId");

                    b.HasOne("Adify.Models.Campaign", null)
                        .WithMany("Ads")
                        .HasForeignKey("CampaignId");

                    b.HasOne("Adify.Models.Category", "Category")
                        .WithMany("ads")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Adify.Models.Campaign", b =>
                {
                    b.HasOne("Adify.Models.Analytics", "Analytics")
                        .WithMany()
                        .HasForeignKey("AnalyticsId");
                });

            modelBuilder.Entity("Adify.Models.Click", b =>
                {
                    b.HasOne("Adify.Models.Analytics", null)
                        .WithMany("Clicks")
                        .HasForeignKey("AnalyticsId");
                });

            modelBuilder.Entity("Adify.Models.View", b =>
                {
                    b.HasOne("Adify.Models.Analytics", null)
                        .WithMany("Views")
                        .HasForeignKey("AnalyticsId");
                });
#pragma warning restore 612, 618
        }
    }
}
