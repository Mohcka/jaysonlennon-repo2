using System;
namespace AptMgmtPortalAPI.Util
{
    public static class ResourceProjection
    {
        public static double TotalForPeriod(double usageInPeriod,
                                            DateTime periodStart,
                                            DateTime periodEnd,
                                            DateTime now)
        {
            double daysInPeriod = (periodEnd - periodStart).TotalDays + 1;
            double daysRemainingInPeriod = (periodEnd - now).TotalDays;
            double daysSampled = daysInPeriod - daysRemainingInPeriod;

            if (daysRemainingInPeriod > 0) {
                var averageDailyUsage = usageInPeriod/ daysSampled;
                var projectedUsageTotal = usageInPeriod + (averageDailyUsage * daysRemainingInPeriod);
                return projectedUsageTotal;
            } else {
                return usageInPeriod;
            }
        }
    }
}