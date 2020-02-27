﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using casaDeShows.Data;

namespace casaDeShows.Migrations
{
    [DbContext(typeof(ApplicationDbContextEntidades))]
    partial class ApplicationDbContextEntidadesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("casaDeShows.Models.CasaDeShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NomeCasaDeShow")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("CasaDeShows");
                });

            modelBuilder.Entity("casaDeShows.Models.CompraEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("QtdIngresso")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("ValorCompra")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("CompraEventos");
                });

            modelBuilder.Entity("casaDeShows.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<int?>("CasaDeShowsId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("GeneroDoEventoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioEvento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeDoEvento")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("PrecoIngresso")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CasaDeShowsId");

                    b.HasIndex("GeneroDoEventoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("casaDeShows.Models.GeneroEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("GeneroEventos");
                });

            modelBuilder.Entity("casaDeShows.Models.CompraEvento", b =>
                {
                    b.HasOne("casaDeShows.Models.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("casaDeShows.Models.Evento", b =>
                {
                    b.HasOne("casaDeShows.Models.CasaDeShow", "CasaDeShow")
                        .WithMany()
                        .HasForeignKey("CasaDeShowsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("casaDeShows.Models.GeneroEvento", "GeneroEvento")
                        .WithMany()
                        .HasForeignKey("GeneroDoEventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
