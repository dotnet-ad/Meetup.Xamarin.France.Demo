namespace Meetup.Xamarin.France.Testing.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Reflection;

	/// <summary>
	/// Simple Ioc container for educational purposes. Use a real IoC container in production (AutoFac, Ninject ...).
	/// </summary>
	public class Ioc
	{
		#region Default

		private static Lazy<Ioc> instance = new Lazy<Ioc>(() => new Ioc());

		public static Ioc Default => instance.Value;

		#endregion

		private Dictionary<Type, object> instances = new Dictionary<Type, object>();

		private Dictionary<Type, Func<object>> registrations = new Dictionary<Type, Func<object>>();

		public void Register<TImpl>() => Register<TImpl, TImpl>();

		public void Register<TService, TImpl>() where TImpl : TService
		{
			this.registrations.Add(typeof(TService), () => this.CreateInstance(typeof(TImpl)));
		}

		public void Register<TService>(Func<TService> instanceCreator) => this.registrations.Add(typeof(TService), () => instanceCreator());

		public T GetInstance<T>() => (T)this.GetInstance(typeof(T));

		public T CreateInstance<T>() => (T)this.CreateInstance(typeof(T));

		public object GetInstance(Type serviceType)
		{
			object instance;

			if (this.instances.TryGetValue(serviceType, out instance))
			{
				return instance;
			}

			instance = this.CreateInstance(serviceType);
			instances[serviceType] = instance;
			return instance;
		}

		public object CreateInstance(Type serviceType)
		{
			Func<object> creator;
			if (this.registrations.TryGetValue(serviceType, out creator))
			{
				return creator();
			}

			if (!serviceType.GetTypeInfo().IsAbstract)
			{
				var ctor = serviceType.GetTypeInfo().DeclaredConstructors.Single();
				var parameterTypes = ctor.GetParameters().Select(p => p.ParameterType);
				var dependencies = parameterTypes.Select(t => this.GetInstance(t)).ToArray();
				return Activator.CreateInstance(serviceType, dependencies);
			}

			throw new InvalidOperationException("No registration for " + serviceType);
		}
	}
}
