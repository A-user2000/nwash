using System.ComponentModel.DataAnnotations;

namespace Wq_Surveillance.Models.QueryTables
{
    public class WqsRangeSummary
    {
        [Key]
        public string range {  get; set; }
        public string status {  get; set; }
        public int num_projects {  get; set; }
        public int total_hhserved {  get; set; }
        public int pop_served {  get; set; }
    }
}
