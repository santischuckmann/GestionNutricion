﻿// <auto-generated />
using System;
using GestionNutricion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionNutricion.Infrastructure.Migrations
{
    [DbContext(typeof(GestionNutricionContext))]
    partial class GestionNutricionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionNutricion.Core.Entitys.DietaryPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Breakfast")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Dinner")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Lunch")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DietaryPlan", (string)null);
                });

            modelBuilder.Entity("GestionNutricion.Core.Entitys.PlanSnack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Food")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdDietaryPlan")
                        .HasColumnType("int");

                    b.Property<DateTime>("IntakeHour")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdDietaryPlan");

                    b.ToTable("PlanSnack", (string)null);
                });

            modelBuilder.Entity("GestionNutricion.Core.Entitys.Snack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Food")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("IntakeHour")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Snack", (string)null);
                });

            modelBuilder.Entity("GestionNutricion.Core.Entitys.PlanSnack", b =>
                {
                    b.HasOne("GestionNutricion.Core.Entitys.DietaryPlan", "DietaryPlan")
                        .WithMany("PlanSnacks")
                        .HasForeignKey("IdDietaryPlan")
                        .IsRequired();

                    b.Navigation("DietaryPlan");
                });

            modelBuilder.Entity("GestionNutricion.Core.Entitys.DietaryPlan", b =>
                {
                    b.Navigation("PlanSnacks");
                });
#pragma warning restore 612, 618
        }
    }
}