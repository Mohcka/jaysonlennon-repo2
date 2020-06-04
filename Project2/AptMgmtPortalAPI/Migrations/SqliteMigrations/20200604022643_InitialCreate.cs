using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AptMgmtPortalAPI.Migrations.SqliteMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    AgreementId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenantId = table.Column<int>(nullable: false),
                    AgreementTemplateId = table.Column<int>(nullable: false),
                    SignedDate = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.AgreementId);
                });

            migrationBuilder.CreateTable(
                name: "AgreementTemplates",
                columns: table => new
                {
                    AgreementTemplateId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreementTemplates", x => x.AgreementTemplateId);
                });

            migrationBuilder.CreateTable(
                name: "BillingPeriods",
                columns: table => new
                {
                    BillingPeriodId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeriodStart = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingPeriods", x => x.BillingPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRequests",
                columns: table => new
                {
                    MaintenanceRequestId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeOpened = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    TimeClosed = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: true),
                    OpeningUserId = table.Column<int>(nullable: false),
                    ClosingUserId = table.Column<int>(nullable: true),
                    MaintenanceRequestType = table.Column<string>(nullable: true),
                    CloseReason = table.Column<string>(nullable: true),
                    OpenNotes = table.Column<string>(nullable: true),
                    ResolutionNotes = table.Column<string>(nullable: true),
                    InternalNotes = table.Column<string>(nullable: true),
                    UnitNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequests", x => x.MaintenanceRequestId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<double>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    TimePaid = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    BillingPeriodId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "ResourceUsageRates",
                columns: table => new
                {
                    ResourceUsageRateId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResourceType = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    PeriodStart = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceUsageRates", x => x.ResourceUsageRateId);
                });

            migrationBuilder.CreateTable(
                name: "TenantResourceUsages",
                columns: table => new
                {
                    TenantResourceUsageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SampleTime = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    UsageAmount = table.Column<double>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantResourceUsages", x => x.TenantResourceUsageId);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UnitNumber = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserAccountType = table.Column<string>(nullable: false),
                    LoginName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ApiKey = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "AgreementTemplates",
                columns: new[] { "AgreementTemplateId", "Text", "Title" },
                values: new object[] { 1, "This is a really long lease agreement text", "Lease Agreement" });

            migrationBuilder.InsertData(
                table: "AgreementTemplates",
                columns: new[] { "AgreementTemplateId", "Text", "Title" },
                values: new object[] { 3, "This is a really long internet connection agreement text", "Internet Connection Agreement" });

            migrationBuilder.InsertData(
                table: "AgreementTemplates",
                columns: new[] { "AgreementTemplateId", "Text", "Title" },
                values: new object[] { 2, "This is a really long utility agreement text", "Utility Agreement" });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 10, 1, new DateTime(2020, 6, 3, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(8551), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 10 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 9, 3, new DateTime(2020, 6, 3, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(8548), new DateTime(2019, 6, 9, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2019, 6, 9, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 9 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 8, 2, new DateTime(2020, 6, 3, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(8545), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 8 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 3, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(7327), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 1 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 6, 3, new DateTime(2020, 6, 3, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(8540), new DateTime(2019, 6, 9, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2019, 6, 9, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 6 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 5, 2, new DateTime(2020, 6, 3, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(8537), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 5 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 4, 1, new DateTime(2020, 6, 3, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(8534), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 4 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 3, 3, new DateTime(2020, 6, 3, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(8531), new DateTime(2019, 6, 9, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2019, 6, 9, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 3 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 2, 2, new DateTime(2020, 6, 3, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(8499), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 2 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 7, 1, new DateTime(2020, 6, 3, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(8543), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 7 });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 1, new DateTime(2020, 6, 4, 19, 26, 43, 51, DateTimeKind.Local).AddTicks(6714), new DateTime(2020, 5, 4, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 2, new DateTime(2020, 6, 4, 19, 26, 43, 51, DateTimeKind.Local).AddTicks(7243), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 3, new DateTime(2020, 6, 4, 19, 26, 43, 51, DateTimeKind.Local).AddTicks(7266), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 4, new DateTime(2020, 6, 4, 19, 26, 43, 51, DateTimeKind.Local).AddTicks(7269), new DateTime(2019, 6, 9, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989) });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 7, null, null, "Call Plumber", null, "No water", 5, null, null, new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), "105" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 10, null, null, "Call Plumber", null, "No water", 8, null, null, new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), "108" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 8, null, null, "Call Plumber", null, "No water", 6, null, null, new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), "106" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 6, null, null, "Call Plumber", null, "No water", 4, null, null, new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), "104" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 9, null, null, "Call Plumber", null, "No water", 7, null, null, new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), "107" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 4, "CanceledByTenant", 1, "Call Plumber", null, "No water", 2, "Fixed", new DateTime(2020, 5, 4, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), "102" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 3, "CanceledByManagement", 1, "Call Plumber", null, "No water", 1, "Fixed", new DateTime(2020, 5, 4, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 2, "Completed", 1, "Call Comcast", null, "No Interet", 1, "Fixed", new DateTime(2020, 5, 4, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 1, "Completed", 1, "Call Plumber", "Plumbing", "No water", 1, "Fully restored.", new DateTime(2020, 6, 3, 19, 26, 43, 51, DateTimeKind.Local).AddTicks(2419), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 5, "CanceledByManagement", 2, "Call Plumber", null, "No water", 3, "Fixed", new DateTime(2020, 5, 4, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), new DateTime(2020, 3, 5, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), "103" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 28, 100.11, 1, 4, 6, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6324) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 29, 100.11, 1, 3, 6, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6326) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 30, 100.11, 1, 1, 6, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6329) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 31, 100.11, 1, 2, 7, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6331) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 32, 100.11, 1, 0, 7, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6334) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 33, 100.11, 1, 4, 7, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6337) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 34, 100.11, 1, 3, 7, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6339) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 35, 100.11, 1, 1, 7, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6342) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 36, 100.11, 1, 2, 8, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6344) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 37, 100.11, 1, 0, 8, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6348) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 38, 100.11, 1, 4, 8, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6351) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 40, 100.11, 1, 1, 8, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6356) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 41, 100.11, 1, 2, 9, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6359) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 42, 100.11, 1, 0, 9, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6361) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 43, 100.11, 1, 4, 9, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6364) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 44, 100.11, 1, 3, 9, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6366) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 45, 100.11, 1, 1, 9, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6369) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 47, 100.11, 1, 0, 10, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6874) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 48, 100.11, 1, 4, 10, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6881) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 49, 100.11, 1, 3, 10, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6885) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 50, 100.11, 1, 1, 10, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6889) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 27, 100.11, 1, 0, 6, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6321) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 39, 100.11, 1, 3, 8, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6354) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 26, 100.11, 1, 2, 6, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6318) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 46, 100.11, 1, 2, 10, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6371) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 24, 100.11, 1, 3, 5, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6313) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 25, 100.11, 1, 1, 5, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6316) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 1, 100.11, 1, 2, 1, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(5661) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 2, 100.11, 1, 0, 1, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6228) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 3, 100.11, 1, 4, 1, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6253) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 5, 100.11, 1, 1, 1, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6258) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 6, 100.11, 1, 2, 2, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6262) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 7, 100.11, 1, 0, 2, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6264) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 8, 100.11, 1, 4, 2, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6267) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 9, 100.11, 1, 3, 2, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6269) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 10, 100.11, 1, 1, 2, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6272) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 11, 100.11, 1, 2, 3, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6275) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 4, 100.11, 1, 3, 1, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6256) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 13, 100.11, 1, 4, 3, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6280) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 14, 100.11, 1, 3, 3, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6283) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 15, 100.11, 1, 1, 3, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6286) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 16, 100.11, 1, 2, 4, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6288) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 17, 100.11, 1, 0, 4, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6293) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 18, 100.11, 1, 4, 4, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6296) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 19, 100.11, 1, 3, 4, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6298) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 23, 100.11, 1, 4, 5, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6311) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 20, 100.11, 1, 1, 4, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6302) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 21, 100.11, 1, 2, 5, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6305) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 22, 100.11, 1, 0, 5, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6308) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 12, 100.11, 1, 0, 3, new DateTime(2020, 6, 2, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(6278) });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 5, new DateTime(2020, 11, 30, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(2051), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 1.75, 1 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 3, new DateTime(2020, 11, 30, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(2045), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 1100.0, 4 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 4, new DateTime(2020, 11, 30, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(2048), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 20.550000000000001, 3 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 1, new DateTime(2020, 11, 30, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(1102), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 40.450000000000003, 2 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 2, new DateTime(2020, 11, 30, 19, 26, 43, 50, DateTimeKind.Local).AddTicks(2018), new DateTime(2019, 12, 6, 19, 26, 43, 41, DateTimeKind.Local).AddTicks(9989), 3.4500000000000002, 0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 168, 1, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3272), 6, 16.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 157, 0, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3241), 6, 21.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 158, 0, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3244), 6, 20.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 159, 0, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3247), 6, 20.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 160, 0, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3250), 6, 20.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 161, 1, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3252), 6, 10.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 162, 1, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3255), 6, 15.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 163, 1, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3257), 6, 16.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 164, 1, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3260), 6, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 165, 1, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3264), 6, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 166, 1, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3267), 6, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 167, 1, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3270), 6, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 156, 0, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3239), 6, 20.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 169, 1, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3275), 6, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 183, 1, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3312), 7, 36.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 171, 0, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3280), 7, 30.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 172, 0, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3283), 7, 39.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 173, 0, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3285), 7, 35.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 174, 0, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3288), 7, 30.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 175, 0, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3290), 7, 30.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 176, 0, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3293), 7, 35.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 177, 0, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3296), 7, 31.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 178, 0, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3298), 7, 30.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 179, 0, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3301), 7, 30.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 180, 0, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3303), 7, 30.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 181, 1, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3306), 7, 30.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 182, 1, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3308), 7, 35.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 155, 0, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3236), 6, 20.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 184, 1, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3315), 7, 31.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 170, 1, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3278), 6, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 154, 0, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3233), 6, 20.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 139, 0, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3193), 5, 10.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 152, 0, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3228), 6, 20.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 185, 1, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3317), 7, 30.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 123, 1, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3149), 4, 16.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 124, 1, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3151), 4, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 125, 1, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3154), 4, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 126, 1, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3157), 4, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 127, 1, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3159), 4, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 128, 1, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3162), 4, 26.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 129, 1, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3165), 4, 4.4100000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 130, 1, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3168), 4, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 131, 0, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3171), 5, 10.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 132, 0, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3174), 5, 19.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 133, 0, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3177), 5, 15.33 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 134, 0, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3179), 5, 10.67 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 135, 0, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3182), 5, 10.779999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 136, 0, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3185), 5, 10.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 137, 0, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3187), 5, 11.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 138, 0, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3190), 5, 10.529999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 140, 0, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3195), 5, 10.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 141, 1, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3198), 5, 11.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 142, 1, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3200), 5, 11.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 143, 1, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3203), 5, 16.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 144, 1, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3206), 5, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 145, 1, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3208), 5, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 146, 1, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3211), 5, 11.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 147, 1, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3215), 5, 11.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 148, 1, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3218), 5, 11.6 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 149, 1, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3221), 5, 11.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 150, 1, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3223), 5, 11.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 151, 0, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3226), 6, 20.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 153, 0, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3231), 6, 25.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 186, 1, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3320), 7, 36.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 227, 1, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3429), 9, 5.7400000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 188, 1, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3325), 7, 36.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 222, 1, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3416), 9, 25.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 223, 1, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3418), 9, 26.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 224, 1, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3421), 9, 21.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 225, 1, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3423), 9, 20.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 226, 1, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3426), 9, 6.9299999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 122, 1, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3146), 4, 30.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 228, 1, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3431), 9, 6.5999999999999996 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 229, 1, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3434), 9, 4.4100000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 230, 1, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3437), 9, 6.3200000000000003 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 231, 0, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3439), 10, 30.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 232, 0, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3442), 10, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 233, 0, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3444), 10, 35.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 234, 0, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3447), 10, 30.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 235, 0, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3450), 10, 30.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 236, 0, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3455), 10, 10.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 237, 0, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3457), 10, 10.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 238, 0, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3460), 10, 10.529999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 239, 0, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3462), 10, 10.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 240, 0, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3465), 10, 10.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 241, 1, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3468), 10, 20.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 242, 1, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3470), 10, 25.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 243, 1, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3473), 10, 26.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 244, 1, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3475), 10, 21.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 245, 1, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3478), 10, 20.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 246, 1, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3481), 10, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 247, 1, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3483), 10, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 248, 1, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3486), 10, 16.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 249, 1, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3488), 10, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 250, 1, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3491), 10, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 221, 1, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3413), 9, 20.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 187, 1, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3322), 7, 35.740000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 220, 0, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3410), 9, 30.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 218, 0, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3404), 9, 20.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 189, 1, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3328), 7, 34.409999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 190, 1, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3330), 7, 36.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 191, 0, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3333), 8, 9.4600000000000009 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 192, 0, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3335), 8, 9.8499999999999996 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 193, 0, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3338), 8, 9.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 194, 0, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3341), 8, 9.6699999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 195, 0, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3343), 8, 9.7799999999999994 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 196, 0, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3346), 8, 9.0700000000000003 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 197, 0, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3349), 8, 31.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 198, 0, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3351), 8, 9.5299999999999994 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 199, 0, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3354), 8, 9.7300000000000004 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 200, 0, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3356), 8, 40.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 201, 1, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3360), 8, 10.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 202, 1, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3362), 8, 10.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 203, 1, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3365), 8, 10.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 204, 1, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3368), 8, 10.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 205, 1, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3370), 8, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 206, 1, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3373), 8, 10.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 207, 1, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3375), 8, 35.740000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 208, 1, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3378), 8, 16.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 209, 1, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3381), 8, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 210, 1, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3384), 8, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 211, 0, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3386), 9, 31.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 212, 0, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3389), 9, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 213, 0, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3391), 9, 25.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 214, 0, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3394), 9, 10.67 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 215, 0, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3397), 9, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 216, 0, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3399), 9, 10.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 217, 0, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3402), 9, 1.3600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 219, 0, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3408), 9, 10.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 121, 1, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3144), 4, 13.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 91, 0, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2919), 3, 9.4600000000000009 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 119, 0, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3138), 4, 15.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 32, 0, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2698), 7, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 33, 4, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2701), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 34, 3, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2703), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 35, 1, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2706), 7, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 36, 2, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2709), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 37, 0, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2711), 8, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 38, 4, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2714), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 39, 3, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2716), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 40, 1, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2720), 8, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 41, 2, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2722), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 42, 0, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2725), 9, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 43, 4, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2727), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 31, 2, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2696), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 120, 0, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3141), 4, 3.21 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 46, 2, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2735), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 47, 0, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2737), 10, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 48, 4, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2740), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 49, 3, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2742), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 50, 1, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2745), 10, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 51, 0, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2747), 1, 30.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 52, 0, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2810), 1, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 53, 0, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2813), 1, 5.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 54, 0, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2816), 1, 50.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 55, 0, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2819), 1, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 56, 0, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2822), 1, 30.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 57, 0, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2825), 1, 31.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 45, 1, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2732), 9, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 30, 1, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2693), 6, 31.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 29, 3, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2690), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 28, 4, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2688), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 1, 2, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(1907), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 2, 0, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2591), 1, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 3, 4, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2619), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 4, 3, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2623), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 5, 1, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2626), 1, 40.399999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 6, 2, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2629), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 7, 0, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2632), 2, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 8, 4, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2635), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 9, 3, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2637), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 10, 1, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2640), 2, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 11, 2, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2643), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 12, 0, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2646), 3, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 13, 4, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2648), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 14, 3, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2651), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 15, 1, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2654), 3, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 16, 2, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2656), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 17, 0, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2659), 4, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 18, 4, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2661), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 19, 3, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2664), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 20, 1, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2667), 4, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 21, 2, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2670), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 22, 0, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2672), 5, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 23, 4, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2675), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 24, 3, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2677), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 25, 1, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2680), 5, 40.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 26, 2, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2683), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 27, 0, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2685), 6, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 58, 0, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2827), 1, 20.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 59, 0, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2831), 1, 10.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 44, 3, new DateTime(2020, 6, 2, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2730), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 61, 1, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2838), 1, 10.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 93, 0, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2924), 3, 5.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 94, 0, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2927), 3, 30.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 95, 0, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2930), 3, 45.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 96, 0, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2933), 3, 30.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 97, 0, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2936), 3, 32.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 98, 0, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2938), 3, 25.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 99, 0, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2941), 3, 11.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 100, 0, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2943), 3, 31.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 101, 1, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2946), 3, 15.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 102, 1, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2949), 3, 25.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 103, 1, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2951), 3, 16.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 104, 1, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3095), 3, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 92, 0, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2921), 3, 23.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 105, 1, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3099), 3, 50.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 107, 1, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3104), 3, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 108, 1, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3107), 3, 6.5999999999999996 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 109, 1, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3110), 3, 24.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 110, 1, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3112), 3, 13.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 111, 0, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3118), 4, 3.46 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 112, 0, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3120), 4, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 113, 0, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3123), 4, 5.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 114, 0, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3125), 4, 10.67 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 115, 0, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3128), 4, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 116, 0, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3131), 4, 20.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 117, 0, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3133), 4, 11.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 118, 0, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3136), 4, 10.529999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 60, 0, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2833), 1, 30.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 90, 1, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2916), 2, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 106, 1, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(3101), 3, 26.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 63, 1, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2843), 1, 6.4299999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 89, 1, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2913), 2, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 62, 1, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2841), 1, 15.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 64, 1, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2847), 1, 31.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 65, 1, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2850), 1, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 66, 1, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2852), 1, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 67, 1, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2855), 1, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 68, 1, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2858), 1, 16.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 69, 1, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2861), 1, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 70, 1, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2863), 1, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 71, 0, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2866), 2, 31.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 72, 0, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2869), 2, 25.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 74, 0, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2874), 2, 50.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 75, 0, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2876), 2, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 73, 0, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2871), 2, 5.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 77, 0, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2883), 2, 30.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 88, 1, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2911), 2, 26.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 87, 1, new DateTime(2020, 5, 26, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2908), 2, 5.7400000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 86, 1, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2906), 2, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 85, 1, new DateTime(2020, 5, 28, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2903), 2, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 76, 0, new DateTime(2020, 5, 27, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2880), 2, 29.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 83, 1, new DateTime(2020, 5, 30, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2898), 2, 9.4299999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 84, 1, new DateTime(2020, 5, 29, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2901), 2, 25.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 81, 1, new DateTime(2020, 6, 1, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2893), 2, 11.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 80, 0, new DateTime(2020, 5, 23, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2890), 2, 40.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 79, 0, new DateTime(2020, 5, 24, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2888), 2, 5.7300000000000004 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 78, 0, new DateTime(2020, 5, 25, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2885), 2, 20.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 82, 1, new DateTime(2020, 5, 31, 19, 26, 43, 49, DateTimeKind.Local).AddTicks(2896), 2, 14.42 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 1, "jayson@gmail.com", "Jayson", "Lennon", "555-164-317", 3 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 2, "david@gmail.com", "David", "Sawyer", "555-195-162", 4 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 3, "michael@gmail.com", "Michael", "Walker", "555-115-412", 5 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 4, "sulav@gmail.com", "Sulav", "Aryal", "555-787-595", 6 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 5, "melvin@gmail.com", "Melvin", "Johnson", "555-858-445", 7 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 8, "frances@gmail.com", "Frances ", "Hook", "555-871-503", 10 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 7, "ruth@gmail.com", "Ruth ", "Williams", "555-337-777", 9 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 9, "linda@gmail.com", "Linda", "Lopez", "555-607-558", 11 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 10, "regina@gmail.com", "Regina", "McCoy", "555-504-625", 12 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 6, "deon@gmail.com", "Deon ", "Smith", "555-514-298", 8 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 10, 10, "110" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 9, 9, "109" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 8, 8, "108" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 7, 7, "107" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 6, 6, "106" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 4, 4, "104" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 3, 3, "103" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 2, 2, "102" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 1, 1, "101" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 5, 5, "105" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 8, "test-key8", "deon", "", "deon", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 11, "test-key11", "linda", "", "linda", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 10, "test-key10", "frances", "", "frances", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 9, "test-key9", "ruth", "", "ruth", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 7, "test-key7", "melvin", "", "melvin", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 12, "test-key12", "regina", "", "regina", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 5, "test-key5", "michael", "", "michael", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 4, "test-key4", "david", "", "david", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 3, "test-key3", "jayson", "", "jayson", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 2, "test-key2", "manager", "manager", "manager", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Manager" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 1, "test-key1", "admin", "admin", "admin", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 6, "test-key6", "sulav", "", "sulav", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 13, "test-key13", "sulav2", "", "sulav2", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitNumber",
                table: "Units",
                column: "UnitNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "AgreementTemplates");

            migrationBuilder.DropTable(
                name: "BillingPeriods");

            migrationBuilder.DropTable(
                name: "MaintenanceRequests");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ResourceUsageRates");

            migrationBuilder.DropTable(
                name: "TenantResourceUsages");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
