using app_store.Domain.Entities;
using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Queries.Producers.GetProductById
{
    public record GetProducerByIdQuery(
        Guid Id) : IRequest<Result<GetProducerByIdResponse>>;
}
