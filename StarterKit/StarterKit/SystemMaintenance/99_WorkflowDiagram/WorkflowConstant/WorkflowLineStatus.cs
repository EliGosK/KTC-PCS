using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlowDiagram
{
    /// <summary>
    /// Status of line.
    /// </summary>
    public enum WorkflowLineStatus
    {
        /// <summary>
        /// Straight line
        /// </summary>
        Straight = 0,

        /// <summary>
        /// End point, this constant will show arrow.
        /// </summary>
        EndPoint = 1,        
    } ;

    public enum WorkflowConnectorType {
        None = 0,        
        /// <summary>
        /// Line Connector symbol (+)
        /// </summary>
        Connector_Cross = 1,

        /// <summary>
        /// Line Connection for line direction left to top.
        /// </summary>
        Connector_LeftTop = 2,

        /// <summary>
        /// Line Connection for line direction left to bottom.
        /// </summary>
        Connector_LeftBottom = 3,

        /// <summary>
        /// Line Connection for line direction right to top.
        /// </summary>
        Connector_RightTop = 4 ,

        /// <summary>
        /// Line Connection for line direction right to bottom.
        /// </summary>
        Connector_RightBottom = 5,        

        Connector_LeftRightTop = 6,
        Connector_RightTopBottom = 7,
        Connector_LeftRightBottom = 8,
        Connector_LeftTopBottom = 9,
    }
}
