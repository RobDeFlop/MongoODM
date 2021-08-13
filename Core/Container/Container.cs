using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SharpMongoDB.Core.Container.Attributes;

namespace SharpMongoDB.Core.Container
{
    public class Container
    {
        public static ServiceProvider ServiceProvider { get; set; }
        private ServiceCollection _container { get; set; }
        private IEnumerable<Type> _singletons { get; set; }
        private IEnumerable<Type> _scopeds { get; set; }
        private IEnumerable<Type> _transients { get; set; }

        public Container()
        {
            _container = new ServiceCollection();
            
            GetClassesWithAttributes();
            RegisterPreloadClasses();
            
            ServiceProvider = _container.BuildServiceProvider();
        }

        private IEnumerable<Type> GetClassesByAttribute(Type attributeName)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach(Type type in assembly.GetTypes()) {
                    if (type.GetCustomAttributes(attributeName, true).Length > 0) {
                        yield return type;
                    }
                }
            }
        }

        private void GetClassesWithAttributes()
        {
            _singletons = GetClassesByAttribute(typeof(Singleton));
            _scopeds = GetClassesByAttribute(typeof(Scoped));
            _transients = GetClassesByAttribute(typeof(Transient));
        }

        private void RegisterPreloadClasses()
        {
            foreach (Type classType in _singletons)
            {
                Console.WriteLine($"Registered ${classType} as singleton");
                RegisterSingleton(classType);
            }

            foreach (Type classType in _scopeds)
            {
                Console.WriteLine($"Registered ${classType} as scoped");
                RegisterScoped(classType);
            }

            foreach (Type classType in _transients)
            {
                Console.WriteLine($"Registered ${classType} as transient");
                RegisterTransient(classType);
            }
        }
        
        
        public void RegisterSingleton(Type singletonClass)
        {
            _container.AddSingleton(singletonClass);
        }

        public void RegisterScoped(Type scopedClass)
        {
            _container.AddScoped(scopedClass);
        }

        public void RegisterTransient(Type transientClass)
        {
            _container.AddTransient(transientClass);
        }
    }
    
}