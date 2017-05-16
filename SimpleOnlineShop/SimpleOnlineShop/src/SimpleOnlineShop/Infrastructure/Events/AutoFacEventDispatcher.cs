using System.Reflection;
using Autofac;
using Autofac.Features.Variance;
using SimpleOnlineShop.SimpleOnlineShop.Domain;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure.Events
{
    public class AutoFacEventDispatcher : IEventDispatcher
    {
        private readonly IComponentContext _container;

        public AutoFacEventDispatcher()
        {
            var builder = new ContainerBuilder();
            var assembly = typeof(AutoFacEventDispatcher).GetTypeInfo().Assembly;

            builder.RegisterSource(new ContravariantRegistrationSource());

            builder
                .RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IDomainEventHandler<>))
                .AsImplementedInterfaces();

            _container = builder.Build();
        }

        public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            var handler = _container.Resolve<IDomainEventHandler<TEvent>>();

            handler.HandleEvent(eventToDispatch);
        }
    }
}