﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Clinica.Data;

#nullable disable

namespace Proiect_Clinica.Migrations
{
    [DbContext(typeof(Proiect_ClinicaContext))]
    partial class Proiect_ClinicaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAngajare")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Angajat");
                });

            modelBuilder.Entity("Proiect_Clinica.Models.AngajatCalificare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AngajatID")
                        .HasColumnType("int");

                    b.Property<int>("CalificareID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AngajatID");

                    b.HasIndex("CalificareID");

                    b.ToTable("AngajatCalificare");
                });

            modelBuilder.Entity("Proiect_Clinica.Models.Calificare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CalificareTip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Calificare");
                });

            modelBuilder.Entity("Proiect_Clinica.Models.Serviciu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AngajatID")
                        .HasColumnType("int");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("AngajatID");

                    b.ToTable("Serviciu");
                });

            modelBuilder.Entity("Proiect_Clinica.Models.AngajatCalificare", b =>
                {
                    b.HasOne("Proiect_Clinica.Models.Angajat", "Angajat")
                        .WithMany("AngajatCalificari")
                        .HasForeignKey("AngajatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Clinica.Models.Calificare", "Calificare")
                        .WithMany("AngajatCalificari")
                        .HasForeignKey("CalificareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Angajat");

                    b.Navigation("Calificare");
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
                    b.Navigation("AngajatCalificari");

                    b.Navigation("Servicii");
                });

            modelBuilder.Entity("Proiect_Clinica.Models.Calificare", b =>
                {
                    b.Navigation("AngajatCalificari");
                });
#pragma warning restore 612, 618
        }
    }
}
