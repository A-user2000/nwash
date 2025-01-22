namespace Wq_Surveillance.Models.Dto
{
    public class Form3Dto: Form3
    {
        public string ProCode { get; set; }
        public string ProName { get; set; }
        public string Address { get; set; }
        public int? TotalPop { get; set; }
        public int? TotalBenificiaryPopulation { get; set; }
        public int? TotalHhServed { get; set; }

    }
}
