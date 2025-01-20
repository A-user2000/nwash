using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.QueryTables
{
    public class SustainabilityDetails
    {
        [Key]
        public string uuid { get; set; }
        public string pro_code { get; set; }
        public string province_code { get; set; }
        public string district_code { get; set; }
        public string municipality_code { get; set; }
        public double year1 { get; set; }
        public double func_population { get; set; }
        public int no_of_meetings { get; set; }
        public int no_of_agm { get; set; }
        public string sop_status_eng { get; set; }
        public int accountant { get; set; }
        public int self { get; set; }
        public string water_usage_eng { get; set; }
        public int no_of_members { get; set; }
        public int female_member { get; set; }
        public int female_member_in_key_post { get; set; }
        public int audit_yes { get; set; }
        public int vmw_payment_yes { get; set; }
        public int insuarance_yes { get; set; }
        public int vmw_being_paid { get; set; }
        public int no_of_vmw { get; set; }
    }
}
