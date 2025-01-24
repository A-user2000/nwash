using System;
using System.ComponentModel.DataAnnotations;

namespace Wq_Surveillance.Models.WaterQuality
{
    public class WqMigrate
    {
        [Key]
        public string prouuid { get; set; }
        public DateTime CollectionDate { get; set; }
        public string SampledBy { get; set; }
        public string type { get; set; }
        public int lab { get; set; }
        public string tapuuid { get; set; }
        public string Turbidity { get; set; }
        public string pH { get; set; }
        public string Color { get; set; }
        public string TasteandOdor { get; set; }
        public string ElectricalConductivity { get; set; }
        public string TotalDissolvedSolids { get; set; }
        public string Iron { get; set; }
        public string Manganese { get; set; }
        public string Arsenic { get; set; }
        public string Fluoride { get; set; }
        public string Ammonia { get; set; }
        public string Chloride { get; set; }
        public string Sulphate { get; set; }
        public string Nitrate { get; set; }
        public string Copper { get; set; }
        public string Zinc { get; set; }
        public string Aluminium { get; set; }
        public string TotalHardness { get; set; }
        public string ResidualChlorine { get; set; }
        public string Calcium { get; set; }
        public string Lead { get; set; }
        public string Cadmium { get; set; }
        public string Chromium { get; set; }
        public string Cyanide { get; set; }
        public string Mercury { get; set; }
        public string Nitrites { get; set; }
        public string FaecalcoliformEcoli { get; set; }
        public string TotalColiform { get; set; }
        public string FaecalContaminationPAvial { get; set; }
    }
}
