﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Confitec.DataContext;

#nullable disable

namespace Projeto_Confitec.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Projeto_Confitec.Models.NivelEscolar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NiveisEscolares");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Infantil"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Fundamental"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Médio"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Superior"
                        });
                });

            modelBuilder.Entity("Projeto_Confitec.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NivelEscolarId")
                        .HasColumnType("int");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobrenomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("NivelEscolarId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            DataNascimento = new DateTime(2000, 7, 7, 2, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailUsuario = "jjesus@gmail.com",
                            NivelEscolarId = 1,
                            NomeUsuario = "Jorge",
                            SobrenomeUsuario = "de Jesus"
                        },
                        new
                        {
                            IdUsuario = 2,
                            DataNascimento = new DateTime(1985, 9, 3, 2, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailUsuario = "enascimento@gmail.com",
                            NivelEscolarId = 2,
                            NomeUsuario = "Emilio",
                            SobrenomeUsuario = "Nascimento"
                        },
                        new
                        {
                            IdUsuario = 3,
                            DataNascimento = new DateTime(1999, 10, 20, 2, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailUsuario = "fahrenheitizin@gmail.com",
                            NivelEscolarId = 3,
                            NomeUsuario = "João",
                            SobrenomeUsuario = "Fahrenheit"
                        },
                        new
                        {
                            IdUsuario = 4,
                            DataNascimento = new DateTime(1990, 12, 24, 2, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailUsuario = "cleytrambiq@gmail.com",
                            NivelEscolarId = 1,
                            NomeUsuario = "Cleysson",
                            SobrenomeUsuario = "Trambique"
                        },
                        new
                        {
                            IdUsuario = 5,
                            DataNascimento = new DateTime(1995, 7, 17, 2, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailUsuario = "jordanJu@gmail.com",
                            NivelEscolarId = 4,
                            NomeUsuario = "Julio",
                            SobrenomeUsuario = "Jordan"
                        });
                });

            modelBuilder.Entity("Projeto_Confitec.Models.Usuario", b =>
                {
                    b.HasOne("Projeto_Confitec.Models.NivelEscolar", "NivelEscolar")
                        .WithMany()
                        .HasForeignKey("NivelEscolarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NivelEscolar");
                });
#pragma warning restore 612, 618
        }
    }
}
