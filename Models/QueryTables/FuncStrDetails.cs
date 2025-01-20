using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.QueryTables
{
    public class FuncStrDetails
    {
        /*
         *  Includes Structure, Pipe, rvt, Water Source
         */
        [Key]
        public string uuid { get; set; }
        public string pro_code { get; set; }
        public int trn_major { get; set; }          // Transmission
        public int dis_major { get; set; }          // Distribution
        public double length_dis { get; set; }
        public double length_trn { get; set; }
        public int no_of_sources { get; set; }
        public int no_of_intakes { get; set; }
        public int int_good { get; set; }
        public int int_minor { get; set; }
        public int int_major { get; set; }
        public int int_reconstruction { get; set; }
        public int no_intake_str { get; set; }
        public int cond_good { get; set; }              //structure condition
        public int cond_minor_rep { get; set; }
        public int cond_major_rep { get; set; }
        public int cond_reconstruction { get; set; }
        public int no_of_rvt { get; set; }
        public int rvt_good { get; set; }
        public int rvt_minor { get; set; }
        public int rvt_major { get; set; }
        public int rvt_reconstruction { get; set; }
    }
}
