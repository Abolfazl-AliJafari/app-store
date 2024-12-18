using app_store.Domain.Entities;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Queries.Producers.GetProductAll
{
    public record GetProducerAllQuery() : IRequest<Result<IEnumerable<GetProducerAllResponse>>>;
}
