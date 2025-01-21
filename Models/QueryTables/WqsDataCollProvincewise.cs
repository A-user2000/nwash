using System;
using System.ComponentModel.DataAnnotations;

namespace Wq_Surveillance.Models.QueryTables
{
    public class WqsDataCollProvincewise
	{
        [Key]
        public string province_code { get; set; }
        public int form1acount { get; set; }
        public int form1bcount { get; set; }
        public int form2count { get; set; }
    }
}
