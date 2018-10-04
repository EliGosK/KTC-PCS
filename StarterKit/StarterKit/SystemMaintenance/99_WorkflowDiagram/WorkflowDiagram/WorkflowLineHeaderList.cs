using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlowDiagram
{
    internal class WorkflowLineHeaderList : List<WorkflowLineHeader>
    {     
        public Cell FindMaxRowColumnIndex() {
            Cell cell = new Cell(null, 0, 0);
            for (int i=0; i<this.Count; i++) {
                Cell lineMaxCell = this[i].FindMaxRowColumnIndex();    
                if (i == 0) {
                    cell = lineMaxCell;
                } else {
                    cell.RowIndex = Math.Max(cell.RowIndex, lineMaxCell.RowIndex);
                    cell.ColumnIndex = Math.Max(cell.ColumnIndex, lineMaxCell.ColumnIndex);
                }                
            }
            return cell;
        }
    }
}
