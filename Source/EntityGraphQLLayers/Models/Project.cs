using System.ComponentModel.DataAnnotations;

namespace EntityGraphQLLayers.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public int ProjectType { get; set; }
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
