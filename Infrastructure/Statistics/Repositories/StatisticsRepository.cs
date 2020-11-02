namespace NewsSystem.Infrastructure.Statistics.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using AutoMapper;
    using Common.Persistence;

    using Application.Statistics;
    using Application.Statistics.Queries.Current;

    using Domain.Statistics.Models;

    internal class StatisticsRepository : DataRepository<IStatisticsDbContext, Statistics>, IStatisticsRepository
    {
        private readonly IMapper mapper;

        public StatisticsRepository(IStatisticsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<GetCurrentStatisticsOutputModel> GetCurrent(CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetCurrentStatisticsOutputModel>(this.All())
                .SingleOrDefaultAsync(cancellationToken);

        public async Task<int> GetArticleViews(int articleId, CancellationToken cancellationToken = default)
            => await this.Data
                .ArticleViews
                .CountAsync(cav => cav.ArticleId == articleId, cancellationToken);

        public async Task IncrementArticleViews(int articleId, string userId, CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken);

            statistics.AddArticleView(articleId, userId);
            await this.Save(statistics, cancellationToken);
        }


        public async Task IncrementArticles(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken);

            statistics.AddArticle();

            await this.Save(statistics, cancellationToken);
        }

        public async Task IncrementUpdatedTitleArticles(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken);

            statistics.UpdateArticleTitle();

            await this.Save(statistics, cancellationToken);
        }

        public async Task IncrementUpdatedContentArticles(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken);

            statistics.UpdateArticleContent();

            await this.Save(statistics, cancellationToken);
        }

        public async Task IncrementComments(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken); 

            statistics.AddComment(); 

            await this.Save(statistics, cancellationToken);
        }
    }
}
