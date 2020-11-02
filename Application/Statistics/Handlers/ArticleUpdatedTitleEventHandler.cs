namespace NewsSystem.Application.Statistics.Handlers
{
    using System.Threading.Tasks;

    using Application.Common;
    using Domain.ArticleCreation.Events.Journalists;

    public class ArticleUpdatedTitleEventHandler : IEventHandler<ArticleUpdatedTitleEvent>
    {
        private readonly IStatisticsRepository statistics;

        public ArticleUpdatedTitleEventHandler(IStatisticsRepository statistics)
            => this.statistics = statistics;

        public Task Handle(ArticleUpdatedTitleEvent domainEvent)
             => this.statistics.IncrementUpdatedTitleArticles();
    }
}
