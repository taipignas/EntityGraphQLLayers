using System.ComponentModel.DataAnnotations;

namespace EntityGraphQLLayers.Models
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }
        public int AttachmentType { get; set; }
    }
}
