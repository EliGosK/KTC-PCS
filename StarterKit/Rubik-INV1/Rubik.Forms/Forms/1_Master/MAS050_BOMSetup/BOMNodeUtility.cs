using System.Collections.Generic;
using Rubik.DTO;
using System;
using System.Drawing;
using EVOFramework.Windows.Forms;
using EVOFramework;
using Rubik.BIZ;

namespace Rubik.Master
{
    partial class MAS050_BOMSetup
    {
        /// <summary>
        /// Write list of BOM structure to root BOMNode.
        /// </summary>
        /// <param name="listData"></param>
        /// <returns></returns>
        private BOMNode WriteToBOMNode(List<BOMSetupViewDTO> listData)
        {
            //##############
            // Generate BOMNode Structure
            //##############
            BOMNode rootNode = null;

            BOMNode currentNode = null;
            for (int i = 0; i < listData.Count; i++)
            {
                BOMSetupViewDTO dto = listData[i];
                BOMNode node = new BOMNode(dto);

                if (dto.LEVEL.StrongValue == 0)
                {
                    rootNode = node;
                    currentNode = rootNode;
                }
                else if (dto.LEVEL.StrongValue > currentNode.DTO.LEVEL.StrongValue)
                {
                    currentNode.Nodes.Add(node);
                }
                else if (dto.LEVEL.StrongValue == currentNode.DTO.LEVEL.StrongValue)
                {
                    currentNode.Parent.Nodes.Add(node);
                }
                else
                {
                    // move back currentNode.
                    int posBack = (currentNode.DTO.LEVEL.StrongValue - dto.LEVEL.StrongValue) + 1;
                    for (int iMoveBack = 0; iMoveBack < posBack; iMoveBack++)
                    {
                        currentNode = (BOMNode)currentNode.Parent;
                    }

                    currentNode.Nodes.Add(node);
                }

                currentNode = node;
            } // end for-loop.

            return rootNode;
        }

        #region Utility
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowToStart"></param>
        /// <returns></returns>
        private int GetNextVisibleRowIndex(int rowToStart)
        {
            for (int i = rowToStart; i < shtView.Rows.Count; i++)
            {
                if (shtView.GetRowVisible(i))
                    return i;
            }

            //Not found.
            return -1;
        }
        /// <summary>
        /// ค้นหา RowIndex จาก Node ที่ระบุ
        /// </summary>
        /// <param name="node"></param>
        /// <param name="searchType"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private int SearchRowIndex(BOMNode node, eSearchType searchType, int startIndex)
        {
            if (searchType == eSearchType.Forward)
            {
                for (int i = startIndex; i < shtView.Rows.Count; i++)
                {
                    if (shtView.Rows[i].Tag.Equals(node))
                        return i;
                }
                return -1;
            }

            for (int i = startIndex; i >= 0; i--)
            {
                if (shtView.Rows[i].Tag.Equals(node))
                    return i;
            }
            return -1;

        }

        /// <summary>
        /// หาโหนด BOMNode จากคีย์ (UPPER_ITEM_CD , LOWER_ITEM_CD)
        /// ซึ่งโหนดที่หาพบ อาจจะมีอยู่ในหลายๆ  Level  จึงทำให้คืนค่าเป็น List<BOMNode>
        /// </summary>        
        /// <returns></returns>
        private List<BOMNode> GetNodes(string upperItemCode, string lowerItemCode)
        {
            if (m_rootBOMNode == null)
                return null;

            List<BOMNode> listBuffer = new List<BOMNode>();
            RetrieveNode_Child(m_rootBOMNode, upperItemCode, lowerItemCode, listBuffer);
            return listBuffer;
        }

        /// <summary>
        /// ค้นหาโหนดที่มีค่า Upper item code ตรงกับที่ระบุ
        /// </summary>
        /// <param name="upperItemCode"></param>
        /// <returns>รายการโหนดที่มี Upper item code ตรงกับที่ระบุ</returns>
        private List<BOMNode> GetNodesOnUpperItem(string upperItemCode)
        {
            if (m_rootBOMNode == null)
                return null;

            List<BOMNode> listBuffer = new List<BOMNode>();
            RetrieveNode_Child(m_rootBOMNode, upperItemCode, null, listBuffer);
            return listBuffer;
        }

        /// <summary>
        /// ค้นหาโหนดที่มีค่า Lower item code ตรงกับที่ระบุ
        /// </summary>
        /// <param name="lowerItemCode"></param>
        /// <returns>รายการโหนดที่มี Upper item code ตรงกับที่ระบุ</returns>
        private List<BOMNode> GetNodesOnLowerItem(string lowerItemCode)
        {
            if (m_rootBOMNode == null)
                return null;

            List<BOMNode> listBuffer = new List<BOMNode>();
            RetrieveNode_Child(m_rootBOMNode, null, lowerItemCode, listBuffer);
            return listBuffer;
        }

