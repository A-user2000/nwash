namespace Wq_Surveillance.Models.Dto
{
    public class WQDto : WqSurveillanceMain
    {
        public string? ProUuid { get; set; }
        public string ProName { get; set; }
        public int? TotalPop { get; set; }
        public decimal? TotalHh { get; set; }


    }
}
