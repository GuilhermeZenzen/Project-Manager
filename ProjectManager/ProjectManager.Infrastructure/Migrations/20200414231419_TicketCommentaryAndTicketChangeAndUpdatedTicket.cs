using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class TicketCommentaryAndTicketChangeAndUpdatedTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TicketChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    PropertyName = table.Column<string>(type: "varchar(64)", nullable: false),
                    OldValue = table.Column<string>(type: "varchar(64)", nullable: false),
                    NewValue = table.Column<string>(type: "varchar(64)", nullable: false),
                    AuthorName = table.Column<string>(type: "varchar(64)", nullable: false),
                    TicketId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketChanges_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketCommentaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    AuthorName = table.Column<string>(type: "varchar(64)", nullable: false),
                    Body = table.Column<string>(type: "varchar(512)", nullable: false),
                    TicketId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCommentaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketCommentaries_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketChanges_TicketId",
                table: "TicketChanges",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketCommentaries_TicketId",
                table: "TicketCommentaries",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketChanges");

            migrationBuilder.DropTable(
                name: "TicketCommentaries");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tickets");
        }
    }
}
