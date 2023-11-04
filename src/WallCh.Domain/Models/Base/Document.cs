using MongoDB.Bson;

namespace WallCh.Domain.Models.Base;

public abstract class Document : IDocument
{
    public ObjectId Id { get; set; }

    public DateTimeOffset CreationDate { get; } = DateTimeOffset.Now;
    
    public DateTimeOffset? UpdateDate { get; set; }
}
