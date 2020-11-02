namespace NewsSystem.Application.Statistics.Handlers
{
    using System.Threading.Tasks;

    using Application.Common;
    using Domain.ArticleCreation.Events.Articles;

    public class CommentAddedEventHandler : IEventHandler<CommentAddedEvent>
    {
        private readonly IStatisticsRepository statistics;

        public CommentAddedEventHandler(IStatisticsRepository statistics)
            => this.statistics = statistics;

        public Task Handle(CommentAddedEvent domainEvent)
            => this.statistics.IncrementComments();
    }
}
