using System;
using System.ComponentModel.DataAnnotations;

namespace Wq_Surveillance.Models.QueryTables
{
    public class DateAndInt
    {
        [Key]
        public DateTime added_date { get; set; }
        public int form1acount { get; set; }
        public int form1bcount { get; set; }
        public int form2count { get; set; }
    }
}
