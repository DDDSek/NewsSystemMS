namespace NewsSystem.Web.Features
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Application.Statistics.Queries.Current;

    public class StatisticsController : ApiController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<GetCurrentStatisticsOutputModel>> Details(
            [FromRoute] GetCurrentStatisticsQuery query)
            => await this.Send(query);
    }
}
