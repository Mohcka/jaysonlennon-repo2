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
                values: new object[] { 1, @"
1. PROPERTY: TENANT agrees to rent from LANDLORD and LANDLORD agrees to rent to TENANT, City of Loose Coupling, State of Texas (the PREMISES).

2. USE OF THE PREMISES: The TENANT may use the PREMISES only as a single-family residence.

3. UTILITIES: The TENANT will pay for the following utilities: Water and Sewer, Electricity, Garbage Removal, Gas, Oil.

4. EVICTION: If the TENANT does not pay the rent within 30 days of the date when it is due, the TENANT may be evicted. The LANDLORD may also evict the TENANT if the TENANT does not comply with all of the terms of this Lease, or for any other causes allowed by law. If evicted, the TENANT must continue to pay the rent for the rest of the term. The TENANT must also pay all costs, including reasonable attorney fees, related to the eviction and the collection of any monies owed to the LANDLORD, along with the cost of re-entering, re-renting, cleaning and repairing the PREMISES. Rent received from any new tenant during the remaining term of this lease will be applied by the LANDLORD to reduce rent only, which may be owed by the TENANT. 

5. PAYMENTS BY LANDLORD: If the TENANT fails to comply with the terms of this Lease, the LANDLORD may take any required action and charge the cost, including reasonable attorney fees, to the TENANT. Failure to pay such costs upon demand is a violation of this Lease.

6. CARE OF THE PREMISES: The TENANT has examined the PREMISES, including (where applicable) the living quarters, all facilities, furniture and appliances, and is satisfied with its present physical condition. The TENANT agrees to maintain the PREMISES in as good condition as it is at the start of this Lease except for ordinary wear and tear. The TENANT must pay for all repairs, replacements, and damages, whether or not caused by the act or neglect of the TENANT. The TENANT will remove all of the TENANT's property at the end of this Lease. Any property that is left becomes the property of the LANDLORD and may be thrown out. All of TENANT'S garbage will be disposed of properly by TENANT in the appropriate receptacles for garbage collection. Accumulations of garbage in and around the PREMISES or depositing by TENANT or those residing with TENANT of garbage in areas not designated and designed as garbage receptacles shall constitute a violation of this lease. TENANT shall generally maintain the PREMISES in a neat and orderly condition. Damage or destruction by TENANT, TENANT's employees or TENANT's visitors of the PREMISES shall constitute a violation of this Lease.

7. DESTRUCTION OF PREMISES: If the PREMISES are destroyed through no fault of the TENANT, the TENANT's employees or TENANT's visitors, then the Lease will end, and the TENANT will pay rent up to the date of destruction.

8. INTERRUPTION OF SERVICES: The LANDLORD is not responsible for any inconvenience or interruption of services due to repairs, improvements or for any reason beyond the LANDLORD’s control.

9. ALTERATIONS: The TENANT must get the LANDLORD's prior written consent to alter, improve, paint or wallpaper the PREMISES. Alterations, additions, and improvements become the LANDLORD's property.

10. COMPLIANCE WITH LAWS: The TENANT must comply with laws, orders, rules, and requirements of governmental authorities and insurance companies which have issued or are about to issue policies covering the PREMISES and/or its contents.

11. NO WAIVER BY LANDLORD: The LANDLORD does not give up or waive any rights by accepting rent or by failing to enforce any terms of this Lease.

12. NO ASSIGNMENT OR SUBLEASE: The TENANT may not sublease the PREMISES or assign this Lease without the LANDLORD's prior written consent.

13. ENTRY BY LANDLORD: Upon reasonable notice, the LANDLORD may enter the PREMISES to provide services, inspect, repair, improve or show it. The TENANT must notify the LANDLORD if the TENANT is away for 14 days or more. In case of an emergency or the TENANT's absence, the LANDLORD may enter the PREMISES without the TENANT's consent. 

14. QUIET ENJOYMENT: The TENANT may live in and use the PREMISES without interference subject to the terms of this Lease.

15. SUBORDINATION: This Lease and the TENANT's rights are subject and subordinate to present and future mortgages on the property which include the PREMISES. The LANDLORD may execute any papers on the TENANT's behalf as the TENANT's attorney in fact to accomplish this.

16. HAZARDOUS USE: The TENANT will not keep anything in the PREMISES which is dangerous, flammable, explosive or which might increase the danger of fire or any other hazard, or which would increase LANDLORD's fire or hazard insurance.

17. INJURY OR DAMAGE: The TENANT will be responsible for any injury or damage caused by the act or neglect of the TENANT, the TENANT's employees or TENANT's visitors. The LANDLORD is not responsible for any injury or damage unless due to the negligence or improper conduct of the LANDLORD.

18. RENEWALS AND CHANGES IN LEASE: Upon expiration of the rental term provided for above, this lease shall automatically renew itself, indefinitely, for successive one-month periods, unless modified by the parties. The LANDLORD may modify this lease or offer the TENANT a new lease by forwarding to the TENANT a copy of the proposed changes or a copy of the new lease. If changes in this lease or a new lease are offered, the TENANT must notify the LANDLORD of the TENANT's decision to stay within thirty (30) days of the date the proposed changes or the copy of the new lease is received by the TENANT. If the TENANT fails to accept the lease changes or the new lease within thirty (30) days of the date the proposed changes or new lease is offered, the TENANT may be evicted by the LANDLORD, as provided for in State law. Nevertheless, if the rent is increased by the lease changes or new lease, the TENANT will be obligated to pay the new rent, regardless of whether the TENANT has affirmatively accepted the lease changes or new lease, if the TENANT continues to occupy the property on the date the new rent becomes effective.

19. PETS: No dogs, cats, or other animals are allowed on the PREMISES without the LANDLORD's prior written consent.

20. NOTICES: All notices provided by this Lease must be written and delivered personally or by certified mail, return receipt requested, to the parties at their addresses listed above, or to such other address as the parties may from time to time designate. Notices to the LANDLORD must also be sent to the LANDLORD's agent listed above (if any).

21. SIGNS: The TENANT may not put any sign or projection (such as a T.V. or radio antenna) in or out of the windows or exteriors of the PREMISES without the LANDLORD's prior written consent.

22. HOLDOVER RENT: Should this Lease be terminated, either through a valid notice of dispossession by the LANDLORD, or through order of a court, and should TENANT remain on the PREMISES thereafter, then TENANT shall be liable to pay rent at a rate of double the base rent provided for under this lease, from the date of termination until such time as TENANT vacates the PREMISES, whether TENANT vacates the PREMISES voluntarily or through enforcement of an order for eviction.

23. VALIDITY OF LEASE: If a clause or provision of this Lease is legally invalid, the rest of this Lease remains in effect. If a clause or provision of this lease is ambiguous, and it may be interpreted in a manner either consistent or inconsistent with existing law, it shall be interpreted in a manner consistent with existing law.

24. PARTIES: The LANDLORD and each of the TENANTS are bound by this Lease. All parties who lawfully succeed to their rights and responsibilities are also bound.

25. GENDER: The use of any particular gender (masculine, feminine or neuter) and case (singular or plural) in this Lease is for convenience, only. No inference is to be drawn therefrom. The correct gender and case is to be freely substituted throughout, as appropriate.

26. TENANT'S ACKNOWLEDGMENT: The TENANT acknowledges having read all of the terms and conditions of this lease and the attached rules and regulations. TENANT acknowledges that no oral representations have been made to him by the LANDLORD or the LANDLORD's agent(s) other than the representations contained in this Lease. The TENANT acknowledges that he/she is relying only upon the promises and representations contained in this Lease.

27. ENTIRE LEASE: All promises the LANDLORD has made are contained in this written Lease. This Lease can only be changed by an agreement in writing by both the TENANT and the LANDLORD.

28. SIGNATURES: The LANDLORD and the TENANT agree to the terms of this Lease. If this Lease is made by a corporation, its proper corporate officers sign and its corporate seal is affixed.
                ", "Lease Agreement" });

            migrationBuilder.InsertData(
                table: "AgreementTemplates",
                columns: new[] { "AgreementTemplateId", "Text", "Title" },
                values: new object[] { 3, @"
Internet Service Agreement

Terms of use.

Term

The Agreement will run from START DATE until the services in this Agreement have been provided in full unless premature termination is allowed by this Agreement.

The length of the Agreement may be changed provided that both Sender.Company and Signer.Company give prior notice via written consent.

Payment, Pricing, and Tax

Sender.Company will pay PAYMENT to Signer.Company for the services detailed in this Agreement.

Signer.Company will provide an invoice when the services have been provided.

Payment of invoices must be made within the payment period of Sender.Company receiving the invoice.

Signer.Company is liable for any tax or similar charges associated with the payment.

Late payments will be subject to a daily interest charge of LATE PENALTY PERCENTAGE % of the amount still owed.

In the case of a termination of this Agreement when the agreed services have been partially completed, Sender.Company will be liable to pay Signer.Company for services provided up to the point of Agreement termination unless there has been a breach of the Agreement by Signer.Company.

Any money referred to in this Agreement is in CURRENCY unless specified otherwise.
Content Responsibility/Usage Restrictions

Any intellectual property which is produced under this Agreement is exclusively the property of Sender.Company and its use will be unrestricted and at their sole discretion.

Signer.Company may only use the intellectual property with explicit permission from Sender.Company.

Signer.Company will be liable for any damages arising from the unpermitted use of the intellectual property.

Licensing

If Sender.Company buys any equipment as part of the Service, Signer.Company grants Sender.Company a limited license to use software provided with the equipment subject to the following terms:

    The software is licensed and copyrighted for sole use on the equipment provided to Sender.Company.
    Software provided hereunder is on license by Signer.Company from third parties. The copyright and title to Software stay with the licensor.
    Sender.Company cannot reverse compile or translate in any way the Software.
    Sender.Company can make any number of copies but only for backup purposes.
    All indemnification provisions and liability from this agreement will apply to the licensor.

Indemnification

Each party agrees to indemnify the other party and its respective permitted successors, assigns, officers, affiliates, agents and employees against attorney’s fees and any claims and costs resulting from any actions or omissions of the indemnifying party or its permitted successors, assigns, officers, affiliates, agents and employees in relation to this Agreement, unless paid as part of a relevant insurance policy or required by applicable law.

Termination

    If any of the following events occur in respect to one party, the other party may terminate the agreement at their sole discretion with prior written notice:
        One party voluntarily petitions or is involuntarily petitioned for bankruptcy; becomes insolvent, proposes liquidation, recapitalization, dissolution or reorganization; a receiver is assigned to take property, and this is not dismissed within DISMISSAL PERIOD days.
        A material breach of this agreement is not resolved within RESOLUTION PERIOD after the details of the breach have been given with written notice.
    Sender.Company may terminate the agreement after NOTICE PERIOD if Signer.Company makes any material alterations to the Service that Sender.Company chooses to decline.
    In case of termination, Sender.Company agrees to discontinue using the Service and return any property provided by Signer.Company.

Export Compliance

Transferring of technologies across national boundaries are regulated by United States law. Sender.Company agrees not to export any technologies transmitted via Signer.Company prior to obtaining any relevant export licenses or official government approval.

Force Majeure

Force Majeure refers to any act beyond the reasonable control of either party, including but not limited to acts of God, fires, and war.

In the case of events of Force Majeure interfering with the completion of this Agreement, neither party shall be held responsible by the other.

If either party’s agreed obligations are restricted by Force Majeure, the affected party must take reasonable action to fulfill their obligations. The other party must continue to fulfill their own agreed obligations.

Notice and Payment

Any notices or other forms of communication between Signer.Company and Sender.Company must be delivered via written notice to the following addresses:

Laws

This Agreement is governable in relation to the laws of LAW.

Successors

This agreement will be binding for and will inure to the benefit of the Parties hereto, their administrators, successors, assigns and heirs.

Assignability

The obligations of Signer.Company shall not be transferred in any way or for any reason to another party, unless Sender.Company has given prior notice via approval in writing.

Waiver

Any waiver of any default by either Party shall not be accepted as a waiver of any subsequent or prior default of other or the same provisions of this agreement.

Severability

If any elements of this Agreement become invalid or unenforceable, all other elements of the Agreement will remain valid and enforceable.

Integration

This Agreement represents the entire agreement between Sender.Company and Signer.Company, relevant to the content of the Agreement.
                ", "Internet Connection Agreement" });

            migrationBuilder.InsertData(
                table: "AgreementTemplates",
                columns: new[] { "AgreementTemplateId", "Text", "Title" },
                values: new object[] { 2, @"
Terms and Conditions

    All electrical installation work will be performed in compliance with Federal, State, and Local guidelines and regulations.
    If Sender.Company discovers a need for additional time or materials once the work has commenced, Sender.Company will seek written approval prior to continuing work.
    Customer is responsible for providing unmitigated access to the work area. This includes moving any furnishings, wall-hangings, or other items which could prevent Sender.Company from carrying out the listed services.
    All areas of installation will be left in the condition found unless otherwise stated in writing by Sender.Name.
    Client.FirstName Client.LastName will provide accessible electricity to all working areas including outdoor areas. This includes proving a live power outlet or generator within 150 feet of the working area.
    Sitework, including demolition or removal of debris, is not included in this electric services contract.

Deviations from Building Regulations

Where applicable, all work performed under this electrical services agreement will be executed fully in compliance with applicable Building Regulations and the National Electric Code. Where a Client requires deviation from such regulations, a written instruction and record will be required along with written approval from a governing authority.
Risk and Title of Goods & Property

    All applicable goods and products installed will become property of the client on date of installation.
    All goods not paid in full or remaining with customer will be property of the service provider until payment has been made or delivery has ensued.
    Client is responsible for all insurance of dwellings and service location for entire time of work.

Warranty

Sender.Company has, to the best of their knowledge has provided installation and quality parts for overall best quality of product. Furthermore all parts will be warrantied for a 12 month period after installation for any technical defects.

Acceptance

By signing below, Customer understands and accepts all terms and conditions outlined in this electrical services agreement.
                ", "Utility Agreement" });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 13, 3, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9218), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 11 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 12, 2, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9215), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 11 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 11, 1, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9212), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 11 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 10, 1, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9209), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 10 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 9, 3, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9206), new DateTime(2019, 6, 10, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2019, 6, 10, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 9 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 1, 1, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(8070), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 1 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 7, 1, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9199), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 7 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 6, 3, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9196), new DateTime(2019, 6, 10, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2019, 6, 10, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 6 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 5, 2, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9193), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 5 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 4, 1, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9190), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 4 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 3, 3, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9186), new DateTime(2019, 6, 10, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2019, 6, 10, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 3 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 2, 2, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9156), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 2 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[] { 8, 2, new DateTime(2020, 7, 4, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(9202), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 8 });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 5, new DateTime(2020, 6, 19, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(6102), new DateTime(2020, 5, 20, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(6099) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 4, new DateTime(2020, 5, 20, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(6097), new DateTime(2020, 5, 5, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(6094) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 2, new DateTime(2020, 4, 5, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(6079), new DateTime(2020, 3, 6, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(6061) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 1, new DateTime(2020, 3, 6, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(5576), new DateTime(2020, 2, 5, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(5091) });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[] { 3, new DateTime(2020, 5, 5, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(6092), new DateTime(2020, 4, 5, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(6089) });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 10, null, null, "Send maintenance", null, "Dead lightbulb", 8, null, null, new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), "108" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 14, null, null, "Call plumber", null, "Clogged toilet", 13, null, null, new DateTime(2020, 6, 1, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(3439), "111" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 13, null, null, "Send maintenance", null, "Leaky faucet", 13, null, null, new DateTime(2020, 5, 28, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(3436), "111" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 12, null, null, "Call electric company", null, "Power out", 2, null, null, new DateTime(2020, 5, 25, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(3433), "111" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 11, "CanceledByTenant", 1, "Call plumber", null, "Low water pressure", 13, "Fixed", new DateTime(2020, 5, 22, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(3430), new DateTime(2020, 5, 21, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(3417), "111" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 8, null, null, "Call Plumber", null, "No hot water", 6, null, null, new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), "106" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 9, null, null, "Send maintenance", null, "Oven not working", 7, null, null, new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), "107" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 6, null, null, "Call electric company", null, "Power out", 4, null, null, new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), "104" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 7, null, null, "Call plumber", null, "Low water pressure", 5, null, null, new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), "105" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 5, "CanceledByManagement", 2, "Call plumber", null, "No water", 3, "Fixed", new DateTime(2020, 5, 5, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), "103" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 4, "CanceledByTenant", 1, "Call plumber", null, "Low water pressure", 2, "Fixed", new DateTime(2020, 5, 5, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), "102" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 3, "CanceledByManagement", 1, "Call plumber", null, "Dirty water", 1, "Fixed", new DateTime(2020, 5, 5, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 2, "Completed", 1, "Call ISP", null, "No Interet", 1, "Fixed", new DateTime(2020, 5, 5, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), "101" });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[] { 1, "Completed", 1, "Call Plumber", "Plumbing", "No water", 1, "Fully restored.", new DateTime(2020, 6, 4, 16, 8, 49, 48, DateTimeKind.Local).AddTicks(2350), new DateTime(2020, 3, 6, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), "101" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 36, 100.11, 1, 2, 8, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7233) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 35, 100.11, 1, 1, 7, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7231) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 34, 100.11, 1, 3, 7, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7228) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 33, 100.11, 1, 4, 7, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7226) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 30, 100.11, 1, 1, 6, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7218) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 31, 100.11, 1, 2, 7, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7221) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 37, 100.11, 1, 0, 8, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7236) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 29, 100.11, 1, 3, 6, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7216) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 28, 100.11, 1, 4, 6, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7213) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 32, 100.11, 1, 0, 7, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7223) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 38, 100.11, 1, 4, 8, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7238) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 41, 100.11, 1, 2, 9, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7247) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 40, 100.11, 1, 1, 8, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7243) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 42, 100.11, 1, 0, 9, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7249) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 43, 100.11, 1, 4, 9, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7251) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 44, 100.11, 1, 3, 9, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7254) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 45, 100.11, 1, 1, 9, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7257) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 47, 100.11, 1, 0, 10, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7262) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 48, 100.11, 1, 4, 10, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7265) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 49, 100.11, 1, 3, 10, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7267) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 50, 100.11, 1, 1, 10, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7270) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 27, 100.11, 1, 0, 6, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7210) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 39, 100.11, 1, 3, 8, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7241) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 26, 100.11, 1, 2, 6, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7208) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 46, 100.11, 1, 2, 10, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7259) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 24, 100.11, 1, 3, 5, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7203) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 25, 100.11, 1, 1, 5, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7205) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 1, 100.11, 1, 2, 1, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(6418) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 2, 100.11, 1, 0, 1, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7126) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 4, 100.11, 1, 3, 1, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7149) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 5, 100.11, 1, 1, 1, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7152) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 6, 100.11, 1, 2, 2, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7156) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 7, 100.11, 1, 0, 2, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7158) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 8, 100.11, 1, 4, 2, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7161) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 9, 100.11, 1, 3, 2, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7164) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 10, 100.11, 1, 1, 2, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7167) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 11, 100.11, 1, 2, 3, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7169) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 3, 100.11, 1, 4, 1, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7146) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 13, 100.11, 1, 4, 3, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7174) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 14, 100.11, 1, 3, 3, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7177) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 15, 100.11, 1, 1, 3, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7179) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 16, 100.11, 1, 2, 4, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7182) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 17, 100.11, 1, 0, 4, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7185) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 18, 100.11, 1, 4, 4, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7187) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 19, 100.11, 1, 3, 4, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7190) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 23, 100.11, 1, 4, 5, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7200) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 20, 100.11, 1, 1, 4, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7192) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 12, 100.11, 1, 0, 3, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7172) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 21, 100.11, 1, 2, 5, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7194) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[] { 22, 100.11, 1, 0, 5, new DateTime(2020, 6, 3, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(7197) });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 4, new DateTime(2020, 12, 1, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(2923), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 30.0, 3 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 3, new DateTime(2020, 12, 1, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(2920), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 1100.0, 4 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 5, new DateTime(2020, 12, 1, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(2926), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 0.10000000000000001, 1 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 1, new DateTime(2020, 12, 1, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(1932), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 50.0, 2 });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[] { 2, new DateTime(2020, 12, 1, 16, 8, 49, 47, DateTimeKind.Local).AddTicks(2889), new DateTime(2019, 12, 7, 16, 8, 49, 39, DateTimeKind.Local).AddTicks(831), 0.13, 0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 188, 1, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4396), 7, 41.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 187, 1, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4394), 7, 35.740000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 175, 0, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4362), 7, 29.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 186, 1, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4391), 7, 36.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 185, 1, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4389), 7, 25.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 184, 1, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4386), 7, 31.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 183, 1, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4384), 7, 36.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 182, 1, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4381), 7, 35.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 180, 0, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4376), 7, 30.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 179, 0, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4373), 7, 35.729999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 178, 0, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4371), 7, 26.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 177, 0, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4368), 7, 26.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 176, 0, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4365), 7, 33.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 189, 1, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4400), 7, 34.409999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 181, 1, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4378), 7, 34.409999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 190, 1, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4402), 7, 31.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 204, 1, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4439), 8, 18.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 192, 0, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4407), 8, 13.85 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 207, 1, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4448), 8, 31.739999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 206, 1, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4445), 8, 15.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 205, 1, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4442), 8, 8.1699999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 174, 0, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4360), 7, 29.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 203, 1, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4436), 8, 10.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 202, 1, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4434), 8, 13.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 201, 1, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4431), 8, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 200, 0, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4428), 8, 3.21 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 199, 0, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4426), 8, 11.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 198, 0, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4423), 8, 11.529999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 197, 0, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4420), 8, 28.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 196, 0, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4418), 8, 12.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 195, 0, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4415), 8, 12.779999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 194, 0, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4412), 8, 11.67 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 193, 0, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4410), 8, 9.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 191, 0, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4405), 8, 12.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 173, 0, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4357), 7, 34.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 158, 0, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4317), 6, 20.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 171, 0, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4352), 7, 30.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 150, 1, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4296), 5, 11.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 149, 1, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4293), 5, 16.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 148, 1, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4291), 5, 11.6 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 147, 1, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4288), 5, 11.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 146, 1, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4285), 5, 6.9299999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 145, 1, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4283), 5, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 151, 0, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4298), 6, 20.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 144, 1, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4280), 5, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 142, 1, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4275), 5, 11.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 141, 1, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4272), 5, 11.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 140, 0, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4270), 5, 10.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 139, 0, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4267), 5, 4.7300000000000004 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 138, 0, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4265), 5, 10.529999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 208, 1, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4451), 8, 16.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 143, 1, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4277), 5, 21.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 152, 0, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4301), 6, 13.85 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 153, 0, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4304), 6, 25.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 154, 0, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4307), 6, 20.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 170, 1, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4348), 6, 15.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 169, 1, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4346), 6, 13.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 168, 1, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4343), 6, 12.6 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 167, 1, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4341), 6, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 166, 1, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4338), 6, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 165, 1, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4335), 6, 16.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 164, 1, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4333), 6, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 163, 1, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4330), 6, 16.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 162, 1, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4328), 6, 19.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 161, 1, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4325), 6, 10.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 160, 0, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4322), 6, 20.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 159, 0, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4320), 6, 15.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 157, 0, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4315), 6, 21.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 156, 0, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4312), 6, 25.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 155, 0, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4310), 6, 20.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 172, 0, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4355), 7, 38.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 209, 1, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4454), 8, 18.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 254, 0, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4621), 11, 25.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 211, 0, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4459), 9, 38.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 262, 0, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4643), 11, 14.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 261, 0, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4641), 11, 15.529999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 260, 0, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4638), 11, 33.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 259, 0, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4634), 11, 25.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 258, 0, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4632), 11, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 257, 0, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4629), 11, 30.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 263, 0, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4646), 11, 25.289999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 256, 0, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4626), 11, 15.33 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 137, 0, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4262), 5, 11.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 253, 3, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4618), 11, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 252, 4, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4616), 11, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 251, 2, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4613), 11, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 250, 1, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4610), 10, 20.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 249, 1, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4608), 10, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 255, 0, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4624), 11, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 264, 0, new DateTime(2020, 5, 23, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4649), 11, 19.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 265, 0, new DateTime(2020, 5, 22, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4651), 11, 16.239999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 266, 0, new DateTime(2020, 5, 21, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4654), 11, 19.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 281, 1, new DateTime(2020, 5, 20, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4693), 11, 18.390000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 280, 1, new DateTime(2020, 5, 21, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4690), 11, 13.109999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 279, 1, new DateTime(2020, 5, 22, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4688), 11, 23.66 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 278, 1, new DateTime(2020, 5, 23, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4685), 11, 21.399999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 277, 1, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4683), 11, 15.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 276, 1, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4680), 11, 12.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 275, 1, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4678), 11, 19.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 274, 1, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4675), 11, 10.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 273, 1, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4672), 11, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 272, 1, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4670), 11, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 271, 1, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4667), 11, 13.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 270, 1, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4664), 11, 6.4299999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 269, 1, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4662), 11, 8.4000000000000004 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 268, 1, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4659), 11, 12.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 267, 0, new DateTime(2020, 5, 20, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4656), 11, 30.149999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 248, 1, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4605), 10, 20.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 210, 1, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4456), 8, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 247, 1, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4603), 10, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 245, 1, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4598), 10, 23.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 225, 1, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4496), 9, 20.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 224, 1, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4494), 9, 21.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 223, 1, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4490), 9, 26.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 222, 1, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4487), 9, 29.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 221, 1, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4485), 9, 20.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 220, 0, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4482), 9, 30.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 226, 1, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4499), 9, 13.960000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 219, 0, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4480), 9, 15.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 217, 0, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4474), 9, 12.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 216, 0, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4472), 9, 18.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 215, 0, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4469), 9, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 214, 0, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4467), 9, 10.67 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 213, 0, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4464), 9, 25.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 212, 0, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4461), 9, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 218, 0, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4477), 9, 20.52 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 227, 1, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4501), 9, 12.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 228, 1, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4504), 9, 13.6 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 229, 1, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4506), 9, 4.4100000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 244, 1, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4595), 10, 21.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 243, 1, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4592), 10, 26.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 242, 1, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4590), 10, 25.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 241, 1, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4586), 10, 20.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 240, 0, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4584), 10, 17.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 239, 0, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4581), 10, 10.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 238, 0, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4578), 10, 11.529999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 237, 0, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4576), 10, 17.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 236, 0, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4573), 10, 10.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 235, 0, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4571), 10, 30.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 234, 0, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4568), 10, 30.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 233, 0, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4565), 10, 35.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 232, 0, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4514), 10, 32.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 231, 0, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4512), 10, 30.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 230, 1, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4509), 9, 6.3200000000000003 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 246, 1, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4600), 10, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 136, 0, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4259), 5, 18.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 107, 1, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4179), 3, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 134, 0, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4253), 5, 17.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 35, 1, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3934), 7, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 36, 2, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3937), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 37, 0, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3939), 8, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 38, 4, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3942), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 39, 3, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3945), 8, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 40, 1, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3947), 8, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 41, 2, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3950), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 42, 0, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3952), 9, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 43, 4, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3955), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 44, 3, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3958), 9, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 135, 0, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4256), 5, 10.779999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 46, 2, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3963), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 47, 0, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3966), 10, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 48, 4, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3969), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 34, 3, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3931), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 49, 3, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3971), 10, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 51, 0, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3977), 1, 30.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 52, 0, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3979), 1, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 53, 0, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3982), 1, 5.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 54, 0, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3984), 1, 50.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 55, 0, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3987), 1, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 56, 0, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3989), 1, 30.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 57, 0, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3992), 1, 31.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 58, 0, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3995), 1, 20.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 59, 0, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3997), 1, 10.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 60, 0, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4000), 1, 30.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 61, 1, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4003), 1, 10.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 62, 1, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4059), 1, 15.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 63, 1, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4062), 1, 6.4299999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 64, 1, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4065), 1, 21.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 50, 1, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3974), 10, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 65, 1, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4068), 1, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 33, 4, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3929), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 31, 2, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3924), 7, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 1, 2, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3178), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 2, 0, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3820), 1, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 3, 4, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3844), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 4, 3, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3848), 1, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 5, 1, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3851), 1, 40.399999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 6, 2, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3853), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 7, 0, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3856), 2, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 8, 4, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3859), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 9, 3, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3862), 2, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 10, 1, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3864), 2, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 11, 2, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3868), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 12, 0, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3871), 3, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 13, 4, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3874), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 14, 3, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3877), 3, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 32, 0, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3926), 7, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 15, 1, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3880), 3, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 17, 0, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3885), 4, 50.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 18, 4, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3888), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 19, 3, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3891), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 20, 1, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3893), 4, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 21, 2, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3896), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 22, 0, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3899), 5, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 23, 4, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3901), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 24, 3, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3904), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 25, 1, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3907), 5, 40.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 26, 2, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3909), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 27, 0, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3912), 6, 60.549999999999997 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 28, 4, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3915), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 29, 3, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3918), 6, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 30, 1, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3921), 6, 31.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 16, 2, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3882), 4, 1.0 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 66, 1, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4070), 1, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 45, 1, new DateTime(2020, 6, 3, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(3960), 9, 30.329999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 68, 1, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4076), 1, 16.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 103, 1, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4169), 3, 19.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 104, 1, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4171), 3, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 105, 1, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4174), 3, 50.170000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 106, 1, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4177), 3, 19.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 108, 1, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4182), 3, 25.629999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 109, 1, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4184), 3, 27.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 110, 1, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4187), 3, 13.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 111, 0, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4190), 4, 3.46 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 112, 0, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4192), 4, 29.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 113, 0, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4195), 4, 16.34 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 114, 0, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4197), 4, 11.67 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 115, 0, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4200), 4, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 116, 0, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4202), 4, 20.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 117, 0, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4205), 4, 15.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 102, 1, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4166), 3, 22.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 118, 0, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4209), 4, 10.529999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 120, 0, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4215), 4, 11.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 121, 1, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4219), 4, 13.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 122, 1, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4222), 4, 30.420000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 67, 1, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4073), 1, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 124, 1, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4228), 4, 11.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 125, 1, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4230), 4, 13.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 126, 1, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4233), 4, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 127, 1, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4235), 4, 15.74 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 128, 1, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4238), 4, 21.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 129, 1, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4240), 4, 11.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 130, 1, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4243), 4, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 131, 0, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4246), 5, 10.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 132, 0, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4248), 5, 19.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 133, 0, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4251), 5, 15.33 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 119, 0, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4212), 4, 12.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 101, 1, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4163), 3, 21.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 123, 1, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4225), 4, 16.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 99, 0, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4157), 3, 10.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 69, 1, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4078), 1, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 70, 1, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4081), 1, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 71, 0, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4083), 2, 21.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 72, 0, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4086), 2, 25.850000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 73, 0, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4089), 2, 15.33 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 74, 0, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4091), 2, 50.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 75, 0, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4094), 2, 40.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 76, 0, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4097), 2, 29.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 77, 0, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4099), 2, 30.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 78, 0, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4102), 2, 20.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 79, 0, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4104), 2, 15.73 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 80, 0, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4107), 2, 40.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 81, 1, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4109), 2, 11.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 100, 0, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4160), 3, 31.210000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 83, 1, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4116), 2, 19.43 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 82, 1, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4113), 2, 14.42 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 85, 1, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4121), 2, 10.17 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 98, 0, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4154), 3, 19.530000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 97, 0, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4152), 3, 32.359999999999999 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 96, 0, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4149), 3, 35.07 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 95, 0, new DateTime(2020, 5, 29, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4147), 3, 51.780000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 84, 1, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4118), 2, 25.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 93, 0, new DateTime(2020, 5, 31, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4142), 3, 5.3300000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 94, 0, new DateTime(2020, 5, 30, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4144), 3, 30.670000000000002 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 91, 0, new DateTime(2020, 6, 2, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4137), 3, 13.460000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 90, 1, new DateTime(2020, 5, 24, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4134), 2, 16.32 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 89, 1, new DateTime(2020, 5, 25, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4131), 2, 14.41 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 88, 1, new DateTime(2020, 5, 26, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4129), 2, 16.600000000000001 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 87, 1, new DateTime(2020, 5, 27, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4126), 2, 16.739999999999998 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 86, 1, new DateTime(2020, 5, 28, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4124), 2, 16.93 });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[] { 92, 0, new DateTime(2020, 6, 1, 16, 8, 49, 46, DateTimeKind.Local).AddTicks(4139), 3, 18.850000000000001 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 1, "jayson@example.com", "Jayson", "Lennon", "555-164-317", 3 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 2, "david@example.com", "David", "Sawyer", "555-195-162", 4 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 3, "michael@example.com", "Michael", "Walker", "555-115-412", 5 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 4, "sulav@example.com", "Sulav", "Aryal", "555-787-595", 6 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 6, "deon@example.com", "Deon ", "Smith", "555-514-298", 8 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 5, "melvin@example.com", "Melvin", "Johnson", "555-858-445", 7 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 8, "frances@example.com", "Frances ", "Hook", "555-871-503", 10 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 9, "linda@example.com", "Linda", "Lopez", "555-607-558", 11 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 10, "regina@example.com", "Regina", "McCoy", "555-504-625", 12 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 11, "demo@example.com", "Demo User", "Demo Last Name", "012-555-2394", 13 });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[] { 7, "ruth@example.com", "Ruth ", "Williams", "555-337-777", 9 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 21, null, "210" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 20, null, "209" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 19, null, "208" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 18, null, "207" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 17, null, "206" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 16, null, "205" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 14, null, "203" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 13, null, "202" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 12, null, "201" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 11, 11, "111" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[] { 15, null, "204" });

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
                values: new object[] { 5, 5, "105" });

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
                values: new object[] { 10, 10, "110" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 11, "test-key11", "Linda", "", "linda@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 10, "test-key10", "Frances", "", "frances@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 9, "test-key9", "Ruth", "", "ruth@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 8, "test-key8", "Deon", "", "deon@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 7, "test-key7", "Melvin", "", "melvin@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 2, "test-key2", "manager", "manager", "manager", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Manager" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 5, "test-key5", "Michael", "", "michael@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 4, "test-key4", "David", "", "david@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 3, "test-key3", "Jayson", "", "jayson@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 1, "test-key1", "admin", "admin", "admin", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 12, "test-key12", "Regina", "", "regina@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 6, "test-key6", "Sulav", "", "sulav@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[] { 13, "demo", "Demo User", "Demo Last Name", "demo@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" });

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
