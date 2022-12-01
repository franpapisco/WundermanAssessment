using System.ComponentModel.DataAnnotations;

namespace WundermanAssessment.Models
{
    
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string Rel { get; set; }
        public string Href { get; set; }
        public string Action { get; set; }
        public List<string> Types { get; set; }
    }
}
