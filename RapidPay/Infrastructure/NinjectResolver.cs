using Ninject;
using Ninject.Extensions.ChildKernel;
using RapidPay.Services.Abstract;
using RapidPay.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace RapidPay.Infrastructure
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {
        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {

        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
           kernel.Bind<ICardService>().To<CardService>().InSingletonScope();
            kernel.Bind<IFeeService>().To<FeeService>().InSingletonScope();
            return kernel;
        }
    }
}