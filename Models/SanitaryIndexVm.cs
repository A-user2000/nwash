namespace Wq_Surveillance.Models
{
    public class SanitaryIndexVm
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Municipality { get; set; }
        public string ProjectName { get; set; }
        public string Surveyor { get; set; }
        public bool ReservoirExists { get; set; }
        public bool SourceExists { get; set; }
        public bool StructureExists { get; set; }
        public bool TapExists { get; set; }
    }

}
