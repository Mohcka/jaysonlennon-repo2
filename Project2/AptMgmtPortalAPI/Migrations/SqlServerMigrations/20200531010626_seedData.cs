using Microsoft.EntityFrameworkCore.Migrations;

namespace AptMgmtPortalAPI.Migrations.SqlServerMigrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, "2020-05-30 18:06:25.3625779", "2020-04-30 18:06:25.3518605" },
                    { 2, "2020-05-30 18:06:25.3626418", "2020-03-01 18:06:25.3518605" },
                    { 3, "2020-05-30 18:06:25.362645", "2019-12-02 18:06:25.3518605" },
                    { 4, "2020-05-30 18:06:25.362646", "2019-06-05 18:06:25.3518605" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[,]
                {
                    { 10, null, null, "Call Plumber", null, "No water", 8, null, null, "2020-03-01 18:06:25.3518605", "108" },
                    { 9, null, null, "Call Plumber", null, "No water", 7, null, null, "2020-03-01 18:06:25.3518605", "107" },
                    { 8, null, null, "Call Plumber", null, "No water", 6, null, null, "2020-03-01 18:06:25.3518605", "106" },
                    { 6, null, null, "Call Plumber", null, "No water", 4, null, null, "2020-03-01 18:06:25.3518605", "104" },
                    { 7, null, null, "Call Plumber", null, "No water", 5, null, null, "2020-03-01 18:06:25.3518605", "105" },
                    { 4, "CanceledByTenant", 1, "Call Plumber", null, "No water", 2, null, null, "2020-03-01 18:06:25.3518605", "102" },
                    { 3, "CanceledByManagement", 1, "Call Plumber", null, "No water", 1, null, null, "2019-12-02 18:06:25.3518605", "101" },
                    { 2, "Completed", 1, "Call Comcast", null, "No Interet", 1, null, null, "2020-03-01 18:06:25.3518605", "101" },
                    { 1, "Completed", 1, "Call Plumber", "Plumbing", "No water", 1, "Fully restored.", "2020-05-30 18:06:25.3622374", "2020-03-01 18:06:25.3518605", "101" },
                    { 5, "CanceledByManagement", null, "Call Plumber", null, "No water", 3, null, null, "2020-03-01 18:06:25.3518605", "103" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[,]
                {
                    { 37, 100.11, 1, 0, 1, "2020-05-30 18:06:25.3616432" },
                    { 28, 100.11, 1, 4, 1, "2020-05-30 18:06:25.361635" },
                    { 29, 100.11, 1, 3, 1, "2020-05-30 18:06:25.3616359" },
                    { 30, 100.11, 1, 1, 1, "2020-05-30 18:06:25.3616368" },
                    { 31, 100.11, 1, 2, 1, "2020-05-30 18:06:25.3616377" },
                    { 32, 100.11, 1, 0, 1, "2020-05-30 18:06:25.3616386" },
                    { 33, 100.11, 1, 4, 1, "2020-05-30 18:06:25.3616396" },
                    { 34, 100.11, 1, 3, 1, "2020-05-30 18:06:25.3616405" },
                    { 35, 100.11, 1, 1, 1, "2020-05-30 18:06:25.3616414" },
                    { 36, 100.11, 1, 2, 1, "2020-05-30 18:06:25.3616423" },
                    { 38, 100.11, 1, 4, 1, "2020-05-30 18:06:25.3616442" },
                    { 46, 100.11, 1, 2, 1, "2020-05-30 18:06:25.3616662" },
                    { 40, 100.11, 1, 1, 1, "2020-05-30 18:06:25.361646" },
                    { 41, 100.11, 1, 2, 1, "2020-05-30 18:06:25.3616469" },
                    { 42, 100.11, 1, 0, 1, "2020-05-30 18:06:25.3616479" },
                    { 43, 100.11, 1, 4, 1, "2020-05-30 18:06:25.3616488" },
                    { 44, 100.11, 1, 3, 1, "2020-05-30 18:06:25.3616497" },
                    { 45, 100.11, 1, 1, 1, "2020-05-30 18:06:25.361665" },
                    { 27, 100.11, 1, 0, 1, "2020-05-30 18:06:25.3616341" },
                    { 47, 100.11, 1, 0, 1, "2020-05-30 18:06:25.3616671" },
                    { 48, 100.11, 1, 4, 1, "2020-05-30 18:06:25.361668" },
                    { 50, 100.11, 1, 1, 1, "2020-05-30 18:06:25.3616699" },
                    { 39, 100.11, 1, 3, 1, "2020-05-30 18:06:25.3616451" },
                    { 26, 100.11, 1, 2, 1, "2020-05-30 18:06:25.3616332" },
                    { 49, 100.11, 1, 3, 1, "2020-05-30 18:06:25.361669" },
                    { 24, 100.11, 1, 3, 1, "2020-05-30 18:06:25.3616313" },
                    { 1, 100.11, 1, 2, 1, "2020-05-30 18:06:25.3615499" },
                    { 25, 100.11, 1, 1, 1, "2020-05-30 18:06:25.3616322" },
                    { 2, 100.11, 1, 0, 1, "2020-05-30 18:06:25.3616084" },
                    { 3, 100.11, 1, 4, 1, "2020-05-30 18:06:25.3616119" },
                    { 4, 100.11, 1, 3, 1, "2020-05-30 18:06:25.361613" },
                    { 5, 100.11, 1, 1, 1, "2020-05-30 18:06:25.3616139" },
                    { 6, 100.11, 1, 2, 1, "2020-05-30 18:06:25.3616148" },
                    { 8, 100.11, 1, 4, 1, "2020-05-30 18:06:25.3616166" },
                    { 9, 100.11, 1, 3, 1, "2020-05-30 18:06:25.3616176" },
                    { 10, 100.11, 1, 1, 1, "2020-05-30 18:06:25.3616185" },
                    { 11, 100.11, 1, 2, 1, "2020-05-30 18:06:25.3616194" },
                    { 7, 100.11, 1, 0, 1, "2020-05-30 18:06:25.3616157" },
                    { 13, 100.11, 1, 4, 1, "2020-05-30 18:06:25.3616212" },
                    { 23, 100.11, 1, 4, 1, "2020-05-30 18:06:25.3616304" },
                    { 12, 100.11, 1, 0, 1, "2020-05-30 18:06:25.3616203" },
                    { 21, 100.11, 1, 2, 1, "2020-05-30 18:06:25.3616286" },
                    { 20, 100.11, 1, 1, 1, "2020-05-30 18:06:25.3616277" },
                    { 19, 100.11, 1, 3, 1, "2020-05-30 18:06:25.3616267" },
                    { 22, 100.11, 1, 0, 1, "2020-05-30 18:06:25.3616295" },
                    { 17, 100.11, 1, 0, 1, "2020-05-30 18:06:25.3616249" },
                    { 16, 100.11, 1, 2, 1, "2020-05-30 18:06:25.361624" },
                    { 15, 100.11, 1, 1, 1, "2020-05-30 18:06:25.3616231" },
                    { 14, 100.11, 1, 3, 1, "2020-05-30 18:06:25.3616221" },
                    { 18, 100.11, 1, 4, 1, "2020-05-30 18:06:25.3616258" }
                });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[,]
                {
                    { 1, "2020-05-30 18:06:25.3611618", "2020-03-01 18:06:25.3518605", 40.450000000000003, 2 },
                    { 2, "2020-05-30 18:06:25.3612618", "2020-03-01 18:06:25.3518605", 30.449999999999999, 0 },
                    { 3, "2020-05-30 18:06:25.3612714", "2020-03-01 18:06:25.3518605", 1100.0, 4 },
                    { 4, "2020-05-30 18:06:25.3612724", "2020-03-01 18:06:25.3518605", 20.550000000000001, 3 },
                    { 5, "2020-05-30 18:06:25.3612733", "2020-03-01 18:06:25.3518605", 15.75, 1 }
                });

            migrationBuilder.InsertData(
                table: "SignedAgreements",
                columns: new[] { "SignedAgreementId", "AgreementId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[,]
                {
                    { 7, 7, "2020-05-30 18:06:25.3609276", "2020-03-01 18:06:25.3518605", "2020-03-01 18:06:25.3518605", 7 },
                    { 10, 10, "2020-05-30 18:06:25.3609304", "2020-03-01 18:06:25.3518605", "2020-03-01 18:06:25.3518605", 10 },
                    { 9, 9, "2020-05-30 18:06:25.3609295", "2019-06-05 18:06:25.3518605", "2019-06-05 18:06:25.3518605", 9 },
                    { 8, 8, "2020-05-30 18:06:25.3609286", "2019-12-02 18:06:25.3518605", "2019-12-02 18:06:25.3518605", 8 },
                    { 6, 6, "2020-05-30 18:06:25.3609267", "2019-06-05 18:06:25.3518605", "2019-06-05 18:06:25.3518605", 6 },
                    { 2, 2, "2020-05-30 18:06:25.3609185", "2019-12-02 18:06:25.3518605", "2019-12-02 18:06:25.3518605", 2 },
                    { 4, 4, "2020-05-30 18:06:25.3609248", "2020-03-01 18:06:25.3518605", "2020-03-01 18:06:25.3518605", 4 },
                    { 3, 3, "2020-05-30 18:06:25.3609237", "2019-06-05 18:06:25.3518605", "2019-06-05 18:06:25.3518605", 3 },
                    { 1, 1, "2020-05-30 18:06:25.3608289", "2020-03-01 18:06:25.3518605", "2020-03-01 18:06:25.3518605", 1 },
                    { 5, 5, "2020-05-30 18:06:25.3609258", "2019-12-02 18:06:25.3518605", "2019-12-02 18:06:25.3518605", 5 }
                });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[,]
                {
                    { 17, 0, "2020-05-30 18:06:25.3604976", 4, 50.549999999999997 },
                    { 18, 4, "2020-05-30 18:06:25.3604985", 4, 1100.5 },
                    { 19, 3, "2020-05-30 18:06:25.3604994", 4, 15.56 },
                    { 20, 1, "2020-05-30 18:06:25.3605003", 4, 30.329999999999998 },
                    { 21, 2, "2020-05-30 18:06:25.3605012", 5, 150.0 },
                    { 22, 0, "2020-05-30 18:06:25.3605022", 5, 60.549999999999997 },
                    { 23, 4, "2020-05-30 18:06:25.3605031", 5, 1200.5 },
                    { 24, 3, "2020-05-30 18:06:25.360504", 5, 20.559999999999999 },
                    { 25, 1, "2020-05-30 18:06:25.3605049", 5, 40.329999999999998 },
                    { 26, 2, "2020-05-30 18:06:25.3605058", 6, 150.0 },
                    { 27, 0, "2020-05-30 18:06:25.3605067", 6, 60.549999999999997 },
                    { 29, 3, "2020-05-30 18:06:25.3605085", 6, 25.559999999999999 },
                    { 30, 1, "2020-05-30 18:06:25.3605094", 6, 31.329999999999998 },
                    { 31, 2, "2020-05-30 18:06:25.3605104", 7, 100.0 },
                    { 32, 0, "2020-05-30 18:06:25.3605113", 7, 50.549999999999997 },
                    { 33, 4, "2020-05-30 18:06:25.3605122", 7, 1100.5 },
                    { 38, 4, "2020-05-30 18:06:25.3605168", 8, 1100.5 },
                    { 34, 3, "2020-05-30 18:06:25.3605131", 7, 15.56 },
                    { 35, 1, "2020-05-30 18:06:25.360514", 7, 30.329999999999998 },
                    { 36, 2, "2020-05-30 18:06:25.3605149", 8, 100.0 },
                    { 37, 0, "2020-05-30 18:06:25.3605159", 8, 50.549999999999997 },
                    { 16, 2, "2020-05-30 18:06:25.3604967", 4, 100.0 },
                    { 28, 4, "2020-05-30 18:06:25.3605076", 6, 1200.5 },
                    { 15, 1, "2020-05-30 18:06:25.3604958", 3, 30.329999999999998 },
                    { 46, 2, "2020-05-30 18:06:25.360524", 10, 100.0 },
                    { 13, 4, "2020-05-30 18:06:25.3604939", 3, 1100.5 },
                    { 39, 3, "2020-05-30 18:06:25.3605177", 8, 15.56 },
                    { 50, 1, "2020-05-30 18:06:25.3605276", 10, 30.329999999999998 },
                    { 49, 3, "2020-05-30 18:06:25.3605267", 10, 15.56 },
                    { 48, 4, "2020-05-30 18:06:25.3605258", 10, 1100.5 },
                    { 47, 0, "2020-05-30 18:06:25.3605249", 10, 50.549999999999997 },
                    { 45, 1, "2020-05-30 18:06:25.3605231", 9, 30.329999999999998 },
                    { 44, 3, "2020-05-30 18:06:25.3605222", 9, 15.56 },
                    { 43, 4, "2020-05-30 18:06:25.3605213", 9, 1100.5 },
                    { 42, 0, "2020-05-30 18:06:25.3605204", 9, 50.549999999999997 },
                    { 41, 2, "2020-05-30 18:06:25.3605195", 9, 100.0 },
                    { 14, 3, "2020-05-30 18:06:25.3604948", 3, 15.56 },
                    { 1, 2, "2020-05-30 18:06:25.3603893", 1, 100.0 },
                    { 3, 4, "2020-05-30 18:06:25.3604845", 1, 1100.5 },
                    { 4, 3, "2020-05-30 18:06:25.3604857", 1, 15.56 },
                    { 5, 1, "2020-05-30 18:06:25.3604866", 1, 30.329999999999998 },
                    { 6, 2, "2020-05-30 18:06:25.3604875", 2, 100.0 },
                    { 7, 0, "2020-05-30 18:06:25.3604885", 2, 50.549999999999997 },
                    { 8, 4, "2020-05-30 18:06:25.3604894", 2, 1100.5 },
                    { 9, 3, "2020-05-30 18:06:25.3604903", 2, 15.56 },
                    { 10, 1, "2020-05-30 18:06:25.3604912", 2, 30.329999999999998 },
                    { 11, 2, "2020-05-30 18:06:25.3604921", 3, 100.0 },
                    { 12, 0, "2020-05-30 18:06:25.360493", 3, 50.549999999999997 },
                    { 2, 0, "2020-05-30 18:06:25.3604692", 1, 50.549999999999997 },
                    { 40, 1, "2020-05-30 18:06:25.3605186", 8, 30.329999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "jayson@gmail.com", "Jayson", "Lennon", "555-1604-317", 4 },
                    { 9, "linda@gmail.com", "Linda", "Lopez", "555-6027-558", 12 },
                    { 8, "frances@gmail.com", "Frances ", "Hook", "555-9871-503", 11 },
                    { 7, "ruth@gmail.com", "Ruth ", "Williams", "555-3037-777", 10 },
                    { 6, "deon@gmail.com", "Deon ", "Smith", "555-5140-298", 9 },
                    { 5, "melvin@gmail.com", "Melvin", "Johnson", "555-2858-445", 8 },
                    { 4, "sulav@gmail.com", "Sulav", "Aryal", "555-7873-595", 7 },
                    { 3, "michael@gmail.com", "Michael", "Walker", "555-3115-412", 6 },
                    { 2, "david@gmail.com", "David", "Sawyer", "555-1958-162", 5 },
                    { 10, "regina@gmail.com", "Regina", "McCoy", "555-5304-625", 13 }
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
                    { 11, "test-key", "linda", "password", "Tenant" },
                    { 10, "test-key", "frances", "password", "Tenant" },
                    { 9, "test-key", "ruth", "password", "Tenant" },
                    { 8, "test-key", "deon", "password", "Tenant" },
                    { 7, "test-key", "melvin", "password", "Tenant" },
                    { 4, "test-key", "david", "password", "Tenant" },
                    { 5, "test-key", "michael", "password", "Tenant" },
                    { 3, "test-key", "jayson", "password", "Tenant" },
                    { 2, "test-key", "manager", "password", "Manager" },
                    { 1, "test-key", "admin", "password", "Admin" },
                    { 12, "test-key", "regina", "password", "Tenant" },
                    { 6, "test-key", "sulav", "password", "Tenant" },
                    { 13, "test-key", "sulav", "password", "Tenant" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "AgreementId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "AgreementId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "AgreementId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BillingPeriods",
                keyColumn: "BillingPeriodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BillingPeriods",
                keyColumn: "BillingPeriodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BillingPeriods",
                keyColumn: "BillingPeriodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BillingPeriods",
                keyColumn: "BillingPeriodId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "MaintenanceRequestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "MaintenanceRequestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "MaintenanceRequestId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "MaintenanceRequestId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "MaintenanceRequestId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "MaintenanceRequestId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "MaintenanceRequestId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "MaintenanceRequestId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "MaintenanceRequestId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MaintenanceRequests",
                keyColumn: "MaintenanceRequestId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ResourceUsageRates",
                keyColumn: "ResourceUsageRateId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ResourceUsageRates",
                keyColumn: "ResourceUsageRateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ResourceUsageRates",
                keyColumn: "ResourceUsageRateId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ResourceUsageRates",
                keyColumn: "ResourceUsageRateId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ResourceUsageRates",
                keyColumn: "ResourceUsageRateId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SignedAgreements",
                keyColumn: "SignedAgreementId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SignedAgreements",
                keyColumn: "SignedAgreementId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SignedAgreements",
                keyColumn: "SignedAgreementId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SignedAgreements",
                keyColumn: "SignedAgreementId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SignedAgreements",
                keyColumn: "SignedAgreementId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SignedAgreements",
                keyColumn: "SignedAgreementId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SignedAgreements",
                keyColumn: "SignedAgreementId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SignedAgreements",
                keyColumn: "SignedAgreementId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SignedAgreements",
                keyColumn: "SignedAgreementId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SignedAgreements",
                keyColumn: "SignedAgreementId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TenantResourceUsages",
                keyColumn: "TenantResourceUsageId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "TenantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "TenantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "TenantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "TenantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "TenantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "TenantId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "TenantId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "TenantId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "TenantId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "TenantId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13);
        }
    }
}
