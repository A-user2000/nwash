using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.QueryTables
{
    public class WSIncomeDetails
    {
        [Key]
        public string uuid { get; set; }
        public string pro_code { get; set; }
        public string expenditure { get; set; }
        public string other_donation { get; set; }
        public string other_income { get; set; }
        public string water_tariff { get; set; }
    }
}
