using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawTrack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Currencies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModelStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatusIDs = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.ID);
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
                name: "Statuses",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyConversions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyIDFrom = table.Column<int>(type: "int", nullable: false),
                    CurrencyIDTo = table.Column<int>(type: "int", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyConversions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CurrencyConversions_Currencies_CurrencyIDFrom",
                        column: x => x.CurrencyIDFrom,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyConversions_Currencies_CurrencyIDTo",
                        column: x => x.CurrencyIDTo,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StatusID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Modules_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionActions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsForFeature = table.Column<bool>(type: "bit", nullable: false),
                    StatusID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionActions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionActions_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionValues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionValues", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionValues_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ActionID = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Values = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StatusID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Permissions_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionActions_ActionID",
                        column: x => x.ActionID,
                        principalTable: "PermissionActions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permissions_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseCharges",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    ChargeTypeID = table.Column<int>(type: "int", nullable: false),
                    AmountDefault = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyIDDefault = table.Column<int>(type: "int", nullable: false),
                    AmountSecond = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyIDSecond = table.Column<int>(type: "int", nullable: false),
                    ChargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserID = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseCharges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CaseCharges_Currencies_CurrencyIDDefault",
                        column: x => x.CurrencyIDDefault,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseCharges_Currencies_CurrencyIDSecond",
                        column: x => x.CurrencyIDSecond,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseCourts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    CourtID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserID = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseCourts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CaseDocuments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DocumentTypeID = table.Column<int>(type: "int", nullable: true),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserID = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseDocuments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CasePayments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    ChargeID = table.Column<int>(type: "int", nullable: true),
                    AmountDefault = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyIDDefault = table.Column<int>(type: "int", nullable: false),
                    AmountSecond = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyIDSecond = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethodID = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentMethodDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserID = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasePayments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CasePayments_CaseCharges_ChargeID",
                        column: x => x.ChargeID,
                        principalTable: "CaseCharges",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasePayments_Currencies_CurrencyIDDefault",
                        column: x => x.CurrencyIDDefault,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasePayments_Currencies_CurrencyIDSecond",
                        column: x => x.CurrencyIDSecond,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasePayments_PaymentMethods_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "PaymentMethods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    StatusID = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    AssignedUserID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PriorityID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    EstimatedAmountDefault = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyIDDefault = table.Column<int>(type: "int", nullable: false),
                    EstimatedAmountSecond = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyIDSecond = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_Cases_CaseStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "CaseStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Currencies_CurrencyIDDefault",
                        column: x => x.CurrencyIDDefault,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Currencies_CurrencyIDSecond",
                        column: x => x.CurrencyIDSecond,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Priorities_PriorityID",
                        column: x => x.PriorityID,
                        principalTable: "Priorities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseTasks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    AssignedUserID = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriorityID = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    TaskRecap = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_CaseTasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CaseTasks_Cases_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Cases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseTasks_Priorities_PriorityID",
                        column: x => x.PriorityID,
                        principalTable: "Priorities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseTasks_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                });

            migrationBuilder.CreateTable(
                name: "ChargeTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_ChargeTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChargeTypes_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeID = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Clients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clients_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientTypes",
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
                    table.PrimaryKey("PK_ClientTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClientTypes_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "CourtSessions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    CourtID = table.Column<int>(type: "int", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JudgeID = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextSessionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_CourtSessions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourtSessions_Cases_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Cases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourtSessions_Courts_CourtID",
                        column: x => x.CourtID,
                        principalTable: "Courts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourtSessions_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_DocumentTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DocumentTypes_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DebitDefault = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditDefault = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyIDDefault = table.Column<int>(type: "int", nullable: false),
                    DebitSecond = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditSecond = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyIDSecond = table.Column<int>(type: "int", nullable: false),
                    ReferenceType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    ReferenceID = table.Column<int>(type: "int", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserID = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserID = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Journals_Cases_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Cases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Journals_Currencies_CurrencyIDDefault",
                        column: x => x.CurrencyIDDefault,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Journals_Currencies_CurrencyIDSecond",
                        column: x => x.CurrencyIDSecond,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Judges",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OfficeNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
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
                    table.PrimaryKey("PK_Judges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Judges_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    PermissionID = table.Column<int>(type: "int", nullable: false),
                    Values = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Roles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Roles_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    UserTypeID = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
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
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedUserID",
                        column: x => x.CreatedUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_DeletedUserID",
                        column: x => x.DeletedUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_UpdatedUserID",
                        column: x => x.UpdatedUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseCharges_CaseID",
                table: "CaseCharges",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCharges_ChargeTypeID",
                table: "CaseCharges",
                column: "ChargeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCharges_CreatedUserID",
                table: "CaseCharges",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCharges_CurrencyIDDefault",
                table: "CaseCharges",
                column: "CurrencyIDDefault");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCharges_CurrencyIDSecond",
                table: "CaseCharges",
                column: "CurrencyIDSecond");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCharges_DeletedUserID",
                table: "CaseCharges",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCharges_UpdatedUserID",
                table: "CaseCharges",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCourts_CaseID",
                table: "CaseCourts",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCourts_CourtID",
                table: "CaseCourts",
                column: "CourtID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCourts_CreatedUserID",
                table: "CaseCourts",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCourts_DeletedUserID",
                table: "CaseCourts",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCourts_UpdatedUserID",
                table: "CaseCourts",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocuments_CaseID",
                table: "CaseDocuments",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocuments_CreatedUserID",
                table: "CaseDocuments",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocuments_DeletedUserID",
                table: "CaseDocuments",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocuments_DocumentTypeID",
                table: "CaseDocuments",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocuments_UpdatedUserID",
                table: "CaseDocuments",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayments_CaseID",
                table: "CasePayments",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayments_ChargeID",
                table: "CasePayments",
                column: "ChargeID");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayments_CreatedUserID",
                table: "CasePayments",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayments_CurrencyIDDefault",
                table: "CasePayments",
                column: "CurrencyIDDefault");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayments_CurrencyIDSecond",
                table: "CasePayments",
                column: "CurrencyIDSecond");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayments_DeletedUserID",
                table: "CasePayments",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayments_PaymentMethodID",
                table: "CasePayments",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayments_UpdatedUserID",
                table: "CasePayments",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_AssignedUserID",
                table: "Cases",
                column: "AssignedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ClientID",
                table: "Cases",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CreatedUserID",
                table: "Cases",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CurrencyIDDefault",
                table: "Cases",
                column: "CurrencyIDDefault");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CurrencyIDSecond",
                table: "Cases",
                column: "CurrencyIDSecond");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_DeletedUserID",
                table: "Cases",
                column: "DeletedUserID");

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
                name: "IX_Cases_UpdatedUserID",
                table: "Cases",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTasks_AssignedUserID",
                table: "CaseTasks",
                column: "AssignedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTasks_CaseID",
                table: "CaseTasks",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTasks_CreatedUserID",
                table: "CaseTasks",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTasks_DeletedUserID",
                table: "CaseTasks",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTasks_PriorityID",
                table: "CaseTasks",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTasks_StatusID",
                table: "CaseTasks",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTasks_UpdatedUserID",
                table: "CaseTasks",
                column: "UpdatedUserID");

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
                name: "IX_ChargeTypes_CreatedUserID",
                table: "ChargeTypes",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeTypes_DeletedUserID",
                table: "ChargeTypes",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeTypes_StatusID",
                table: "ChargeTypes",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeTypes_UpdatedUserID",
                table: "ChargeTypes",
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
                name: "IX_Clients_StatusID",
                table: "Clients",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TypeID",
                table: "Clients",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UpdatedUserID",
                table: "Clients",
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
                name: "IX_ClientTypes_StatusID",
                table: "ClientTypes",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTypes_UpdatedUserID",
                table: "ClientTypes",
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

            migrationBuilder.CreateIndex(
                name: "IX_CourtSessions_CaseID",
                table: "CourtSessions",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourtSessions_CourtID",
                table: "CourtSessions",
                column: "CourtID");

            migrationBuilder.CreateIndex(
                name: "IX_CourtSessions_CreatedUserID",
                table: "CourtSessions",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CourtSessions_DeletedUserID",
                table: "CourtSessions",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CourtSessions_JudgeID",
                table: "CourtSessions",
                column: "JudgeID");

            migrationBuilder.CreateIndex(
                name: "IX_CourtSessions_StatusID",
                table: "CourtSessions",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_CourtSessions_UpdatedUserID",
                table: "CourtSessions",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyConversions_CurrencyIDFrom",
                table: "CurrencyConversions",
                column: "CurrencyIDFrom");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyConversions_CurrencyIDTo",
                table: "CurrencyConversions",
                column: "CurrencyIDTo");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_CreatedUserID",
                table: "DocumentTypes",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_DeletedUserID",
                table: "DocumentTypes",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_StatusID",
                table: "DocumentTypes",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_UpdatedUserID",
                table: "DocumentTypes",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_CaseID",
                table: "Journals",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_CreatedUserID",
                table: "Journals",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_CurrencyIDDefault",
                table: "Journals",
                column: "CurrencyIDDefault");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_CurrencyIDSecond",
                table: "Journals",
                column: "CurrencyIDSecond");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_DeletedUserID",
                table: "Journals",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_UpdatedUserID",
                table: "Journals",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Judges_CreatedUserID",
                table: "Judges",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Judges_DeletedUserID",
                table: "Judges",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Judges_StatusID",
                table: "Judges",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Judges_UpdatedUserID",
                table: "Judges",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_StatusID",
                table: "Modules",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionActions_StatusID",
                table: "PermissionActions",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ActionID",
                table: "Permissions",
                column: "ActionID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ModuleID",
                table: "Permissions",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_StatusID",
                table: "Permissions",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionValues_StatusID",
                table: "PermissionValues",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionID",
                table: "RolePermissions",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleID",
                table: "RolePermissions",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedUserID",
                table: "Roles",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DeletedUserID",
                table: "Roles",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_StatusID",
                table: "Roles",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UpdatedUserID",
                table: "Roles",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedUserID",
                table: "Users",
                column: "CreatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedUserID",
                table: "Users",
                column: "DeletedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusID",
                table: "Users",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedUserID",
                table: "Users",
                column: "UpdatedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                column: "UserTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseCharges_Cases_CaseID",
                table: "CaseCharges",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseCharges_ChargeTypes_ChargeTypeID",
                table: "CaseCharges",
                column: "ChargeTypeID",
                principalTable: "ChargeTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseCharges_Users_CreatedUserID",
                table: "CaseCharges",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseCharges_Users_DeletedUserID",
                table: "CaseCharges",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseCharges_Users_UpdatedUserID",
                table: "CaseCharges",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseCourts_Cases_CaseID",
                table: "CaseCourts",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseCourts_Courts_CourtID",
                table: "CaseCourts",
                column: "CourtID",
                principalTable: "Courts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseCourts_Users_CreatedUserID",
                table: "CaseCourts",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseCourts_Users_DeletedUserID",
                table: "CaseCourts",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseCourts_Users_UpdatedUserID",
                table: "CaseCourts",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDocuments_Cases_CaseID",
                table: "CaseDocuments",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDocuments_DocumentTypes_DocumentTypeID",
                table: "CaseDocuments",
                column: "DocumentTypeID",
                principalTable: "DocumentTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDocuments_Users_CreatedUserID",
                table: "CaseDocuments",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDocuments_Users_DeletedUserID",
                table: "CaseDocuments",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDocuments_Users_UpdatedUserID",
                table: "CaseDocuments",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CasePayments_Cases_CaseID",
                table: "CasePayments",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CasePayments_Users_CreatedUserID",
                table: "CasePayments",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CasePayments_Users_DeletedUserID",
                table: "CasePayments",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CasePayments_Users_UpdatedUserID",
                table: "CasePayments",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CaseTypes_TypeID",
                table: "Cases",
                column: "TypeID",
                principalTable: "CaseTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Clients_ClientID",
                table: "Cases",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Users_AssignedUserID",
                table: "Cases",
                column: "AssignedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Users_CreatedUserID",
                table: "Cases",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Users_DeletedUserID",
                table: "Cases",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Users_UpdatedUserID",
                table: "Cases",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTasks_Users_AssignedUserID",
                table: "CaseTasks",
                column: "AssignedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTasks_Users_CreatedUserID",
                table: "CaseTasks",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTasks_Users_DeletedUserID",
                table: "CaseTasks",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTasks_Users_UpdatedUserID",
                table: "CaseTasks",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypes_Users_CreatedUserID",
                table: "CaseTypes",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypes_Users_DeletedUserID",
                table: "CaseTypes",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTypes_Users_UpdatedUserID",
                table: "CaseTypes",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChargeTypes_Users_CreatedUserID",
                table: "ChargeTypes",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChargeTypes_Users_DeletedUserID",
                table: "ChargeTypes",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChargeTypes_Users_UpdatedUserID",
                table: "ChargeTypes",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientTypes_TypeID",
                table: "Clients",
                column: "TypeID",
                principalTable: "ClientTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Courts_Users_CreatedUserID",
                table: "Courts",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Users_DeletedUserID",
                table: "Courts",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Users_UpdatedUserID",
                table: "Courts",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtSessions_Judges_JudgeID",
                table: "CourtSessions",
                column: "JudgeID",
                principalTable: "Judges",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtSessions_Users_CreatedUserID",
                table: "CourtSessions",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtSessions_Users_DeletedUserID",
                table: "CourtSessions",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtSessions_Users_UpdatedUserID",
                table: "CourtSessions",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypes_Users_CreatedUserID",
                table: "DocumentTypes",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypes_Users_DeletedUserID",
                table: "DocumentTypes",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypes_Users_UpdatedUserID",
                table: "DocumentTypes",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Users_CreatedUserID",
                table: "Journals",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Users_DeletedUserID",
                table: "Journals",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Users_UpdatedUserID",
                table: "Journals",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Judges_Users_CreatedUserID",
                table: "Judges",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Judges_Users_DeletedUserID",
                table: "Judges",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Judges_Users_UpdatedUserID",
                table: "Judges",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RoleID",
                table: "RolePermissions",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreatedUserID",
                table: "Roles",
                column: "CreatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_DeletedUserID",
                table: "Roles",
                column: "DeletedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UpdatedUserID",
                table: "Roles",
                column: "UpdatedUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_CreatedUserID",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_DeletedUserID",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UpdatedUserID",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "CaseCourts");

            migrationBuilder.DropTable(
                name: "CaseDocuments");

            migrationBuilder.DropTable(
                name: "CasePayments");

            migrationBuilder.DropTable(
                name: "CaseTasks");

            migrationBuilder.DropTable(
                name: "CourtSessions");

            migrationBuilder.DropTable(
                name: "CurrencyConversions");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "ModelStatuses");

            migrationBuilder.DropTable(
                name: "PermissionValues");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "CaseCharges");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "Judges");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "ChargeTypes");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "PermissionActions");

            migrationBuilder.DropTable(
                name: "CaseStatuses");

            migrationBuilder.DropTable(
                name: "CaseTypes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "ClientTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
