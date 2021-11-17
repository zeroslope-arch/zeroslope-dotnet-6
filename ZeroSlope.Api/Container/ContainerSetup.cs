using AutoMapper.Configuration;
using ZeroSlope.Packages.DotNet.AutoMapper.Installers;
using ZeroSlope.Packages.DotNet.IService.Installers;
using ZeroSlope.Packages.DotNet.Redis.Installers;
using ZeroSlope.Packages.DotNet.Serilogger.Installers;

namespace ZeroSlope.Api.Container
{
    public class ContainerSetup
    {
		private readonly ContainerSettings _options;

		public ContainerSetup(ContainerSettings options)
		{
			_options = options;
		}

		public void Install(IServiceCollection serviceCollection)
		{
			new SeriloggerInstaller()
				.Install(serviceCollection);

			new IDbConnectionInstaller(_options.Database.SqlConnectionString)
				.Install(serviceCollection);

			new AutoMapperInstaller(new MapperConfigurationExpression() { })
				.Install(serviceCollection);

            new RedisInstaller(_options.Caching.RedisHost, _options.Caching.RedisPort, _options.Caching.RedisDatabaseId)
                .Install(serviceCollection);

            serviceCollection.Scan(scan => new IServiceInstaller(typeof(Domain.Init)).Install(scan));
		}
	}
}
