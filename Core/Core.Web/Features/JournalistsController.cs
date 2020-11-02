namespace NewsSystem.Web.Features
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Application.Common;
   // using Application.ArticleCreation.Journalists.Commands.Edit;
    using Application.ArticleCreation.Journalists.Queries.Details;
    using NewsSystem.Application.ArticleCreation.Journalists.Commands.Create;

    public class JournalistsController : ApiController
    {

 

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<JournalistDetailsOutputModel>> Details(
            [FromRoute] JournalistDetailsQuery query)
            => await this.Send(query);

        //[HttpPut]
        //[Route(Id)]
        //public async Task<ActionResult> Edit(
        //    int id, EditJournalistCommand command)
        //    => await this.Send(command.SetId(id));

        [HttpPost]
        [Authorize]
        [Route(nameof(Journalist))]
        public async Task<ActionResult> Journalist(RegisterJournalistCommand command)
            => await base.Send(command);
    }
}
