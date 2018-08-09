// Copyright (c) 2017 Nandalala Software Ltd 
// Nandalala Platformation Framework components

using Unity;
using System;
using Unity.Resolution;
using Nandalala.Paas.Core.IoC.Interfaces;

namespace Nandalala.Paas.Core.IoC.Unity
{
    /// <summary>
    /// Unity dependency resolver used for business and repository classes
    /// </summary>
    public class UnityDependencyResolver : BaseDependencyResolver
    {
        private readonly IUnityContainer _container;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container">Unity container</param>
        public UnityDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Resolves instance for Type T
        /// </summary>
        /// <typeparam name="T">Type to be resolved</typeparam>
        /// <returns>Instance of Resolved type</returns>
        protected override T ResolveInstance<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        ///  Resolves instance for Type T
        /// </summary>
        /// <typeparam name="T">Type to be resolved</typeparam>
        /// <param name="name"></param>
        /// <returns>Instance of Resolved type</returns>
        protected override T ResolveInstance<T>(string name)
        {
            return _container.Resolve<T>(name);
        }

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="parameterValue">Parameter value</param>
        /// <returns>Instance of Resolved Type T</returns>
        protected override T ResolveInstance<T>(string parameterName, object parameterValue)
        {
            return _container.Resolve<T>(new ParameterOverride(parameterName, parameterValue));
        }

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <param name="type">Type to resolve</param>
        /// <returns>Instance of Resolved Type</returns>
        protected override object ResolveInstance(Type type)
        {
            return _container.Resolve(type);
        }

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <param name="parameters">List of parameters</param>
        /// <returns></returns>
        protected override T ResolveInstance<T>(params Parameter[] parameters)
        {
            ParameterOverrides allParams = new ParameterOverrides();
            foreach (var param in parameters)
            {
                allParams.Add(param.ParameterName, param.ParameterValue);
            }

            return _container.Resolve<T>(allParams);
        }

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <param name="name">Named resolution</param>
        /// <param name="resolverOverrides">List of parameters</param>
        /// <returns></returns>
        protected override T ResolveInstance<T>(string name, params ResolverOverride[] resolverOverrides)
        {
            return _container.Resolve<T>(name, resolverOverrides);
        }
    }
}