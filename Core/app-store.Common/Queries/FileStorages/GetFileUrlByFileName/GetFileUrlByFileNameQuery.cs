using app_store.Domain.Helper;
using MediatR;

namespace app_store.Common.Queries.FileStorages.GetFileUrlByFileName
{
    public record GetFileUrlByFileNameQuery (
        string FileName): IRequest<Result<GetFileUrlByFileNameResponse>>;
}
