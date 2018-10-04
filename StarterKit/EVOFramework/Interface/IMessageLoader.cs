namespace EVOFramework
{
    /// <summary>
    /// Implement this interface to customize own load message description.
    /// </summary>
    public interface IMessageLoader
    {
        /// <summary>
        /// Load message description
        /// </summary>
        /// <param name="msgCode">Message Code.</param>        
        /// <returns>Description.</returns>
        string LoadDecription(string msgCode);
    }
}
