﻿// <auto-generated />
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(DbEquationContext))]
    [Migration("20230218021322_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api.Models.EquationInput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FifthInput")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("FirstInput")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("FourthInput")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("SecondInput")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("SixthInput")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("ThirdInput")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("Equations");
                });
#pragma warning restore 612, 618
        }
    }
}
