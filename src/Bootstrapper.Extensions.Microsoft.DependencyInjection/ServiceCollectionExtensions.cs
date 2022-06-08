// ReSharper disable once CheckNamespace

namespace Microsoft.Extensions.Hosting;

using System.Reflection;
using Bootstrapper.Extensions.Microsoft.DependencyInjection;
using Bootstrapper.Extensions.Microsoft.DependencyInjection.Utility;
using Configuration;
using DependencyInjection;

/// <summary>
///     Service collection extension.
/// </summary>
public static class ServiceCollectionExtensions
{
	/// <summary>
	///     Collect all registered implementations by <see cref="IBootstrapper" /> and add them to DI container.
	/// </summary>
	/// <param name="services">Instance of <see cref="IServiceCollection" />.</param>
	/// <param name="configuration">Instance of <see cref="IConfiguration" />.</param>
	/// <returns>Returns <see cref="IServiceCollection" /> after boostrap.</returns>
	public static IServiceCollection Bootstrap(this IServiceCollection services, IConfiguration configuration)
	{
		var list = Assembly
			.GetCallingAssembly()
			.GetReferencedAssemblies().Select(Assembly.Load)
			.ToList();

		var callingAssembly = Assembly.GetCallingAssembly();

		if (!list.Contains(callingAssembly))
		{
			list.Add(callingAssembly);
		}

		list
			.ScanBootstrappers()
			.ForEach(b => b?.Initialize(services, configuration));

		return services;
	}

	/// <summary>
	///     Collect all registered implementations by <see cref="IBootstrapper" /> from given assembly(s) and add them to DI container.
	/// </summary>
	/// <param name="services">Instance of <see cref="IServiceCollection" />.</param>
	/// <param name="configuration">Instance of <see cref="IConfiguration" />.</param>
	/// <param name="assemblies">List of referenced assembly(s).</param>
	/// <returns>Returns <see cref="IServiceCollection" /> after boostrap.</returns>
	public static IServiceCollection Bootstrap(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
	{
		assemblies.ScanBootstrappers()
			.ForEach(b => b?.Initialize(services, configuration));

		return services;
	}
}
