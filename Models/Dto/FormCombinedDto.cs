namespace Wq_Surveillance.Models.Dto
{
    public class FormCombinedDto
    {
        public WQDto WqData { get; set; } // Single instance (common data)
        public List<FormResDto> ReservoirSanitationData { get; set; } // List for multiple forms
        public List<FormSouDto> SourceSanitationData { get; set; } // List for multiple forms
        public List<FormStrDto> StructureSanitationData { get; set; } // List for multiple forms
        public List<FormTapDto> TapSanitationData { get; set; } // List for multiple forms
    }
}
