﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using registrosanna.Data;

#nullable disable

namespace registrosanna.Data
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231006052644_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("registrosanna.Models.Registro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("apemater");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("apepater");

                    b.Property<string>("ContrasenaHash")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contrasena");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("documento");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nombre");

                    b.Property<string>("PlanSalud")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("plansalud");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("tipodoc");

                    b.Property<string>("sexo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("sexo");

                    b.HasKey("Id");

                    b.ToTable("registro");
                });
#pragma warning restore 612, 618
        }
    }
}
