using Lambdajection.CustomResource;

namespace Brighid.Identity.Resources.Application
{
    /// <summary>
    /// Represents data returned to CloudFormation about an application.
    /// </summary>
    public class OutputData : ICustomResourceOutputData
    {
        /// <summary>
        /// Gets or sets the application's ID in string form.
        /// </summary>
        public string Id { get; set; } = string.Empty;
    }
}
