using PolicyService.Domain.Interfaces;

namespace PolicyService.Infrastructure.Rating
{
    public class TenPercentRatingEngine : IRatingEngine
    {
        public decimal CalculatePremium(decimal previousPremium)
        {
            return Math.Round(previousPremium * 1.10m, 2);
        }
    }
}
