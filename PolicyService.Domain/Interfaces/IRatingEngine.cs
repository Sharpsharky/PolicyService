namespace PolicyService.Domain.Interfaces
{
    public interface IRatingEngine
    {
        decimal CalculatePremium(decimal previousPremium);
    }
}
