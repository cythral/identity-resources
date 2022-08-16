using System;
using System.Threading;
using System.Threading.Tasks;

using Brighid.Identity.Client;

using Lambdajection.Attributes;
using Lambdajection.CustomResource;

namespace Brighid.Identity.Resources.Application
{
    /// <summary>
    /// Custom resource handler for commands.
    /// </summary>
    [CustomResourceProvider(typeof(Startup))]
    public partial class Handler
    {
        private readonly IApplicationsClient applicationsClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Handler" /> class.
        /// </summary>
        /// <param name="applicationsClient">Client used to manage applications with.</param>
        public Handler(
            IApplicationsClient applicationsClient
        )
        {
            this.applicationsClient = applicationsClient;
        }

        /// <summary>
        /// Creates a new application.
        /// </summary>
        /// <param name="request">Data to pass to the identity service for creating an application.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Create(CustomResourceRequest<ApplicationRequest> request, CancellationToken cancellationToken = default)
        {
            var result = await applicationsClient.Create(request.ResourceProperties, cancellationToken);
            return new OutputData
            {
                Id = result.Id.ToString(),
                EncryptedSecret = result.EncryptedSecret,
            };
        }

        /// <summary>
        /// Updates an existing application.
        /// </summary>
        /// <param name="request">Data to pass to the commands service for updating an application.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Update(CustomResourceRequest<ApplicationRequest> request, CancellationToken cancellationToken = default)
        {
            var result = await applicationsClient.UpdateById(Guid.Parse(request.PhysicalResourceId!), request.ResourceProperties, cancellationToken);
            return new OutputData
            {
                Id = result.Id.ToString(),
                EncryptedSecret = result.EncryptedSecret,
            };
        }

        /// <summary>
        /// Updates an existing application.
        /// </summary>
        /// <param name="request">Data to pass to the commands service for updating an application.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Delete(CustomResourceRequest<ApplicationRequest> request, CancellationToken cancellationToken = default)
        {
            var result = await applicationsClient.DeleteById(Guid.Parse(request.PhysicalResourceId!), cancellationToken);
            return new OutputData
            {
                Id = result.Id.ToString(),
                EncryptedSecret = result.EncryptedSecret,
            };
        }
    }
}
