using SimpleInjector;
using Nandalala.Paas.Core.Command;
using Nandalala.Paas.Core.Eventing;
using Nandalala.Paas.Core.Query;
using System;

namespace Nandalala.Paas.Core
{
    public class Broker : IBroker
    {
        private readonly Container _container;
        
        public Broker(Container container)
        {
            _container = container;
        }

        public TResult Execute<TResult>(QueryBase<TResult> queryBase)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryBase.GetType(), typeof(TResult));

            dynamic handler = _container.GetInstance(handlerType);

            try
            {

                return handler.Handle((dynamic)queryBase);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : CommandBase
        {
            var handler = _container.GetInstance<ICommandHandler<TCommand>>();

            try
            {
                handler.Handle(command);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Raise<TEvent>(TEvent eventToHandle) where TEvent : IEvent
        {
            var handlers = _container.GetAllInstances<IEventHandler<TEvent>>();
            
            try
            {
                foreach (var handler in handlers)
                {
                    handler.Handle(eventToHandle);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}
