namespace Bootstrapper.UnitTest;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Utility;

/// <summary>
///     Test scenarios for Bootstrapper.
/// </summary>
public class BootstrapperTests
{
	/// <summary>
	///     Scenario to test bootstrap with Assembly scan.
	/// </summary>
	[Fact]
	public void Test_Bootstrap_WithAssemblyScan()
	{
		var collection = new ServiceCollection();
		var configuration = new ConfigurationBuilder().Build();

		collection.Bootstrap(configuration);

		var serviceProvider = collection.BuildServiceProvider();

		var service = serviceProvider.GetService<TestTransient>();

		Assert.NotNull(service);
	}

	/// <summary>
	///     Scenario to test bootstrap not exist without bootstrapping.
	/// </summary>
	[Fact]
	public void Test_Bootstrap_NotExist()
	{
		var collection = new ServiceCollection();

		var serviceProvider = collection.BuildServiceProvider();

		var service = serviceProvider.GetService<TestTransient>();

		Assert.Null(service);
	}

	/// <summary>
	///     Scenario to test bootstrap with selective assemblies scan.
	/// </summary>
	[Fact]
	public void Test_Bootstrap_WithSelectiveAssemblies()
	{
		var collection = new ServiceCollection();
		var configuration = new ConfigurationBuilder().Build();

		collection.Bootstrap(configuration, typeof(BootstrapperTests).Assembly);

		var serviceProvider = collection.BuildServiceProvider();

		var service = serviceProvider.GetService<TestTransient>();

		Assert.NotNull(service);
	}

	/// <summary>
	///     Scenario to test bootstrap not exist with selective assemblies.
	/// </summary>
	[Fact]
	public void Test_Bootstrap_NotExistWithSelectiveAssemblies()
	{
		var collection = new ServiceCollection();
		var configuration = new ConfigurationBuilder().Build();

		collection.Bootstrap(configuration, typeof(IBootstrapper).Assembly);

		var serviceProvider = collection.BuildServiceProvider();

		var service = serviceProvider.GetService<TestTransient>();

		Assert.Null(service);
	}
}
