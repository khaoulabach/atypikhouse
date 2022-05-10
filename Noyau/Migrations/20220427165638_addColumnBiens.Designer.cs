﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Noyau;

namespace Noyau.Migrations
{
    [DbContext(typeof(LocationBiensContext))]
    [Migration("20220427165638_addColumnBiens")]
    partial class addColumnBiens
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Noyau.Bien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Capacite")
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Couchage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Equipements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ListeNoire")
                        .HasColumnType("bit");

                    b.Property<string>("Localisation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.Property<int?>("ProprietaireId")
                        .HasColumnType("int");

                    b.Property<string>("Statut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Superficie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeBienId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProprietaireId");

                    b.HasIndex("TypeBienId");

                    b.ToTable("Biens");
                });

            modelBuilder.Entity("Noyau.BienPropriete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BienId")
                        .HasColumnType("int");

                    b.Property<int?>("ProprieteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BienId");

                    b.HasIndex("ProprieteId");

                    b.ToTable("BienProprietes");
                });

            modelBuilder.Entity("Noyau.Commentaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BienId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InternauteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BienId");

                    b.HasIndex("InternauteId");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("Noyau.Internaute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ListeNoire")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Internautes");
                });

            modelBuilder.Entity("Noyau.Proprietaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ListeNoire")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proprietaires");
                });

            modelBuilder.Entity("Noyau.Propriete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndObligatoire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeBienId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeBienId");

                    b.ToTable("Proprietes");
                });

            modelBuilder.Entity("Noyau.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BienId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InternauteId")
                        .HasColumnType("int");

                    b.Property<string>("Statut")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BienId");

                    b.HasIndex("InternauteId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Noyau.TypeBien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionAbrege")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeBiens");
                });

            modelBuilder.Entity("Noyau.Bien", b =>
                {
                    b.HasOne("Noyau.Proprietaire", "Proprietaire")
                        .WithMany("Biens")
                        .HasForeignKey("ProprietaireId");

                    b.HasOne("Noyau.TypeBien", "TypeBien")
                        .WithMany("Biens")
                        .HasForeignKey("TypeBienId");
                });

            modelBuilder.Entity("Noyau.BienPropriete", b =>
                {
                    b.HasOne("Noyau.Bien", "Bien")
                        .WithMany("BienProprietes")
                        .HasForeignKey("BienId");

                    b.HasOne("Noyau.Propriete", "Propriete")
                        .WithMany("BienProprietes")
                        .HasForeignKey("ProprieteId");
                });

            modelBuilder.Entity("Noyau.Commentaire", b =>
                {
                    b.HasOne("Noyau.Bien", "Bien")
                        .WithMany("Commentaires")
                        .HasForeignKey("BienId");

                    b.HasOne("Noyau.Internaute", "Internaute")
                        .WithMany("Commentaires")
                        .HasForeignKey("InternauteId");
                });

            modelBuilder.Entity("Noyau.Propriete", b =>
                {
                    b.HasOne("Noyau.TypeBien", "TypeBien")
                        .WithMany("Proprietes")
                        .HasForeignKey("TypeBienId");
                });

            modelBuilder.Entity("Noyau.Reservation", b =>
                {
                    b.HasOne("Noyau.Bien", "Bien")
                        .WithMany("Reservations")
                        .HasForeignKey("BienId");

                    b.HasOne("Noyau.Internaute", "Internaute")
                        .WithMany("Reservations")
                        .HasForeignKey("InternauteId");
                });
#pragma warning restore 612, 618
        }
    }
}
