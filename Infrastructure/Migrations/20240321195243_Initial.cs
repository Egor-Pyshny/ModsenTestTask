using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_event",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    plan = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    organizer_first_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    organizer_second_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    spicker_first_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    spicker_second_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    country = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    city = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    street = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    category = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    max_participants = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_event", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    second_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    third_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    event_id = table.Column<Guid>(type: "uuid", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_images_tbl_event_event_id",
                        column: x => x.event_id,
                        principalTable: "tbl_event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventDbModelUserDbModel",
                columns: table => new
                {
                    EventsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDbModelUserDbModel", x => new { x.EventsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_EventDbModelUserDbModel_tbl_event_EventsId",
                        column: x => x.EventsId,
                        principalTable: "tbl_event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDbModelUserDbModel_tbl_user_UsersId",
                        column: x => x.UsersId,
                        principalTable: "tbl_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDbModelUserDbModel_UsersId",
                table: "EventDbModelUserDbModel",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_images_event_id",
                table: "tbl_images",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_email",
                table: "tbl_user",
                column: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDbModelUserDbModel");

            migrationBuilder.DropTable(
                name: "tbl_images");

            migrationBuilder.DropTable(
                name: "tbl_user");

            migrationBuilder.DropTable(
                name: "tbl_event");
        }
    }
}
