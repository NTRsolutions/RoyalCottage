// Copyright (c) 2017 Nandalala Software Ltd 
// Nandalala Platformation Framework components

using System;

namespace Nandalala.Paas.Core.IoC
{
    /// <summary>
    /// Dependency exception object
    /// </summary>
    public class DependencyResolverException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dependencyType">Type of dependency</param>
        /// <param name="innerException">Inner exception</param>
        public DependencyResolverException(Type dependencyType, Exception innerException = null)
            : base(
                $"Could not resolve type '{dependencyType}'.  Make sure you have configured your Ioc container for this type.  View the InnerException for more details.",
                innerException)
        {
            DependencyType = dependencyType;
        }

        /// <summary>
        /// Dependency Type
        /// </summary>
        public Type DependencyType { get; internal set; }
    }
}