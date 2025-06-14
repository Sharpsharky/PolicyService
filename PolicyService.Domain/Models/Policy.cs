using PolicyService.Domain.Interfaces;

namespace PolicyService.Domain.Models
{
    public class Policy
    {
        public Guid Id { get; private set; }
        public string Number { get; private set; }

        private readonly List<PolicyPeriod> periods = new();
        public IReadOnlyCollection<PolicyPeriod> Periods => periods.AsReadOnly();

        private Policy() { }

        public Policy(string number, PolicyPeriod initialPeriod)
        {
            Id = Guid.NewGuid();
            Number = number;
            periods.Add(initialPeriod);
        }

        public void Renew(IRatingEngine ratingEngine)
        {
            var last = periods.OrderByDescending(p => p.Start).First();
            var newPremium = ratingEngine.CalculatePremium(last.Premium);
            var nextStart = last.End.AddDays(1);
            var nextEnd = nextStart.AddYears(1).AddDays(-1);

            var newPeriod = new PolicyPeriod(nextStart, nextEnd, newPremium);
            periods.Add(newPeriod);
        }
    }
}
