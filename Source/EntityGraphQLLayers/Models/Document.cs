using System.ComponentModel.DataAnnotations;

namespace EntityGraphQLLayers.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public int DocumentType { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
