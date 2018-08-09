// Copyright (c) 2017 Nandalala Software Ltd 
// Nandalala Platformation Framework components

using Unity;
using System;
using Unity.Registration;
using Unity.Lifetime;

namespace Nandalala.Paas.Core.IoC.Unity
{
    /// <summary>
    /// Utility for resolving Unity types
    /// </summary>
    public static class UnityUtil
    {
        /// <summary>
        /// Register type if not already registered
        /// </summary>
        /// <typeparam name="TFrom">TFrom</typeparam>
        /// <typeparam name="TTo">TTo</typeparam>
        /// <param name="container">IUnityContainer</param>
        public static void RegisterType<TFrom, TTo>(IUnityContainer container) where TTo : TFrom
        {
            container.RegisterType<TFrom, TTo>();
        }

        /// <summary>
        /// Check if a particular type has been registered or not.
        /// </summary>
        /// <typeparam name="TFrom">TFrom</typeparam>
        /// <param name="container">IUnityContainer</param>
        /// <returns>True if type is registered else false</returns>
        public static bool IsRegistered<TFrom>(IUnityContainer container)
        {
            return container.IsRegistered<TFrom>();
        }

        /// <summary>
        /// Check if a particular type has been registered or not with a name
        /// </summary>
        /// <typeparam name="TFrom">TFrom</typeparam>
        /// <param name="container">IUnityContainer</param>
        /// <param name="nameToCheck">Name it is registered with</param>
        /// <returns>True if type is registered else false</returns>
        public static bool IsRegistered<TFrom>(IUnityContainer container, string nameToCheck)
        {
            return container.IsRegistered<TFrom>(nameToCheck);
        }

        /// <summary>
        /// Register Type based on Constructor Name
        /// </summary>
        /// <typeparam name="TFrom">TFrom</typeparam>
        /// <typeparam name="TTo">TTo</typeparam>
        /// <param name="container">Container</param>
        /// <param name="name">ConstructorName</param>
        /// <param name="injectionMember">Injection Constructor Members</param>
        public static void RegisterType<TFrom, TTo>(IUnityContainer container, string name,
            params InjectionMember[] injectionMember) where TTo : TFrom
        {
            container.RegisterType<TFrom, TTo>(name, injectionMember);
        }

        /// <summary>
        /// Register Type based on Constructor Name
        /// </summary>
        /// <param name="container">Container</param>
        /// <param name="name">ConstructorName</param>
        /// <param name="injectionMember">Injection Constructor Members</param>
        /// <param name="lifetimeManager">Type of lifetime manager</param>
        /// <typeparam name="TFrom">TFrom</typeparam>
        /// <typeparam name="TTo">TTo</typeparam>
        public static void RegisterType<TFrom, TTo>(IUnityContainer container, string name,
            LifetimeManager lifetimeManager,
            params InjectionMember[] injectionMember) where TTo : TFrom
        {
            container.RegisterType<TFrom, TTo>(name, lifetimeManager, injectionMember);
        }

        /// <summary>
        /// Register Type
        /// </summary>
        /// <typeparam name="TFrom">TFrom</typeparam>
        /// <typeparam name="TTo">TTo</typeparam>
        /// <param name="container">Container</param>
        /// <param name="injectionMember">Injection Constructor Members</param>
        public static void RegisterType<TFrom, TTo>(IUnityContainer container, params InjectionMember[] injectionMember)
            where TTo : TFrom
        {
            container.RegisterType<TFrom, TTo>(injectionMember);
        }

        /// <summary>
        /// Register Type
        /// </summary>
        /// <typeparam name="TFrom">TFrom</typeparam>
        /// <typeparam name="TTo">TTo</typeparam>
        /// <param name="container">Container</param>
        /// <param name="lifetimeManager">LifetimeManager</param>
        /// <param name="injectionMember">Injection Constructor Members</param>
        public static void RegisterType<TFrom, TTo>(IUnityContainer container, LifetimeManager lifetimeManager,
            params InjectionMember[] injectionMember) where TTo : TFrom
        {
            container.RegisterType<TFrom, TTo>(lifetimeManager, injectionMember);
        }

        /// <summary>
        /// Register type if not already registered
        /// </summary>
        /// <param name="container">IUnityContainer</param>
        /// <param name="from">Type to convert from</param>
        /// <param name="to">Type to convert to</param>
        public static void RegisterType(IUnityContainer container, Type from, Type to)
        {
            container.RegisterType(from, to);
        }

        /// <summary>
        /// Register type if not already registered
        /// </summary>
        /// <param name="container">IUnityContainer</param>
        /// <param name="from">Type to convert from</param>
        /// <param name="to">Type to convert to</param>
        /// <param name="name">The name.</param>
        /// <param name="injectionMember">The injection member.</param>
        public static void RegisterType(IUnityContainer container, Type from, Type to, string name,
            params InjectionMember[] injectionMember)
        {
            container.RegisterType(from, to, name, injectionMember);
        }

        /// <summary>
        /// Register instance for a type with an instance
        /// </summary>
        /// <param name="container">Unity Container</param>
        /// <param name="type">Type of instance to be registered</param>
        /// <param name="instance">Instance to be registered</param>
        public static void RegisterInstance(IUnityContainer container, Type type, object instance)
        {
            container.RegisterInstance(type, instance);
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <param name="instance">The instance.</param>
        public static void RegisterInstance(IUnityContainer container, Type type, string name, object instance)
        {
            container.RegisterInstance(type, name, instance);
        }
    }
}