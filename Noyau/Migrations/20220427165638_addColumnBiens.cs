using Microsoft.EntityFrameworkCore.Migrations;

namespace Noyau.Migrations
{
    public partial class addColumnBiens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaire_Biens_BienId",
                table: "Commentaire");

            migrationBuilder.DropForeignKey(
                name: "FK_Commentaire_Internautes_InternauteId",
                table: "Commentaire");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Biens_BienId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Internautes_InternauteId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commentaire",
                table: "Commentaire");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "Commentaire",
                newName: "Commentaires");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_InternauteId",
                table: "Reservations",
                newName: "IX_Reservations_InternauteId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_BienId",
                table: "Reservations",
                newName: "IX_Reservations_BienId");

            migrationBuilder.RenameIndex(
                name: "IX_Commentaire_InternauteId",
                table: "Commentaires",
                newName: "IX_Commentaires_InternauteId");

            migrationBuilder.RenameIndex(
                name: "IX_Commentaire_BienId",
                table: "Commentaires",
                newName: "IX_Commentaires_BienId");

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Biens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Couchage",
                table: "Biens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Equipements",
                table: "Biens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Biens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localisation",
                table: "Biens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Superficie",
                table: "Biens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titre",
                table: "Biens",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commentaires",
                table: "Commentaires",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaires_Biens_BienId",
                table: "Commentaires",
                column: "BienId",
                principalTable: "Biens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaires_Internautes_InternauteId",
                table: "Commentaires",
                column: "InternauteId",
                principalTable: "Internautes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Biens_BienId",
                table: "Reservations",
                column: "BienId",
                principalTable: "Biens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Internautes_InternauteId",
                table: "Reservations",
                column: "InternauteId",
                principalTable: "Internautes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_Biens_BienId",
                table: "Commentaires");

            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_Internautes_InternauteId",
                table: "Commentaires");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Biens_BienId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Internautes_InternauteId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commentaires",
                table: "Commentaires");

            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Biens");

            migrationBuilder.DropColumn(
                name: "Couchage",
                table: "Biens");

            migrationBuilder.DropColumn(
                name: "Equipements",
                table: "Biens");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Biens");

            migrationBuilder.DropColumn(
                name: "Localisation",
                table: "Biens");

            migrationBuilder.DropColumn(
                name: "Superficie",
                table: "Biens");

            migrationBuilder.DropColumn(
                name: "Titre",
                table: "Biens");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameTable(
                name: "Commentaires",
                newName: "Commentaire");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_InternauteId",
                table: "Reservation",
                newName: "IX_Reservation_InternauteId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_BienId",
                table: "Reservation",
                newName: "IX_Reservation_BienId");

            migrationBuilder.RenameIndex(
                name: "IX_Commentaires_InternauteId",
                table: "Commentaire",
                newName: "IX_Commentaire_InternauteId");

            migrationBuilder.RenameIndex(
                name: "IX_Commentaires_BienId",
                table: "Commentaire",
                newName: "IX_Commentaire_BienId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commentaire",
                table: "Commentaire",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaire_Biens_BienId",
                table: "Commentaire",
                column: "BienId",
                principalTable: "Biens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaire_Internautes_InternauteId",
                table: "Commentaire",
                column: "InternauteId",
                principalTable: "Internautes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Biens_BienId",
                table: "Reservation",
                column: "BienId",
                principalTable: "Biens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Internautes_InternauteId",
                table: "Reservation",
                column: "InternauteId",
                principalTable: "Internautes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
