﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORT_PNT1_Proyecto_2022_2C_I_Foro.Data;

#nullable disable

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Migrations
{
    [DbContext(typeof(ForoContext))]
    [Migration("20221127151147_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoriaPregunta", b =>
                {
                    b.Property<int>("CategoriasCategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("PreguntasPreguntaId")
                        .HasColumnType("int");

                    b.HasKey("CategoriasCategoriaId", "PreguntasPreguntaId");

                    b.HasIndex("PreguntasPreguntaId");

                    b.ToTable("CategoriaPregunta");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Administrador", b =>
                {
                    b.Property<int>("AdministradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdministradorId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdministradorId");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Miembro", b =>
                {
                    b.Property<int>("MiembroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MiembroId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MiembroId");

                    b.ToTable("Miembros");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Pregunta", b =>
                {
                    b.Property<int>("PreguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PreguntaId"), 1L, 1);

                    b.Property<bool>("Activa")
                        .HasColumnType("bit");

                    b.Property<int>("CantMeGustas")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("MiembroId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PreguntaId");

                    b.HasIndex("MiembroId");

                    b.ToTable("Pregunta", (string)null);
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Respuesta", b =>
                {
                    b.Property<int>("RespuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RespuestaId"), 1L, 1);

                    b.Property<int>("CantMeGustas")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("MiembroId")
                        .HasColumnType("int");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.HasKey("RespuestaId");

                    b.HasIndex("MiembroId");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuestas");
                });

            modelBuilder.Entity("CategoriaPregunta", b =>
                {
                    b.HasOne("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriasCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Pregunta", null)
                        .WithMany()
                        .HasForeignKey("PreguntasPreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Pregunta", b =>
                {
                    b.HasOne("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Miembro", "Miembro")
                        .WithMany("Preguntas")
                        .HasForeignKey("MiembroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Miembro");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Respuesta", b =>
                {
                    b.HasOne("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Miembro", "Miembro")
                        .WithMany("Respuestas")
                        .HasForeignKey("MiembroId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Pregunta", "Pregunta")
                        .WithMany("Respuestas")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Miembro");

                    b.Navigation("Pregunta");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Miembro", b =>
                {
                    b.Navigation("Preguntas");

                    b.Navigation("Respuestas");
                });

            modelBuilder.Entity("ORT_PNT1_Proyecto_2022_2C_I_Foro.Models.Pregunta", b =>
                {
                    b.Navigation("Respuestas");
                });
#pragma warning restore 612, 618
        }
    }
}