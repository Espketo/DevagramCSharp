﻿// <auto-generated />
using System;
using DevagramCSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevagramCSharp.Migrations
{
    [DbContext(typeof(DevagramContext))]
    [Migration("20220824175114_TabelaSeguidores")]
    partial class TabelaSeguidores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DevagramCSharp.Models.Seguidor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("IdSeguidor")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioSeguido")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioSeguidor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioSeguido");

                    b.HasIndex("IdUsuarioSeguidor");

                    b.ToTable("Seguidores");
                });

            modelBuilder.Entity("DevagramCSharp.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoPerfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DevagramCSharp.Models.Seguidor", b =>
                {
                    b.HasOne("DevagramCSharp.Models.Usuario", "UsuarioSeguido")
                        .WithMany()
                        .HasForeignKey("IdUsuarioSeguido");

                    b.HasOne("DevagramCSharp.Models.Usuario", "UsuarioSeguidor")
                        .WithMany()
                        .HasForeignKey("IdUsuarioSeguidor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioSeguido");

                    b.Navigation("UsuarioSeguidor");
                });
#pragma warning restore 612, 618
        }
    }
}
