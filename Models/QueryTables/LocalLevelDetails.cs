using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.QueryTables
{
    public class LocalLevelDetails
    {
        [Key]
        public int id { get; set; }
        public string province_code { get; set; }
        public string province_name { get; set; }
        public string district_code { get; set; }
        public string district_name { get; set; }
        public string mun_code { get; set; }
        public string mun_name { get; set; }
    }
}
