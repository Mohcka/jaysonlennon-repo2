using Microsoft.EntityFrameworkCore.Migrations;

namespace AptMgmtPortalAPI.Migrations.SqlServerMigrations
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: false),
                    AgreementTemplateId = table.Column<int>(nullable: false),
                    SignedDate = table.Column<string>(type: "NVARCHAR(48)", nullable: true),
                    StartDate = table.Column<string>(type: "NVARCHAR(48)", nullable: false),
                    EndDate = table.Column<string>(type: "NVARCHAR(48)", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodStart = table.Column<string>(type: "NVARCHAR(48)", nullable: false),
                    PeriodEnd = table.Column<string>(type: "NVARCHAR(48)", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOpened = table.Column<string>(type: "NVARCHAR(48)", nullable: false),
                    TimeClosed = table.Column<string>(type: "NVARCHAR(48)", nullable: true),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(nullable: false),
                    ResourceType = table.Column<int>(nullable: false),
                    TimePaid = table.Column<string>(type: "NVARCHAR(48)", nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceType = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    PeriodStart = table.Column<string>(type: "NVARCHAR(48)", nullable: false),
                    PeriodEnd = table.Column<string>(type: "NVARCHAR(48)", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleTime = table.Column<string>(type: "NVARCHAR(48)", nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                values: new object[,]
                {
                    { 1, "This is a really long lease agreement text", "Lease Agreement" },
                    { 3, "This is a really long internet connection agreement text", "Internet Connection Agreement" },
                    { 2, "This is a really long utility agreement text", "Utility Agreement" }
                });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[,]
                {
                    { 10, 1, "2020-06-03 09:17:53.5153048", "2020-03-05 09:17:53.5018244", "2020-03-05 09:17:53.5018244", 10 },
                    { 9, 3, "2020-06-03 09:17:53.5153045", "2019-06-09 09:17:53.5018244", "2019-06-09 09:17:53.5018244", 9 },
                    { 8, 2, "2020-06-03 09:17:53.5153041", "2019-12-06 09:17:53.5018244", "2019-12-06 09:17:53.5018244", 8 },
                    { 1, 1, "2020-06-03 09:17:53.5151515", "2020-03-05 09:17:53.5018244", "2020-03-05 09:17:53.5018244", 1 },
                    { 6, 3, "2020-06-03 09:17:53.5153032", "2019-06-09 09:17:53.5018244", "2019-06-09 09:17:53.5018244", 6 },
                    { 5, 2, "2020-06-03 09:17:53.5153029", "2019-12-06 09:17:53.5018244", "2019-12-06 09:17:53.5018244", 5 },
                    { 4, 1, "2020-06-03 09:17:53.5153024", "2020-03-05 09:17:53.5018244", "2020-03-05 09:17:53.5018244", 4 },
                    { 3, 3, "2020-06-03 09:17:53.5153018", "2019-06-09 09:17:53.5018244", "2019-06-09 09:17:53.5018244", 3 },
                    { 2, 2, "2020-06-03 09:17:53.5152975", "2019-12-06 09:17:53.5018244", "2019-12-06 09:17:53.5018244", 2 },
                    { 7, 1, "2020-06-03 09:17:53.5153036", "2020-03-05 09:17:53.5018244", "2020-03-05 09:17:53.5018244", 7 }
                });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[,]
                {
                    { 1, "2020-06-04 09:17:53.5184313", "2020-05-04 09:17:53.5018244" },
                    { 2, "2020-06-04 09:17:53.5185175", "2020-03-05 09:17:53.5018244" },
                    { 3, "2020-06-04 09:17:53.5185217", "2019-12-06 09:17:53.5018244" },
                    { 4, "2020-06-04 09:17:53.5185222", "2019-06-09 09:17:53.5018244" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[,]
                {
                    { 7, null, null, "Call Plumber", null, "No water", 5, null, null, "2020-03-05 09:17:53.5018244", "105" },
                    { 10, null, null, "Call Plumber", null, "No water", 8, null, null, "2020-03-05 09:17:53.5018244", "108" },
                    { 8, null, null, "Call Plumber", null, "No water", 6, null, null, "2020-03-05 09:17:53.5018244", "106" },
                    { 6, null, null, "Call Plumber", null, "No water", 4, null, null, "2020-03-05 09:17:53.5018244", "104" },
                    { 9, null, null, "Call Plumber", null, "No water", 7, null, null, "2020-03-05 09:17:53.5018244", "107" },
                    { 4, "CanceledByTenant", 1, "Call Plumber", null, "No water", 2, "Fixed", "2020-05-04 09:17:53.5018244", "2020-03-05 09:17:53.5018244", "102" },
                    { 3, "CanceledByManagement", 1, "Call Plumber", null, "No water", 1, "Fixed", "2020-05-04 09:17:53.5018244", "2019-12-06 09:17:53.5018244", "101" },
                    { 2, "Completed", 1, "Call Comcast", null, "No Interet", 1, "Fixed", "2020-05-04 09:17:53.5018244", "2020-03-05 09:17:53.5018244", "101" },
                    { 1, "Completed", 1, "Call Plumber", "Plumbing", "No water", 1, "Fully restored.", "2020-06-03 09:17:53.5175351", "2020-03-05 09:17:53.5018244", "101" },
                    { 5, "CanceledByManagement", 2, "Call Plumber", null, "No water", 3, "Fixed", "2020-05-04 09:17:53.5018244", "2020-03-05 09:17:53.5018244", "103" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[,]
                {
                    { 28, 100.11, 1, 4, 6, "2020-06-02 09:17:53.5165678" },
                    { 29, 100.11, 1, 3, 6, "2020-06-02 09:17:53.5165682" },
                    { 30, 100.11, 1, 1, 6, "2020-06-02 09:17:53.5165685" },
                    { 31, 100.11, 1, 2, 7, "2020-06-02 09:17:53.5165689" },
                    { 32, 100.11, 1, 0, 7, "2020-06-02 09:17:53.5165693" },
                    { 33, 100.11, 1, 4, 7, "2020-06-02 09:17:53.5165696" },
                    { 34, 100.11, 1, 3, 7, "2020-06-02 09:17:53.5165702" },
                    { 35, 100.11, 1, 1, 7, "2020-06-02 09:17:53.5165706" },
                    { 36, 100.11, 1, 2, 8, "2020-06-02 09:17:53.5165709" },
                    { 37, 100.11, 1, 0, 8, "2020-06-02 09:17:53.5165713" },
                    { 38, 100.11, 1, 4, 8, "2020-06-02 09:17:53.5165717" },
                    { 41, 100.11, 1, 2, 9, "2020-06-02 09:17:53.5165728" },
                    { 42, 100.11, 1, 0, 9, "2020-06-02 09:17:53.5165732" },
                    { 43, 100.11, 1, 4, 9, "2020-06-02 09:17:53.5165738" },
                    { 44, 100.11, 1, 3, 9, "2020-06-02 09:17:53.5165742" },
                    { 45, 100.11, 1, 1, 9, "2020-06-02 09:17:53.5165747" },
                    { 46, 100.11, 1, 2, 10, "2020-06-02 09:17:53.516575" },
                    { 47, 100.11, 1, 0, 10, "2020-06-02 09:17:53.5165755" },
                    { 48, 100.11, 1, 4, 10, "2020-06-02 09:17:53.5165758" },
                    { 49, 100.11, 1, 3, 10, "2020-06-02 09:17:53.5165763" },
                    { 50, 100.11, 1, 1, 10, "2020-06-02 09:17:53.5165767" },
                    { 27, 100.11, 1, 0, 6, "2020-06-02 09:17:53.5165674" },
                    { 40, 100.11, 1, 1, 8, "2020-06-02 09:17:53.5165725" },
                    { 26, 100.11, 1, 2, 6, "2020-06-02 09:17:53.5165664" },
                    { 39, 100.11, 1, 3, 8, "2020-06-02 09:17:53.5165721" },
                    { 24, 100.11, 1, 3, 5, "2020-06-02 09:17:53.5165657" },
                    { 1, 100.11, 1, 2, 1, "2020-06-02 09:17:53.5164464" },
                    { 2, 100.11, 1, 0, 1, "2020-06-02 09:17:53.5165523" },
                    { 3, 100.11, 1, 4, 1, "2020-06-02 09:17:53.5165563" },
                    { 4, 100.11, 1, 3, 1, "2020-06-02 09:17:53.5165568" },
                    { 5, 100.11, 1, 1, 1, "2020-06-02 09:17:53.5165575" },
                    { 6, 100.11, 1, 2, 2, "2020-06-02 09:17:53.5165579" },
                    { 7, 100.11, 1, 0, 2, "2020-06-02 09:17:53.5165583" },
                    { 8, 100.11, 1, 4, 2, "2020-06-02 09:17:53.5165587" },
                    { 9, 100.11, 1, 3, 2, "2020-06-02 09:17:53.5165591" },
                    { 10, 100.11, 1, 1, 2, "2020-06-02 09:17:53.5165595" },
                    { 11, 100.11, 1, 2, 3, "2020-06-02 09:17:53.5165599" },
                    { 25, 100.11, 1, 1, 5, "2020-06-02 09:17:53.516566" },
                    { 13, 100.11, 1, 4, 3, "2020-06-02 09:17:53.5165607" },
                    { 14, 100.11, 1, 3, 3, "2020-06-02 09:17:53.5165611" },
                    { 15, 100.11, 1, 1, 3, "2020-06-02 09:17:53.5165615" },
                    { 16, 100.11, 1, 2, 4, "2020-06-02 09:17:53.5165618" },
                    { 17, 100.11, 1, 0, 4, "2020-06-02 09:17:53.5165628" },
                    { 18, 100.11, 1, 4, 4, "2020-06-02 09:17:53.5165634" },
                    { 19, 100.11, 1, 3, 4, "2020-06-02 09:17:53.5165638" },
                    { 20, 100.11, 1, 1, 4, "2020-06-02 09:17:53.5165642" },
                    { 21, 100.11, 1, 2, 5, "2020-06-02 09:17:53.5165645" },
                    { 22, 100.11, 1, 0, 5, "2020-06-02 09:17:53.5165649" },
                    { 23, 100.11, 1, 4, 5, "2020-06-02 09:17:53.5165653" },
                    { 12, 100.11, 1, 0, 3, "2020-06-02 09:17:53.5165603" }
                });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[,]
                {
                    { 5, "2020-11-30 09:17:53.5158979", "2019-12-06 09:17:53.5018244", 1.75, 1 },
                    { 4, "2020-11-30 09:17:53.5158974", "2019-12-06 09:17:53.5018244", 20.550000000000001, 3 },
                    { 2, "2020-11-30 09:17:53.5158921", "2019-12-06 09:17:53.5018244", 3.4500000000000002, 0 },
                    { 1, "2020-11-30 09:17:53.5157529", "2019-12-06 09:17:53.5018244", 40.450000000000003, 2 },
                    { 3, "2020-11-30 09:17:53.5158969", "2019-12-06 09:17:53.5018244", 1100.0, 4 }
                });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[,]
                {
                    { 16, 2, "2020-06-02 09:17:53.514392", 4, 1.0 },
                    { 17, 0, "2020-06-02 09:17:53.5143924", 4, 50.549999999999997 },
                    { 18, 4, "2020-06-02 09:17:53.5143927", 4, 1.0 },
                    { 19, 3, "2020-06-02 09:17:53.5143931", 4, 1.0 },
                    { 20, 1, "2020-06-02 09:17:53.5143935", 4, 30.329999999999998 },
                    { 21, 2, "2020-06-02 09:17:53.5143939", 5, 1.0 },
                    { 22, 0, "2020-06-02 09:17:53.5143943", 5, 60.549999999999997 },
                    { 23, 4, "2020-06-02 09:17:53.5143946", 5, 1.0 },
                    { 24, 3, "2020-06-02 09:17:53.514395", 5, 1.0 },
                    { 25, 1, "2020-06-02 09:17:53.5143954", 5, 40.329999999999998 },
                    { 26, 2, "2020-06-02 09:17:53.5143957", 6, 1.0 },
                    { 28, 4, "2020-06-02 09:17:53.5143965", 6, 1.0 },
                    { 38, 4, "2020-06-02 09:17:53.514401", 8, 1.0 },
                    { 29, 3, "2020-06-02 09:17:53.5143977", 6, 1.0 },
                    { 30, 1, "2020-06-02 09:17:53.514398", 6, 31.329999999999998 },
                    { 31, 2, "2020-06-02 09:17:53.5143984", 7, 1.0 },
                    { 32, 0, "2020-06-02 09:17:53.5143988", 7, 50.549999999999997 },
                    { 33, 4, "2020-06-02 09:17:53.5143991", 7, 1.0 },
                    { 34, 3, "2020-06-02 09:17:53.5143995", 7, 1.0 },
                    { 35, 1, "2020-06-02 09:17:53.5143999", 7, 30.329999999999998 },
                    { 36, 2, "2020-06-02 09:17:53.5144002", 8, 1.0 },
                    { 37, 0, "2020-06-02 09:17:53.5144006", 8, 50.549999999999997 },
                    { 27, 0, "2020-06-02 09:17:53.5143961", 6, 60.549999999999997 },
                    { 15, 1, "2020-06-02 09:17:53.5143917", 3, 30.329999999999998 },
                    { 41, 2, "2020-06-02 09:17:53.5144021", 9, 1.0 },
                    { 13, 4, "2020-06-02 09:17:53.5143909", 3, 1.0 },
                    { 39, 3, "2020-06-02 09:17:53.5144014", 8, 1.0 },
                    { 50, 1, "2020-06-02 09:17:53.5144056", 10, 30.329999999999998 },
                    { 49, 3, "2020-06-02 09:17:53.5144053", 10, 1.0 },
                    { 48, 4, "2020-06-02 09:17:53.5144049", 10, 1.0 },
                    { 47, 0, "2020-06-02 09:17:53.5144043", 10, 50.549999999999997 },
                    { 46, 2, "2020-06-02 09:17:53.5144039", 10, 1.0 },
                    { 45, 1, "2020-06-02 09:17:53.5144036", 9, 30.329999999999998 },
                    { 44, 3, "2020-06-02 09:17:53.5144032", 9, 1.0 },
                    { 43, 4, "2020-06-02 09:17:53.5144029", 9, 1.0 },
                    { 42, 0, "2020-06-02 09:17:53.5144025", 9, 50.549999999999997 },
                    { 14, 3, "2020-06-02 09:17:53.5143913", 3, 1.0 },
                    { 1, 2, "2020-06-02 09:17:53.5141785", 1, 1.0 },
                    { 3, 4, "2020-06-02 09:17:53.5143692", 1, 1.0 },
                    { 4, 3, "2020-06-02 09:17:53.5143699", 1, 1.0 },
                    { 5, 1, "2020-06-02 09:17:53.5143703", 1, 40.399999999999999 },
                    { 6, 2, "2020-06-02 09:17:53.5143707", 2, 1.0 },
                    { 7, 0, "2020-06-02 09:17:53.5143711", 2, 50.549999999999997 },
                    { 8, 4, "2020-06-02 09:17:53.5143714", 2, 1.0 },
                    { 9, 3, "2020-06-02 09:17:53.5143719", 2, 1.0 },
                    { 10, 1, "2020-06-02 09:17:53.5143723", 2, 30.329999999999998 },
                    { 11, 2, "2020-06-02 09:17:53.5143899", 3, 1.0 },
                    { 12, 0, "2020-06-02 09:17:53.5143905", 3, 50.549999999999997 },
                    { 2, 0, "2020-06-02 09:17:53.5143623", 1, 50.549999999999997 },
                    { 40, 1, "2020-06-02 09:17:53.5144017", 8, 30.329999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "jayson@gmail.com", "Jayson", "Lennon", "555-164-317", 3 },
                    { 9, "linda@gmail.com", "Linda", "Lopez", "555-607-558", 11 },
                    { 8, "frances@gmail.com", "Frances ", "Hook", "555-871-503", 10 },
                    { 7, "ruth@gmail.com", "Ruth ", "Williams", "555-337-777", 9 },
                    { 6, "deon@gmail.com", "Deon ", "Smith", "555-514-298", 8 },
                    { 5, "melvin@gmail.com", "Melvin", "Johnson", "555-858-445", 7 },
                    { 4, "sulav@gmail.com", "Sulav", "Aryal", "555-787-595", 6 },
                    { 3, "michael@gmail.com", "Michael", "Walker", "555-115-412", 5 },
                    { 2, "david@gmail.com", "David", "Sawyer", "555-195-162", 4 },
                    { 10, "regina@gmail.com", "Regina", "McCoy", "555-504-625", 12 }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[,]
                {
                    { 10, 10, "110" },
                    { 9, 9, "109" },
                    { 8, 8, "108" },
                    { 6, 6, "106" },
                    { 7, 7, "107" },
                    { 4, 4, "104" },
                    { 3, 3, "103" },
                    { 2, 2, "102" },
                    { 1, 1, "101" },
                    { 5, 5, "105" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[,]
                {
                    { 11, "test-key11", "linda", "", "linda", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 10, "test-key10", "frances", "", "frances", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 9, "test-key9", "ruth", "", "ruth", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 8, "test-key8", "deon", "", "deon", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 7, "test-key7", "melvin", "", "melvin", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 4, "test-key4", "david", "", "david", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 5, "test-key5", "michael", "", "michael", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 3, "test-key3", "jayson", "", "jayson", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 2, "test-key2", "manager", "manager", "manager", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Manager" },
                    { 1, "test-key1", "admin", "admin", "admin", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Admin" },
                    { 12, "test-key12", "regina", "", "regina", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 6, "test-key6", "sulav", "", "sulav", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 13, "test-key13", "sulav2", "", "sulav2", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitNumber",
                table: "Units",
                column: "UnitNumber",
                unique: true,
                filter: "[UnitNumber] IS NOT NULL");
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
