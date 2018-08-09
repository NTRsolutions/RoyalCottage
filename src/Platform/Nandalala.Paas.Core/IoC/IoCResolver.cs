// Copyright (c) 2017 Nandalala Software Ltd 
// Nandalala Platformation Framework components

using Nandalala.Paas.Core.IoC.Interfaces;

namespace Nandalala.Paas.Core.IoC
{
    /// <summary>
    /// IoC resolver class
    /// </summary>
    public static class IoCResolver
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static IoCResolver()
        {
            Current = null;
        }

        /// <summary>
        /// Current dependency resolver
        /// </summary>
        public static IDependencyResolver Current { get; private set; }

        /// <summary>
        /// Sets current dependency resolver
        /// </summary>
        /// <param name="resolver">Dependency resolver</param>
        public static void SetDependencyResolver(IDependencyResolver resolver)
        {
            Current = resolver;
        }
    }
}