namespace PolicyService.Domain.Models
{
    public class PolicyPeriod
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public decimal Premium { get; private set; }

        private PolicyPeriod() { }

        public PolicyPeriod(DateTime start, DateTime end, decimal premium)
        {
            Start = start;
            End = end;
            Premium = premium;
        }
    }
}
