using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MDW.Data.migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    drugname = table.Column<string>(type: "text", nullable: false),
                    genericnames = table.Column<string>(type: "text", nullable: false),
                    dosetype = table.Column<string>(type: "text", nullable: false),
                    company = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    phonenumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drugsDonations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrugId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<string>(type: "text", nullable: false),
                    Donerid = table.Column<int>(type: "integer", nullable: false),
                    Recipient = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drugsDonations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_drugsDonations_drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_drugsDonations_users_Donerid",
                        column: x => x.Donerid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "drugsRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrugId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<string>(type: "text", nullable: false),
                    AskedUserid = table.Column<int>(type: "integer", nullable: false),
                    Donerid = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drugsRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_drugsRequests_drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_drugsRequests_users_AskedUserid",
                        column: x => x.AskedUserid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_drugsRequests_users_Donerid",
                        column: x => x.Donerid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moneyDonations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MoneyAmount = table.Column<int>(type: "integer", nullable: false),
                    Donerid = table.Column<int>(type: "integer", nullable: false),
                    Recipient = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moneyDonations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_moneyDonations_users_Donerid",
                        column: x => x.Donerid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moneyRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MoneyAmount = table.Column<int>(type: "integer", nullable: false),
                    AskedUserid = table.Column<int>(type: "integer", nullable: false),
                    Donerid = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moneyRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_moneyRequests_users_AskedUserid",
                        column: x => x.AskedUserid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_moneyRequests_users_Donerid",
                        column: x => x.Donerid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_drugsDonations_Donerid",
                table: "drugsDonations",
                column: "Donerid");

            migrationBuilder.CreateIndex(
                name: "IX_drugsDonations_DrugId",
                table: "drugsDonations",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_drugsRequests_AskedUserid",
                table: "drugsRequests",
                column: "AskedUserid");

            migrationBuilder.CreateIndex(
                name: "IX_drugsRequests_Donerid",
                table: "drugsRequests",
                column: "Donerid");

            migrationBuilder.CreateIndex(
                name: "IX_drugsRequests_DrugId",
                table: "drugsRequests",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_moneyDonations_Donerid",
                table: "moneyDonations",
                column: "Donerid");

            migrationBuilder.CreateIndex(
                name: "IX_moneyRequests_AskedUserid",
                table: "moneyRequests",
                column: "AskedUserid");

            migrationBuilder.CreateIndex(
                name: "IX_moneyRequests_Donerid",
                table: "moneyRequests",
                column: "Donerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drugsDonations");

            migrationBuilder.DropTable(
                name: "drugsRequests");

            migrationBuilder.DropTable(
                name: "moneyDonations");

            migrationBuilder.DropTable(
                name: "moneyRequests");

            migrationBuilder.DropTable(
                name: "drugs");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
