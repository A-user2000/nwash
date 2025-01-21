using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Models.API
{
    public class CheckUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
