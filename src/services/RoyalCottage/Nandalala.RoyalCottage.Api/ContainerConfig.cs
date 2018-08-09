using SimpleInjector;
using Nandalala.RoyalCottage.Domain.Products;
using Nandalala.Paas.Core.Command;
using Nandalala.Paas.Core.Eventing;
using Nandalala.Paas.Core.Query;
using System;

namespace Nandalala.RoyalCottage.Api
{
    public class ContainerConfig
    {
        
        public static void Configure(Container container)
        {

            container.Register(typeof(IQueryHandler<,>),
                   new[] { typeof(CreateProductHandler).Assembly });

            container.Register(typeof(ICommandHandler<>),
                   new[] { typeof(CreateProductHandler).Assembly });
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(CommandValidator<>));


            container.Register(typeof(IEventHandler<>),
                  new[] { typeof(CreateProductHandler).Assembly });

            container.Register<IServiceProvider>(() => container);
        }

        
    }
}
