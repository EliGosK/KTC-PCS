namespace EVOFramework.Database
{
    public enum TransactionState
    {
        /// <summary>
        /// Ready to BeginTransaction
        /// </summary>
        IDLE,

        /// <summary>
        /// Processing, waiting for commit or rollback
        /// </summary>
        PROCESSING
    };
}
