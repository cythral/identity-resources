using System;
using System.Threading;
using System.Threading.Tasks;

using Brighid.Identity.Client;

using Lambdajection.Attributes;
using Lambdajection.CustomResource;

namespace Brighid.Identity.Resources.Role
{
    /// <summary>
    /// Custom resource handler for commands.
    /// </summary>
    [CustomResourceProvider(typeof(Startup))]
    public partial class Handler
    {
        private readonly IRolesClient rolesClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Handler" /> class.
        /// </summary>
        /// <param name="rolesClient">Client used to manage applications with.</param>
        public Handler(
            IRolesClient rolesClient
        )
        {
            this.rolesClient = rolesClient;
        }

        /// <summary>
        /// Creates a new application.
        /// </summary>
        /// <param name="request">Data to pass to the identity service for creating an application.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Create(CustomResourceRequest<RoleRequest> request, CancellationToken cancellationToken = default)
        {
            var result = await rolesClient.Post(request.ResourceProperties, cancellationToken);
            return new OutputData
            {
                Id = result.Id.ToString(),
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
            var result = await rolesClient.Put(Guid.Parse(request.PhysicalResourceId), request.ResourceProperties, cancellationToken);
            return new OutputData
            {
                Id = result.Id.ToString(),
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
            var result = await rolesClient.Delete(Guid.Parse(request.PhysicalResourceId), cancellationToken);
            return new OutputData
            {
                Id = result.Id.ToString(),
            };
        }
    }
}
