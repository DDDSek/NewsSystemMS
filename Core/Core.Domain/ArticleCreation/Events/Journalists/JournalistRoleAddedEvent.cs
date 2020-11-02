namespace NewsSystem.Domain.ArticleCreation.Events.Journalists
{
    using NewsSystem.Domain.Common;

    public class JournalistRoleAddedEvent : IDomainEvent
    {
        public string UserId { get; private set; } = default!;

        public JournalistRoleAddedEvent(string userId)
             => this.UserId = userId;
    }
}
