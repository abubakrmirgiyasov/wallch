using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WallCh.Domain.Models.Base;

public interface IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    ObjectId Id { get; set; }

    DateTimeOffset CreationDate { get; }

    DateTimeOffset? UpdateDate { get; set; }
}
