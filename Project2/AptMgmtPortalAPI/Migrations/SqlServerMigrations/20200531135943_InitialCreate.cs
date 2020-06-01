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
                    SignedDate = table.Column<string>(type: "NVARCHAR(48)", nullable: false),
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
                    ApiKey = table.Column<string>(nullable: true)
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
                    { 1, "2020-05-31 06:59:43.0544131", "2020-05-01 06:59:43.0466512" },
                    { 2, "2020-05-31 06:59:43.0544604", "2020-03-02 06:59:43.0466512" },
                    { 3, "2020-05-31 06:59:43.0544623", "2019-12-03 06:59:43.0466512" },
                    { 4, "2020-05-31 06:59:43.0544626", "2019-06-06 06:59:43.0466512" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[,]
                {
                    { 10, null, null, "Call Plumber", null, "No water", 8, null, null, "2020-03-02 06:59:43.0466512", "108" },
                    { 9, null, null, "Call Plumber", null, "No water", 7, null, null, "2020-03-02 06:59:43.0466512", "107" },
                    { 8, null, null, "Call Plumber", null, "No water", 6, null, null, "2020-03-02 06:59:43.0466512", "106" },
                    { 6, null, null, "Call Plumber", null, "No water", 4, null, null, "2020-03-02 06:59:43.0466512", "104" },
                    { 7, null, null, "Call Plumber", null, "No water", 5, null, null, "2020-03-02 06:59:43.0466512", "105" },
                    { 4, "CanceledByTenant", 1, "Call Plumber", null, "No water", 2, null, null, "2020-03-02 06:59:43.0466512", "102" },
                    { 3, "CanceledByManagement", 1, "Call Plumber", null, "No water", 1, null, null, "2019-12-03 06:59:43.0466512", "101" },
                    { 2, "Completed", 1, "Call Comcast", null, "No Interet", 1, null, null, "2020-03-02 06:59:43.0466512", "101" },
                    { 1, "Completed", 1, "Call Plumber", "Plumbing", "No water", 1, "Fully restored.", "2020-05-31 06:59:43.0541134", "2020-03-02 06:59:43.0466512", "101" },
                    { 5, "CanceledByManagement", null, "Call Plumber", null, "No water", 3, null, null, "2020-03-02 06:59:43.0466512", "103" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[,]
                {
                    { 37, 100.11, 1, 0, 8, "2020-05-31 06:59:43.0536517" },
                    { 28, 100.11, 1, 4, 6, "2020-05-31 06:59:43.0536496" },
                    { 29, 100.11, 1, 3, 6, "2020-05-31 06:59:43.0536498" },
                    { 30, 100.11, 1, 1, 6, "2020-05-31 06:59:43.05365" },
                    { 31, 100.11, 1, 2, 7, "2020-05-31 06:59:43.0536503" },
                    { 32, 100.11, 1, 0, 7, "2020-05-31 06:59:43.0536505" },
                    { 33, 100.11, 1, 4, 7, "2020-05-31 06:59:43.0536507" },
                    { 34, 100.11, 1, 3, 7, "2020-05-31 06:59:43.0536509" },
                    { 35, 100.11, 1, 1, 7, "2020-05-31 06:59:43.0536512" },
                    { 36, 100.11, 1, 2, 8, "2020-05-31 06:59:43.0536514" },
                    { 38, 100.11, 1, 4, 8, "2020-05-31 06:59:43.0536519" },
                    { 46, 100.11, 1, 2, 10, "2020-05-31 06:59:43.0536537" },
                    { 40, 100.11, 1, 1, 8, "2020-05-31 06:59:43.0536524" },
                    { 41, 100.11, 1, 2, 9, "2020-05-31 06:59:43.0536526" },
                    { 42, 100.11, 1, 0, 9, "2020-05-31 06:59:43.0536528" },
                    { 43, 100.11, 1, 4, 9, "2020-05-31 06:59:43.053653" },
                    { 44, 100.11, 1, 3, 9, "2020-05-31 06:59:43.0536532" },
                    { 45, 100.11, 1, 1, 9, "2020-05-31 06:59:43.0536535" },
                    { 27, 100.11, 1, 0, 6, "2020-05-31 06:59:43.0536494" },
                    { 47, 100.11, 1, 0, 10, "2020-05-31 06:59:43.0536539" },
                    { 48, 100.11, 1, 4, 10, "2020-05-31 06:59:43.0536541" },
                    { 50, 100.11, 1, 1, 10, "2020-05-31 06:59:43.0536545" },
                    { 39, 100.11, 1, 3, 8, "2020-05-31 06:59:43.0536522" },
                    { 26, 100.11, 1, 2, 6, "2020-05-31 06:59:43.0536492" },
                    { 49, 100.11, 1, 3, 10, "2020-05-31 06:59:43.0536543" },
                    { 24, 100.11, 1, 3, 5, "2020-05-31 06:59:43.0536487" },
                    { 1, 100.11, 1, 2, 1, "2020-05-31 06:59:43.0535949" },
                    { 25, 100.11, 1, 1, 5, "2020-05-31 06:59:43.0536489" },
                    { 2, 100.11, 1, 0, 1, "2020-05-31 06:59:43.053642" },
                    { 3, 100.11, 1, 4, 1, "2020-05-31 06:59:43.0536437" },
                    { 4, 100.11, 1, 3, 1, "2020-05-31 06:59:43.053644" },
                    { 5, 100.11, 1, 1, 1, "2020-05-31 06:59:43.0536442" },
                    { 6, 100.11, 1, 2, 2, "2020-05-31 06:59:43.0536445" },
                    { 8, 100.11, 1, 4, 2, "2020-05-31 06:59:43.0536449" },
                    { 9, 100.11, 1, 3, 2, "2020-05-31 06:59:43.0536452" },
                    { 10, 100.11, 1, 1, 2, "2020-05-31 06:59:43.0536454" },
                    { 11, 100.11, 1, 2, 3, "2020-05-31 06:59:43.0536456" },
                    { 7, 100.11, 1, 0, 2, "2020-05-31 06:59:43.0536447" },
                    { 13, 100.11, 1, 4, 3, "2020-05-31 06:59:43.0536461" },
                    { 23, 100.11, 1, 4, 5, "2020-05-31 06:59:43.0536485" },
                    { 12, 100.11, 1, 0, 3, "2020-05-31 06:59:43.0536459" },
                    { 21, 100.11, 1, 2, 5, "2020-05-31 06:59:43.053648" },
                    { 20, 100.11, 1, 1, 4, "2020-05-31 06:59:43.0536478" },
                    { 19, 100.11, 1, 3, 4, "2020-05-31 06:59:43.0536476" },
                    { 22, 100.11, 1, 0, 5, "2020-05-31 06:59:43.0536482" },
                    { 17, 100.11, 1, 0, 4, "2020-05-31 06:59:43.0536471" },
                    { 16, 100.11, 1, 2, 4, "2020-05-31 06:59:43.0536468" },
                    { 15, 100.11, 1, 1, 3, "2020-05-31 06:59:43.0536466" },
                    { 14, 100.11, 1, 3, 3, "2020-05-31 06:59:43.0536463" },
                    { 18, 100.11, 1, 4, 4, "2020-05-31 06:59:43.0536473" }
                });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[,]
                {
                    { 1, "2020-05-31 06:59:43.0532196", "2020-03-02 06:59:43.0466512", 40.450000000000003, 2 },
                    { 2, "2020-05-31 06:59:43.0533007", "2020-03-02 06:59:43.0466512", 3.4500000000000002, 0 },
                    { 3, "2020-05-31 06:59:43.053304", "2020-03-02 06:59:43.0466512", 1100.0, 4 },
                    { 4, "2020-05-31 06:59:43.0533043", "2020-03-02 06:59:43.0466512", 20.550000000000001, 3 },
                    { 5, "2020-05-31 06:59:43.0533046", "2020-03-02 06:59:43.0466512", 1.75, 1 }
                });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[,]
                {
                    { 7, 1, "2020-05-31 06:59:43.0529947", "2020-03-02 06:59:43.0466512", "2020-03-02 06:59:43.0466512", 7 },
                    { 10, 1, "2020-05-31 06:59:43.0529954", "2020-03-02 06:59:43.0466512", "2020-03-02 06:59:43.0466512", 10 },
                    { 9, 3, "2020-05-31 06:59:43.0529952", "2019-06-06 06:59:43.0466512", "2019-06-06 06:59:43.0466512", 9 },
                    { 8, 2, "2020-05-31 06:59:43.052995", "2019-12-03 06:59:43.0466512", "2019-12-03 06:59:43.0466512", 8 },
                    { 6, 3, "2020-05-31 06:59:43.0529945", "2019-06-06 06:59:43.0466512", "2019-06-06 06:59:43.0466512", 6 },
                    { 2, 2, "2020-05-31 06:59:43.0529912", "2019-12-03 06:59:43.0466512", "2019-12-03 06:59:43.0466512", 2 },
                    { 4, 1, "2020-05-31 06:59:43.052994", "2020-03-02 06:59:43.0466512", "2020-03-02 06:59:43.0466512", 4 },
                    { 3, 3, "2020-05-31 06:59:43.0529937", "2019-06-06 06:59:43.0466512", "2019-06-06 06:59:43.0466512", 3 },
                    { 1, 1, "2020-05-31 06:59:43.0529101", "2020-03-02 06:59:43.0466512", "2020-03-02 06:59:43.0466512", 1 },
                    { 5, 2, "2020-05-31 06:59:43.0529943", "2019-12-03 06:59:43.0466512", "2019-12-03 06:59:43.0466512", 5 }
                });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[,]
                {
                    { 17, 0, "2020-05-31 06:59:43.0526253", 4, 50.549999999999997 },
                    { 18, 4, "2020-05-31 06:59:43.0526255", 4, 1100.5 },
                    { 19, 3, "2020-05-31 06:59:43.0526258", 4, 15.56 },
                    { 20, 1, "2020-05-31 06:59:43.052626", 4, 30.329999999999998 },
                    { 21, 2, "2020-05-31 06:59:43.0526263", 5, 150.0 },
                    { 22, 0, "2020-05-31 06:59:43.0526265", 5, 60.549999999999997 },
                    { 23, 4, "2020-05-31 06:59:43.0526267", 5, 1200.5 },
                    { 24, 3, "2020-05-31 06:59:43.052627", 5, 20.559999999999999 },
                    { 25, 1, "2020-05-31 06:59:43.0526272", 5, 40.329999999999998 },
                    { 26, 2, "2020-05-31 06:59:43.0526274", 6, 150.0 },
                    { 27, 0, "2020-05-31 06:59:43.0526276", 6, 60.549999999999997 },
                    { 29, 3, "2020-05-31 06:59:43.0526281", 6, 25.559999999999999 },
                    { 30, 1, "2020-05-31 06:59:43.0526283", 6, 31.329999999999998 },
                    { 31, 2, "2020-05-31 06:59:43.0526286", 7, 100.0 },
                    { 32, 0, "2020-05-31 06:59:43.0526288", 7, 50.549999999999997 },
                    { 33, 4, "2020-05-31 06:59:43.052629", 7, 1100.5 },
                    { 38, 4, "2020-05-31 06:59:43.0526301", 8, 1100.5 },
                    { 34, 3, "2020-05-31 06:59:43.0526292", 7, 15.56 },
                    { 35, 1, "2020-05-31 06:59:43.0526295", 7, 30.329999999999998 },
                    { 36, 2, "2020-05-31 06:59:43.0526297", 8, 100.0 },
                    { 37, 0, "2020-05-31 06:59:43.0526299", 8, 50.549999999999997 },
                    { 16, 2, "2020-05-31 06:59:43.0526251", 4, 100.0 },
                    { 28, 4, "2020-05-31 06:59:43.0526279", 6, 1200.5 },
                    { 15, 1, "2020-05-31 06:59:43.0526248", 3, 30.329999999999998 },
                    { 46, 2, "2020-05-31 06:59:43.052632", 10, 100.0 },
                    { 13, 4, "2020-05-31 06:59:43.0526244", 3, 1100.5 },
                    { 39, 3, "2020-05-31 06:59:43.0526304", 8, 15.56 },
                    { 50, 1, "2020-05-31 06:59:43.0526329", 10, 30.329999999999998 },
                    { 49, 3, "2020-05-31 06:59:43.0526327", 10, 15.56 },
                    { 48, 4, "2020-05-31 06:59:43.0526324", 10, 1100.5 },
                    { 47, 0, "2020-05-31 06:59:43.0526322", 10, 50.549999999999997 },
                    { 45, 1, "2020-05-31 06:59:43.0526317", 9, 30.329999999999998 },
                    { 44, 3, "2020-05-31 06:59:43.0526315", 9, 15.56 },
                    { 43, 4, "2020-05-31 06:59:43.0526313", 9, 1100.5 },
                    { 42, 0, "2020-05-31 06:59:43.052631", 9, 50.549999999999997 },
                    { 41, 2, "2020-05-31 06:59:43.0526308", 9, 100.0 },
                    { 14, 3, "2020-05-31 06:59:43.0526246", 3, 15.56 },
                    { 1, 2, "2020-05-31 06:59:43.0525686", 1, 100.0 },
                    { 3, 4, "2020-05-31 06:59:43.052622", 1, 1100.5 },
                    { 4, 3, "2020-05-31 06:59:43.0526223", 1, 15.56 },
                    { 5, 1, "2020-05-31 06:59:43.0526225", 1, 30.329999999999998 },
                    { 6, 2, "2020-05-31 06:59:43.0526228", 2, 100.0 },
                    { 7, 0, "2020-05-31 06:59:43.052623", 2, 50.549999999999997 },
                    { 8, 4, "2020-05-31 06:59:43.0526232", 2, 1100.5 },
                    { 9, 3, "2020-05-31 06:59:43.0526235", 2, 15.56 },
                    { 10, 1, "2020-05-31 06:59:43.0526237", 2, 30.329999999999998 },
                    { 11, 2, "2020-05-31 06:59:43.0526239", 3, 100.0 },
                    { 12, 0, "2020-05-31 06:59:43.0526242", 3, 50.549999999999997 },
                    { 2, 0, "2020-05-31 06:59:43.0526201", 1, 50.549999999999997 },
                    { 40, 1, "2020-05-31 06:59:43.0526306", 8, 30.329999999999998 }
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
                columns: new[] { "UserId", "ApiKey", "LoginName", "Password", "UserAccountType" },
                values: new object[,]
                {
                    { 11, "test-key11", "linda", "password", "Tenant" },
                    { 10, "test-key10", "frances", "password", "Tenant" },
                    { 9, "test-key9", "ruth", "password", "Tenant" },
                    { 8, "test-key8", "deon", "password", "Tenant" },
                    { 7, "test-key7", "melvin", "password", "Tenant" },
                    { 4, "test-key4", "david", "password", "Tenant" },
                    { 5, "test-key5", "michael", "password", "Tenant" },
                    { 3, "test-key3", "jayson", "password", "Tenant" },
                    { 2, "test-key2", "manager", "password", "Manager" },
                    { 1, "test-key1", "admin", "password", "Admin" },
                    { 12, "test-key12", "regina", "password", "Tenant" },
                    { 6, "test-key6", "sulav", "password", "Tenant" },
                    { 13, "test-key13", "sulav2", "password", "Tenant" }
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
