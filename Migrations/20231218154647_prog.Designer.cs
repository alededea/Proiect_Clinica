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
    [Migration("20231218154647_prog")]
    partial class prog
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

            modelBuilder.Entity("Proiect_Clinica.Models.Animal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNastere")
                        .HasColumnType("datetime2");

                    b.Property<double>("Greutate")
                        .HasColumnType("float");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rasa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Animale");
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

            modelBuilder.Entity("Proiect_Clinica.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Proiect_Clinica.Models.Programare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServiciuID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("ServiciuID");

                    b.ToTable("Programare");
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

            modelBuilder.Entity("Proiect_Clinica.Models.Animal", b =>
                {
                    b.HasOne("Proiect_Clinica.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Proiect_Clinica.Models.Programare", b =>
                {
                    b.HasOne("Proiect_Clinica.Models.Client", "Client")
                        .WithMany("Programari")
                        .HasForeignKey("ClientID");

                    b.HasOne("Proiect_Clinica.Models.Serviciu", "Serviciu")
                        .WithMany("Programari")
                        .HasForeignKey("ServiciuID");

                    b.Navigation("Client");

                    b.Navigation("Serviciu");
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

            modelBuilder.Entity("Proiect_Clinica.Models.Client", b =>
                {
                    b.Navigation("Programari");
                });

            modelBuilder.Entity("Proiect_Clinica.Models.Serviciu", b =>
                {
                    b.Navigation("Programari");
                });
#pragma warning restore 612, 618
        }
    }
}
