using Castle.DynamicProxy;
using Core.Abstracts.Autofac.Logging;
using Core.Abstracts.Autofac.Perfromance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttribute = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttribute = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttribute.Add(new PerformanceAspect(5));
            classAttribute.AddRange(methodAttribute);

            return classAttribute.OrderBy(x => x.Priority).ToArray();
        }
    }
}
