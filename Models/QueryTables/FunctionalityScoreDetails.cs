using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.QueryTables
{
    public class FunctionalityScoreDetails
    {
        [Key]
        public string uuid { get; set; }
        public string pro_code { get; set; }
        public string pro_name { get; set; }
        public string province_code { get; set; }
        public string province_name { get; set; }
        public string district_name { get; set; }
        public string district_code { get; set; }
        public string mun_name { get; set; }
        public string municipality_code { get; set; }
        public string year1 { get; set; }
        public int tap_count { get; set; }
        public int hh { get; set; }
        public int male { get; set; }
        public int female { get; set; }
    }
}
