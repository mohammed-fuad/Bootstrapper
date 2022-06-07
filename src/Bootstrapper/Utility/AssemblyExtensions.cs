namespace Bootstrapper.Utility;

using System.Reflection;

/// <summary>
/// Extension methods for <see cref="Assembly"/> to scan <see cref="IBootstrapper"/>.
/// </summary>
internal static class AssemblyExtensions
{
	/// <summary>
	///     Retrieve <see cref="IBootstrapper" /> instance from given assemblies.
	/// </summary>
	/// <param name="assemblies">Assemblies to scan.</param>
	/// <returns>List of found Bootstrappers.</returns>
	public static List<IBootstrapper?> ScanBootstrappers(this IEnumerable<Assembly> assemblies)
	{
		return assemblies.SelectMany(a => a.GetTypes().Where(t => t.IsClass && t.GetInterfaces().Contains(typeof(IBootstrapper))))
			.Select(t => Activator.CreateInstance(t) as IBootstrapper)
			.Where(b => b != null)
			.ToList();
	}
}
