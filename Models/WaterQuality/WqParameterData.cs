using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.WaterQuality
{
    public class WqParameterData
    {
        [Key]
        public string pcode { get; set; }
        public int total_pop { get; set; }
        public int sample_pop { get; set; }
        public int sampling_points { get; set; }
        public int samples_in_year { get; set; }
        public int complying_samples { get; set; }
        public int ph_complied_pop { get; set; }
        public int ph_not_complied_pop { get; set; }
        public int sufficient_data_available { get; set; }
        public int sufficient_data_pop { get; set; }
        // public int sufficient_data_not_available { get; set; }        sufficient data not available = sampling_points - sufficient_data_available
    }
}
