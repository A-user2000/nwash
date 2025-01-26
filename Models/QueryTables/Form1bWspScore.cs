using System.ComponentModel.DataAnnotations;

namespace Wq_Surveillance.Models.QueryTables
{
    public class Form1bWspScore
    {
        [Key]
        public string score_category {  get; set; }
        public string ranges {  get; set; }
        public int total_projects {  get; set; }
        public int total_households {  get; set; }
        public int total_beneficiaries {  get; set; }
    }
}
