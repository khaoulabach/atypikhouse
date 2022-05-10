using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Noyau.Migrations
{
    public partial class partieReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commentaire",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    BienId = table.Column<int>(nullable: true),
                    InternauteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaire_Biens_BienId",
                        column: x => x.BienId,
                        principalTable: "Biens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commentaire_Internautes_InternauteId",
                        column: x => x.InternauteId,
                        principalTable: "Internautes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: false),
                    Statut = table.Column<string>(nullable: true),
                    BienId = table.Column<int>(nullable: true),
                    InternauteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Biens_BienId",
                        column: x => x.BienId,
                        principalTable: "Biens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Internautes_InternauteId",
                        column: x => x.InternauteId,
                        principalTable: "Internautes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_BienId",
                table: "Commentaire",
                column: "BienId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_InternauteId",
                table: "Commentaire",
                column: "InternauteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BienId",
                table: "Reservation",
                column: "BienId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_InternauteId",
                table: "Reservation",
                column: "InternauteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaire");

            migrationBuilder.DropTable(
                name: "Reservation");
        }
    }
}
