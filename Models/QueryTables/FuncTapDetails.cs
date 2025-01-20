using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.QueryTables
{
    public class FuncTapDetails
    {
        [Key]
        public int tap_id { get; set; }
        public string pro_code { get; set; }
        public string pro_name { get; set; }
        public string tap_no { get; set; }
        public string tap_type { get; set; }
        public string tap_cond { get; set; }
        public double tap_fhours { get; set; }
        public int hh_serverd { get; set; }
        public int male_pop { get; set; }
        public int female_pop { get; set; }
        public string tap_flow_con { get; set; }
        public string tap_water_quality { get; set; }
        public int tap_complaint { get; set; }
        public int no_leakage { get; set; }
        public int hh_toilet { get; set; }
        public int no_of_vmw { get; set; }
        public int vmw_tools_adequate { get; set; }
    }
}
