using System;
using System.Threading;
using System.Threading.Tasks;

using AutoFixture.AutoNSubstitute;
using AutoFixture.NUnit3;

using Brighid.Identity.Client;
using Brighid.Identity.Resources.Application;

using FluentAssertions;

using Lambdajection.CustomResource;

using NSubstitute;

using NUnit.Framework;

using static NSubstitute.Arg;

namespace Brighid.Identity.Resources
{
    public class ApplicationHandlerTests
    {
        [TestFixture]
        public class Create
        {
            [Test, Auto]
            public async Task ShouldCreateApplicationWithClient(
                CustomResourceRequest<ApplicationRequest> request,
                [Frozen, Substitute] IApplicationsClient applicationsClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                await handler.Create(request, cancellationToken);

                await applicationsClient.Received().Create(Is(request.ResourceProperties), Is(cancellationToken));
            }

            [Test, Auto]
            public async Task ShouldReturnTheId(
                CustomResourceRequest<ApplicationRequest> request,
                [Frozen] Client.Application application,
                [Frozen, Substitute] IApplicationsClient applicationsClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                var result = await handler.Create(request, cancellationToken);

                result.Id.Should().Be(application.Id.ToString());
            }

            [Test, Auto]
            public async Task ShouldReturnTheEncryptedSecret(
                CustomResourceRequest<ApplicationRequest> request,
                [Frozen] Client.Application application,
                [Frozen, Substitute] IApplicationsClient applicationsClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                var result = await handler.Create(request, cancellationToken);

                result.EncryptedSecret.Should().Be(application.EncryptedSecret);
            }
        }

        [TestFixture]
        public class Update
        {
            [Test, Auto]
            public async Task ShouldUpdateApplicationWithClient(
                Guid id,
                CustomResourceRequest<ApplicationRequest> request,
                [Frozen, Substitute] IApplicationsClient applicationsClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                await handler.Update(request, cancellationToken);

                await applicationsClient.Received().UpdateById(Is(id), Is(request.ResourceProperties), Is(cancellationToken));
            }

            [Test, Auto]
            public async Task ShouldReturnTheId(
                Guid id,
                CustomResourceRequest<ApplicationRequest> request,
                [Frozen] Client.Application application,
                [Frozen, Substitute] IApplicationsClient applicationsClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                var result = await handler.Update(request, cancellationToken);

                result.Id.Should().Be(application.Id.ToString());
            }

            [Test, Auto]
            public async Task ShouldReturnTheEncryptedSecret(
                Guid id,
                CustomResourceRequest<ApplicationRequest> request,
                [Frozen] Client.Application application,
                [Frozen, Substitute] IApplicationsClient applicationsClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                var result = await handler.Update(request, cancellationToken);

                result.EncryptedSecret.Should().Be(application.EncryptedSecret);
            }
        }

        [TestFixture]
        public class Delete
        {
            [Test, Auto]
            public async Task ShouldDeleteApplicationWithClient(
                Guid id,
                CustomResourceRequest<ApplicationRequest> request,
                [Frozen, Substitute] IApplicationsClient applicationsClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                await handler.Delete(request, cancellationToken);

                await applicationsClient.Received().DeleteById(Is(id), Is(cancellationToken));
            }

            [Test, Auto]
            public async Task ShouldReturnTheId(
                Guid id,
                CustomResourceRequest<ApplicationRequest> request,
                [Frozen] Client.Application application,
                [Frozen, Substitute] IApplicationsClient applicationsClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                var result = await handler.Delete(request, cancellationToken);

                result.Id.Should().Be(application.Id.ToString());
            }

            [Test, Auto]
            public async Task ShouldReturnTheEncryptedSecret(
                Guid id,
                CustomResourceRequest<ApplicationRequest> request,
                [Frozen] Client.Application application,
                [Frozen, Substitute] IApplicationsClient applicationsClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                var result = await handler.Delete(request, cancellationToken);

                result.EncryptedSecret.Should().Be(application.EncryptedSecret);
            }
        }
    }
}
