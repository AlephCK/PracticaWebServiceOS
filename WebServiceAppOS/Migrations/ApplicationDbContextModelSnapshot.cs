﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebServiceAppOS.Data;

namespace WebServiceAppOS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebServiceAppOS.Models.Acreditacion", b =>
                {
                    b.Property<string>("Matricula")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("aceptado");

                    b.Property<decimal>("costoTotal");

                    b.Property<int>("creditos");

                    b.HasKey("Matricula");

                    b.ToTable("Acreditaciones");
                });

            modelBuilder.Entity("WebServiceAppOS.Models.Detalle", b =>
                {
                    b.Property<int>("numEmision")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("cantidadEstudiante");

                    b.Property<DateTime>("fechaTransmision");

                    b.Property<decimal>("montoCredito");

                    b.HasKey("numEmision");

                    b.ToTable("Detalles");
                });
#pragma warning restore 612, 618
        }
    }
}
