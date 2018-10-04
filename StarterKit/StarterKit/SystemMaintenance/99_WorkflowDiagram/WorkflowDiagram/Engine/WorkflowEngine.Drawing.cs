using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using EVOFramework;

namespace WorkFlowDiagram
{
    internal partial class WorkflowEngine
    {
        #region "  Calculate Draw Position  "

        #region "== Get Rectangle Area =="
        private Rectangle GetConnectorRectangle(Cell cell) {
            
            Rectangle rectCell = GetCellRectangle(GetIndexWorkFlowButtonCell(cell.RowIndex, cell.ColumnIndex));

            Rectangle rectConnector = Rectangle.Empty;

            rectConnector.Width = ParentWorkflow.LineImage.CONNECTOR_SIZE.Width;
            rectConnector.Height = ParentWorkflow.LineImage.CONNECTOR_SIZE.Height;
            rectConnector.X = rectCell.X + ( rectCell.Width/2 ) - ( rectConnector.Width/2 );
            rectConnector.Y = rectCell.Y + (rectCell.Height / 2) - (rectConnector.Height/ 2);
            return rectConnector;
        }
        private Rectangle GetLineRectangle(Cell from, Cell to, WorkflowLineDirection direction) {
            Rectangle rectStartCell = GetCellRectangle(new Cell(null, from.RowIndex, from.ColumnIndex));
            Rectangle rectEndCell = GetCellRectangle(new Cell(null, to.RowIndex, to.ColumnIndex));

            Rectangle lineRectangle = Rectangle.Empty;
            switch (direction) {
                case WorkflowLineDirection.LEFT:
                case WorkflowLineDirection.RIGHT:
                    // Horizontal Line
                    Image hline = ParentWorkflow.LineImage.HLINE;
                    lineRectangle.X = rectStartCell.X + ( rectStartCell.Width/2 );
                    lineRectangle.Y = rectStartCell.Y + ( rectStartCell.Height/2 ) - ( hline.Height/2 );
                    lineRectangle.Height = hline.Height;

                    lineRectangle.Width = ( rectEndCell.X + ( rectEndCell.Width/2 ) ) - lineRectangle.X;
                    break;
                case WorkflowLineDirection.TOP:                    
                case WorkflowLineDirection.BOTTOM:
                    // Vertical Line
                    Image vline = ParentWorkflow.LineImage.VLINE;
                    lineRectangle.X = rectStartCell.X + ( rectStartCell.Width/2 ) - ( vline.Width/2 );
                    lineRectangle.Y = rectStartCell.Y + ( rectStartCell.Height/2 );
                    lineRectangle.Width = vline.Width;

                    lineRectangle.Height = rectEndCell.Y + ( rectEndCell.Height/2 ) - lineRectangle.Y;
                    break;            
            }            

            return lineRectangle;
        }
        private Rectangle GetArrowRectangle(Cell cell, WorkflowLineDirection direction) {
            Rectangle cellRect = GetCellRectangle(cell);
            

            Image arrowImg = GetArrowImageFromLineDirection(direction);

            Rectangle arrowRect = Rectangle.Empty;
            arrowRect.Width = arrowImg.Width;
            arrowRect.Height = arrowImg.Height;
            switch (direction) {
                case WorkflowLineDirection.LEFT:
                    arrowRect.X = cellRect.X;
                    arrowRect.Y = cellRect.Y + ( cellRect.Height/2 ) - ( arrowImg.Height/2 );                    
                    break;
                case WorkflowLineDirection.TOP:
                    arrowRect.X = cellRect.X + (cellRect.Width / 2) - (arrowImg.Width / 2);
                    arrowRect.Y = cellRect.Y;
                    break;
                case WorkflowLineDirection.RIGHT:
                    arrowRect.X = cellRect.Right - arrowRect.Width;
                    arrowRect.Y = cellRect.Y + (cellRect.Height / 2) - (arrowImg.Height / 2);                    
                    break;
                case WorkflowLineDirection.BOTTOM:
                    arrowRect.X = cellRect.X + ( cellRect.Width/2 ) - ( arrowImg.Width/2 );
                    arrowRect.Y = cellRect.Bottom - arrowImg.Height;
                    break;
                case WorkflowLineDirection.NONE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }

            return arrowRect;
        }
        #endregion

        #region "== Get Image =="
        /// <summary>
        /// Get image of line from line direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private Image GetImageFromLineDirection(WorkflowLineDirection direction)
        {
            switch (direction)
            {
                case WorkflowLineDirection.LEFT:
                case WorkflowLineDirection.RIGHT:
                    return ParentWorkflow.LineImage.HLINE;
                case WorkflowLineDirection.TOP:
                case WorkflowLineDirection.BOTTOM:
                    return ParentWorkflow.LineImage.VLINE;
            }

            return ParentWorkflow.LineImage.EMPTY;

        }

        /// <summary>
        /// Get image of arrow from line direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private Image GetArrowImageFromLineDirection(WorkflowLineDirection direction) {
            switch (direction) {
                case WorkflowLineDirection.LEFT:
                    return ParentWorkflow.LineImage.ARROW_LEFT;
                case WorkflowLineDirection.TOP:
                    return ParentWorkflow.LineImage.ARROW_UP;
                case WorkflowLineDirection.RIGHT:
                    return ParentWorkflow.LineImage.ARROW_RIGHT;
                case WorkflowLineDirection.BOTTOM:
                    return ParentWorkflow.LineImage.ARROW_DOWN;
                
            }

