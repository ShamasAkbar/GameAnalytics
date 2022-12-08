using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameAnalyticCore.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Game_Metric_Score_1",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Game_Metric_Score_2",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Game_Metric_Score_1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Game_Metric_Score_2",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Events");
        }
    }
}
