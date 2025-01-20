namespace Wq_Surveillance.Models.Dto
{
    public class FormCombinedDto
    {
     
        public FormResDto ReservoirSanitationData { get; set; }
        public FormSouDto SourceSanitationData { get; set; }
        public FormStrDto StructureSanitationData { get; set; }
        public FormTapDto TapSanitationData { get; set; }
        public TapSanitary TapSanitationDatas { get; set; }
    }
}
