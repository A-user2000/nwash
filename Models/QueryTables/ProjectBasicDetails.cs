using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.QueryTables
{
    public class ProjectBasicDetails
    {
        [Key]
        public string uuid { get; set; }
        public string pro_code { get; set; }
        public int data_year { get; set; }
        public string pro_type { get; set; }
        public int cons_year { get; set; }
        public string cons_agency { get; set; }
        public string ward_no { get; set; }
        public string inv_agency { get; set; }
        public string district_name { get; set; }
        public string province_name { get; set; }
    }
}
