using System.Text.Json;

using Lambdajection.Core;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brighid.Identity.Resources.Application
{
    /// <inheritdoc />
    public class Startup : ILambdaStartup
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">Configuration to use when configuring startup services.</param>
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <inheritdoc />
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureBrighidIdentity<IdentityConfig>(configuration.GetSection("Identity"));
            services.UseBrighidIdentityApplications();
            services.AddSingleton(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }
    }
}
