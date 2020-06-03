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
                    StartDate = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "NVARCHAR(48)", nullable: false)
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
                values: new object[] { 10, 1, new DateTime(2020, 6, 3, 9, 17, 45, 126, DateTimeKind.Local).AddTicks(5965), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 10 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 9, 3, new DateTime(2020, 6, 3, 9, 17, 45, 126, DateTimeKind.Local).AddTicks(5960), new DateTime(2019, 6, 9, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2019, 6, 9, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 9 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 8, 2, new DateTime(2020, 6, 3, 9, 17, 45, 126, DateTimeKind.Local).AddTicks(5956), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 8 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 3, 9, 17, 45, 126, DateTimeKind.Local).AddTicks(4103), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 1 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 6, 3, new DateTime(2020, 6, 3, 9, 17, 45, 126, DateTimeKind.Local).AddTicks(5947), new DateTime(2019, 6, 9, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2019, 6, 9, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 6 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 5, 2, new DateTime(2020, 6, 3, 9, 17, 45, 126, DateTimeKind.Local).AddTicks(5685), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 5 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 4, 1, new DateTime(2020, 6, 3, 9, 17, 45, 126, DateTimeKind.Local).AddTicks(5681), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 4 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 3, 3, new DateTime(2020, 6, 3, 9, 17, 45, 126, DateTimeKind.Local).AddTicks(5675), new DateTime(2019, 6, 9, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2019, 6, 9, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 3 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 2, 2, new DateTime(2020, 6, 3, 9, 17, 45, 126, DateTimeKind.Local).AddTicks(5622), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 2 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 7, 1, new DateTime(2020, 6, 3, 9, 17, 45, 126, DateTimeKind.Local).AddTicks(5952), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 7 });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 1, new DateTime(2020, 6, 4, 9, 17, 45, 130, DateTimeKind.Local).AddTicks(230), new DateTime(2020, 5, 4, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 2, new DateTime(2020, 6, 4, 9, 17, 45, 130, DateTimeKind.Local).AddTicks(1208), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 3, new DateTime(2020, 6, 4, 9, 17, 45, 130, DateTimeKind.Local).AddTicks(1261), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 4, new DateTime(2020, 6, 4, 9, 17, 45, 130, DateTimeKind.Local).AddTicks(1266), new DateTime(2019, 6, 9, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440) });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 7, null, null, "Call Plumber", null, "No water", 5, null, null, new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), "105" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 10, null, null, "Call Plumber", null, "No water", 8, null, null, new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), "108" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 8, null, null, "Call Plumber", null, "No water", 6, null, null, new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), "106" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 6, null, null, "Call Plumber", null, "No water", 4, null, null, new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), "104" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 9, null, null, "Call Plumber", null, "No water", 7, null, null, new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), "107" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 4, "CanceledByTenant", 1, "Call Plumber", null, "No water", 2, "Fixed", new DateTime(2020, 5, 4, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), "102" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 3, "CanceledByManagement", 1, "Call Plumber", null, "No water", 1, "Fixed", new DateTime(2020, 5, 4, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 2, "Completed", 1, "Call Comcast", null, "No Interet", 1, "Fixed", new DateTime(2020, 5, 4, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 1, "Completed", 1, "Call Plumber", "Plumbing", "No water", 1, "Fully restored.", new DateTime(2020, 6, 3, 9, 17, 45, 129, DateTimeKind.Local).AddTicks(3329), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 5, "CanceledByManagement", 2, "Call Plumber", null, "No water", 3, "Fixed", new DateTime(2020, 5, 4, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), new DateTime(2020, 3, 5, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), "103" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 28, 100.11, 1, 4, 6, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4221) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 29, 100.11, 1, 3, 6, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4225) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 30, 100.11, 1, 1, 6, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4229) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 31, 100.11, 1, 2, 7, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4234) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 32, 100.11, 1, 0, 7, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4238) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 33, 100.11, 1, 4, 7, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4242) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 34, 100.11, 1, 3, 7, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4246) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 35, 100.11, 1, 1, 7, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4250) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 36, 100.11, 1, 2, 8, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4254) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 37, 100.11, 1, 0, 8, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4258) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 38, 100.11, 1, 4, 8, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4262) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 41, 100.11, 1, 2, 9, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4275) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 42, 100.11, 1, 0, 9, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4279) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 43, 100.11, 1, 4, 9, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4283) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 44, 100.11, 1, 3, 9, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4286) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 45, 100.11, 1, 1, 9, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4290) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 46, 100.11, 1, 2, 10, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4294) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 47, 100.11, 1, 0, 10, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4299) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 48, 100.11, 1, 4, 10, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4302) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 49, 100.11, 1, 3, 10, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4306) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 50, 100.11, 1, 1, 10, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4311) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 27, 100.11, 1, 0, 6, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4217) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 40, 100.11, 1, 1, 8, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4271) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 26, 100.11, 1, 2, 6, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4214) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 39, 100.11, 1, 3, 8, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4266) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 24, 100.11, 1, 3, 5, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4206) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 1, 100.11, 1, 2, 1, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(2998) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 2, 100.11, 1, 0, 1, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4075) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 3, 100.11, 1, 4, 1, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4118) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 4, 100.11, 1, 3, 1, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4123) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 5, 100.11, 1, 1, 1, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4127) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 6, 100.11, 1, 2, 2, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4131) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 7, 100.11, 1, 0, 2, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4136) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 8, 100.11, 1, 4, 2, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4141) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 9, 100.11, 1, 3, 2, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4145) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 10, 100.11, 1, 1, 2, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4149) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 11, 100.11, 1, 2, 3, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4153) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 25, 100.11, 1, 1, 5, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4210) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 13, 100.11, 1, 4, 3, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4161) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 14, 100.11, 1, 3, 3, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4165) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 15, 100.11, 1, 1, 3, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4170) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 16, 100.11, 1, 2, 4, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4174) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 17, 100.11, 1, 0, 4, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4178) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 18, 100.11, 1, 4, 4, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4182) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 19, 100.11, 1, 3, 4, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4185) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 20, 100.11, 1, 1, 4, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4189) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 21, 100.11, 1, 2, 5, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4193) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 22, 100.11, 1, 0, 5, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4198) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 23, 100.11, 1, 4, 5, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4202) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 12, 100.11, 1, 0, 3, new DateTime(2020, 6, 2, 9, 17, 45, 128, DateTimeKind.Local).AddTicks(4157) });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 5, new DateTime(2020, 11, 30, 9, 17, 45, 127, DateTimeKind.Local).AddTicks(4632), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 1.75, 1 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 4, new DateTime(2020, 11, 30, 9, 17, 45, 127, DateTimeKind.Local).AddTicks(4627), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 20.550000000000001, 3 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 2, new DateTime(2020, 11, 30, 9, 17, 45, 127, DateTimeKind.Local).AddTicks(4567), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 3.4500000000000002, 0 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 1, new DateTime(2020, 11, 30, 9, 17, 45, 127, DateTimeKind.Local).AddTicks(2519), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 40.450000000000003, 2 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 3, new DateTime(2020, 11, 30, 9, 17, 45, 127, DateTimeKind.Local).AddTicks(4622), new DateTime(2019, 12, 6, 9, 17, 45, 108, DateTimeKind.Local).AddTicks(6440), 1100.0, 4 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 16, 2, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8603), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 17, 0, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8607), 4, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 18, 4, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8611), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 19, 3, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8615), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 20, 1, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8619), 4, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 21, 2, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8623), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 22, 0, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8628), 5, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 23, 4, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8631), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 24, 3, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8635), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 25, 1, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8639), 5, 40.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 26, 2, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8643), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 28, 4, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8650), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 38, 4, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8690), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 29, 3, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8654), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 30, 1, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8658), 6, 31.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 31, 2, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8662), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 32, 0, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8666), 7, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 33, 4, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8671), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 34, 3, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8675), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 35, 1, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8679), 7, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 36, 2, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8682), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 37, 0, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8686), 8, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 27, 0, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8647), 6, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 15, 1, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8599), 3, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 41, 2, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8701), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 13, 4, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8591), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 39, 3, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8694), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 50, 1, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8738), 10, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 49, 3, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8734), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 48, 4, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8730), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 47, 0, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8726), 10, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 46, 2, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8722), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 45, 1, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8717), 9, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 44, 3, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8713), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 43, 4, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8710), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 42, 0, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8706), 9, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 14, 3, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8596), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 1, 2, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(7469), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 3, 4, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8549), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 4, 3, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8554), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 5, 1, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8558), 1, 40.399999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 6, 2, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8563), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 7, 0, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8567), 2, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 8, 4, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8571), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 9, 3, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8575), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 10, 1, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8579), 2, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 11, 2, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8583), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 12, 0, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8587), 3, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 2, 0, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8510), 1, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 40, 1, new DateTime(2020, 6, 2, 9, 17, 45, 125, DateTimeKind.Local).AddTicks(8698), 8, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 1, "jayson@gmail.com", "Jayson", "Lennon", "555-164-317", 3 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 9, "linda@gmail.com", "Linda", "Lopez", "555-607-558", 11 });

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
                values: new object[] { 6, "deon@gmail.com", "Deon ", "Smith", "555-514-298", 8 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 5, "melvin@gmail.com", "Melvin", "Johnson", "555-858-445", 7 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 4, "sulav@gmail.com", "Sulav", "Aryal", "555-787-595", 6 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 3, "michael@gmail.com", "Michael", "Walker", "555-115-412", 5 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 2, "david@gmail.com", "David", "Sawyer", "555-195-162", 4 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 10, "regina@gmail.com", "Regina", "McCoy", "555-504-625", 12 });

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
                values: new object[] { 6, 6, "106" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 7, 7, "107" });

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
                values: new object[] { 8, "test-key8", "deon", "", "deon", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 7, "test-key7", "melvin", "", "melvin", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 4, "test-key4", "david", "", "david", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 5, "test-key5", "michael", "", "michael", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

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
                values: new object[] { 12, "test-key12", "regina", "", "regina", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

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
