using app_store.Common.Commands.Producers;
using app_store.Domain.Entities;

namespace app_store.Application.Commands.Producers.CreateProducer
{
    public class CreateProducerCommandMapper
    {
        public static Producer Map(CreateProducerCommand command)
        {
            return new Producer(
                command.Title,
                command.Description,
                command.Email);
        }
    }
}
