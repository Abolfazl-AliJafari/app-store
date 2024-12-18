using app_store.Common.Queries.Producers.GetProductAll;
using app_store.Domain.Entities;

namespace app_store.Application.Queries.Producers.GetProducerAll
{
    public class GetProducerAllQueryMapper
    {
        public static IEnumerable<GetProducerAllResponse> Map(IEnumerable<Producer> Producers)
        {
            List<GetProducerAllResponse> getProducersAllResponses = new List<GetProducerAllResponse>();
            foreach (var Producer in Producers)
            {
                getProducersAllResponses.Add(new GetProducerAllResponse
                {
                    Id = Producer.Id,
                    Title = Producer.Title,
                });
            }
            return getProducersAllResponses.AsEnumerable();
        }
    }
}
