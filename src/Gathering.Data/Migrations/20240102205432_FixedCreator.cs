using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gathering.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedCreator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GatheringEvent_User_CreatorId1",
                table: "GatheringEvent");

            migrationBuilder.DropIndex(
                name: "IX_GatheringEvent_CreatorId1",
                table: "GatheringEvent");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "GatheringEvent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId1",
                table: "GatheringEvent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GatheringEvent_CreatorId1",
                table: "GatheringEvent",
                column: "CreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GatheringEvent_User_CreatorId1",
                table: "GatheringEvent",
                column: "CreatorId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
