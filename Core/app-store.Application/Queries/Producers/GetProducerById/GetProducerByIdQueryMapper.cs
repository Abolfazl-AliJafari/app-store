using app_store.Common.Queries.Producers.GetProductById;
using app_store.Domain.Entities;

namespace app_store.Application.Queries.Producers.GetProducerById
{
    public class GetProducerByIdQueryMapper
    {
        public static GetProducerByIdResponse Map(Producer producer)
        {
            return
                new GetProducerByIdResponse
                {
                    Id = producer.Id,
                    Title = producer.Title,
                    Description = producer.Description,
                    Email = producer.Email,
                };
        }
    }
}
