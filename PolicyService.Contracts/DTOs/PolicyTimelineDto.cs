namespace PolicyService.Contracts.DTOs
{
    public class PolicyTimelineDto
    {
        public string Number { get; set; } = string.Empty;
        public List<PeriodDto> Periods { get; set; } = new();
    }
}
