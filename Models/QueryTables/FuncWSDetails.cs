using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.QueryTables
{
    public class FuncWSDetails
    {
        [Key]
        public int ws_id { get; set; }
        public string pro_code { get; set; }
        public string flow_reg { get; set; }
        public int adj_month { get; set; }
        public double min_yield { get; set; }
    }
}
