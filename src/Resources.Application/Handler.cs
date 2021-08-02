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
        /// <summary>
        /// Initializes a new instance of the <see cref="Handler" /> class.
        /// </summary>
        public Handler()
        {
        }

#pragma warning disable IDE0060

        /// <summary>
        /// Creates a new application.
        /// </summary>
        /// <param name="request">Data to pass to the identity service for creating an application.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Create(CustomResourceRequest<ApplicationRequest> request, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing application.
        /// </summary>
        /// <param name="request">Data to pass to the commands service for updating an application.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Update(CustomResourceRequest<ApplicationRequest> request, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing application.
        /// </summary>
        /// <param name="request">Data to pass to the commands service for updating an application.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Delete(CustomResourceRequest<ApplicationRequest> request, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
