using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(type: "varchar(64)", nullable: true),
                    Surname = table.Column<string>(type: "varchar(256)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(64)", nullable: true),
                    Email_LocalPart = table.Column<string>(type: "varchar(64)", nullable: true),
                    Email_Domain = table.Column<string>(type: "varchar(64)", nullable: true),
                    Password = table.Column<byte[]>(type: "binary(64)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSubordinations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SuperiorId = table.Column<Guid>(nullable: false),
                    SubordinateId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubordinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubordinations_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubordinations_Users_SubordinateId",
                        column: x => x.SubordinateId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubordinations_Users_SuperiorId",
                        column: x => x.SuperiorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSubordinations_RoleId",
                table: "UserSubordinations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubordinations_SubordinateId",
                table: "UserSubordinations",
                column: "SubordinateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubordinations_SuperiorId",
                table: "UserSubordinations",
                column: "SuperiorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSubordinations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
