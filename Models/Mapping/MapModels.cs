using AutoMapper;
using Wq_Surveillance.Models.Dto;

namespace Wq_Surveillance.Models.Mapping
{
    public class MapModels : Profile
    {
        public MapModels() {
            CreateMap<Form1a, Form1ADto>();
            CreateMap<Form1b, Form1BDto>();
            CreateMap<Form2, Form2Dto>();
            CreateMap<Form3, Form3Dto>();
            CreateMap<ReservoirSanitary, FormResDto>();
            CreateMap<SourceSanitary, FormSouDto>();
            CreateMap<StructureSanitary, FormStrDto>();
            CreateMap<TapSanitary, FormTapDto>();
            CreateMap<WqSurvellianceMain, WQDto>();


        }
    }
}
