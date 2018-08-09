// Copyright (c) 2017 Nandalala Software Ltd 
// Nandalala Platformation Framework components

using System;
using Unity.Resolution;

namespace Nandalala.Paas.Core.IoC.Interfaces
{
    /// <summary>
    /// Common dependency resolver interface
    /// </summary>
    public interface IDependencyResolver
    {
        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>Resolved Type</returns>
        T Resolve<T>();

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>Resolved Type</returns>
        T Resolve<T>(string name);

        /// <summary>
        /// Resolves with a Type
        /// </summary>
        /// <param name="type">Type to reslove</param>
        /// <returns>Resolved object</returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="parameterValue">Parameter value</param>
        /// <returns>Instance of Resolved Type T</returns>
        T Resolve<T>(string parameterName, object parameterValue);

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <param name="parameters">List of parameters</param>
        /// <returns></returns>
        T Resolve<T>(params Parameter[] parameters);

        /// <summary>
        /// Resolves with Type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Named resolution</param>
        /// <param name="resolverOverrides">List of parameters</param>
        /// <returns></returns>
        T Resolve<T>(string name, params ResolverOverride[] resolverOverrides);
    }

    /// <summary>
    /// Parameter to accept key value
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Parameter Name
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Parameter value
        /// </summary>
        public object ParameterValue { get; set; }
    }
}