        /// <summary>
        /// Adjust level of BOMNode by relative position.
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="index"></param>
        private void AdjustLevelByRelative(BOMNode startNode, int index)
        {
            if (startNode == null)
                return;

            int newLevel = startNode.DTO.LEVEL.NVL(0);
            startNode.DTO.LEVEL.Value = newLevel + index;

            for (int i = 0; i < startNode.Nodes.Count; i++)
            {
                AdjustLevelByRelative((BOMNode)startNode.Nodes[i], index);
            }
        }

        /// <summary>
        /// ค้นหารายการ Node ทั้งหมดที่เป็นตัวลูก  โดยเริ่มนับจาก startNode เป็นจุดตั้งต้น แล้ววนหาโหนดลูกภายในไปยังตัวสุดท้าย
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="buffer">ตัวแปรเก็บรายการที่ค้นพบ</param>
        private void RetrieveListOfNodes(BOMNode startNode, List<BOMNode> buffer)
        {

            buffer.Add(startNode);

            for (int i = 0; i < startNode.Nodes.Count; i++)
            {
                RetrieveListOfNodes((BOMNode)startNode.Nodes[i], buffer);
            }
        }

        /// <summary>
        /// ค้นหารายการ Node ทั้งหมด โดยเริ่มนับจาก startNode เป็นจุดตั้งต้น  
        /// แล้ววนหา Parent ไปยัง TopItem
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="buffer">ตัวแปรที่ใช้เก็บรายการที่ค้นหา</param>
        private void RetrieveListOfTopNodes(BOMNode startNode, List<BOMNode> buffer)
        {
            buffer.Add(startNode);

            BOMNode parent = (BOMNode)startNode.Parent;
            while (parent != null)
            {
                buffer.Add(parent);
                parent = (BOMNode)parent.Parent;
            }
        }

        /// <summary>
        /// ไม่ใช้คำสั่งนี้  ให้ใช้คำสั่ง GetNode แทน
        /// </summary>
        /// <param name="root"></param>
        /// <param name="upperItemCode"></param>
        /// <param name="lowerItemCode"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private void RetrieveNode_Child(BOMNode root, string upperItemCode, string lowerItemCode, List<BOMNode> buffer)
        {
            if (upperItemCode != null && lowerItemCode != null)
            {
                if (Equals(root.DTO.UPPER_ITEM_CD.Value, upperItemCode) &&
                Equals(root.DTO.LOWER_ITEM_CD.Value, lowerItemCode))
                {
                    buffer.Add(root);
                    return;
                }
            }
            else if (upperItemCode == null)
            {
                if (Equals(root.DTO.LOWER_ITEM_CD.Value, lowerItemCode))
                {
                    buffer.Add(root);
                    return;
                }
            }
            else
            {
                if (Equals(root.DTO.UPPER_ITEM_CD.Value, upperItemCode))
                {
                    buffer.Add(root);
                    return;
                }
            }


            for (int i = 0; i < root.Nodes.Count; i++)
            {
                RetrieveNode_Child((BOMNode)root.Nodes[i], upperItemCode, lowerItemCode, buffer);
            }
        }

        /// <summary>
        /// Check if that specified row index is top level.
        /// </summary>
        /// <param name="rowIndex">Row Index of Spread</param>
        /// <returns></returns>
        private bool IsTopItem(int rowIndex)
        {
            return (rowIndex == 0);
        }
        private bool IsLeafItem(int rowIndex)
        {
            BOMNode node = shtView.Rows[rowIndex].Tag as BOMNode;
            if (node != null)
            {
                return node.Nodes.Count == 0;
            }

            return (false);
        }
        private bool IsPurchaseItem(int rowIndex)
        {
            BOMNode node = shtView.Rows[rowIndex].Tag as BOMNode;
            if (node != null)
            {
                //if (Equals(node.DTO.LOWER_ITEM_CLS.Value, DataDefine.Convert2ClassCode(eItemType.RawMaterial)))  // check raw material.
                //    return true;
                return false;
            }

            return (false);
        }

        /// <summary>
        /// Get white space width.
        /// </summary>
        private int WhiteSpaceWidth
        {
            get
            {
                if (m_whiteSpaceWidth == -1)
                {
                    Graphics g = fpView.CreateGraphics();
                    m_whiteSpaceWidth = Convert.ToInt32(g.MeasureString(" ", fpView.Font).Width);
                    g.Dispose();
                }

                return m_whiteSpaceWidth;
            }
        }

        private int GetLeftIndentPosition(int level)
        {
            return level * 16;
        }

        private int GetNumWhiteSpaceAtLevel(int level)
        {
            int leftIndent = GetLeftIndentPosition(level) + 20;  // 20 = safely of image width size.
            return Convert.ToInt32(Math.Ceiling(leftIndent / (double)WhiteSpaceWidth));
        }
        #endregion

