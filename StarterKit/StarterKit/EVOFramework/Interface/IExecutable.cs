using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVOFramework
{
    /// <summary>
    /// Implement this interface to support execute script.
    /// </summary>
    public interface IExecutable
    {
        /// <summary>
        /// Execute operation.
        /// </summary>
        void Execute();
    }
}
