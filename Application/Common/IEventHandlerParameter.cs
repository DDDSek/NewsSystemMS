namespace NewsSystem.Application.Common
{
    using System.Threading.Tasks;
    using Domain.Common;

    public interface IEventHandlerParameter<in TEvent, in parameter>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent, string parameter);
    }
}