        #region Expand / Collapse / Show / Hide
        private void CollapseNode(BOMNode node)
        {

            for (int i = 0; i < node.Nodes.Count; i++)
            {
                int RowIndex = SearchRowIndex((BOMNode)node.Nodes[i], eSearchType.Forward, 0);
                HideRow(RowIndex);

                CollapseNode_Recursive((BOMNode)node.Nodes[i], RowIndex);
            }
        }
        private void CollapseNode_Recursive(BOMNode node, int rowIndex)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                int RowIndex = SearchRowIndex((BOMNode)node.Nodes[i], eSearchType.Forward, rowIndex);
                HideRow(RowIndex);

                CollapseNode_Recursive((BOMNode)node.Nodes[i], RowIndex);
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="node"></param>
        private void ExpandNode(BOMNode node)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                int RowIndex = SearchRowIndex((BOMNode)node.Nodes[i], eSearchType.Forward, 0);
                ExpandNode_Recursive((BOMNode)node.Nodes[i], RowIndex);
            }
        }
        private void ExpandNode_Recursive(BOMNode node, int rowIndex)
        {
            ShowRow(rowIndex);

            if (node.IsExpanded)
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    int RowIndex = SearchRowIndex((BOMNode)node.Nodes[i], eSearchType.Forward, rowIndex);
                    ExpandNode_Recursive((BOMNode)node.Nodes[i], RowIndex);
                }
            }
        }


        private void HideRow(int row)
        {
            shtView.Rows[row].Visible = false;
        }
        private void ShowRow(int row)
        {
            shtView.Rows[row].Visible = true;
        }
        #endregion

        #region Spread Fill / Drawing.
        /// <summary>
        /// วาดโครงสร้าง BOM ลง Grid จะวนหาทุก Node ที่สัมพันธ์กันเพื่อวาดโครงสร้าง
        /// </summary>
        /// <param name="node"></param>
        private void FillBOMNodeToGrid(BOMNode node)
        {
            FillRowGrid(node);

            for (int i = 0; i < node.Nodes.Count; i++)
            {
                FillBOMNodeToGrid((BOMNode)node.Nodes[i]);
            }
        }

        /// <summary>
        /// เพิ่มแถวใน Grid จากข้อมูลใน DTO
        /// รวมถึงการวาดระดับ Level ด้วย  แถวที่เพิ่มเสร็จแล้วจะเก็บ Tag = DTO
        /// </summary>
        /// <param name="dto"></param>
        private void FillRowGrid(BOMNode node)
        {
            int iRow = shtView.Rows.Count;
            shtView.Rows.Add(iRow, 1);

            shtView.Rows[iRow].Tag = node;

            UpdateRowGrid(iRow);
        }

        /// <summary>
        /// Update การแสดงผลใน Grid ให้ตรงตาม DTO ที่เก็บไว้ใน Tag
        /// </summary>
        /// <param name="rowIndex"></param>
        private void UpdateRowGrid(int rowIndex)
        {
            try
            {
                int iRow = rowIndex;
                BOMNode node = shtView.Rows[iRow].Tag as BOMNode;
                BOMSetupViewDTO dto = node.DTO;

                int whiteSpaceNum = GetNumWhiteSpaceAtLevel(node.Level);
                string space = string.Empty.PadLeft(whiteSpaceNum, ' ');

                shtView.Cells[rowIndex, (int)eColView.ITEM_CD].Value = space + dto.LOWER_ITEM_CD.Value;
                shtView.Cells[rowIndex, (int)eColView.ITEM_DESC].Value = dto.LOWER_ITEM_DESC.Value;
                shtView.Cells[rowIndex, (int)eColView.ITEM_CLS].Value = dto.LOWER_ITEM_CLS.Value;
                shtView.Cells[rowIndex, (int)eColView.LOT_CONTROL_CLS].Value = dto.LOWER_LOT_CONTROL_CLS.Value;
                shtView.Cells[rowIndex, (int)eColView.CONSUMTION_CLS].Value = dto.LOWER_CONSUMTION_CLS.Value;
                //shtView.Cells[rowIndex, (int)eColView.SEQ].Value = dto.SEQ.Value;
                shtView.Cells[rowIndex, (int)eColView.CHILD_RATE].Value = dto.LOWER_QTY.Value;
                shtView.Cells[rowIndex, (int)eColView.PARENT_RATE].Value = dto.UPPER_QTY.Value;
                //shtView.Cells[rowIndex, (int)eColView.CHILD_ORDER_LOC].Value = dto.CHILD_ORDER_LOC_CD.Value;

                // edit by Chatas C. 13/6/2011
                //if (dto.MRP_FLAG.StrongValue != string.Empty)
                //{
                //    BOMBIZ bizBom = new BOMBIZ();
                //    try
                //    {
                //        NZString str = ((Convert.ToString(dto.MRP_FLAG)).Substring(0, 2)).ToNZString();
                //        NZString strMRPFlag = bizBom.FindMRPFlag(str);
                //        shtView.Cells[rowIndex, (int)eColView.MRP_FLAG].Value = str + " : " +strMRPFlag;
                //    }
                //    catch (Exception ex)
                //    { }
                //}

            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, null, err.Source);
            }
        }
        #endregion
    }
}
