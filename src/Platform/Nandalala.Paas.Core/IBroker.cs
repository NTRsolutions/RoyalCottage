using Nandalala.Paas.Core.Command;
using Nandalala.Paas.Core.Eventing;
using Nandalala.Paas.Core.Query;

namespace Nandalala.Paas.Core
{
    public interface IBroker
    {
        TResult Execute<TResult>(QueryBase<TResult> queryBase);
        void Dispatch<TCommand>(TCommand command) where TCommand : CommandBase;
        void Raise<TEvent>(TEvent eventToHandle) where TEvent : IEvent;
    }
}
