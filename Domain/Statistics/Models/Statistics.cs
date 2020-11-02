namespace NewsSystem.Domain.Statistics.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Domain.Common.Models;

    public class Statistics : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<ArticleView> articleViews;

        internal Statistics()
        {
            this.TotalArticles = 0;
            this.TotalComments = 0;
            this.TotalUpdatedArticleTitles = 0;
            this.TotalUpdatedArticleContent = 0;

            this.articleViews = new HashSet<ArticleView>();
        }

        public int TotalArticles { get; private set; }

        public int TotalUpdatedArticleTitles { get; private set; }

        public int TotalUpdatedArticleContent { get; private set; }

        public int TotalComments { get; private set; }

        public IReadOnlyCollection<ArticleView> ArticleViews
            => this.articleViews.ToList().AsReadOnly();

        public void AddArticle()
            => this.TotalArticles++;

        public void UpdateArticleTitle()
            => this.TotalUpdatedArticleTitles++;

        public void UpdateArticleContent()
            => this.TotalUpdatedArticleContent++;


        public void AddComment()
          => this.TotalComments++; 

        public void AddArticleView(int аrticleId, string? userId)
            => this.articleViews.Add(new ArticleView(аrticleId, userId));
    }
}
