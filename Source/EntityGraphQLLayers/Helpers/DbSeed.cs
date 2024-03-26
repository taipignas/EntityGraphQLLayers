using EntityGraphQLLayers.Models;

namespace EntityGraphQLLayers.Helpers
{
    internal static class DbSeed
    {
        internal static void Seed(DocumentDbContext ctx)
        {
            if (ctx.Projects.Any())
                return;

            var project = new Project
            {
                Id = 1,
                ProjectType = 1,
                Documents = new List<Document>
                {
                    new Document
                    {
                        Id = 1,
                        DocumentType = 1,
                        Attachments = new List<Attachment> {
                            new Attachment
                            {
                                Id = 1,
                                AttachmentType = 1
                            }
                        }
                    }
                }
            };

            ctx.Projects.Add(project);
            ctx.SaveChanges();
        }
    }
}
