namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Application.Common;
    using Journalists;
    using Application.Statistics;
    using Application.Common.Contracts;

    public class ArticleDetailsQuery : EntityCommand<int>, IRequest<ArticleDetailsOutputModel>
    {
        public class ArticleDetailsQueryHandler : IRequestHandler<ArticleDetailsQuery, ArticleDetailsOutputModel>
        {
            private readonly IArticleRepository articleRepository;
            private readonly IJournalistRepository journalistRepository;
            private readonly IStatisticsRepository statistics;
            private readonly ICurrentUser currentUser;

            public ArticleDetailsQueryHandler(
                IArticleRepository articleRepository, 
                IJournalistRepository journalistRepository,
                IStatisticsRepository statistics,
                ICurrentUser currentUser)
            {
                this.articleRepository = articleRepository;
                this.journalistRepository = journalistRepository;
                this.statistics = statistics;
                this.currentUser = currentUser;
            }

            public async Task<ArticleDetailsOutputModel> Handle(
                ArticleDetailsQuery request, 
                CancellationToken cancellationToken)
            {
                var articleDetails = await this.articleRepository.GetDetails(
                    request.Id,
                    cancellationToken);

                articleDetails.Journalist = await this.journalistRepository.GetDetailsByArticleId(
                    request.Id,
                    cancellationToken);

                await statistics.IncrementArticleViews(request.Id, currentUser.UserId);

                return articleDetails;
            }
        }
    }
}
