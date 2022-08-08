﻿// <auto-generated />
using System;
using CrudUsuario.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudUsuario.Infra.Migrations
{
    [DbContext(typeof(dbCrudUsuarioContext))]
    [Migration("20220808135529_MigrationsCinco")]
    partial class MigrationsCinco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CrudUsuario.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(180)");

                    b.Property<DateTime?>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(180)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(180)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("VARCHAR(180)");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
