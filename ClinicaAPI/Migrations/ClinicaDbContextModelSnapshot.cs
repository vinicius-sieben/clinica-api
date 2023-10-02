﻿// <auto-generated />
using System;
using ClinicaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicaAPI.Migrations
{
    [DbContext(typeof(ClinicaDbContext))]
    partial class ClinicaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("ClinicaAPI.Models.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdMedico")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Razao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("ClinicaAPI.Models.Exame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Exame");
                });

            modelBuilder.Entity("ClinicaAPI.Models.Medico", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("ClinicaAPI.Models.Paciente", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("ClinicaAPI.Models.Prontuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tratamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Prontuario");
                });

            modelBuilder.Entity("ClinicaAPI.Models.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dosagem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdMedico")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InstrucoesUso")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Medicamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Receita");
                });
#pragma warning restore 612, 618
        }
    }
}
