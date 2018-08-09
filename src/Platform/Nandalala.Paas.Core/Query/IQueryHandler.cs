using System.Threading.Tasks;

namespace Nandalala.Paas.Core.Query
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : QueryBase<TResult>
    {
        TResult Handle(TQuery query);
    }
}
