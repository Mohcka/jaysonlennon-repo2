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
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.AgreementId);
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
                name: "SignedAgreements",
                columns: table => new
                {
                    SignedAgreementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: false),
                    AgreementId = table.Column<int>(nullable: false),
                    SignedDate = table.Column<string>(type: "NVARCHAR(48)", nullable: true),
                    StartDate = table.Column<string>(type: "NVARCHAR(48)", nullable: false),
                    EndDate = table.Column<string>(type: "NVARCHAR(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignedAgreements", x => x.SignedAgreementId);
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
                table: "Agreements",
                columns: new[] { "AgreementId", "Text", "Title" },
                values: new object[,]
                {
                    { 1, "This is a really long lease agreement text", "Lease Agreement" },
                    { 2, "This is a really long utility agreement text", "Utility Agreement" },
                    { 3, "This is a really long internet connection agreement text", "Internet Connection Agreement" }
                });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[,]
                {
                    { 1, "2020-06-03 21:37:25.5221353", "2020-05-03 21:37:25.5059952" },
                    { 2, "2020-06-03 21:37:25.5221802", "2020-03-04 21:37:25.5059952" },
                    { 3, "2020-06-03 21:37:25.522182", "2019-12-05 21:37:25.5059952" },
                    { 4, "2020-06-03 21:37:25.5221871", "2019-06-08 21:37:25.5059952" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[,]
                {
                    { 10, null, null, "Call Plumber", null, "No water", 8, null, null, "2020-03-04 21:37:25.5059952", "108" },
                    { 9, null, null, "Call Plumber", null, "No water", 7, null, null, "2020-03-04 21:37:25.5059952", "107" },
                    { 8, null, null, "Call Plumber", null, "No water", 6, null, null, "2020-03-04 21:37:25.5059952", "106" },
                    { 6, null, null, "Call Plumber", null, "No water", 4, null, null, "2020-03-04 21:37:25.5059952", "104" },
                    { 7, null, null, "Call Plumber", null, "No water", 5, null, null, "2020-03-04 21:37:25.5059952", "105" },
                    { 4, "CanceledByTenant", 1, "Call Plumber", null, "No water", 2, "Fixed", "2020-05-03 21:37:25.5059952", "2020-03-04 21:37:25.5059952", "102" },
                    { 3, "CanceledByManagement", 1, "Call Plumber", null, "No water", 1, "Fixed", "2020-05-03 21:37:25.5059952", "2019-12-05 21:37:25.5059952", "101" },
                    { 2, "Completed", 1, "Call Comcast", null, "No Interet", 1, "Fixed", "2020-05-03 21:37:25.5059952", "2020-03-04 21:37:25.5059952", "101" },
                    { 1, "Completed", 1, "Call Plumber", "Plumbing", "No water", 1, "Fully restored.", "2020-06-02 21:37:25.521845", "2020-03-04 21:37:25.5059952", "101" },
                    { 5, "CanceledByManagement", 2, "Call Plumber", null, "No water", 3, "Fixed", "2020-05-03 21:37:25.5059952", "2020-03-04 21:37:25.5059952", "103" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[,]
                {
                    { 37, 100.11, 1, 0, 8, "2020-06-01 21:37:25.521388" },
                    { 28, 100.11, 1, 4, 6, "2020-06-01 21:37:25.5213859" },
                    { 29, 100.11, 1, 3, 6, "2020-06-01 21:37:25.5213861" },
                    { 30, 100.11, 1, 1, 6, "2020-06-01 21:37:25.5213863" },
                    { 31, 100.11, 1, 2, 7, "2020-06-01 21:37:25.5213866" },
                    { 32, 100.11, 1, 0, 7, "2020-06-01 21:37:25.5213868" },
                    { 33, 100.11, 1, 4, 7, "2020-06-01 21:37:25.521387" },
                    { 34, 100.11, 1, 3, 7, "2020-06-01 21:37:25.5213873" },
                    { 35, 100.11, 1, 1, 7, "2020-06-01 21:37:25.5213875" },
                    { 36, 100.11, 1, 2, 8, "2020-06-01 21:37:25.5213877" },
                    { 38, 100.11, 1, 4, 8, "2020-06-01 21:37:25.5213882" },
                    { 46, 100.11, 1, 2, 10, "2020-06-01 21:37:25.52139" },
                    { 40, 100.11, 1, 1, 8, "2020-06-01 21:37:25.5213887" },
                    { 41, 100.11, 1, 2, 9, "2020-06-01 21:37:25.5213889" },
                    { 42, 100.11, 1, 0, 9, "2020-06-01 21:37:25.5213891" },
                    { 43, 100.11, 1, 4, 9, "2020-06-01 21:37:25.5213894" },
                    { 44, 100.11, 1, 3, 9, "2020-06-01 21:37:25.5213896" },
                    { 45, 100.11, 1, 1, 9, "2020-06-01 21:37:25.5213898" },
                    { 27, 100.11, 1, 0, 6, "2020-06-01 21:37:25.5213856" },
                    { 47, 100.11, 1, 0, 10, "2020-06-01 21:37:25.5213903" },
                    { 48, 100.11, 1, 4, 10, "2020-06-01 21:37:25.5213906" },
                    { 50, 100.11, 1, 1, 10, "2020-06-01 21:37:25.521391" },
                    { 39, 100.11, 1, 3, 8, "2020-06-01 21:37:25.5213884" },
                    { 26, 100.11, 1, 2, 6, "2020-06-01 21:37:25.5213854" },
                    { 49, 100.11, 1, 3, 10, "2020-06-01 21:37:25.5213908" },
                    { 24, 100.11, 1, 3, 5, "2020-06-01 21:37:25.5213849" },
                    { 1, 100.11, 1, 2, 1, "2020-06-01 21:37:25.5213302" },
                    { 25, 100.11, 1, 1, 5, "2020-06-01 21:37:25.5213852" },
                    { 2, 100.11, 1, 0, 1, "2020-06-01 21:37:25.5213778" },
                    { 3, 100.11, 1, 4, 1, "2020-06-01 21:37:25.5213797" },
                    { 4, 100.11, 1, 3, 1, "2020-06-01 21:37:25.52138" },
                    { 5, 100.11, 1, 1, 1, "2020-06-01 21:37:25.5213802" },
                    { 6, 100.11, 1, 2, 2, "2020-06-01 21:37:25.5213805" },
                    { 8, 100.11, 1, 4, 2, "2020-06-01 21:37:25.521381" },
                    { 9, 100.11, 1, 3, 2, "2020-06-01 21:37:25.5213812" },
                    { 10, 100.11, 1, 1, 2, "2020-06-01 21:37:25.5213814" },
                    { 11, 100.11, 1, 2, 3, "2020-06-01 21:37:25.5213817" },
                    { 7, 100.11, 1, 0, 2, "2020-06-01 21:37:25.5213807" },
                    { 13, 100.11, 1, 4, 3, "2020-06-01 21:37:25.5213822" },
                    { 23, 100.11, 1, 4, 5, "2020-06-01 21:37:25.5213847" },
                    { 12, 100.11, 1, 0, 3, "2020-06-01 21:37:25.5213819" },
                    { 21, 100.11, 1, 2, 5, "2020-06-01 21:37:25.5213842" },
                    { 20, 100.11, 1, 1, 4, "2020-06-01 21:37:25.521384" },
                    { 19, 100.11, 1, 3, 4, "2020-06-01 21:37:25.5213836" },
                    { 22, 100.11, 1, 0, 5, "2020-06-01 21:37:25.5213845" },
                    { 17, 100.11, 1, 0, 4, "2020-06-01 21:37:25.5213832" },
                    { 16, 100.11, 1, 2, 4, "2020-06-01 21:37:25.5213829" },
                    { 15, 100.11, 1, 1, 3, "2020-06-01 21:37:25.5213827" },
                    { 14, 100.11, 1, 3, 3, "2020-06-01 21:37:25.5213824" },
                    { 18, 100.11, 1, 4, 4, "2020-06-01 21:37:25.5213834" }
                });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[,]
                {
                    { 1, "2020-11-29 21:37:25.520932", "2019-12-05 21:37:25.5059952", 40.450000000000003, 2 },
                    { 2, "2020-11-29 21:37:25.5210156", "2019-12-05 21:37:25.5059952", 3.4500000000000002, 0 },
                    { 3, "2020-11-29 21:37:25.521018", "2019-12-05 21:37:25.5059952", 1100.0, 4 },
                    { 4, "2020-11-29 21:37:25.5210183", "2019-12-05 21:37:25.5059952", 20.550000000000001, 3 },
                    { 5, "2020-11-29 21:37:25.5210185", "2019-12-05 21:37:25.5059952", 1.75, 1 }
                });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[,]
                {
                    { 7, 1, "2020-06-02 21:37:25.5207035", "2020-03-04 21:37:25.5059952", "2020-03-04 21:37:25.5059952", 7 },
                    { 10, 1, "2020-06-02 21:37:25.5207042", "2020-03-04 21:37:25.5059952", "2020-03-04 21:37:25.5059952", 10 },
                    { 9, 3, "2020-06-02 21:37:25.520704", "2019-06-08 21:37:25.5059952", "2019-06-08 21:37:25.5059952", 9 },
                    { 8, 2, "2020-06-02 21:37:25.5207037", "2019-12-05 21:37:25.5059952", "2019-12-05 21:37:25.5059952", 8 },
                    { 6, 3, "2020-06-02 21:37:25.5207032", "2019-06-08 21:37:25.5059952", "2019-06-08 21:37:25.5059952", 6 },
                    { 2, 2, "2020-06-02 21:37:25.5206998", "2019-12-05 21:37:25.5059952", "2019-12-05 21:37:25.5059952", 2 },
                    { 4, 1, "2020-06-02 21:37:25.5207028", "2020-03-04 21:37:25.5059952", "2020-03-04 21:37:25.5059952", 4 },
                    { 3, 3, "2020-06-02 21:37:25.5207024", "2019-06-08 21:37:25.5059952", "2019-06-08 21:37:25.5059952", 3 },
                    { 1, 1, "2020-06-02 21:37:25.5206164", "2020-03-04 21:37:25.5059952", "2020-03-04 21:37:25.5059952", 1 },
                    { 5, 2, "2020-06-02 21:37:25.520703", "2019-12-05 21:37:25.5059952", "2019-12-05 21:37:25.5059952", 5 }
                });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[,]
                {
                    { 17, 0, "2020-06-01 21:37:25.5203161", 4, 50.549999999999997 },
                    { 18, 4, "2020-06-01 21:37:25.5203163", 4, 1.0 },
                    { 19, 3, "2020-06-01 21:37:25.5203165", 4, 1.0 },
                    { 20, 1, "2020-06-01 21:37:25.5203168", 4, 30.329999999999998 },
                    { 21, 2, "2020-06-01 21:37:25.5203171", 5, 1.0 },
                    { 22, 0, "2020-06-01 21:37:25.5203173", 5, 60.549999999999997 },
                    { 23, 4, "2020-06-01 21:37:25.5203176", 5, 1.0 },
                    { 24, 3, "2020-06-01 21:37:25.5203178", 5, 1.0 },
                    { 25, 1, "2020-06-01 21:37:25.5203181", 5, 40.329999999999998 },
                    { 26, 2, "2020-06-01 21:37:25.5203183", 6, 1.0 },
                    { 27, 0, "2020-06-01 21:37:25.5203185", 6, 60.549999999999997 },
                    { 29, 3, "2020-06-01 21:37:25.520319", 6, 1.0 },
                    { 30, 1, "2020-06-01 21:37:25.5203193", 6, 31.329999999999998 },
                    { 31, 2, "2020-06-01 21:37:25.5203195", 7, 1.0 },
                    { 32, 0, "2020-06-01 21:37:25.5203198", 7, 50.549999999999997 },
                    { 33, 4, "2020-06-01 21:37:25.52032", 7, 1.0 },
                    { 38, 4, "2020-06-01 21:37:25.5203213", 8, 1.0 },
                    { 34, 3, "2020-06-01 21:37:25.5203203", 7, 1.0 },
                    { 35, 1, "2020-06-01 21:37:25.5203205", 7, 30.329999999999998 },
                    { 36, 2, "2020-06-01 21:37:25.5203208", 8, 1.0 },
                    { 37, 0, "2020-06-01 21:37:25.520321", 8, 50.549999999999997 },
                    { 16, 2, "2020-06-01 21:37:25.5203158", 4, 1.0 },
                    { 28, 4, "2020-06-01 21:37:25.5203188", 6, 1.0 },
                    { 15, 1, "2020-06-01 21:37:25.5203156", 3, 30.329999999999998 },
                    { 46, 2, "2020-06-01 21:37:25.5203231", 10, 1.0 },
                    { 13, 4, "2020-06-01 21:37:25.5203151", 3, 1.0 },
                    { 39, 3, "2020-06-01 21:37:25.5203215", 8, 1.0 },
                    { 50, 1, "2020-06-01 21:37:25.5203242", 10, 30.329999999999998 },
                    { 49, 3, "2020-06-01 21:37:25.5203239", 10, 1.0 },
                    { 48, 4, "2020-06-01 21:37:25.5203236", 10, 1.0 },
                    { 47, 0, "2020-06-01 21:37:25.5203234", 10, 50.549999999999997 },
                    { 45, 1, "2020-06-01 21:37:25.5203229", 9, 30.329999999999998 },
                    { 44, 3, "2020-06-01 21:37:25.5203227", 9, 1.0 },
                    { 43, 4, "2020-06-01 21:37:25.5203224", 9, 1.0 },
                    { 42, 0, "2020-06-01 21:37:25.5203222", 9, 50.549999999999997 },
                    { 41, 2, "2020-06-01 21:37:25.520322", 9, 1.0 },
                    { 14, 3, "2020-06-01 21:37:25.5203154", 3, 1.0 },
                    { 1, 2, "2020-06-01 21:37:25.520259", 1, 1.0 },
                    { 3, 4, "2020-06-01 21:37:25.5203124", 1, 1.0 },
                    { 4, 3, "2020-06-01 21:37:25.5203127", 1, 1.0 },
                    { 5, 1, "2020-06-01 21:37:25.520313", 1, 40.399999999999999 },
                    { 6, 2, "2020-06-01 21:37:25.5203133", 2, 1.0 },
                    { 7, 0, "2020-06-01 21:37:25.5203135", 2, 50.549999999999997 },
                    { 8, 4, "2020-06-01 21:37:25.5203138", 2, 1.0 },
                    { 9, 3, "2020-06-01 21:37:25.520314", 2, 1.0 },
                    { 10, 1, "2020-06-01 21:37:25.5203143", 2, 30.329999999999998 },
                    { 11, 2, "2020-06-01 21:37:25.5203146", 3, 1.0 },
                    { 12, 0, "2020-06-01 21:37:25.5203149", 3, 50.549999999999997 },
                    { 2, 0, "2020-06-01 21:37:25.5203105", 1, 50.549999999999997 },
                    { 40, 1, "2020-06-01 21:37:25.5203217", 8, 30.329999999999998 }
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
                name: "BillingPeriods");

            migrationBuilder.DropTable(
                name: "MaintenanceRequests");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ResourceUsageRates");

            migrationBuilder.DropTable(
                name: "SignedAgreements");

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
