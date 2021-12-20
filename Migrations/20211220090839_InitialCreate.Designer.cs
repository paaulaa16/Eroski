﻿// <auto-generated />
using ApiEroski.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiEroski.Migrations
{
    [DbContext(typeof(EroskiContext))]
    [Migration("20211220090839_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ApiEroski.Models.Eroski", b =>
                {
                    b.Property<string>("Seccion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Ticket")
                        .HasColumnType("int");

                    b.HasKey("Seccion");

                    b.ToTable("Eroski");
                });
#pragma warning restore 612, 618
        }
    }
}