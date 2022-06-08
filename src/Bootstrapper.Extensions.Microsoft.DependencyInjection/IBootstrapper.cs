namespace Bootstrapper.Extensions.Microsoft.DependencyInjection;

using global::Microsoft.Extensions.Configuration;
using global::Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Bootstrapper interface to collect registered implementations and bootstrap them into the main DI container.
/// </summary>
public interface IBootstrapper
{
	/// <summary>
	///     Register implementations into <see cref="IServiceCollection" />.
	/// </summary>
	/// <param name="collection">The instance of <see cref="IServiceCollection" />.</param>
	/// <param name="configuration">The instance of <see cref="IConfiguration" />.</param>
	/// <returns>Instance of <see cref="IServiceCollection" /> the contains registered implementations.</returns>
	IServiceCollection Initialize(IServiceCollection collection, IConfiguration configuration);
}
