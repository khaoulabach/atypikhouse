using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Noyau.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Internautes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Statut = table.Column<string>(nullable: true),
                    ListeNoire = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internautes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proprietaires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Statut = table.Column<string>(nullable: true),
                    ListeNoire = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeBiens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    DescriptionAbrege = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBiens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Capacite = table.Column<long>(nullable: false),
                    Prix = table.Column<float>(nullable: false),
                    Statut = table.Column<string>(nullable: true),
                    ListeNoire = table.Column<bool>(nullable: true),
                    TypeBienId = table.Column<int>(nullable: true),
                    ProprietaireId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biens_Proprietaires_ProprietaireId",
                        column: x => x.ProprietaireId,
                        principalTable: "Proprietaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Biens_TypeBiens_TypeBienId",
                        column: x => x.TypeBienId,
                        principalTable: "TypeBiens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proprietes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IndObligatoire = table.Column<string>(nullable: true),
                    TypeBienId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proprietes_TypeBiens_TypeBienId",
                        column: x => x.TypeBienId,
                        principalTable: "TypeBiens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BienProprietes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BienId = table.Column<int>(nullable: true),
                    ProprieteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BienProprietes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BienProprietes_Biens_BienId",
                        column: x => x.BienId,
                        principalTable: "Biens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BienProprietes_Proprietes_ProprieteId",
                        column: x => x.ProprieteId,
                        principalTable: "Proprietes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BienProprietes_BienId",
                table: "BienProprietes",
                column: "BienId");

            migrationBuilder.CreateIndex(
                name: "IX_BienProprietes_ProprieteId",
                table: "BienProprietes",
                column: "ProprieteId");

            migrationBuilder.CreateIndex(
                name: "IX_Biens_ProprietaireId",
                table: "Biens",
                column: "ProprietaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Biens_TypeBienId",
                table: "Biens",
                column: "TypeBienId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietes_TypeBienId",
                table: "Proprietes",
                column: "TypeBienId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BienProprietes");

            migrationBuilder.DropTable(
                name: "Internautes");

            migrationBuilder.DropTable(
                name: "Biens");

            migrationBuilder.DropTable(
                name: "Proprietes");

            migrationBuilder.DropTable(
                name: "Proprietaires");

            migrationBuilder.DropTable(
                name: "TypeBiens");
        }
    }
}
