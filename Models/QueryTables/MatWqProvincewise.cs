using System.ComponentModel.DataAnnotations;

namespace Wq_Surveillance.Models.QueryTables
{
    public class MatWqProvincewise
    {
        [Key]
        public string province_code {  get; set; }
        public string province_name {  get; set; }
        public int ecoli_0 { get; set; }
        public int ecoli_less0 { get; set; }
        public int ph_between { get; set; }
        public int ph_out_of_range { get; set; }
        public int turbid_between { get; set; }
        public int turbid_out_of_range { get; set; }
        public int iron_between { get; set; }
        public int iron_out_of_range { get; set; }
        public int arsenic_between { get; set; }
        public int arsenic_out_of_range { get; set; }
        public int residual_between { get; set; }
        public int residual_out_of_range { get; set; }
    }
}
