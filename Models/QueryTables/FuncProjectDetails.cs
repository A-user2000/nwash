using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.QueryTables
{
    public class FuncProjectDetails
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
        public int cons_year { get; set; }
    }
}
