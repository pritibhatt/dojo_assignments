using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVP_Users_UserId",
                table: "RSVP");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVP_Weddings_WeddingId",
                table: "RSVP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RSVP",
                table: "RSVP");

            migrationBuilder.RenameTable(
                name: "RSVP",
                newName: "RSVPS");

            migrationBuilder.RenameIndex(
                name: "IX_RSVP_WeddingId",
                table: "RSVPS",
                newName: "IX_RSVPS_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVP_UserId",
                table: "RSVPS",
                newName: "IX_RSVPS_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RSVPS",
                table: "RSVPS",
                column: "RSVPId");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPS_Users_UserId",
                table: "RSVPS",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPS_Weddings_WeddingId",
                table: "RSVPS",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVPS_Users_UserId",
                table: "RSVPS");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVPS_Weddings_WeddingId",
                table: "RSVPS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RSVPS",
                table: "RSVPS");

            migrationBuilder.RenameTable(
                name: "RSVPS",
                newName: "RSVP");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPS_WeddingId",
                table: "RSVP",
                newName: "IX_RSVP_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPS_UserId",
                table: "RSVP",
                newName: "IX_RSVP_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RSVP",
                table: "RSVP",
                column: "RSVPId");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVP_Users_UserId",
                table: "RSVP",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVP_Weddings_WeddingId",
                table: "RSVP",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
