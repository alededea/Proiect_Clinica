﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Clinica.Data;

#nullable disable

namespace Proiect_Clinica.Migrations
{
    [DbContext(typeof(Proiect_ClinicaContext))]
    [Migration("20231211094832_Angajat")]
    partial class Angajat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Clinica.Models.Angajat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Calificare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Angajat");
                });

            modelBuilder.Entity("Proiect_Clinica.Models.Serviciu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AngajatID")
                        .HasColumnType("int");

                    b.Property<decimal>("Durata")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("AngajatID");

                    b.ToTable("Serviciu");
                });

            modelBuilder.Entity("Proiect_Clinica.Models.Serviciu", b =>
                {
                    b.HasOne("Proiect_Clinica.Models.Angajat", "Angajat")
                        .WithMany("Servicii")
                        .HasForeignKey("AngajatID");

                    b.Navigation("Angajat");
                });

            modelBuilder.Entity("Proiect_Clinica.Models.Angajat", b =>
                {
                    b.Navigation("Servicii");
                });
#pragma warning restore 612, 618
        }
    }
}
