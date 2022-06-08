namespace Bootstrapper.UnitTest.Utility;

using Extensions.Microsoft.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Implementation of <see cref="IBootstrapper"/>.
/// </summary>
internal class TestBootstrapper : IBootstrapper
{
	/// <inheritdoc />
	public IServiceCollection Initialize(IServiceCollection collection, IConfiguration configuration)
	{
		collection.AddTransient<TestTransient>();
		return collection;
	}
}
