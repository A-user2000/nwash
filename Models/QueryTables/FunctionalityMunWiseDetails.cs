using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.QueryTables
{
    public class FunctionalityMunWiseDetails
    {
        [Key]
        public string municipality_code { get; set; }
        public string province_code { get; set; }
        public string mun_name { get; set; }
        public string district_name { get; set; }
        public int score_70_above { get; set; }
        public int score_60_to_70 { get; set; }
        public int score_below_60 { get; set; }
        public double tap_70_above { get; set; }
        public double tap_60_to_70 { get; set; }
        public double tap_less_60 { get; set; }
        public double hh_70_above { get; set; }
        public double hh_60_to_70 { get; set; }
        public double hh_less_60 { get; set; }
        public double male_70_above { get; set; }
        public double male_60_to_70 { get; set; }
        public double male_less_60 { get; set; }
        public double female_70_above { get; set; }
        public double female_60_to_70 { get; set; }
        public double female_less_60 { get; set; }


    }
}
