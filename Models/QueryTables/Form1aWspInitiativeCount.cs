using System.ComponentModel.DataAnnotations;

namespace Wq_Surveillance.Models.QueryTables
{
    public class Form1aWspInitiativeCount
    {
        [Key]
        public string initiative_name { get; set; }
        public string column_name { get; set; }
        public int bad { get; set; }
        public int average { get; set; }
        public int good { get; set; }
        public int excellent { get; set; }
    }
}
