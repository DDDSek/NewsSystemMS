namespace NewsSystem.Application.Identity.Handlers
{
    using NewsSystem.Application.Common;
    using NewsSystem.Application.Statistics.Handlers;
    using NewsSystem.Domain.ArticleCreation.Events.Journalists;
    using System.Threading.Tasks;

    public class JournalistRoleAddedEventHandler : IEventHandler<JournalistRoleAddedEvent> 
    {
        //private readonly string userId;

        private readonly IIdentity identity;

        public JournalistRoleAddedEventHandler(IIdentity identity)//, string userId)
        {
            this.identity = identity;
            //this.userId = userId;
        } 

        public Task Handle(JournalistRoleAddedEvent domainEvent)
        // NOT TESTED !
        // => this.identity.AddToRoleJournalist(userId);
        {
            var userId = domainEvent.UserId;
           return  this.identity.AddToRoleJournalist(userId);
        }

    }
}
