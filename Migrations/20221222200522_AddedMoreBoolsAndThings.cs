using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicationTracking.Migrations
{
    public partial class AddedMoreBoolsAndThings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlphaDescriptor",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "ResponsibleCode",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Publications");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Publications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SequenceNumber",
                table: "Publications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Revision",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PointOfContactOrganizationId",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PointOfContactOrganization",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PointOfContactMailCode",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PointOfContactEmail",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EnteredBy",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRequested",
                table: "Publications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "AlphaDescriptorCode",
                table: "Publications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDigital",
                table: "Publications",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInternalOnly",
                table: "Publications",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "Publications",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleCodeCode",
                table: "Publications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_AlphaDescriptorCode",
                table: "Publications",
                column: "AlphaDescriptorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ResponsibleCodeCode",
                table: "Publications",
                column: "ResponsibleCodeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_AlphaDescriptors_AlphaDescriptorCode",
                table: "Publications",
                column: "AlphaDescriptorCode",
                principalTable: "AlphaDescriptors",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_ResponsibleCodes_ResponsibleCodeCode",
                table: "Publications",
                column: "ResponsibleCodeCode",
                principalTable: "ResponsibleCodes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_AlphaDescriptors_AlphaDescriptorCode",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_ResponsibleCodes_ResponsibleCodeCode",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_AlphaDescriptorCode",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_ResponsibleCodeCode",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "AlphaDescriptorCode",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "IsDigital",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "IsInternalOnly",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "ResponsibleCodeCode",
                table: "Publications");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SequenceNumber",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Revision",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PointOfContactOrganizationId",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PointOfContactOrganization",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PointOfContactMailCode",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PointOfContactEmail",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnteredBy",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRequested",
                table: "Publications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlphaDescriptor",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleCode",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
