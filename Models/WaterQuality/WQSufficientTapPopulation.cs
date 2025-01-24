using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.WaterQuality
{
    public class WQSufficientTapPopulation
    {
        [Key]
        public string pro_code { get; set; }
        public int sample_total_pop { get; set; }
        public int scheme_total_pop { get; set; }
        public int sufficient_value { get; set; }
        public int sufficient_val_pop { get; set; }
    }
}
