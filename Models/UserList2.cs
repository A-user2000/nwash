using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Wq_Surveillance.Models
{
    public class UserList2
    {
        [Key]
        public int user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string user_type { get; set; }
        public int? groups { get; set; }
        public int? status { get; set; }

        [DataType(DataType.Date)]
        public DateTime created_date { get; set; }
        public int? district { get; set; }
        public string district_name { get; set; }
        public string mun_name { get; set; }
        public string inv_agency { get; set; }
        public string province { get; set; }
        public int? municipality { get; set; }
        public int? training_user { get; set; }
        public double? last_login { get; set; }
        public string last_login_date { get; set; }
        public int user_category { get; set; }
    }
}
