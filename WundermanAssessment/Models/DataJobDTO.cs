using System.ComponentModel.DataAnnotations;

namespace WundermanAssessment.Models
{
    public class DataJobDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FilePathToProcess { get; set; }
        public DataJobStatus Status { get; set; } = DataJobStatus.New;
        public List<string> Results { get; set; } = new List<string>();
        public List<Link> Links { get; set; } = new List<Link>();
    }  
}