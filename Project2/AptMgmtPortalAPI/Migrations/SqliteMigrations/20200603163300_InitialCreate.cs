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
                values: new object[] { 10, 1, new DateTime(2020, 6, 3, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(6799), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 10 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 9, 3, new DateTime(2020, 6, 3, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(6796), new DateTime(2019, 6, 9, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2019, 6, 9, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 9 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 8, 2, new DateTime(2020, 6, 3, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(6793), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 8 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 3, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(5821), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 1 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 6, 3, new DateTime(2020, 6, 3, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(6787), new DateTime(2019, 6, 9, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2019, 6, 9, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 6 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 5, 2, new DateTime(2020, 6, 3, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(6784), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 5 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 4, 1, new DateTime(2020, 6, 3, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(6781), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 4 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 3, 3, new DateTime(2020, 6, 3, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(6777), new DateTime(2019, 6, 9, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2019, 6, 9, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 3 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 2, 2, new DateTime(2020, 6, 3, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(6748), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 2 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 7, 1, new DateTime(2020, 6, 3, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(6790), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 7 });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 1, new DateTime(2020, 6, 4, 9, 33, 0, 5, DateTimeKind.Local).AddTicks(2923), new DateTime(2020, 5, 4, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 2, new DateTime(2020, 6, 4, 9, 33, 0, 5, DateTimeKind.Local).AddTicks(3429), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 3, new DateTime(2020, 6, 4, 9, 33, 0, 5, DateTimeKind.Local).AddTicks(3450), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 4, new DateTime(2020, 6, 4, 9, 33, 0, 5, DateTimeKind.Local).AddTicks(3453), new DateTime(2019, 6, 9, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626) });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 7, null, null, "Call Plumber", null, "No water", 5, null, null, new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), "105" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 10, null, null, "Call Plumber", null, "No water", 8, null, null, new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), "108" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 8, null, null, "Call Plumber", null, "No water", 6, null, null, new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), "106" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 6, null, null, "Call Plumber", null, "No water", 4, null, null, new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), "104" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 9, null, null, "Call Plumber", null, "No water", 7, null, null, new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), "107" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 4, "CanceledByTenant", 1, "Call Plumber", null, "No water", 2, "Fixed", new DateTime(2020, 5, 4, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), "102" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 3, "CanceledByManagement", 1, "Call Plumber", null, "No water", 1, "Fixed", new DateTime(2020, 5, 4, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 2, "Completed", 1, "Call Comcast", null, "No Interet", 1, "Fixed", new DateTime(2020, 5, 4, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 1, "Completed", 1, "Call Plumber", "Plumbing", "No water", 1, "Fully restored.", new DateTime(2020, 6, 3, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(9674), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 5, "CanceledByManagement", 2, "Call Plumber", null, "No water", 3, "Fixed", new DateTime(2020, 5, 4, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), new DateTime(2020, 3, 5, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), "103" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 28, 100.11, 1, 4, 6, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4530) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 29, 100.11, 1, 3, 6, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4533) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 30, 100.11, 1, 1, 6, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4536) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 31, 100.11, 1, 2, 7, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4538) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 32, 100.11, 1, 0, 7, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4541) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 33, 100.11, 1, 4, 7, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4545) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 34, 100.11, 1, 3, 7, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4547) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 35, 100.11, 1, 1, 7, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4550) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 36, 100.11, 1, 2, 8, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4553) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 37, 100.11, 1, 0, 8, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4556) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 38, 100.11, 1, 4, 8, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4558) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 40, 100.11, 1, 1, 8, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4564) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 41, 100.11, 1, 2, 9, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4568) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 42, 100.11, 1, 0, 9, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4570) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 43, 100.11, 1, 4, 9, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4573) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 44, 100.11, 1, 3, 9, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4576) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 45, 100.11, 1, 1, 9, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4579) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 47, 100.11, 1, 0, 10, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4584) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 48, 100.11, 1, 4, 10, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4587) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 49, 100.11, 1, 3, 10, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4590) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 50, 100.11, 1, 1, 10, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4592) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 27, 100.11, 1, 0, 6, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4527) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 39, 100.11, 1, 3, 8, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4561) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 26, 100.11, 1, 2, 6, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4525) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 46, 100.11, 1, 2, 10, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4582) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 24, 100.11, 1, 3, 5, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4519) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 25, 100.11, 1, 1, 5, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4522) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 1, 100.11, 1, 2, 1, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(3823) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 2, 100.11, 1, 0, 1, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4372) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 3, 100.11, 1, 4, 1, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4393) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 5, 100.11, 1, 1, 1, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4400) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 6, 100.11, 1, 2, 2, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4403) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 7, 100.11, 1, 0, 2, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4406) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 8, 100.11, 1, 4, 2, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4409) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 9, 100.11, 1, 3, 2, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4411) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 10, 100.11, 1, 1, 2, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4415) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 11, 100.11, 1, 2, 3, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4418) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 4, 100.11, 1, 3, 1, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4396) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 13, 100.11, 1, 4, 3, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4487) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 14, 100.11, 1, 3, 3, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4491) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 15, 100.11, 1, 1, 3, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4493) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 16, 100.11, 1, 2, 4, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4496) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 17, 100.11, 1, 0, 4, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4499) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 18, 100.11, 1, 4, 4, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4501) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 19, 100.11, 1, 3, 4, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4504) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 23, 100.11, 1, 4, 5, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4517) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 20, 100.11, 1, 1, 4, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4507) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 21, 100.11, 1, 2, 5, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4510) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 22, 100.11, 1, 0, 5, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4512) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 12, 100.11, 1, 0, 3, new DateTime(2020, 6, 2, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(4421) });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 5, new DateTime(2020, 11, 30, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(349), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 1.75, 1 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 3, new DateTime(2020, 11, 30, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(342), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 1100.0, 4 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 4, new DateTime(2020, 11, 30, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(346), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 20.550000000000001, 3 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 1, new DateTime(2020, 11, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(9360), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 40.450000000000003, 2 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 2, new DateTime(2020, 11, 30, 9, 33, 0, 4, DateTimeKind.Local).AddTicks(311), new DateTime(2019, 12, 6, 9, 32, 59, 994, DateTimeKind.Local).AddTicks(7626), 3.4500000000000002, 0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 168, 1, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2188), 6, 16.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 157, 0, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2156), 6, 21.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 158, 0, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2159), 6, 20.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 159, 0, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2161), 6, 20.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 160, 0, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2164), 6, 20.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 161, 1, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2167), 6, 10.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 162, 1, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2170), 6, 15.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 163, 1, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2173), 6, 16.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 164, 1, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2176), 6, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 165, 1, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2179), 6, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 166, 1, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2182), 6, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 167, 1, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2185), 6, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 156, 0, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2153), 6, 20.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 169, 1, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2191), 6, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 183, 1, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2230), 7, 36.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 171, 0, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2196), 7, 30.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 172, 0, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2199), 7, 39.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 173, 0, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2202), 7, 35.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 174, 0, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2204), 7, 30.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 175, 0, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2207), 7, 30.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 176, 0, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2210), 7, 35.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 177, 0, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2212), 7, 31.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 178, 0, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2215), 7, 30.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 179, 0, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2218), 7, 30.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 180, 0, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2221), 7, 30.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 181, 1, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2223), 7, 30.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 182, 1, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2226), 7, 35.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 155, 0, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2150), 6, 20.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 184, 1, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2232), 7, 31.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 170, 1, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2193), 6, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 154, 0, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2148), 6, 20.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 139, 0, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2106), 5, 10.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 152, 0, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2142), 6, 20.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 185, 1, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2235), 7, 30.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 123, 1, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2060), 4, 16.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 124, 1, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2063), 4, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 125, 1, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2065), 4, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 126, 1, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2069), 4, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 127, 1, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2071), 4, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 128, 1, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2074), 4, 26.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 129, 1, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2077), 4, 4.4100000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 130, 1, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2081), 4, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 131, 0, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2084), 5, 10.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 132, 0, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2087), 5, 19.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 133, 0, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2089), 5, 15.33 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 134, 0, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2092), 5, 10.67 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 135, 0, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2095), 5, 10.779999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 136, 0, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2098), 5, 10.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 137, 0, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2100), 5, 11.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 138, 0, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2103), 5, 10.529999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 140, 0, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2109), 5, 10.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 141, 1, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2111), 5, 11.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 142, 1, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2114), 5, 11.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 143, 1, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2117), 5, 16.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 144, 1, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2120), 5, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 145, 1, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2122), 5, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 146, 1, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2125), 5, 11.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 147, 1, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2129), 5, 11.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 148, 1, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2131), 5, 11.6 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 149, 1, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2134), 5, 11.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 150, 1, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2137), 5, 11.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 151, 0, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2140), 6, 20.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 153, 0, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2145), 6, 25.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 186, 1, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2238), 7, 36.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 227, 1, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2353), 9, 5.7400000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 188, 1, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2243), 7, 36.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 222, 1, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2339), 9, 25.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 223, 1, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2342), 9, 26.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 224, 1, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2345), 9, 21.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 225, 1, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2347), 9, 20.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 226, 1, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2350), 9, 6.9299999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 122, 1, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2057), 4, 30.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 228, 1, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2355), 9, 6.5999999999999996 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 229, 1, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2358), 9, 4.4100000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 230, 1, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2361), 9, 6.3200000000000003 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 231, 0, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2364), 10, 30.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 232, 0, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2367), 10, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 233, 0, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2369), 10, 35.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 234, 0, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2373), 10, 30.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 235, 0, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2376), 10, 30.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 236, 0, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2379), 10, 10.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 237, 0, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2464), 10, 10.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 238, 0, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2468), 10, 10.529999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 239, 0, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2471), 10, 10.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 240, 0, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2474), 10, 10.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 241, 1, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2476), 10, 20.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 242, 1, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2479), 10, 25.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 243, 1, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2482), 10, 26.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 244, 1, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2485), 10, 21.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 245, 1, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2487), 10, 20.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 246, 1, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2493), 10, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 247, 1, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2495), 10, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 248, 1, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2498), 10, 16.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 249, 1, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2501), 10, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 250, 1, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2504), 10, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 221, 1, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2336), 9, 20.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 187, 1, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2241), 7, 35.740000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 220, 0, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2334), 9, 30.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 218, 0, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2327), 9, 20.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 189, 1, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2246), 7, 34.409999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 190, 1, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2249), 7, 36.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 191, 0, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2252), 8, 9.4600000000000009 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 192, 0, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2254), 8, 9.8499999999999996 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 193, 0, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2257), 8, 9.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 194, 0, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2260), 8, 9.6699999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 195, 0, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2262), 8, 9.7799999999999994 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 196, 0, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2265), 8, 9.0700000000000003 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 197, 0, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2268), 8, 31.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 198, 0, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2271), 8, 9.5299999999999994 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 199, 0, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2274), 8, 9.7300000000000004 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 200, 0, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2276), 8, 40.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 201, 1, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2280), 8, 10.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 202, 1, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2283), 8, 10.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 203, 1, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2286), 8, 10.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 204, 1, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2288), 8, 10.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 205, 1, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2291), 8, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 206, 1, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2294), 8, 10.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 207, 1, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2296), 8, 35.740000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 208, 1, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2300), 8, 16.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 209, 1, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2302), 8, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 210, 1, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2305), 8, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 211, 0, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2308), 9, 31.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 212, 0, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2311), 9, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 213, 0, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2313), 9, 25.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 214, 0, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2316), 9, 10.67 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 215, 0, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2319), 9, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 216, 0, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2321), 9, 10.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 217, 0, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2324), 9, 1.3600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 219, 0, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2331), 9, 10.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 121, 1, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2054), 4, 13.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 91, 0, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1941), 3, 9.4600000000000009 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 119, 0, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2049), 4, 15.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 32, 0, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1664), 7, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 33, 4, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1667), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 34, 3, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1670), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 35, 1, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1673), 7, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 36, 2, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1675), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 37, 0, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1678), 8, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 38, 4, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1680), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 39, 3, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1683), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 40, 1, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1687), 8, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 41, 2, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1689), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 42, 0, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1692), 9, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 43, 4, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1695), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 31, 2, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1662), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 120, 0, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2052), 4, 3.21 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 46, 2, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1703), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 47, 0, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1705), 10, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 48, 4, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1708), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 49, 3, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1711), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 50, 1, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1713), 10, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 51, 0, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1716), 1, 30.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 52, 0, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1762), 1, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 53, 0, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1765), 1, 5.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 54, 0, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1768), 1, 50.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 55, 0, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1770), 1, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 56, 0, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1773), 1, 30.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 57, 0, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1776), 1, 31.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 45, 1, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1700), 9, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 30, 1, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1659), 6, 31.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 29, 3, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1657), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 28, 4, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1654), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 1, 2, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(838), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 2, 0, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1553), 1, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 3, 4, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1580), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 4, 3, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1584), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 5, 1, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1586), 1, 40.399999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 6, 2, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1589), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 7, 0, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1592), 2, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 8, 4, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1596), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 9, 3, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1599), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 10, 1, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1602), 2, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 11, 2, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1605), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 12, 0, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1607), 3, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 13, 4, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1610), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 14, 3, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1613), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 15, 1, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1616), 3, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 16, 2, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1619), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 17, 0, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1622), 4, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 18, 4, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1625), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 19, 3, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1627), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 20, 1, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1631), 4, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 21, 2, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1634), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 22, 0, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1636), 5, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 23, 4, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1640), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 24, 3, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1643), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 25, 1, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1645), 5, 40.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 26, 2, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1648), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 27, 0, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1651), 6, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 58, 0, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1779), 1, 20.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 59, 0, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1782), 1, 10.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 44, 3, new DateTime(2020, 6, 2, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1697), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 61, 1, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1788), 1, 10.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 93, 0, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1947), 3, 5.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 94, 0, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1950), 3, 30.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 95, 0, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1952), 3, 45.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 96, 0, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1955), 3, 30.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 97, 0, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1958), 3, 32.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 98, 0, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1962), 3, 25.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 99, 0, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1966), 3, 11.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 100, 0, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1970), 3, 31.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 101, 1, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1974), 3, 15.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 102, 1, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1978), 3, 25.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 103, 1, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1981), 3, 16.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 104, 1, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1985), 3, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 92, 0, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1943), 3, 23.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 105, 1, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1990), 3, 50.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 107, 1, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1998), 3, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 108, 1, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2003), 3, 6.5999999999999996 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 109, 1, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2007), 3, 24.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 110, 1, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2012), 3, 13.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 111, 0, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2016), 4, 3.46 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 112, 0, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2022), 4, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 113, 0, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2027), 4, 5.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 114, 0, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2030), 4, 10.67 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 115, 0, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2034), 4, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 116, 0, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2038), 4, 20.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 117, 0, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2043), 4, 11.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 118, 0, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(2046), 4, 10.529999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 60, 0, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1785), 1, 30.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 90, 1, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1938), 2, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 106, 1, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1994), 3, 26.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 63, 1, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1794), 1, 6.4299999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 89, 1, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1935), 2, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 62, 1, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1791), 1, 15.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 64, 1, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1796), 1, 31.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 65, 1, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1799), 1, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 66, 1, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1865), 1, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 67, 1, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1868), 1, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 68, 1, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1871), 1, 16.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 69, 1, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1874), 1, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 70, 1, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1877), 1, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 71, 0, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1879), 2, 31.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 72, 0, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1882), 2, 25.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 74, 0, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1888), 2, 50.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 75, 0, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1890), 2, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 73, 0, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1885), 2, 5.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 77, 0, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1897), 2, 30.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 88, 1, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1932), 2, 26.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 87, 1, new DateTime(2020, 5, 26, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1928), 2, 5.7400000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 86, 1, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1925), 2, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 85, 1, new DateTime(2020, 5, 28, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1922), 2, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 76, 0, new DateTime(2020, 5, 27, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1894), 2, 29.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 83, 1, new DateTime(2020, 5, 30, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1917), 2, 9.4299999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 84, 1, new DateTime(2020, 5, 29, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1920), 2, 25.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 81, 1, new DateTime(2020, 6, 1, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1909), 2, 11.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 80, 0, new DateTime(2020, 5, 23, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1906), 2, 40.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 79, 0, new DateTime(2020, 5, 24, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1903), 2, 5.7300000000000004 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 78, 0, new DateTime(2020, 5, 25, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1900), 2, 20.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 82, 1, new DateTime(2020, 5, 31, 9, 33, 0, 3, DateTimeKind.Local).AddTicks(1912), 2, 14.42 });

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
