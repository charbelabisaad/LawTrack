using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawTrack.Migrations
{
    /// <inheritdoc />
    public partial class CreateCases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeletedUserID",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedUserID",
                table: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Statuses",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserID",
                table: "ClientTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ClientTypes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserID",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "CaseStatuses",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CaseTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatusID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserID = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CaseTypes_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseTypes_Users_CreatedUserID",
                        column: x => x.CreatedUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseTypes_Users_DeletedUserID",
                        column: x => x.DeletedUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseTypes_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StatusID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserID = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courts_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courts_Users_CreatedUserID",
                        column: x => x.CreatedUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courts_Users_DeletedUserID",
                        column: x => x.DeletedUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courts_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    CaseStatusID = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    AssignedUserID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PriorityID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CourtID = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserID = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cases_CaseStatuses_CaseStatusID",
                        column: x => x.CaseStatusID,
                        principalTable: "CaseStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_CaseTypes_TypeID",
                        column: x => x.TypeID,
                        principalTable: "CaseTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Courts_CourtID",
                        column: x => x.CourtID,
                        principalTable: "Courts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Priorities_PriorityID",
                        column: x => x.PriorityID,
                        principalTable: "Priorities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Users_AssignedUserID",
                        column: x => x.AssignedUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedUserID",
                table: "Users",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedUserID",
                table: "Users",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedUserID",
                table: "Users",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTypes_CreatedUserID",
                table: "ClientTypes",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTypes_DeletedUserID",
                table: "ClientTypes",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTypes_UpdatedUserID",
                table: "ClientTypes",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatedUserID",
                table: "Clients",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DeletedUserID",
                table: "Clients",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UpdatedUserID",
                table: "Clients",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_AssignedUserID",
                table: "Cases",
                column: "AssignedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseStatusID",
                table: "Cases",
                column: "CaseStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ClientID",
                table: "Cases",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CourtID",
                table: "Cases",
                column: "CourtID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_PriorityID",
                table: "Cases",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_StatusID",
                table: "Cases",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_TypeID",
                table: "Cases",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypes_CreatedUserID",
                table: "CaseTypes",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypes_DeletedUserID",
                table: "CaseTypes",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypes_StatusID",
                table: "CaseTypes",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTypes_UpdatedUserID",
                table: "CaseTypes",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_CreatedUserID",
                table: "Courts",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_DeletedUserID",
                table: "Courts",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_StatusID",
                table: "Courts",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_UpdatedUserID",
                table: "Courts",
                column: "UpdatedUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CreatedUserID",
                table: "Clients",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_DeletedUserID",
                table: "Clients",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UpdatedUserID",
                table: "Clients",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTypes_Users_CreatedUserID",
                table: "ClientTypes",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTypes_Users_DeletedUserID",
                table: "ClientTypes",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTypes_Users_UpdatedUserID",
                table: "ClientTypes",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatedUserID",
                table: "Users",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_DeletedUserID",
                table: "Users",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UpdatedUserID",
                table: "Users",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CreatedUserID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_DeletedUserID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UpdatedUserID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTypes_Users_CreatedUserID",
                table: "ClientTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTypes_Users_DeletedUserID",
                table: "ClientTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTypes_Users_UpdatedUserID",
                table: "ClientTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreatedUserID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_DeletedUserID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UpdatedUserID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "CaseStatuses");

            migrationBuilder.DropTable(
                name: "CaseTypes");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreatedUserID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DeletedUserID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UpdatedUserID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ClientTypes_CreatedUserID",
                table: "ClientTypes");

            migrationBuilder.DropIndex(
                name: "IX_ClientTypes_DeletedUserID",
                table: "ClientTypes");

            migrationBuilder.DropIndex(
                name: "IX_ClientTypes_UpdatedUserID",
                table: "ClientTypes");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreatedUserID",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_DeletedUserID",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UpdatedUserID",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Statuses",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedDate",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserID",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserID",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserID",
                table: "ClientTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ClientTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserID",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
