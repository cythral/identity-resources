using Lambdajection.Attributes;
using Lambdajection.Encryption;

namespace Brighid.Identity.Resources.Application
{
    /// <summary>
    /// Options to use for Brighid Identity.
    /// </summary>
    [LambdaOptions(typeof(Handler), "Identity")]
    public class IdentityConfig : Client.IdentityConfig
    {
        /// <summary>
        /// Gets or sets the Identity Client Secret.
        /// </summary>
        [Encrypted]
        public override string ClientSecret { get; set; } = string.Empty;
    }
}
