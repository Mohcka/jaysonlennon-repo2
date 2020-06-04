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
                    StartDate = table.Column<string>(type: "NVARCHAR(48)", nullable: true),
                    EndDate = table.Column<string>(type: "NVARCHAR(48)", nullable: true)
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
                    { 1, @"
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
                                ", "Lease Agreement" },
                    { 3, @"
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

                Address

                To Sender.Company:
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
                                ", "Internet Connection Agreement" },
                    { 2, @"
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
                                ", "Utility Agreement" }
                });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "AgreementId", "AgreementTemplateId", "EndDate", "SignedDate", "StartDate", "TenantId" },
                values: new object[,]
                {
                    { 13, 3, "2020-07-04 12:28:48.5406667", "2020-03-06 12:28:48.5326159", "2020-03-06 12:28:48.5326159", 11 },
                    { 12, 2, "2020-07-04 12:28:48.5406664", "2020-03-06 12:28:48.5326159", "2020-03-06 12:28:48.5326159", 11 },
                    { 11, 1, "2020-07-04 12:28:48.5406661", "2020-03-06 12:28:48.5326159", "2020-03-06 12:28:48.5326159", 11 },
                    { 10, 1, "2020-07-04 12:28:48.5406658", "2020-03-06 12:28:48.5326159", "2020-03-06 12:28:48.5326159", 10 },
                    { 9, 3, "2020-07-04 12:28:48.5406656", "2019-06-10 12:28:48.5326159", "2019-06-10 12:28:48.5326159", 9 },
                    { 1, 1, "2020-07-04 12:28:48.540557", "2020-03-06 12:28:48.5326159", "2020-03-06 12:28:48.5326159", 1 },
                    { 7, 1, "2020-07-04 12:28:48.540665", "2020-03-06 12:28:48.5326159", "2020-03-06 12:28:48.5326159", 7 },
                    { 6, 3, "2020-07-04 12:28:48.5406646", "2019-06-10 12:28:48.5326159", "2019-06-10 12:28:48.5326159", 6 },
                    { 5, 2, "2020-07-04 12:28:48.5406641", "2019-12-07 12:28:48.5326159", "2019-12-07 12:28:48.5326159", 5 },
                    { 4, 1, "2020-07-04 12:28:48.5406638", "2020-03-06 12:28:48.5326159", "2020-03-06 12:28:48.5326159", 4 },
                    { 3, 3, "2020-07-04 12:28:48.5406634", "2019-06-10 12:28:48.5326159", "2019-06-10 12:28:48.5326159", 3 },
                    { 2, 2, "2020-07-04 12:28:48.5406602", "2019-12-07 12:28:48.5326159", "2019-12-07 12:28:48.5326159", 2 },
                    { 8, 2, "2020-07-04 12:28:48.5406653", "2019-12-07 12:28:48.5326159", "2019-12-07 12:28:48.5326159", 8 }
                });

            migrationBuilder.InsertData(
                table: "BillingPeriods",
                columns: new[] { "BillingPeriodId", "PeriodEnd", "PeriodStart" },
                values: new object[,]
                {
                    { 5, "2020-06-19 12:28:48.5426041", "2020-05-20 12:28:48.5426039" },
                    { 4, "2020-05-20 12:28:48.5426036", "2020-05-05 12:28:48.5426034" },
                    { 2, "2020-04-05 12:28:48.5426017", "2020-03-06 12:28:48.5425994" },
                    { 1, "2020-03-06 12:28:48.5425459", "2020-02-05 12:28:48.5424944" },
                    { 3, "2020-05-05 12:28:48.5426031", "2020-04-05 12:28:48.5426028" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRequests",
                columns: new[] { "MaintenanceRequestId", "CloseReason", "ClosingUserId", "InternalNotes", "MaintenanceRequestType", "OpenNotes", "OpeningUserId", "ResolutionNotes", "TimeClosed", "TimeOpened", "UnitNumber" },
                values: new object[,]
                {
                    { 10, null, null, "Send maintenance", null, "Dead lightbulb", 8, null, null, "2020-03-06 12:28:48.5326159", "108" },
                    { 14, null, null, "Call plumber", null, "Clogged toilet", 13, null, null, "2020-06-01 12:28:48.542267", "111" },
                    { 13, null, null, "Send maintenance", null, "Leaky faucet", 13, null, null, "2020-05-28 12:28:48.5422668", "111" },
                    { 12, null, null, "Call electric company", null, "Power out", 2, null, null, "2020-05-25 12:28:48.5422665", "111" },
                    { 11, "CanceledByTenant", 1, "Call plumber", null, "Low water pressure", 13, "Fixed", "2020-05-22 12:28:48.5422661", "2020-05-21 12:28:48.5422642", "111" },
                    { 8, null, null, "Call Plumber", null, "No hot water", 6, null, null, "2020-03-06 12:28:48.5326159", "106" },
                    { 9, null, null, "Send maintenance", null, "Oven not working", 7, null, null, "2020-03-06 12:28:48.5326159", "107" },
                    { 6, null, null, "Call electric company", null, "Power out", 4, null, null, "2020-03-06 12:28:48.5326159", "104" },
                    { 7, null, null, "Call plumber", null, "Low water pressure", 5, null, null, "2020-03-06 12:28:48.5326159", "105" },
                    { 5, "CanceledByManagement", 2, "Call plumber", null, "No water", 3, "Fixed", "2020-05-05 12:28:48.5326159", "2020-03-06 12:28:48.5326159", "103" },
                    { 4, "CanceledByTenant", 1, "Call plumber", null, "Low water pressure", 2, "Fixed", "2020-05-05 12:28:48.5326159", "2020-03-06 12:28:48.5326159", "102" },
                    { 3, "CanceledByManagement", 1, "Call plumber", null, "Dirty water", 1, "Fixed", "2020-05-05 12:28:48.5326159", "2019-12-07 12:28:48.5326159", "101" },
                    { 2, "Completed", 1, "Call ISP", null, "No Interet", 1, "Fixed", "2020-05-05 12:28:48.5326159", "2020-03-06 12:28:48.5326159", "101" },
                    { 1, "Completed", 1, "Call Plumber", "Plumbing", "No water", 1, "Fully restored.", "2020-06-04 12:28:48.5421317", "2020-03-06 12:28:48.5326159", "101" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BillingPeriodId", "ResourceType", "TenantId", "TimePaid" },
                values: new object[,]
                {
                    { 36, 100.11, 1, 2, 8, "2020-06-03 12:28:48.5415519" },
                    { 35, 100.11, 1, 1, 7, "2020-06-03 12:28:48.5415517" },
                    { 34, 100.11, 1, 3, 7, "2020-06-03 12:28:48.5415514" },
                    { 33, 100.11, 1, 4, 7, "2020-06-03 12:28:48.5415512" },
                    { 30, 100.11, 1, 1, 6, "2020-06-03 12:28:48.5415502" },
                    { 31, 100.11, 1, 2, 7, "2020-06-03 12:28:48.5415505" },
                    { 37, 100.11, 1, 0, 8, "2020-06-03 12:28:48.5415522" },
                    { 29, 100.11, 1, 3, 6, "2020-06-03 12:28:48.5415499" },
                    { 28, 100.11, 1, 4, 6, "2020-06-03 12:28:48.5415495" },
                    { 32, 100.11, 1, 0, 7, "2020-06-03 12:28:48.5415508" },
                    { 38, 100.11, 1, 4, 8, "2020-06-03 12:28:48.5415525" },
                    { 41, 100.11, 1, 2, 9, "2020-06-03 12:28:48.5415534" },
                    { 40, 100.11, 1, 1, 8, "2020-06-03 12:28:48.5415531" },
                    { 42, 100.11, 1, 0, 9, "2020-06-03 12:28:48.5415537" },
                    { 43, 100.11, 1, 4, 9, "2020-06-03 12:28:48.5415539" },
                    { 44, 100.11, 1, 3, 9, "2020-06-03 12:28:48.5415542" },
                    { 45, 100.11, 1, 1, 9, "2020-06-03 12:28:48.5415544" },
                    { 47, 100.11, 1, 0, 10, "2020-06-03 12:28:48.541555" },
                    { 48, 100.11, 1, 4, 10, "2020-06-03 12:28:48.5415552" },
                    { 49, 100.11, 1, 3, 10, "2020-06-03 12:28:48.5415555" },
                    { 50, 100.11, 1, 1, 10, "2020-06-03 12:28:48.5415557" },
                    { 27, 100.11, 1, 0, 6, "2020-06-03 12:28:48.5415493" },
                    { 39, 100.11, 1, 3, 8, "2020-06-03 12:28:48.5415528" },
                    { 26, 100.11, 1, 2, 6, "2020-06-03 12:28:48.541549" },
                    { 46, 100.11, 1, 2, 10, "2020-06-03 12:28:48.5415547" },
                    { 24, 100.11, 1, 3, 5, "2020-06-03 12:28:48.5415484" },
                    { 25, 100.11, 1, 1, 5, "2020-06-03 12:28:48.5415487" },
                    { 1, 100.11, 1, 2, 1, "2020-06-03 12:28:48.54148" },
                    { 2, 100.11, 1, 0, 1, "2020-06-03 12:28:48.5415386" },
                    { 4, 100.11, 1, 3, 1, "2020-06-03 12:28:48.5415411" },
                    { 5, 100.11, 1, 1, 1, "2020-06-03 12:28:48.5415415" },
                    { 6, 100.11, 1, 2, 2, "2020-06-03 12:28:48.5415421" },
                    { 7, 100.11, 1, 0, 2, "2020-06-03 12:28:48.5415424" },
                    { 8, 100.11, 1, 4, 2, "2020-06-03 12:28:48.5415428" },
                    { 9, 100.11, 1, 3, 2, "2020-06-03 12:28:48.5415432" },
                    { 10, 100.11, 1, 1, 2, "2020-06-03 12:28:48.5415436" },
                    { 11, 100.11, 1, 2, 3, "2020-06-03 12:28:48.5415442" },
                    { 3, 100.11, 1, 4, 1, "2020-06-03 12:28:48.5415408" },
                    { 13, 100.11, 1, 4, 3, "2020-06-03 12:28:48.5415449" },
                    { 14, 100.11, 1, 3, 3, "2020-06-03 12:28:48.5415452" },
                    { 15, 100.11, 1, 1, 3, "2020-06-03 12:28:48.5415455" },
                    { 16, 100.11, 1, 2, 4, "2020-06-03 12:28:48.5415458" },
                    { 17, 100.11, 1, 0, 4, "2020-06-03 12:28:48.5415461" },
                    { 18, 100.11, 1, 4, 4, "2020-06-03 12:28:48.5415464" },
                    { 19, 100.11, 1, 3, 4, "2020-06-03 12:28:48.5415469" },
                    { 23, 100.11, 1, 4, 5, "2020-06-03 12:28:48.5415481" },
                    { 20, 100.11, 1, 1, 4, "2020-06-03 12:28:48.5415472" },
                    { 12, 100.11, 1, 0, 3, "2020-06-03 12:28:48.5415446" },
                    { 21, 100.11, 1, 2, 5, "2020-06-03 12:28:48.5415475" },
                    { 22, 100.11, 1, 0, 5, "2020-06-03 12:28:48.5415478" }
                });

            migrationBuilder.InsertData(
                table: "ResourceUsageRates",
                columns: new[] { "ResourceUsageRateId", "PeriodEnd", "PeriodStart", "Rate", "ResourceType" },
                values: new object[,]
                {
                    { 4, "2020-12-01 12:28:48.5410869", "2019-12-07 12:28:48.5326159", 30.0, 3 },
                    { 3, "2020-12-01 12:28:48.5410866", "2019-12-07 12:28:48.5326159", 1100.0, 4 },
                    { 5, "2020-12-01 12:28:48.5410875", "2019-12-07 12:28:48.5326159", 0.10000000000000001, 1 },
                    { 1, "2020-12-01 12:28:48.540983", "2019-12-07 12:28:48.5326159", 50.0, 2 },
                    { 2, "2020-12-01 12:28:48.5410835", "2019-12-07 12:28:48.5326159", 0.13, 0 }
                });

            migrationBuilder.InsertData(
                table: "TenantResourceUsages",
                columns: new[] { "TenantResourceUsageId", "ResourceType", "SampleTime", "TenantId", "UsageAmount" },
                values: new object[,]
                {
                    { 188, 1, "2020-05-26 12:28:48.5401584", 7, 41.600000000000001 },
                    { 187, 1, "2020-05-27 12:28:48.5401582", 7, 35.740000000000002 },
                    { 175, 0, "2020-05-29 12:28:48.5401549", 7, 29.780000000000001 },
                    { 186, 1, "2020-05-28 12:28:48.5401579", 7, 36.93 },
                    { 185, 1, "2020-05-29 12:28:48.5401576", 7, 25.170000000000002 },
                    { 184, 1, "2020-05-30 12:28:48.5401574", 7, 31.460000000000001 },
                    { 183, 1, "2020-05-31 12:28:48.5401571", 7, 36.43 },
                    { 182, 1, "2020-06-01 12:28:48.5401569", 7, 35.420000000000002 },
                    { 180, 0, "2020-05-24 12:28:48.5401562", 7, 30.210000000000001 },
                    { 179, 0, "2020-05-25 12:28:48.540156", 7, 35.729999999999997 },
                    { 178, 0, "2020-05-26 12:28:48.5401557", 7, 26.530000000000001 },
                    { 177, 0, "2020-05-27 12:28:48.5401554", 7, 26.359999999999999 },
                    { 176, 0, "2020-05-28 12:28:48.5401552", 7, 33.07 },
                    { 189, 1, "2020-05-25 12:28:48.5401587", 7, 34.409999999999997 },
                    { 181, 1, "2020-06-02 12:28:48.5401566", 7, 34.409999999999997 },
                    { 190, 1, "2020-05-24 12:28:48.5401589", 7, 31.32 },
                    { 204, 1, "2020-05-30 12:28:48.5401627", 8, 18.460000000000001 },
                    { 192, 0, "2020-06-01 12:28:48.5401595", 8, 13.85 },
                    { 207, 1, "2020-05-27 12:28:48.5401637", 8, 31.739999999999998 },
                    { 206, 1, "2020-05-28 12:28:48.5401634", 8, 15.93 },
                    { 205, 1, "2020-05-29 12:28:48.540163", 8, 8.1699999999999999 },
                    { 174, 0, "2020-05-30 12:28:48.5401546", 7, 29.670000000000002 },
                    { 203, 1, "2020-05-31 12:28:48.5401625", 8, 10.43 },
                    { 202, 1, "2020-06-01 12:28:48.5401622", 8, 13.42 },
                    { 201, 1, "2020-06-02 12:28:48.5401618", 8, 14.41 },
                    { 200, 0, "2020-05-24 12:28:48.5401616", 8, 3.21 },
                    { 199, 0, "2020-05-25 12:28:48.5401613", 8, 11.73 },
                    { 198, 0, "2020-05-26 12:28:48.540161", 8, 11.529999999999999 },
                    { 197, 0, "2020-05-27 12:28:48.5401608", 8, 28.359999999999999 },
                    { 196, 0, "2020-05-28 12:28:48.5401605", 8, 12.07 },
                    { 195, 0, "2020-05-29 12:28:48.5401602", 8, 12.779999999999999 },
                    { 194, 0, "2020-05-30 12:28:48.54016", 8, 11.67 },
                    { 193, 0, "2020-05-31 12:28:48.5401597", 8, 9.3300000000000001 },
                    { 191, 0, "2020-06-02 12:28:48.5401592", 8, 12.460000000000001 },
                    { 173, 0, "2020-05-31 12:28:48.5401542", 7, 34.329999999999998 },
                    { 158, 0, "2020-05-26 12:28:48.5401368", 6, 20.530000000000001 },
                    { 171, 0, "2020-06-02 12:28:48.5401537", 7, 30.460000000000001 },
                    { 150, 1, "2020-05-24 12:28:48.5401346", 5, 11.32 },
                    { 149, 1, "2020-05-25 12:28:48.5401343", 5, 16.41 },
                    { 148, 1, "2020-05-26 12:28:48.5401339", 5, 11.6 },
                    { 147, 1, "2020-05-27 12:28:48.5401336", 5, 11.74 },
                    { 146, 1, "2020-05-28 12:28:48.5401333", 5, 6.9299999999999997 },
                    { 145, 1, "2020-05-29 12:28:48.5401331", 5, 10.17 },
                    { 151, 0, "2020-06-02 12:28:48.5401348", 6, 20.460000000000001 },
                    { 144, 1, "2020-05-30 12:28:48.5401328", 5, 11.460000000000001 },
                    { 142, 1, "2020-06-01 12:28:48.5401322", 5, 11.42 },
                    { 141, 1, "2020-06-02 12:28:48.5401318", 5, 11.41 },
                    { 140, 0, "2020-05-24 12:28:48.5401316", 5, 10.210000000000001 },
                    { 139, 0, "2020-05-25 12:28:48.5401313", 5, 4.7300000000000004 },
                    { 138, 0, "2020-05-26 12:28:48.540131", 5, 10.529999999999999 },
                    { 208, 1, "2020-05-26 12:28:48.540164", 8, 16.600000000000001 },
                    { 143, 1, "2020-05-31 12:28:48.5401326", 5, 21.43 },
                    { 152, 0, "2020-06-01 12:28:48.5401352", 6, 13.85 },
                    { 153, 0, "2020-05-31 12:28:48.5401355", 6, 25.329999999999998 },
                    { 154, 0, "2020-05-30 12:28:48.5401358", 6, 20.670000000000002 },
                    { 170, 1, "2020-05-24 12:28:48.5401533", 6, 15.32 },
                    { 169, 1, "2020-05-25 12:28:48.5401398", 6, 13.41 },
                    { 168, 1, "2020-05-26 12:28:48.5401395", 6, 12.6 },
                    { 167, 1, "2020-05-27 12:28:48.5401392", 6, 15.74 },
                    { 166, 1, "2020-05-28 12:28:48.540139", 6, 16.93 },
                    { 165, 1, "2020-05-29 12:28:48.5401387", 6, 16.170000000000002 },
                    { 164, 1, "2020-05-30 12:28:48.5401384", 6, 11.460000000000001 },
                    { 163, 1, "2020-05-31 12:28:48.5401381", 6, 16.43 },
                    { 162, 1, "2020-06-01 12:28:48.5401379", 6, 19.420000000000002 },
                    { 161, 1, "2020-06-02 12:28:48.5401376", 6, 10.41 },
                    { 160, 0, "2020-05-24 12:28:48.5401373", 6, 20.210000000000001 },
                    { 159, 0, "2020-05-25 12:28:48.5401371", 6, 15.73 },
                    { 157, 0, "2020-05-27 12:28:48.5401366", 6, 21.359999999999999 },
                    { 156, 0, "2020-05-28 12:28:48.5401363", 6, 25.07 },
                    { 155, 0, "2020-05-29 12:28:48.540136", 6, 20.780000000000001 },
                    { 172, 0, "2020-06-01 12:28:48.540154", 7, 38.850000000000001 },
                    { 209, 1, "2020-05-25 12:28:48.5401642", 8, 18.41 },
                    { 254, 0, "2020-06-02 12:28:48.5401774", 11, 25.460000000000001 },
                    { 211, 0, "2020-06-02 12:28:48.5401647", 9, 38.460000000000001 },
                    { 262, 0, "2020-05-25 12:28:48.5401795", 11, 14.73 },
                    { 261, 0, "2020-05-26 12:28:48.5401792", 11, 15.529999999999999 },
                    { 260, 0, "2020-05-27 12:28:48.540179", 11, 33.359999999999999 },
                    { 259, 0, "2020-05-28 12:28:48.5401787", 11, 25.07 },
                    { 258, 0, "2020-05-29 12:28:48.5401785", 11, 40.780000000000001 },
                    { 257, 0, "2020-05-30 12:28:48.5401782", 11, 30.670000000000002 },
                    { 263, 0, "2020-05-24 12:28:48.5401798", 11, 25.289999999999999 },
                    { 256, 0, "2020-05-31 12:28:48.5401779", 11, 15.33 },
                    { 137, 0, "2020-05-27 12:28:48.5401308", 5, 11.359999999999999 },
                    { 253, 3, "2020-06-03 12:28:48.5401772", 11, 1.0 },
                    { 252, 4, "2020-06-03 12:28:48.5401769", 11, 1.0 },
                    { 251, 2, "2020-06-03 12:28:48.5401766", 11, 1.0 },
                    { 250, 1, "2020-05-24 12:28:48.5401761", 10, 20.32 },
                    { 249, 1, "2020-05-25 12:28:48.5401758", 10, 14.41 },
                    { 255, 0, "2020-06-01 12:28:48.5401777", 11, 29.850000000000001 },
                    { 264, 0, "2020-05-23 12:28:48.54018", 11, 19.210000000000001 },
                    { 265, 0, "2020-05-22 12:28:48.5401803", 11, 16.239999999999998 },
                    { 266, 0, "2020-05-21 12:28:48.5401805", 11, 19.210000000000001 },
                    { 281, 1, "2020-05-20 12:28:48.5401846", 11, 18.390000000000001 },
                    { 280, 1, "2020-05-21 12:28:48.5401844", 11, 13.109999999999999 },
                    { 279, 1, "2020-05-22 12:28:48.5401841", 11, 23.66 },
                    { 278, 1, "2020-05-23 12:28:48.5401838", 11, 21.399999999999999 },
                    { 277, 1, "2020-05-24 12:28:48.5401835", 11, 15.32 },
                    { 276, 1, "2020-05-25 12:28:48.5401833", 11, 12.41 },
                    { 275, 1, "2020-05-26 12:28:48.540183", 11, 19.600000000000001 },
                    { 274, 1, "2020-05-27 12:28:48.5401827", 11, 10.74 },
                    { 273, 1, "2020-05-28 12:28:48.5401825", 11, 16.93 },
                    { 272, 1, "2020-05-29 12:28:48.5401821", 11, 10.17 },
                    { 271, 1, "2020-05-30 12:28:48.5401819", 11, 13.460000000000001 },
                    { 270, 1, "2020-05-31 12:28:48.5401816", 11, 6.4299999999999997 },
                    { 269, 1, "2020-06-01 12:28:48.5401813", 11, 8.4000000000000004 },
                    { 268, 1, "2020-06-02 12:28:48.5401811", 11, 12.41 },
                    { 267, 0, "2020-05-20 12:28:48.5401808", 11, 30.149999999999999 },
                    { 248, 1, "2020-05-26 12:28:48.5401755", 10, 20.600000000000001 },
                    { 210, 1, "2020-05-24 12:28:48.5401645", 8, 16.32 },
                    { 247, 1, "2020-05-27 12:28:48.5401751", 10, 15.74 },
                    { 245, 1, "2020-05-29 12:28:48.5401746", 10, 23.170000000000002 },
                    { 225, 1, "2020-05-29 12:28:48.5401689", 9, 20.170000000000002 },
                    { 224, 1, "2020-05-30 12:28:48.5401686", 9, 21.460000000000001 },
                    { 223, 1, "2020-05-31 12:28:48.5401684", 9, 26.43 },
                    { 222, 1, "2020-06-01 12:28:48.5401681", 9, 29.420000000000002 },
                    { 221, 1, "2020-06-02 12:28:48.5401678", 9, 20.41 },
                    { 220, 0, "2020-05-24 12:28:48.5401675", 9, 30.210000000000001 },
                    { 226, 1, "2020-05-28 12:28:48.5401692", 9, 13.960000000000001 },
                    { 219, 0, "2020-05-25 12:28:48.5401671", 9, 15.73 },
                    { 217, 0, "2020-05-27 12:28:48.5401665", 9, 12.359999999999999 },
                    { 216, 0, "2020-05-28 12:28:48.5401662", 9, 18.07 },
                    { 215, 0, "2020-05-29 12:28:48.540166", 9, 40.780000000000001 },
                    { 214, 0, "2020-05-30 12:28:48.5401657", 9, 10.67 },
                    { 213, 0, "2020-05-31 12:28:48.5401654", 9, 25.329999999999998 },
                    { 212, 0, "2020-06-01 12:28:48.5401651", 9, 29.850000000000001 },
                    { 218, 0, "2020-05-26 12:28:48.5401668", 9, 20.52 },
                    { 227, 1, "2020-05-27 12:28:48.5401694", 9, 12.74 },
                    { 228, 1, "2020-05-26 12:28:48.5401698", 9, 13.6 },
                    { 229, 1, "2020-05-25 12:28:48.5401701", 9, 4.4100000000000001 },
                    { 244, 1, "2020-05-30 12:28:48.5401743", 10, 21.460000000000001 },
                    { 243, 1, "2020-05-31 12:28:48.540174", 10, 26.43 },
                    { 242, 1, "2020-06-01 12:28:48.5401738", 10, 25.420000000000002 },
                    { 241, 1, "2020-06-02 12:28:48.5401735", 10, 20.41 },
                    { 240, 0, "2020-05-24 12:28:48.5401733", 10, 17.210000000000001 },
                    { 239, 0, "2020-05-25 12:28:48.540173", 10, 10.73 },
                    { 238, 0, "2020-05-26 12:28:48.5401727", 10, 11.529999999999999 },
                    { 237, 0, "2020-05-27 12:28:48.5401724", 10, 17.359999999999999 },
                    { 236, 0, "2020-05-28 12:28:48.5401721", 10, 10.07 },
                    { 235, 0, "2020-05-29 12:28:48.5401718", 10, 30.780000000000001 },
                    { 234, 0, "2020-05-30 12:28:48.5401716", 10, 30.670000000000002 },
                    { 233, 0, "2020-05-31 12:28:48.5401713", 10, 35.329999999999998 },
                    { 232, 0, "2020-06-01 12:28:48.540171", 10, 32.850000000000001 },
                    { 231, 0, "2020-06-02 12:28:48.5401708", 10, 30.460000000000001 },
                    { 230, 1, "2020-05-24 12:28:48.5401704", 9, 6.3200000000000003 },
                    { 246, 1, "2020-05-28 12:28:48.5401748", 10, 16.93 },
                    { 136, 0, "2020-05-28 12:28:48.5401305", 5, 18.07 },
                    { 107, 1, "2020-05-27 12:28:48.5401218", 3, 15.74 },
                    { 134, 0, "2020-05-30 12:28:48.54013", 5, 17.670000000000002 },
                    { 35, 1, "2020-06-03 12:28:48.5400943", 7, 30.329999999999998 },
                    { 36, 2, "2020-06-03 12:28:48.5400946", 8, 1.0 },
                    { 37, 0, "2020-06-03 12:28:48.5400949", 8, 50.549999999999997 },
                    { 38, 4, "2020-06-03 12:28:48.5400951", 8, 1.0 },
                    { 39, 3, "2020-06-03 12:28:48.5400956", 8, 1.0 },
                    { 40, 1, "2020-06-03 12:28:48.5400959", 8, 30.329999999999998 },
                    { 41, 2, "2020-06-03 12:28:48.5400965", 9, 1.0 },
                    { 42, 0, "2020-06-03 12:28:48.5400968", 9, 50.549999999999997 },
                    { 43, 4, "2020-06-03 12:28:48.5400971", 9, 1.0 },
                    { 44, 3, "2020-06-03 12:28:48.5400974", 9, 1.0 },
                    { 135, 0, "2020-05-29 12:28:48.5401303", 5, 10.779999999999999 },
                    { 46, 2, "2020-06-03 12:28:48.5400979", 10, 1.0 },
                    { 47, 0, "2020-06-03 12:28:48.5400982", 10, 50.549999999999997 },
                    { 48, 4, "2020-06-03 12:28:48.5400985", 10, 1.0 },
                    { 34, 3, "2020-06-03 12:28:48.5400941", 7, 1.0 },
                    { 49, 3, "2020-06-03 12:28:48.5400987", 10, 1.0 },
                    { 51, 0, "2020-06-02 12:28:48.5400992", 1, 30.460000000000001 },
                    { 52, 0, "2020-06-01 12:28:48.5400995", 1, 29.850000000000001 },
                    { 53, 0, "2020-05-31 12:28:48.5400998", 1, 5.3300000000000001 },
                    { 54, 0, "2020-05-30 12:28:48.5401002", 1, 50.670000000000002 },
                    { 55, 0, "2020-05-29 12:28:48.5401005", 1, 40.780000000000001 },
                    { 56, 0, "2020-05-28 12:28:48.5401008", 1, 30.07 },
                    { 57, 0, "2020-05-27 12:28:48.540101", 1, 31.359999999999999 },
                    { 58, 0, "2020-05-26 12:28:48.5401013", 1, 20.530000000000001 },
                    { 59, 0, "2020-05-25 12:28:48.5401016", 1, 10.73 },
                    { 60, 0, "2020-05-24 12:28:48.5401019", 1, 30.210000000000001 },
                    { 61, 1, "2020-06-02 12:28:48.5401022", 1, 10.41 },
                    { 62, 1, "2020-06-01 12:28:48.5401024", 1, 15.42 },
                    { 63, 1, "2020-05-31 12:28:48.5401027", 1, 6.4299999999999997 },
                    { 64, 1, "2020-05-30 12:28:48.5401083", 1, 21.460000000000001 },
                    { 50, 1, "2020-06-03 12:28:48.540099", 10, 30.329999999999998 },
                    { 65, 1, "2020-05-29 12:28:48.5401086", 1, 10.17 },
                    { 33, 4, "2020-06-03 12:28:48.5400937", 7, 1.0 },
                    { 31, 2, "2020-06-03 12:28:48.5400931", 7, 1.0 },
                    { 1, 2, "2020-06-03 12:28:48.5400072", 1, 1.0 },
                    { 2, 0, "2020-06-03 12:28:48.5400812", 1, 50.549999999999997 },
                    { 3, 4, "2020-06-03 12:28:48.540084", 1, 1.0 },
                    { 4, 3, "2020-06-03 12:28:48.5400844", 1, 1.0 },
                    { 5, 1, "2020-06-03 12:28:48.5400847", 1, 40.399999999999999 },
                    { 6, 2, "2020-06-03 12:28:48.5400849", 2, 1.0 },
                    { 7, 0, "2020-06-03 12:28:48.5400854", 2, 50.549999999999997 },
                    { 8, 4, "2020-06-03 12:28:48.5400857", 2, 1.0 },
                    { 9, 3, "2020-06-03 12:28:48.5400861", 2, 1.0 },
                    { 10, 1, "2020-06-03 12:28:48.5400864", 2, 30.329999999999998 },
                    { 11, 2, "2020-06-03 12:28:48.5400867", 3, 1.0 },
                    { 12, 0, "2020-06-03 12:28:48.540087", 3, 50.549999999999997 },
                    { 13, 4, "2020-06-03 12:28:48.5400873", 3, 1.0 },
                    { 14, 3, "2020-06-03 12:28:48.5400876", 3, 1.0 },
                    { 32, 0, "2020-06-03 12:28:48.5400934", 7, 50.549999999999997 },
                    { 15, 1, "2020-06-03 12:28:48.5400879", 3, 30.329999999999998 },
                    { 17, 0, "2020-06-03 12:28:48.5400885", 4, 50.549999999999997 },
                    { 18, 4, "2020-06-03 12:28:48.5400888", 4, 1.0 },
                    { 19, 3, "2020-06-03 12:28:48.540089", 4, 1.0 },
                    { 20, 1, "2020-06-03 12:28:48.5400894", 4, 30.329999999999998 },
                    { 21, 2, "2020-06-03 12:28:48.5400897", 5, 1.0 },
                    { 22, 0, "2020-06-03 12:28:48.5400901", 5, 60.549999999999997 },
                    { 23, 4, "2020-06-03 12:28:48.5400905", 5, 1.0 },
                    { 24, 3, "2020-06-03 12:28:48.5400911", 5, 1.0 },
                    { 25, 1, "2020-06-03 12:28:48.5400913", 5, 40.329999999999998 },
                    { 26, 2, "2020-06-03 12:28:48.5400916", 6, 1.0 },
                    { 27, 0, "2020-06-03 12:28:48.5400919", 6, 60.549999999999997 },
                    { 28, 4, "2020-06-03 12:28:48.5400922", 6, 1.0 },
                    { 29, 3, "2020-06-03 12:28:48.5400925", 6, 1.0 },
                    { 30, 1, "2020-06-03 12:28:48.5400928", 6, 31.329999999999998 },
                    { 16, 2, "2020-06-03 12:28:48.5400882", 4, 1.0 },
                    { 66, 1, "2020-05-28 12:28:48.5401089", 1, 16.93 },
                    { 45, 1, "2020-06-03 12:28:48.5400977", 9, 30.329999999999998 },
                    { 68, 1, "2020-05-26 12:28:48.5401096", 1, 16.600000000000001 },
                    { 103, 1, "2020-05-31 12:28:48.5401207", 3, 19.43 },
                    { 104, 1, "2020-05-30 12:28:48.540121", 3, 11.460000000000001 },
                    { 105, 1, "2020-05-29 12:28:48.5401213", 3, 50.170000000000002 },
                    { 106, 1, "2020-05-28 12:28:48.5401216", 3, 19.93 },
                    { 108, 1, "2020-05-26 12:28:48.5401221", 3, 25.629999999999999 },
                    { 109, 1, "2020-05-25 12:28:48.5401223", 3, 27.41 },
                    { 110, 1, "2020-05-24 12:28:48.5401226", 3, 13.32 },
                    { 111, 0, "2020-06-02 12:28:48.540123", 4, 3.46 },
                    { 112, 0, "2020-06-01 12:28:48.5401233", 4, 29.850000000000001 },
                    { 113, 0, "2020-05-31 12:28:48.5401236", 4, 16.34 },
                    { 114, 0, "2020-05-30 12:28:48.5401239", 4, 11.67 },
                    { 115, 0, "2020-05-29 12:28:48.5401243", 4, 40.780000000000001 },
                    { 116, 0, "2020-05-28 12:28:48.5401246", 4, 20.07 },
                    { 117, 0, "2020-05-27 12:28:48.5401249", 4, 15.359999999999999 },
                    { 102, 1, "2020-06-01 12:28:48.5401205", 3, 22.420000000000002 },
                    { 118, 0, "2020-05-26 12:28:48.5401251", 4, 10.529999999999999 },
                    { 120, 0, "2020-05-24 12:28:48.5401257", 4, 11.210000000000001 },
                    { 121, 1, "2020-06-02 12:28:48.5401261", 4, 13.41 },
                    { 122, 1, "2020-06-01 12:28:48.5401263", 4, 30.420000000000002 },
                    { 67, 1, "2020-05-27 12:28:48.5401093", 1, 15.74 },
                    { 124, 1, "2020-05-30 12:28:48.5401268", 4, 11.460000000000001 },
                    { 125, 1, "2020-05-29 12:28:48.5401271", 4, 13.17 },
                    { 126, 1, "2020-05-28 12:28:48.5401274", 4, 16.93 },
                    { 127, 1, "2020-05-27 12:28:48.5401276", 4, 15.74 },
                    { 128, 1, "2020-05-26 12:28:48.5401279", 4, 21.600000000000001 },
                    { 129, 1, "2020-05-25 12:28:48.5401282", 4, 11.43 },
                    { 130, 1, "2020-05-24 12:28:48.5401286", 4, 16.32 },
                    { 131, 0, "2020-06-02 12:28:48.5401292", 5, 10.460000000000001 },
                    { 132, 0, "2020-06-01 12:28:48.5401295", 5, 19.850000000000001 },
                    { 133, 0, "2020-05-31 12:28:48.5401297", 5, 15.33 },
                    { 119, 0, "2020-05-25 12:28:48.5401255", 4, 12.73 },
                    { 101, 1, "2020-06-02 12:28:48.5401202", 3, 21.41 },
                    { 123, 1, "2020-05-31 12:28:48.5401266", 4, 16.43 },
                    { 99, 0, "2020-05-25 12:28:48.5401197", 3, 10.73 },
                    { 69, 1, "2020-05-25 12:28:48.54011", 1, 14.41 },
                    { 70, 1, "2020-05-24 12:28:48.5401102", 1, 16.32 },
                    { 71, 0, "2020-06-02 12:28:48.5401106", 2, 21.460000000000001 },
                    { 72, 0, "2020-06-01 12:28:48.5401108", 2, 25.850000000000001 },
                    { 73, 0, "2020-05-31 12:28:48.5401111", 2, 15.33 },
                    { 74, 0, "2020-05-30 12:28:48.5401113", 2, 50.670000000000002 },
                    { 75, 0, "2020-05-29 12:28:48.5401116", 2, 40.780000000000001 },
                    { 76, 0, "2020-05-28 12:28:48.5401119", 2, 29.07 },
                    { 77, 0, "2020-05-27 12:28:48.5401121", 2, 30.359999999999999 },
                    { 78, 0, "2020-05-26 12:28:48.5401125", 2, 20.530000000000001 },
                    { 79, 0, "2020-05-25 12:28:48.5401129", 2, 15.73 },
                    { 80, 0, "2020-05-24 12:28:48.5401132", 2, 40.210000000000001 },
                    { 81, 1, "2020-06-02 12:28:48.5401135", 2, 11.41 },
                    { 100, 0, "2020-05-24 12:28:48.5401199", 3, 31.210000000000001 },
                    { 83, 1, "2020-05-31 12:28:48.540114", 2, 19.43 },
                    { 82, 1, "2020-06-01 12:28:48.5401138", 2, 14.42 },
                    { 85, 1, "2020-05-29 12:28:48.5401146", 2, 10.17 },
                    { 98, 0, "2020-05-26 12:28:48.540119", 3, 19.530000000000001 },
                    { 97, 0, "2020-05-27 12:28:48.5401186", 3, 32.359999999999999 },
                    { 96, 0, "2020-05-28 12:28:48.5401184", 3, 35.07 },
                    { 95, 0, "2020-05-29 12:28:48.5401181", 3, 51.780000000000001 },
                    { 84, 1, "2020-05-30 12:28:48.5401143", 2, 25.460000000000001 },
                    { 93, 0, "2020-05-31 12:28:48.5401176", 3, 5.3300000000000001 },
                    { 94, 0, "2020-05-30 12:28:48.5401178", 3, 30.670000000000002 },
                    { 91, 0, "2020-06-02 12:28:48.5401168", 3, 13.460000000000001 },
                    { 90, 1, "2020-05-24 12:28:48.5401163", 2, 16.32 },
                    { 89, 1, "2020-05-25 12:28:48.5401157", 2, 14.41 },
                    { 88, 1, "2020-05-26 12:28:48.5401154", 2, 16.600000000000001 },
                    { 87, 1, "2020-05-27 12:28:48.5401151", 2, 16.739999999999998 },
                    { 86, 1, "2020-05-28 12:28:48.5401149", 2, 16.93 },
                    { 92, 0, "2020-06-01 12:28:48.5401171", 3, 18.850000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "Email", "FirstName", "LastName", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "jayson@example.com", "Jayson", "Lennon", "555-164-317", 3 },
                    { 2, "david@example.com", "David", "Sawyer", "555-195-162", 4 },
                    { 3, "michael@example.com", "Michael", "Walker", "555-115-412", 5 },
                    { 4, "sulav@example.com", "Sulav", "Aryal", "555-787-595", 6 },
                    { 6, "deon@example.com", "Deon ", "Smith", "555-514-298", 8 },
                    { 5, "melvin@example.com", "Melvin", "Johnson", "555-858-445", 7 },
                    { 8, "frances@example.com", "Frances ", "Hook", "555-871-503", 10 },
                    { 9, "linda@example.com", "Linda", "Lopez", "555-607-558", 11 },
                    { 10, "regina@example.com", "Regina", "McCoy", "555-504-625", 12 },
                    { 11, "demo@example.com", "Demo User", "Demo Last Name", "012-555-2394", 13 },
                    { 7, "ruth@example.com", "Ruth ", "Williams", "555-337-777", 9 }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[,]
                {
                    { 21, null, "210" },
                    { 20, null, "209" },
                    { 19, null, "208" },
                    { 18, null, "207" },
                    { 17, null, "206" },
                    { 16, null, "205" },
                    { 14, null, "203" },
                    { 13, null, "202" },
                    { 12, null, "201" },
                    { 11, 11, "111" },
                    { 15, null, "204" },
                    { 9, 9, "109" },
                    { 8, 8, "108" },
                    { 7, 7, "107" },
                    { 6, 6, "106" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "TenantId", "UnitNumber" },
                values: new object[,]
                {
                    { 5, 5, "105" },
                    { 4, 4, "104" },
                    { 3, 3, "103" },
                    { 2, 2, "102" },
                    { 1, 1, "101" },
                    { 10, 10, "110" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApiKey", "FirstName", "LastName", "LoginName", "Password", "UserAccountType" },
                values: new object[,]
                {
                    { 11, "test-key11", "Linda", "", "linda@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 10, "test-key10", "Frances", "", "frances@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 9, "test-key9", "Ruth", "", "ruth@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 8, "test-key8", "Deon", "", "deon@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 7, "test-key7", "Melvin", "", "melvin@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 2, "test-key2", "manager", "manager", "manager", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Manager" },
                    { 5, "test-key5", "Michael", "", "michael@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 4, "test-key4", "David", "", "david@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 3, "test-key3", "Jayson", "", "jayson@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 1, "test-key1", "admin", "admin", "admin", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Admin" },
                    { 12, "test-key12", "Regina", "", "regina@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 6, "test-key6", "Sulav", "", "sulav@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" },
                    { 13, "demo", "Demo User", "Demo Last Name", "demo@example.com", "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", "Tenant" }
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