            return ParentWorkflow.LineImage.EMPTY;
        }
        /// <summary>
        /// Get image of connector from ConnectorType.
        /// </summary>
        /// <param name="connectorType"></param>
        /// <returns></returns>
        private Image GetImageFromConnectorType(WorkflowConnectorType connectorType) {
            switch (connectorType) {
                case WorkflowConnectorType.None:
                    return ParentWorkflow.LineImage.EMPTY;                    
                case WorkflowConnectorType.Connector_Cross:
                    return ParentWorkflow.LineImage.CONNECTOR_CROSS;
                case WorkflowConnectorType.Connector_LeftTop:
                    return ParentWorkflow.LineImage.CONNECTOR_LEFT_TOP;
                case WorkflowConnectorType.Connector_LeftBottom:
                    return ParentWorkflow.LineImage.CONNECTOR_LEFT_BOTTOM;
                case WorkflowConnectorType.Connector_RightTop:
                    return ParentWorkflow.LineImage.CONNECTOR_RIGHT_TOP;
                case WorkflowConnectorType.Connector_RightBottom:
                    return ParentWorkflow.LineImage.CONNECTOR_RIGHT_BOTTOM;
                case WorkflowConnectorType.Connector_LeftRightTop:
                    return ParentWorkflow.LineImage.CONNECTOR_LEFT_RIGHT_TOP;
                case WorkflowConnectorType.Connector_RightTopBottom:
                    return ParentWorkflow.LineImage.CONNECTOR_RIGHT_TOP_BOTTOM;
                case WorkflowConnectorType.Connector_LeftRightBottom:
                    return ParentWorkflow.LineImage.CONNECTOR_LEFT_RIGHT_BOTTOM;
                case WorkflowConnectorType.Connector_LeftTopBottom:
                    return ParentWorkflow.LineImage.CONNECTOR_LEFT_TOP_BOTTOM;                
            }

            return ParentWorkflow.LineImage.EMPTY;
        }
        #endregion

        #endregion


        #region "  Draw line engine.  "        
        /// <summary>
        /// Drawing line follow line detail direction.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="line">Line detail of start-end point that will drawing</param>
        private void DrawLine(Graphics g, WorkflowLineDetail line) {
            Cell fromCell = GetIndexWorkFlowButtonCell(line.FromCell.RowIndex, line.FromCell.ColumnIndex);
            Cell toCell = GetIndexWorkFlowButtonCell(line.ToCell.RowIndex, line.ToCell.ColumnIndex);            

            Cell startCell = null;
            Cell endCell = null;

            WorkflowLineDirection direction = line.GetLineDirection();
            switch (direction) {
                case WorkflowLineDirection.LEFT:
                    if (line.Status == WorkflowLineStatus.EndPoint)
                        toCell.ColumnIndex += 1;
                    startCell = toCell;
                    endCell = fromCell;
                    break;
                case WorkflowLineDirection.TOP:
                    if (line.Status == WorkflowLineStatus.EndPoint)
                        toCell.RowIndex += 1;
                    startCell = toCell;
                    endCell = fromCell;
                    break;
                case WorkflowLineDirection.RIGHT:
                    if (line.Status == WorkflowLineStatus.EndPoint)
                        toCell.ColumnIndex -= 1;
                    startCell = fromCell;
                    endCell = toCell;
                    break;
                case WorkflowLineDirection.BOTTOM:
                    if (line.Status == WorkflowLineStatus.EndPoint)
                        toCell.RowIndex -= 1;
                    startCell = fromCell;
                    endCell = toCell;
                    break;
                case WorkflowLineDirection.NONE:
                    return;
            }

            if (startCell == null || endCell == null)
                return;

            // Draw Straight-Line (Without Arrow).
            Rectangle lineRect = GetLineRectangle(startCell, endCell, direction);

            Image img = GetImageFromLineDirection(direction);
            //img = ImageHelper.GetThumbnailImage(img, lineRect.Width, lineRect.Height);
            img = ImageHelper.ResizeImage(img, lineRect.Width, lineRect.Height);

            g.DrawImage(img, lineRect);
            img.Dispose();

            if (line.Status == WorkflowLineStatus.EndPoint) {
                Image arrowImg = GetArrowImageFromLineDirection(direction);
                Rectangle arrowRect = GetArrowRectangle(toCell, direction);
                g.DrawImage(arrowImg, arrowRect);
            }
            
        }

        /// <summary>
        /// Drawing line connector.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="connector">Connector detail of point that will drawing.</param>
        private void DrawConnector(Graphics g, WorkflowLineConnector connector) {
            Rectangle rectConnector = GetConnectorRectangle(connector.Cell);
            Image img = GetImageFromConnectorType(connector.ConnectorType);

            g.DrawImage(img, rectConnector);
        }
        
        #endregion

        /// <summary>
        /// Draw all line into control's surface.
        /// It will draw line and connector.
        /// </summary>
        /// <param name="g"></param>
        internal void DrawLines(Graphics g)
        {            
            if (ButtonList == null || LineHeaderList == null)
                throw new ArgumentException("Engine is not initialize.");

            for (int i = 0; i < LineHeaderList.Count; i++)
            {
                //Draw Line and SubLine.
                for (int iLine = 0; iLine < LineHeaderList[i].Lines.Count; iLine++)
                {
                    DrawLine(g, LineHeaderList[i].Lines[iLine]);
                }

                // Draw Connector
                for (int iConnector = 0; iConnector < LineHeaderList[i].Connectors.Count; iConnector++) {
                    DrawConnector(g, LineHeaderList[i].Connectors[iConnector]);
                }
            }
        }
    }
}
