# Calculating payments due
Payments due within a period can be calculated as follows:
1) Get the `TenantId` who is leasing the unit
2) Get the `BillingPeriod` entity
3) Get all `ResourceUsageRates` entity where the `EffectiveDate` is earlier than the current date
  * Order by `EffectiveDate` descending
  * Select only unique `ResourceUsageRates` based on `ResourceType`
4) Get the `TenantResourceUsage` entities that are between `BillingPeriod.PeriodStart` and `BillingPeriod.PeriodEnd`
5) For each `TenantResourceUsage` entity, calculate the total cost of the resource:
  * Multiply `TenantResourceUsage.UsageAmount` by `ResourceUsageRates.Rate` where the `TenantResourceUsage.ResourceType` == `ResourceUsageRates.ResourceType`. This is the `Cost`
  * Use `select()` to generate a new entity (`#5`) type containing `TenantId`, `ResourceType`, `Sum(UsageAmount)`, `Rate`, `Cost`; grouped by `ResourceType`
6) For each entity from `#5`:
  * Get all `Payment` entity, filtering by `Payments.TenantId`, `Payments.BillingPeriod`, and `Payments.ResourceType`
  * `Payments.Amount` - `#5.Cost` = amount due
  * If no matching `Payment` entity for the corresponding `#5.ResourceType`, amount due is the `#5.Cost`

# Listing available units
This needs to be translated into EFcore:
`SELECT * FROM Units WHERE UnitId NOT IN (SELECT UnitId FROM Tenants WHERE IsPresent = TRUE)`

# Listing lease agreements that will end soon
`SELECT * FROM LeaseAgreements WHERE TimeEnd - now() <= '2 months' AND ExpirationReview IS NOT NULL`

