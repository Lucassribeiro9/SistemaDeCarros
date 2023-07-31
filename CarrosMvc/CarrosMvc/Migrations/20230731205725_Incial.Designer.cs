﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarrosMvc.Migrations
{
    [DbContext(typeof(CarroDbContext))]
    [Migration("20230731205725_Incial")]
    partial class Incial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarrosMvc.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CustoProducao")
                        .HasColumnType("float");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroChassi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroMotor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carros");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Carro");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CarrosMvc.Models.CarroDiesel", b =>
                {
                    b.HasBaseType("CarrosMvc.Models.Carro");

                    b.Property<double>("CapacidadeCarga")
                        .HasColumnType("float");

                    b.Property<double>("VolumeCacamba")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("CarroDiesel");
                });

            modelBuilder.Entity("CarrosMvc.Models.CarroEletrico", b =>
                {
                    b.HasBaseType("CarrosMvc.Models.Carro");

                    b.Property<double>("DuracaoBateria")
                        .HasColumnType("float");

                    b.Property<double>("Potencia")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("CarroEletrico");
                });

            modelBuilder.Entity("CarrosMvc.Models.CarroFlex", b =>
                {
                    b.HasBaseType("CarrosMvc.Models.Carro");

                    b.Property<double>("Cilindrada")
                        .HasColumnType("float");

                    b.Property<int>("NumeroPortas")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("CarroFlex");
                });
#pragma warning restore 612, 618
        }
    }
}
