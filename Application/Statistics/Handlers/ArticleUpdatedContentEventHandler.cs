namespace NewsSystem.Application.Statistics.Handlers
{
    using System.Threading.Tasks;

    using Application.Common;
    using Domain.ArticleCreation.Events.Journalists;

    public class ArticleUpdatedContentEventHandler : IEventHandler<ArticleUpdatedContentEvent>
    {
        private readonly IStatisticsRepository statistics;

        public ArticleUpdatedContentEventHandler(IStatisticsRepository statistics)
            => this.statistics = statistics;

        public Task Handle(ArticleUpdatedContentEvent domainEvent)
             => this.statistics.IncrementUpdatedContentArticles();
    }
}
