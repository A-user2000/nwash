using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.MapData
{
    public class ProjectDetailData
    {
        [Key]
        public string uuid { get; set; }
        public string province_code { get; set; }
        public string district_code { get; set; }
        public string municipality_code { get; set; }
        public string pro_name { get; set; }
        public string pro_code { get; set; }
        public string district_name { get; set; }
        public string dcode { get; set; }
        public string mun_name { get; set; }
        public string mun_code { get; set; }
        public string inv_agency { get; set; }
        public string pro_type { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public double ele { get; set; }
        public string cons_agency { get; set; }
        public int cons_year { get; set; }
        public string sup_agency { get; set; }
        public string settlement_name { get; set; }
        public string ward_no { get; set; }

    }
}
