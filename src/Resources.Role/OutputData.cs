using Lambdajection.CustomResource;

namespace Brighid.Identity.Resources.Role
{
    /// <summary>
    /// Represents data returned to CloudFormation about an role.
    /// </summary>
    public class OutputData : ICustomResourceOutputData
    {
        /// <summary>
        /// Gets or sets the role's ID in string form.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the role's name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
