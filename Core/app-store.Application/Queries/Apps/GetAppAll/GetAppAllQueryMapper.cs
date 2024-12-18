using app_store.Common.Queries.Apps.GetAppAll;
using app_store.Common.Queries.Categories.GetCategoryAll;
using app_store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_store.Application.Queries.Apps.GetAppAll
{
    public class GetAppAllQueryMapper
    {
        public static IEnumerable<GetAppAllResponse> Map(IEnumerable<App> Apps)
        {
            List<GetAppAllResponse> getAppAllResponses = new List<GetAppAllResponse>();
            foreach (var app in Apps)
            {
                getAppAllResponses.Add(new GetAppAllResponse
                {
                    Id = app.Id,
                    Title = app.Title,
                    IconId = app.IconId,
                    CategoryId = app.CategoryId,
                });
            }
            return getAppAllResponses.AsEnumerable();
        }
    }
}
