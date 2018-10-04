using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlowDiagram
{
    public class WorkflowButtonList : List<WorkflowButton>
    {
        /// <summary>
        /// Find max row and column index of button from this collection.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public Cell FindMaxRowColumnIndex() {
            Cell cell = new Cell(null, 0, 0);
            for (int i=0; i< this.Count; i++) {
                cell.RowIndex = Math.Max(cell.RowIndex, this[i].Data.ROW_INDEX);
                cell.ColumnIndex = Math.Max(cell.ColumnIndex, this[i].Data.COL_INDEX);
            }

            return cell;
        }               
    }
}
