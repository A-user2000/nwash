namespace Wq_Surveillance.Models.Dto
{
    public class FormResDto : ReservoirSanitary

    {
        public string ProCode { get; set; }
        public string Address { get; set; }
        public int? TotalPop { get; set; }
        public int? TotalBenificiaryPopulation { get; set; }
        public int? TotalHhServed { get; set; }
    }
}
