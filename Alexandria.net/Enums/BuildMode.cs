using Alexandria.net.Helpers;

namespace Alexandria.net.Enums
{
    /// <summary>
    /// Library build modes
    /// </summary>
    public enum BuildMode
    {
        /// <summary>
        /// Test mode
        /// </summary>
        [StringValue("Test")]
        Test,
        /// <summary>
        /// Production mode
        /// </summary>
        [StringValue("Prod")]
        Prod
    }
}