#nullable disable

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WallCh.Domain.Attributes;
using WallCh.Domain.Common;
using WallCh.Domain.Models.Base;

namespace WallCh.Infrastructure.Repositories.Base;

public class Repository<TDocument> : IRepository<TDocument>
    where TDocument : IDocument
{
    private readonly IMongoCollection<TDocument> _collection;

    public Repository(IOptions<AppSettings> appSettings)
    {
        var database = new MongoClient(appSettings.Value.MongoDbSettings.ConnectionString).GetDatabase(appSettings.Value.MongoDbSettings.DatabaseeName);
        _collection = database.GetCollection<TDocument>(Repository<TDocument>.GetCollectionName(typeof(TDocument)));
    }

    private static string GetCollectionName(Type type)
    {

        return ((BsonCollectionAttribute)type
            .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
            .FirstOrDefault())?.CollectionName;
    }

    public IQueryable<TDocument> AsQueryable()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
    {
        throw new NotImplementedException();
    }
}
