using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SQLiteAspNetCoreMvcIdentity.Data.Migrations
{
    public partial class VragenAntwoorden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AntwoordCommentaar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Commentaar = table.Column<string>(nullable: true),
                    EigenaarId = table.Column<string>(nullable: true),
                    LaatsteWijziging = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntwoordCommentaar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AntwoordCommentaar_AspNetUsers_EigenaarId",
                        column: x => x.EigenaarId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vragenlijst",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EigenaarId = table.Column<string>(nullable: true),
                    Gequoteerd = table.Column<bool>(nullable: false),
                    LaatsteWijziging = table.Column<DateTime>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: true),
                    Opmerkingen = table.Column<string>(nullable: true),
                    Titel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vragenlijst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vragenlijst_AspNetUsers_EigenaarId",
                        column: x => x.EigenaarId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vraag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Afbeelding = table.Column<string>(nullable: true),
                    LaatsteWijziging = table.Column<DateTime>(nullable: false),
                    MaxPunten = table.Column<double>(nullable: false),
                    Opmerkingen = table.Column<string>(nullable: true),
                    Tekst = table.Column<string>(nullable: true),
                    VragenlijstId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vraag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vraag_Vragenlijst_VragenlijstId",
                        column: x => x.VragenlijstId,
                        principalTable: "Vragenlijst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Antwoord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Afbeelding = table.Column<string>(nullable: true),
                    Afgesloten = table.Column<bool>(nullable: false),
                    EigenaarId = table.Column<string>(nullable: true),
                    LaatsteWijziging = table.Column<DateTime>(nullable: false),
                    Tekst = table.Column<string>(nullable: true),
                    VraagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antwoord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Antwoord_AspNetUsers_EigenaarId",
                        column: x => x.EigenaarId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Antwoord_Vraag_VraagId",
                        column: x => x.VraagId,
                        principalTable: "Vraag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Antwoord_EigenaarId",
                table: "Antwoord",
                column: "EigenaarId");

            migrationBuilder.CreateIndex(
                name: "IX_Antwoord_VraagId",
                table: "Antwoord",
                column: "VraagId");

            migrationBuilder.CreateIndex(
                name: "IX_AntwoordCommentaar_EigenaarId",
                table: "AntwoordCommentaar",
                column: "EigenaarId");

            migrationBuilder.CreateIndex(
                name: "IX_Vraag_VragenlijstId",
                table: "Vraag",
                column: "VragenlijstId");

            migrationBuilder.CreateIndex(
                name: "IX_Vragenlijst_EigenaarId",
                table: "Vragenlijst",
                column: "EigenaarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antwoord");

            migrationBuilder.DropTable(
                name: "AntwoordCommentaar");

            migrationBuilder.DropTable(
                name: "Vraag");

            migrationBuilder.DropTable(
                name: "Vragenlijst");
        }
    }
}
