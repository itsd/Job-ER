using JobER.Domain.Interfaces.Services;
using JobER.Repositories;
using JobER.Repositories.Context;
using JobER.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JobER.UnitTests {
    public static class Resolver {

        private static IUnityContainer _container;

        static Resolver() {
            _container = new UnityContainer();

            _container.RegisterTypes(
               AllClasses.FromAssemblies(
                   typeof(IUserService).Assembly,
                   typeof(UserService).Assembly,
                   typeof(UserRepository).Assembly
               ),
               WithMappings.FromMatchingInterface,
               WithName.Default,
               x => new TransientLifetimeManager()
           );

            _container.RegisterType(
                typeof(EntityContext),
                new ContainerControlledLifetimeManager()
            );
        }

        public static T GetService<T>() {
            return _container.Resolve<T>();
        }
    }
}