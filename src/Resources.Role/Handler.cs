using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Brighid.Identity.Client;

using Lambdajection.Attributes;
using Lambdajection.CustomResource;

using Microsoft.Extensions.Logging;

namespace Brighid.Identity.Resources.Role
{
    /// <summary>
    /// Custom resource handler for commands.
    /// </summary>
    [CustomResourceProvider(typeof(Startup))]
    public partial class Handler
    {
        private readonly IRolesClient rolesClient;
        private readonly ILogger<Handler> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Handler" /> class.
        /// </summary>
        /// <param name="rolesClient">Client used to manage applications with.</param>
        /// <param name="logger">Logger used to log info to some destination(s).</param>
        public Handler(
            IRolesClient rolesClient,
            ILogger<Handler> logger
        )
        {
            this.rolesClient = rolesClient;
            this.logger = logger;
        }

        /// <summary>
        /// Creates a new application.
        /// </summary>
        /// <param name="request">Data to pass to the identity service for creating an application.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Create(CustomResourceRequest<RoleRequest> request, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Received create role request: {@request}", JsonSerializer.Serialize(request));
            var result = await rolesClient.Post(request.ResourceProperties, cancellationToken);
            logger.LogInformation("Received create role response: {@response}", JsonSerializer.Serialize(result));

            return new OutputData
            {
                Id = result.Id.ToString(),
                Name = result.Name,
            };
        }

        /// <summary>
        /// Updates an existing application.
        /// </summary>
        /// <param name="request">Data to pass to the commands service for updating an application.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Update(CustomResourceRequest<RoleRequest> request, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Received update role request: {@request}", JsonSerializer.Serialize(request));
            var result = await rolesClient.Put(Guid.Parse(request.PhysicalResourceId), request.ResourceProperties, cancellationToken);
            logger.LogInformation("Received update role response: {@response}", JsonSerializer.Serialize(result));

            return new OutputData
            {
                Id = result.Id.ToString(),
                Name = result.Name,
            };
        }

        /// <summary>
        /// Updates an existing application.
        /// </summary>
        /// <param name="request">Data to pass to the commands service for updating an application.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Delete(CustomResourceRequest<RoleRequest> request, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Received delete role request: {@request}", JsonSerializer.Serialize(request));
            var result = await rolesClient.Delete(Guid.Parse(request.PhysicalResourceId), cancellationToken);
            logger.LogInformation("Received delete role response: {@response}", JsonSerializer.Serialize(result));

            return new OutputData
            {
                Id = result.Id.ToString(),
                Name = result.Name,
            };
        }
    }
}
