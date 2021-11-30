using System;
using System.Threading;
using System.Threading.Tasks;

using AutoFixture.AutoNSubstitute;
using AutoFixture.NUnit3;

using Brighid.Identity.Client;
using Brighid.Identity.Resources.Role;

using FluentAssertions;

using Lambdajection.CustomResource;

using NSubstitute;

using NUnit.Framework;

using static NSubstitute.Arg;

namespace Brighid.Identity.Resources
{
    public class RoleHandlerTests
    {
        [TestFixture]
        public class Create
        {
            [Test, Auto]
            public async Task ShouldCreateRoleWithClient(
                CustomResourceRequest<RoleRequest> request,
                [Frozen, Substitute] IRolesClient rolesClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                await handler.Create(request, cancellationToken);

                await rolesClient.Received().Post(Is(request.ResourceProperties), Is(cancellationToken));
            }

            [Test, Auto]
            public async Task ShouldReturnTheId(
                CustomResourceRequest<RoleRequest> request,
                [Frozen] Client.Role role,
                [Frozen, Substitute] IApplicationsClient applicationsClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                var result = await handler.Create(request, cancellationToken);

                result.Id.Should().Be(role.Id.ToString());
            }

            [Test, Auto]
            public async Task ShouldReturnTheName(
                Guid id,
                CustomResourceRequest<RoleRequest> request,
                [Frozen] Client.Role role,
                [Frozen, Substitute] IRolesClient rolesClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                var result = await handler.Create(request, cancellationToken);

                result.Name.Should().Be(role.Name);
            }
        }

        [TestFixture]
        public class Update
        {
            [Test, Auto]
            public async Task ShouldUpdateApplicationWithClient(
                Guid id,
                CustomResourceRequest<RoleRequest> request,
                [Frozen, Substitute] IRolesClient rolesClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                await handler.Update(request, cancellationToken);

                await rolesClient.Received().Put(Is(id), Is(request.ResourceProperties), Is(cancellationToken));
            }

            [Test, Auto]
            public async Task ShouldReturnTheId(
                Guid id,
                CustomResourceRequest<RoleRequest> request,
                [Frozen] Client.Role role,
                [Frozen, Substitute] IRolesClient rolesClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                var result = await handler.Update(request, cancellationToken);

                result.Id.Should().Be(role.Id.ToString());
            }

            [Test, Auto]
            public async Task ShouldReturnTheName(
                Guid id,
                CustomResourceRequest<RoleRequest> request,
                [Frozen] Client.Role role,
                [Frozen, Substitute] IRolesClient rolesClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                var result = await handler.Update(request, cancellationToken);

                result.Name.Should().Be(role.Name);
            }
        }

        [TestFixture]
        public class Delete
        {
            [Test, Auto]
            public async Task ShouldDeleteApplicationWithClient(
                Guid id,
                CustomResourceRequest<RoleRequest> request,
                [Frozen, Substitute] IRolesClient rolesClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                await handler.Delete(request, cancellationToken);

                await rolesClient.Received().Delete(Is(id), Is(cancellationToken));
            }

            [Test, Auto]
            public async Task ShouldReturnTheId(
                Guid id,
                CustomResourceRequest<RoleRequest> request,
                [Frozen] Client.Role role,
                [Frozen, Substitute] IRolesClient rolesClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                var result = await handler.Delete(request, cancellationToken);

                result.Id.Should().Be(role.Id.ToString());
            }

            [Test, Auto]
            public async Task ShouldReturnTheName(
                Guid id,
                CustomResourceRequest<RoleRequest> request,
                [Frozen] Client.Role role,
                [Frozen, Substitute] IRolesClient rolesClient,
                [Target] Handler handler,
                CancellationToken cancellationToken
            )
            {
                request.PhysicalResourceId = id.ToString();

                var result = await handler.Delete(request, cancellationToken);

                result.Name.Should().Be(role.Name);
            }
        }
    }
}
