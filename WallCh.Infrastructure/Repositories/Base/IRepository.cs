using System.Linq.Expressions;
using WallCh.Domain.Models.Base;

namespace WallCh.Infrastructure.Repositories.Base;

public interface IRepository<TDocument>
    where TDocument : IDocument
{
    IQueryable<TDocument> AsQueryable();

    IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression);
}
