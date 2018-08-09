// Copyright (c) 2017 Nandalala Software Ltd 
// Nandalala Platformation Framework components

using System;
using Unity.Resolution;
using Nandalala.Paas.Core.IoC.Interfaces;

namespace Nandalala.Paas.Core.IoC
{
    /// <summary>
    /// Abstract class the dependency resolver
    /// </summary>
    public abstract class BaseDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>Resolved Type</returns>
        public T Resolve<T>()
        {
            try
            {
                return ResolveInstance<T>();
            }
            catch (Exception ex)
            {
                throw new DependencyResolverException(typeof(T), ex);
            }
        }

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <param name="name">Name of the parameter</param>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>Resolved Type</returns>
        public T Resolve<T>(string name)
        {
            try
            {
                return ResolveInstance<T>(name);
            }
            catch (Exception ex)
            {
                throw new DependencyResolverException(typeof(T), ex);
            }
        }

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="parameterValue">Parameter value</param>
        /// <returns>Instance of Resolved Type T</returns>
        public T Resolve<T>(string parameterName, object parameterValue)
        {
            try
            {
                return ResolveInstance<T>(parameterName, parameterValue);
            }
            catch (Exception ex)
            {
                throw new DependencyResolverException(typeof(T), ex);
            }
        }

        /// <summary>
        /// Resolves with a Type
        /// </summary>
        /// <param name="type">Type to reslove</param>
        /// <returns>Resolved object</returns>
        public object Resolve(Type type)
        {
            try
            {
                return ResolveInstance(type);
            }
            catch (Exception ex)
            {
                throw new DependencyResolverException(type, ex);
            }
        }

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <param name="parameters">List of parameters</param>
        /// <returns></returns>
        public T Resolve<T>(params Parameter[] parameters)
        {
            return ResolveInstance<T>(parameters);
        }

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <param name="name">Named resolution</param>
        /// <param name="resolverOverrides">List of parameters</param>
        /// <returns></returns>
        public T Resolve<T>(string name, params ResolverOverride[] resolverOverrides)
        {
            return ResolveInstance<T>(name, resolverOverrides);
        }

        /// <summary>
        /// Resolves instance of Type T
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <returns>Instance of T</returns>
        protected abstract T ResolveInstance<T>();

        /// <summary>
        /// Resolves instance of Type
        /// </summary>
        /// <param name="type">Type to be resolved</param>
        /// <returns>Instance of Type type</returns>
        protected abstract object ResolveInstance(Type type);

        /// <summary>
        /// Resolves with a paramter name
        /// </summary>
        /// <typeparam name="T">Type to be resolved</typeparam>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="parameterValue">Value of the parameter</param>
        /// <returns>Instance of Type T</returns>
        protected abstract T ResolveInstance<T>(string parameterName, object parameterValue);

        /// <summary>
        /// Resolve with name
        /// </summary>
        /// <typeparam name="T">Type to be resolved</typeparam>
        /// <param name="name">name</param>
        /// <returns>Instance of Type T</returns>
        protected abstract T ResolveInstance<T>(string name);

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <param name="parameters">List of parameters</param>
        /// <returns></returns>
        protected abstract T ResolveInstance<T>(params Parameter[] parameters);

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <param name="name">Named resolution</param>
        /// <param name="resolverOverrides">List of parameters</param>
        /// <returns></returns>
        protected abstract T ResolveInstance<T>(string name, params ResolverOverride[] resolverOverrides);
    }
}