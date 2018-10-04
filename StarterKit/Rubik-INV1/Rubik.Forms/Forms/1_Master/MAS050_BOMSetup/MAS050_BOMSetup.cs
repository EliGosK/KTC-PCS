using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SystemMaintenance.Forms;
using EVOFramework;
using EVOFramework.Windows.Forms;
using Rubik.BIZ;
using EVOFramework.Data;
using Rubik.Controller;
using CommonLib;
using FarPoint.Win.Spread;
using Rubik.DTO;
using Rubik.UIDataModel;
using Message = EVOFramework.Message;
using SystemMaintenance;
using System.Data;

namespace Rubik.Master
{
    //[Screen("MAS050", "BOM Setup", eShowAction.Normal, eScreenType.Screen, "BOM Setup")]
    public partial class MAS050_BOMSetup : CustomizeBaseForm
    {
        #region Enum
        public enum eColView
        {
            ITEM_CD,
            ITEM_DESC,
            ITEM_CLS,
            LOT_CONTROL_CLS,
            CONSUMTION_CLS,
            SEQ,
            PARENT_RATE,
            CHILD_RATE,
            CHILD_ORDER_LOC,
            MRP_FLAG,
        }

        public enum eSearchType
        {
            Forward,
            Backward,
        }
        #endregion

        #region Variables
        private BOMSetupController m_bomSetupController = new BOMSetupController();
        private readonly SqlExecuteScript m_executeScript = null;

        private HScrollBar m_hScrollBar = null;  //HScroll of Spread.
        private VScrollBar m_vScrollBar = null;  //VScroll of Spread.
        private BOMNode m_rootBOMNode = new BOMNode();
        private int m_whiteSpaceWidth = -1;

        /// <summary>
        /// Flag to show context menu.
        /// </summary>
        private bool m_bShowContext = false;
        #endregion

        #region Constructor
        public MAS050_BOMSetup()
        {
            InitializeComponent();

            m_executeScript = new SqlExecuteScript();


            m_hScrollBar = fpView.Controls[1] as HScrollBar;
            m_vScrollBar = fpView.Controls[2] as VScrollBar;
            if (m_hScrollBar != null)
                m_hScrollBar.Scroll += m_hScrollBar_Scroll;

            if (m_vScrollBar != null)
                m_vScrollBar.Scroll += m_vScrollBar_Scroll;
        }

        public MAS050_BOMSetup(NZString ParentPart, NZString ParentItemName)
            : this()
        {

            this.txtItemCD.Text = ParentPart.StrongValue;
            this.txtItemDesc.Text = ParentItemName.StrongValue;

            if (txtItemCD.Text.Trim() != string.Empty)
                txtItem_KeyPressResult(txtItemCD, true, new NZString(txtItemCD, txtItemCD.Text.Trim()));

        }

        #endregion

        #region Private method
        #region Initial Screen
        private void InitialScreen()
        {
            InitialSpread();

            txtItemCD.KeyPress += CtrlUtil.SetNextControl;

            CtrlUtil.EnabledControl(false, txtItemDesc);
            CtrlUtil.EnabledControl(true, txtItemCD, btnItemCD, fpView);
        }


        private void InitialSpread()
        {
            shtView.ActiveSkin = Common.ACTIVE_SKIN;

            CtrlUtil.MappingDataFieldWithEnum(shtView, typeof(eColView));

            LookupDataBIZ biz = new LookupDataBIZ();
            LookupData lookupItemClass = biz.LoadLookupClassType(DataDefine.ITEM_CLS.ToNZString());
            LookupData lookupLotControlClass = biz.LoadLookupClassType(DataDefine.LOT_CONTROL_CLS.ToNZString());
            LookupData lookupConsumptionClass = biz.LoadLookupClassType(DataDefine.CONSUMPTION_CLS.ToNZString());

            shtView.Columns[(int)eColView.ITEM_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(lookupItemClass);
            shtView.Columns[(int)eColView.LOT_CONTROL_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(lookupLotControlClass);
            shtView.Columns[(int)eColView.CONSUMTION_CLS].CellType = CtrlUtil.CreateReadOnlyPairCellType(lookupConsumptionClass);
        }


        #endregion

        #region Load / Save data.
        private void LoadData()
        {
            m_executeScript.Clear();
            shtView.RowCount = 0;

            List<BOMSetupViewDTO> list = m_bomSetupController.LoadBOMSetup(txtItemCD.Text.ToNZString());
            if (m_rootBOMNode != null)
                m_rootBOMNode.Nodes.Clear();


            m_rootBOMNode = WriteToBOMNode(list);
            if (m_rootBOMNode != null)
            {
                m_rootBOMNode.ExpandAll();
                FillBOMNodeToGrid((BOMNode)m_rootBOMNode);
                ExpandNode(m_rootBOMNode);
            }

            SetOrderLoactionandMRPFlag();

            UpdateUpDownButton();
        }


        private void SetOrderLoactionandMRPFlag()
        {

            for (int iRow = 0; iRow < shtView.RowCount; iRow++)
            {
                if (Convert.ToString(shtView.Cells[iRow, (int)eColView.CHILD_ORDER_LOC].Value) == string.Empty)
                {
                    BOMBIZ bizBOM = new BOMBIZ();
                    ItemProcessDTO dto = bizBOM.LoadLocationandMRPFLag(Convert.ToString(shtView.Cells[iRow, (int)eColView.ITEM_CD].Value));
                    if (dto != null)
                    {
                        //shtView.Cells[iRow, (int)eColView.CHILD_ORDER_LOC].Value = dto.ORDER_LOC_CD;
                        shtView.Cells[iRow, (int)eColView.CHILD_ORDER_LOC].ForeColor = Color.Gray;
                        //shtView.Cells[iRow, (int)eColView.CHILD_ORDER_LOC].HorizontalAlignment = FarPoint.Win.Spread.she
                    }
                }
                else
                    shtView.Cells[iRow, (int)eColView.CHILD_ORDER_LOC].ForeColor = Color.Black;

                if (Convert.ToString(shtView.Cells[iRow, (int)eColView.MRP_FLAG].Value) == string.Empty)
                {
                    BOMBIZ bizBOM = new BOMBIZ();
                    ItemProcessDTO dto = bizBOM.LoadLocationandMRPFLag(Convert.ToString(shtView.Cells[iRow, (int)eColView.ITEM_CD].Value));
                    if (dto != null)
                    {
                        //shtView.Cells[iRow, (int)eColView.MRP_FLAG].Value = dto.MRP_FLAG.StrongValue == string.Empty ? "" : bizBOM.LoadMRPFLag(dto.MRP_FLAG);
                        shtView.Cells[iRow, (int)eColView.MRP_FLAG].ForeColor = Color.Gray;
                    }
                }
                else
                    shtView.Cells[iRow, (int)eColView.MRP_FLAG].ForeColor = Color.Black;
            }
        }

        #endregion

        #region Move / Adjust BOM sequence
        /// <summary>
        /// ปรังปรุงการ เปิด/ปิดของปุ่มเลื่อนค่า Seq 
        /// </summary>
        private void UpdateUpDownButton()
        {
            int rowIndex = shtView.ActiveRowIndex;
            if (shtView.RowCount == 0 || rowIndex < 0)
            {
                CtrlUtil.EnabledControl(false, btnMoveDown, btnMoveUp);
                return;
            }

            BOMSetupViewDTO dto = ((BOMNode)shtView.Rows[shtView.ActiveRowIndex].Tag).DTO;
            List<BOMNode> nodes = GetNodes(dto.UPPER_ITEM_CD.StrongValue, dto.LOWER_ITEM_CD.StrongValue);

            BOMNode node = null;
            if (nodes != null && nodes.Count > 0)
                node = nodes[0];

            if (node == null)
            {
                CtrlUtil.EnabledControl(false, btnMoveDown, btnMoveUp);
                return;
            }

            if (node.Parent == null)
            {
                CtrlUtil.EnabledControl(false, btnMoveUp, btnMoveDown);
                return;
            }

            if (node.Equals(node.Parent.FirstNode))
            {
                CtrlUtil.EnabledControl(false, btnMoveUp);
            }
            else
            {
                CtrlUtil.EnabledControl(true, btnMoveUp);
            }

            if (node.Equals(node.Parent.LastNode))
            {
                CtrlUtil.EnabledControl(false, btnMoveDown);
            }
            else
            {
                CtrlUtil.EnabledControl(true, btnMoveDown);
            }
        }

        private void MoveSequenceUp(int rowIndex)
        {

            BOMNode activeNode = shtView.Rows[rowIndex].Tag as BOMNode;
            BOMNode activeUpperNode = activeNode.Parent.Nodes[activeNode.Index - 1] as BOMNode;

            BOMSetupViewDTO currentBOM = activeNode.DTO;
            List<BOMNode> listNodes = GetNodes(currentBOM.UPPER_ITEM_CD.StrongValue, currentBOM.LOWER_ITEM_CD.StrongValue);

            for (int i = 0; i < listNodes.Count; i++)
            {
                BOMNode currentNode = listNodes[i];
                BOMNode upperNode = currentNode.Parent.Nodes[currentNode.Index - 1] as BOMNode;

                //== Update sequence in DTO object.
                //int currentSeq = currentNode.DTO.SEQ.NVL(1);
                //currentNode.DTO.SEQ.Value = upperNode.DTO.SEQ.Value;
                //upperNode.DTO.SEQ.Value = currentSeq;

                // swap position on node-list.
                BOMNode parentNode = currentNode.Parent as BOMNode;
                currentNode.Remove();

                if (parentNode != null)
                {
                    parentNode.Nodes.Insert(upperNode.Index, currentNode);
                }


                //== Save script Update.
                UpdateSqlExecute execute1 = new UpdateSqlExecute(
                    (BOMDTO)currentNode.DTO.Clone(),
                    currentNode.DTO.UPPER_ITEM_CD,
                    currentNode.DTO.LOWER_ITEM_CD);

                UpdateSqlExecute execute2 = new UpdateSqlExecute(
                    (BOMDTO)upperNode.DTO.Clone(),
                    upperNode.DTO.UPPER_ITEM_CD,
                    upperNode.DTO.LOWER_ITEM_CD);

                m_executeScript.Add(execute1);
                m_executeScript.Add(execute2);
            }

            // Refill grid.
            shtView.RowCount = 0;
            FillBOMNodeToGrid(m_rootBOMNode);

            // Expand / collapse the last action.
            if (activeNode.IsExpanded)
                ExpandNode(activeNode);
            else
                CollapseNode(activeNode);

            if (activeUpperNode.IsExpanded)
                ExpandNode(activeUpperNode);
            else
                CollapseNode(activeUpperNode);

            // Hilight current row.
            int newRowIndex = SearchRowIndex(activeNode, eSearchType.Forward, 0);
            shtView.SetActiveCell(newRowIndex, 0);
            shtView.AddSelection(newRowIndex, 0, 1, 1);


            // Update button.
            UpdateUpDownButton();


        }

        private void MoveSequenceDown(int rowIndex)
        {
            BOMNode activeNode = shtView.Rows[rowIndex].Tag as BOMNode;
            BOMNode activeLowerNode = activeNode.Parent.Nodes[activeNode.Index + 1] as BOMNode;

            BOMSetupViewDTO currentBOM = activeNode.DTO;
            List<BOMNode> listNodes = GetNodes(currentBOM.UPPER_ITEM_CD.StrongValue, currentBOM.LOWER_ITEM_CD.StrongValue);

            for (int i = 0; i < listNodes.Count; i++)
            {
                BOMNode currentNode = listNodes[i];
                BOMNode lowerNode = currentNode.Parent.Nodes[currentNode.Index + 1] as BOMNode;

                //== Update sequence in DTO object.
                //int currentSeq = currentNode.DTO.SEQ.NVL(1);
                //currentNode.DTO.SEQ.Value = lowerNode.DTO.SEQ.Value;
                //lowerNode.DTO.SEQ.Value = currentSeq;

                // swap position on node-list.
                BOMNode parentNode = currentNode.Parent as BOMNode;
                currentNode.Remove();

                if (parentNode != null)
                {
                    parentNode.Nodes.Insert(lowerNode.Index + 1, currentNode);
                }


                //== Save script Update.
                UpdateSqlExecute execute1 = new UpdateSqlExecute(
                    (BOMDTO)currentNode.DTO.Clone(),
                    currentNode.DTO.UPPER_ITEM_CD,
                    currentNode.DTO.LOWER_ITEM_CD);

                UpdateSqlExecute execute2 = new UpdateSqlExecute(
                    (BOMDTO)lowerNode.DTO.Clone(),
                    lowerNode.DTO.UPPER_ITEM_CD,
                    lowerNode.DTO.LOWER_ITEM_CD);

                m_executeScript.Add(execute1);
                m_executeScript.Add(execute2);
            }


            //TODO: ตอนที่ทำการย้าย Node ที่มีลูกหลายๆ ชั้น  ยังแสดงไม่ถูกต้อง
            // Refill grid.
            shtView.RowCount = 0;
            FillBOMNodeToGrid(m_rootBOMNode);

            // Expand / collapse the last action.
            if (activeNode.IsExpanded)
                ExpandNode(activeNode);
            else
                CollapseNode(activeNode);

            if (activeLowerNode.IsExpanded)
                ExpandNode(activeLowerNode);
            else
                CollapseNode(activeLowerNode);

            // Hilight current row.
            int newRowIndex = SearchRowIndex(activeNode, eSearchType.Forward, 0);
            shtView.SetActiveCell(newRowIndex, 0);
            shtView.AddSelection(newRowIndex, 0, 1, 1);


            // Update button.
            UpdateUpDownButton();
        }
        #endregion
        #endregion

        #region Form Event
        private void MAS050_BOMSetup_Load(object sender, EventArgs e)
        {
            InitialScreen();

        }

        private void MAS050_BOMSetup_Shown(object sender, EventArgs e)
        {
            CtrlUtil.FocusControl(txtItemCD);
            UpdateUpDownButton();
            PermissionControl();
        }
        #endregion

        #region Control Event
        void m_vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                fpView.Invalidate();
            }
        }

        void m_hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                fpView.Invalidate();
            }

        }



        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveSequenceUp(shtView.ActiveRowIndex);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveSequenceDown(shtView.ActiveRowIndex);
        }

        private void txtItem_KeyPressResult(object sender, bool isFound, EVOFramework.NZString ItemCD)
        {
            if (!isFound)
            {
                shtView.RowCount = 0;
                fpView.DataSource = null;
                UpdateUpDownButton();
            }
            else
            {
                LoadData();
            }
        }

        #region Context menu

        private void ctxMenu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = !m_bShowContext;

            if (e.Cancel)
                return;


            miAddChildItem.Enabled = true;
            miEditItem.Enabled = true;
            miDeleteItem.Enabled = true;
            miDeleteTree.Enabled = true;

            if (IsTopItem(shtView.ActiveRowIndex))
            {
                miEditItem.Enabled = false;
                miDeleteItem.Enabled = false;
            }

            if (IsLeafItem(shtView.ActiveRowIndex))
            {
                miDeleteTree.Enabled = false;
            }

            if (IsPurchaseItem(shtView.ActiveRowIndex))
            {
                miAddChildItem.Enabled = false;
            }
        }

        private void miAddChildItem_Click(object sender, EventArgs e)
        {
            BOMNode activeNode = shtView.ActiveRow.Tag as BOMNode;
            BOMSetupViewDTO activeBOMDTO = activeNode.DTO;

            MAS051_RegisterBOM dialog = new MAS051_RegisterBOM(activeBOMDTO.LOWER_ITEM_CD.StrongValue);
            dialog.ShowDialog();

            if (dialog.IsSelected)
            {
                BOMRegisterUIDM selectedItem = dialog.SelectedItem;

                //== Decision to use data from in-memory or database.
                List<BOMNode> listCopyNode = GetNodesOnLowerItem(selectedItem.ITEM_CD.StrongValue);
                BOMNode copyNode = null;
                if (listCopyNode != null && listCopyNode.Count > 0)
                {
                    //if (listCopyNode[0].Nodes.Count > 0)  // has child.
                    copyNode = (BOMNode)listCopyNode[0].Clone();
                }
                else
                {
                    List<BOMSetupViewDTO> dbListDTO = m_bomSetupController.LoadBOMSetup(selectedItem.ITEM_CD);
                    copyNode = WriteToBOMNode(dbListDTO);
                }


                // == Validate before add child item.

                bool bCheck = CheckBeforeAddNewChildItem(activeNode, copyNode);
                if (bCheck == false)
                {
                    return;
                }

                //===================

                BOMNode lastChildNode = (BOMNode)activeNode.LastNode;
                int nextSeq = 1;
                if (lastChildNode != null)
                {
                    //nextSeq = lastChildNode.DTO.SEQ.NVL(0) + 1;
                }

                //BOMBIZ biz = new BOMBIZ();
                //int nextSeq = biz.GetNextSequenceOfUpperItem(activeBOMDTO.LOWER_ITEM_CD);

                // Create new BOMDTO
                BOMSetupViewDTO dto = new BOMSetupViewDTO();
                dto.UPPER_ITEM_CD.Value = activeBOMDTO.LOWER_ITEM_CD.Value;
                dto.LOWER_ITEM_CD.Value = selectedItem.ITEM_CD.Value;
                //dto.SEQ.Value = nextSeq;
                dto.UPPER_QTY.Value = selectedItem.UPPER_QTY.Value;
                dto.LOWER_QTY.Value = selectedItem.LOWER_QTY.Value;

                dto.UPPER_ITEM_CLS.Value = activeBOMDTO.LOWER_ITEM_CLS.Value;
                dto.UPPER_ITEM_DESC.Value = activeBOMDTO.LOWER_ITEM_DESC.Value;
                dto.UPPER_LOT_CONTROL_CLS.Value = activeBOMDTO.LOWER_LOT_CONTROL_CLS.Value;
                dto.UPPER_CONSUMTION_CLS.Value = activeBOMDTO.LOWER_CONSUMTION_CLS.Value;

                dto.LOWER_ITEM_DESC.Value = selectedItem.ITEM_DESC.Value;
                //dto.LOWER_ITEM_CLS.Value = selectedItem.ITEM_CLS.Value;
                //dto.LOWER_LOT_CONTROL_CLS.Value = selectedItem.LOT_CONTROL_CLS.Value;
                //dto.LOWER_CONSUMTION_CLS.Value = selectedItem.CONSUMTION_CLS.Value;

                dto.PATH.Value = activeBOMDTO.PATH.StrongValue + "~" + selectedItem.ITEM_CD.StrongValue;
                //dto.CHILD_ORDER_LOC_CD.Value = selectedItem.CHILD_ORDER_LOC_CD.Value;
                //dto.MRP_FLAG.Value = selectedItem.MRP_FLAG.Value;
                // Insert new node.
                List<BOMNode> listNodes = GetNodesOnLowerItem(activeBOMDTO.LOWER_ITEM_CD.StrongValue);
                for (int i = 0; i < listNodes.Count; i++)
                {
                    BOMSetupViewDTO newDTO = dto.Clone() as BOMSetupViewDTO;

                    BOMNode newNode = null;
                    if (copyNode == null)
                    {
                        newNode = (BOMNode)copyNode.Clone();
                        newNode.DTO = newDTO;
                    }
                    else
                    {
                        newNode = copyNode.Clone() as BOMNode;
                        newNode.DTO = newDTO;
                        newNode.ExpandAll();
                    }

                    listNodes[i].Nodes.Add(newNode);


                }

                shtView.RowCount = 0;

                FillBOMNodeToGrid(m_rootBOMNode);

                activeNode.Expand();
                CollapseNode(m_rootBOMNode);
                ExpandNode(m_rootBOMNode);

                InsertSqlExecute execute1 = new InsertSqlExecute(dto);
                m_executeScript.Add(execute1);

                SetOrderLoactionandMRPFlag();
            }
        }

        private void miEditItem_Click(object sender, EventArgs e)
        {
            BOMNode activeNode = shtView.ActiveRow.Tag as BOMNode;
            BOMSetupViewDTO activeBOMDTO = activeNode.DTO;
            //if(activeBOMDTO.MRP_FLAG.Value.ToString().Length > 2)
            //    activeBOMDTO.MRP_FLAG = ((Convert.ToString(activeBOMDTO.MRP_FLAG.StrongValue)).Substring(0, 2)).ToNZString();

            MAS052_ChangeItem dialog = new MAS052_ChangeItem(activeBOMDTO);
            dialog.ShowDialog();

            if (dialog.IsSelected)
            {


                BOMRegisterUIDM selectedItem = dialog.SelectedItem;

                //== Decision to use data from in-memory or database.
                List<BOMNode> listCopyNode = GetNodesOnLowerItem(selectedItem.ITEM_CD.StrongValue);
                BOMNode copyNode = null;
                if (listCopyNode != null && listCopyNode.Count > 0)
                {
                    // Use explosion BOM from in-memory.
                    copyNode = (BOMNode)listCopyNode[0].Clone();
                }
                else
                {
                    // Load Explosion BOM from database.
                    List<BOMSetupViewDTO> dbListDTO = m_bomSetupController.LoadBOMSetup(selectedItem.ITEM_CD);
                    copyNode = WriteToBOMNode(dbListDTO);
                }

                //== Create new DTO.
                //BOMSetupViewDTO dto = activeNode.DTO.Clone() as BOMSetupViewDTO;
                BOMSetupViewDTO dto = copyNode.DTO.Clone() as BOMSetupViewDTO;
                dto.UPPER_ITEM_CD.Value = activeBOMDTO.UPPER_ITEM_CD.Value;
                dto.UPPER_ITEM_CLS.Value = activeBOMDTO.UPPER_ITEM_CLS.Value;
                dto.UPPER_ITEM_DESC.Value = activeBOMDTO.UPPER_ITEM_DESC.Value;
                dto.UPPER_LOT_CONTROL_CLS.Value = activeBOMDTO.UPPER_LOT_CONTROL_CLS.Value;

                dto.LOWER_ITEM_CD.Value = selectedItem.ITEM_CD.Value;
                //dto.LOWER_ITEM_CLS.Value = selectedItem.ITEM_CLS.Value;
                dto.LOWER_ITEM_DESC.Value = selectedItem.ITEM_DESC.Value;
                //dto.LOWER_LOT_CONTROL_CLS.Value = selectedItem.LOT_CONTROL_CLS.Value;

                //dto.SEQ.Value = activeBOMDTO.SEQ.Value;
                dto.UPPER_QTY.Value = selectedItem.UPPER_QTY.Value;
                dto.LOWER_QTY.Value = selectedItem.LOWER_QTY.Value;
                //dto.CHILD_ORDER_LOC_CD.Value = selectedItem.CHILD_ORDER_LOC_CD.Value;
                //dto.MRP_FLAG.Value = selectedItem.MRP_FLAG.Value;
                copyNode.DTO = dto;

                List<BOMNode> listNodes = GetNodes(activeBOMDTO.UPPER_ITEM_CD.StrongValue, activeBOMDTO.LOWER_ITEM_CD.StrongValue);
                for (int i = 0; i < listNodes.Count; i++)
                {
                    // Remove old node and replace with new node.

                    BOMNode oldNode = listNodes[i];
                    int oldIndex = oldNode.Index;
                    BOMNode parentNode = (BOMNode)oldNode.Parent;

                    oldNode.Remove();
                    BOMNode newNode = (BOMNode)copyNode.Clone();
                    newNode.ExpandAll();
                    parentNode.Nodes.Insert(oldIndex, newNode);
                }

                shtView.RowCount = 0;
                FillBOMNodeToGrid(m_rootBOMNode);
                CollapseNode(m_rootBOMNode);
                ExpandNode(m_rootBOMNode);


                UpdateSqlExecute execute1 = new UpdateSqlExecute(dto, activeBOMDTO.UPPER_ITEM_CD, activeBOMDTO.LOWER_ITEM_CD);
                m_executeScript.Add(execute1);

                SetOrderLoactionandMRPFlag();
            }
        }

        private void miDeleteItem_Click(object sender, EventArgs e)
        {
            // Delete RawMaterial item Only!!!!
            BOMNode activeNode = shtView.ActiveRow.Tag as BOMNode;
            BOMSetupViewDTO activeBOMDTO = activeNode.DTO;

            List<BOMNode> listNodes = GetNodes(activeBOMDTO.UPPER_ITEM_CD.StrongValue, activeBOMDTO.LOWER_ITEM_CD.StrongValue);
            for (int i = 0; i < listNodes.Count; i++)
            {
                listNodes[i].Remove();
            }

            shtView.RowCount = 0;
            FillBOMNodeToGrid(m_rootBOMNode);

            CollapseNode(m_rootBOMNode);
            ExpandNode(m_rootBOMNode);


            DeleteSqlExecute execute1 = new DeleteSqlExecute(activeBOMDTO);
            m_executeScript.Add(execute1);
        }

        private void miDeleteTree_Click(object sender, EventArgs e)
        {
            // Delete RawMaterial item Only!!!!
            BOMNode activeNode = shtView.ActiveRow.Tag as BOMNode;
            BOMSetupViewDTO activeBOMDTO = activeNode.DTO;

            List<BOMNode> listBuffer = new List<BOMNode>();
            RetrieveListOfNodes(activeNode, listBuffer);

            if (IsTopItem(shtView.ActiveRowIndex))
            {
                for (int i = 0; i < listBuffer.Count; i++)
                {
                    listBuffer[i].Remove();

                }
            }
            else
            {
                // ลบ Node ที่ถูกคลิก
                activeNode.Remove();

                // Remove node that has same upper item code.
                List<BOMNode> listSameUpper = GetNodes(activeBOMDTO.UPPER_ITEM_CD.StrongValue, activeBOMDTO.LOWER_ITEM_CD.StrongValue);
                for (int i = 0; i < listSameUpper.Count; i++)
                {
                    listSameUpper[i].Remove();
                }

                // Remove node not same upper item code, but has same lower item code.
                List<BOMNode> listNotSameUpper = GetNodesOnLowerItem(activeBOMDTO.LOWER_ITEM_CD.StrongValue);
                for (int i = 0; i < listNotSameUpper.Count; i++)
                {
                    BOMNode node = listNotSameUpper[i];
                    node.Nodes.Clear();
                }
            }

            for (int i = 0; i < listBuffer.Count; i++)
            {
                DeleteSqlExecute execute1 = new DeleteSqlExecute(listBuffer[i].DTO);
                m_executeScript.Add(execute1);
            }

            shtView.RowCount = 0;
            FillBOMNodeToGrid(m_rootBOMNode);
            CollapseNode(m_rootBOMNode);
            ExpandNode(m_rootBOMNode);

        }
        #endregion

        #region Toolbar button event
        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Do you want to save?
                MessageDialogResult dr = MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9001.ToString()));
                if (dr == MessageDialogResult.Cancel)
                {
                    return;
                }

                if (dr == MessageDialogResult.Yes)
                {
                    m_executeScript.ExecuteScript();
                    m_executeScript.Clear();
                    MessageDialog.ShowInformation(this, null, Message.LoadMessage(Messages.eInformation.INF9003.ToString()).MessageDescription);
                    return;
                }
            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, null, err.Message);
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            // Do you want to save?
            if (MessageDialog.ShowConfirmation(this, Message.LoadMessage(Messages.eConfirm.CFM9003.ToString()), MessageDialogButtons.YesNo) == MessageDialogResult.No)
            {
                return;
            }

            m_rootBOMNode.Nodes.Clear();
            m_rootBOMNode = new BOMNode();

            shtView.RowCount = 0;
            shtView.DataSource = null;

            CtrlUtil.ClearControlData(txtItemCD, txtItemDesc);
            CtrlUtil.FocusControl(txtItemCD);

            UpdateUpDownButton();
        }
        #endregion
        #endregion

        #region FarPoint Event
        private void fpView_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;

            //หาขอบเขตแถวที่จะต้องวาด
            int startRowIndex = m_vScrollBar.Value;
            int countRow = m_vScrollBar.LargeChange;
            int currentCountRowIndex = startRowIndex;

            int currentRowIndex = startRowIndex;
            while (currentCountRowIndex < countRow + startRowIndex)
            {
                //หาพื้นที่ที่ใช้วาด
                currentRowIndex = GetNextVisibleRowIndex(currentRowIndex);
                Rectangle rect = fpView.GetCellRectangle(0, 0, currentRowIndex, 0);
                if (rect == Rectangle.Empty)
                    break;

                //วาดรูปได้เฉพาะในพื้นที่ของ Cell เท่านั้น
                gfx.ResetClip();
                gfx.SetClip(rect, System.Drawing.Drawing2D.CombineMode.Intersect);

                BOMNode currentNode = (BOMNode)shtView.Rows[currentRowIndex].Tag;

                // image index
                // 0 = Blank
                // 1 = Plus
                // 2 = Minus
                Image img = imgListStateNode.Images[0]; // default: Blank image.
                Point location = Point.Empty;

                //คำนวณตำแหน่งที่จะวางรูป
                location.Y = rect.Y + (rect.Height / 2) - 8;  // vertical-align : center
                location.X = rect.X + GetLeftIndentPosition(currentNode.Level);  // indent = 16px * level.

                //เลือกรูปที่วาดลง Cell
                if (currentNode.Nodes.Count > 0)
                {
                    if (currentNode.IsExpanded)
                    {
                        img = imgListStateNode.Images[2];
                    }
                    else
                    {
                        img = imgListStateNode.Images[1];
                    }
                }

                //วาดรูป และตำแหน่งที่ถูกต้อง
                gfx.DrawImage(img, location);


                // เลื่อนตำแหน่ง Pointer
                currentCountRowIndex++;
                currentRowIndex++;
            }
        }

        private void fpView_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            if (shtView.RowCount <= 0) return;
            if (e.Button == MouseButtons.Left)
            {
                //if (!e.ColumnHeader)                
                //    miEditItem.PerformClick();

                if (!e.ColumnHeader)
                {
                    BOMNode node = shtView.Rows[e.Row].Tag as BOMNode;
                    if (node.IsExpanded)
                    {
                        node.Collapse(true);
                        CollapseNode(node);
                    }
                    else
                    {
                        node.Expand();
                        ExpandNode(node);
                    }
                }
            }
        }

        private void fpView_MouseDown(object sender, MouseEventArgs e)
        {
            // ตัดสินใจว่าจะให้แสดง ContextMenu หรือไม่?
            if (e.Button == MouseButtons.Right)
            {
                FarPoint.Win.Spread.Model.CellRange range = fpView.GetCellFromPixel(0, 0, e.X, e.Y);

                if (range == null || range.Row == -1 || range.Column == -1)
                    m_bShowContext = false;
                else
                {
                    fpView.ActiveSheet.SetActiveCell(range.Row, range.Column);
                    fpView.ShowRow(0, range.Row, VerticalPosition.Center);
                    fpView.ActiveSheet.ClearSelection();
                    fpView.ActiveSheet.AddSelection(range.Row, 0, 1, shtView.Columns.Count);

                    // Activate SelectionChanged event.
                    fpView_SelectionChanged(sender, new SelectionChangedEventArgs(fpView.GetRootWorkbook(), range));
                    m_bShowContext = true;
                }
            }
            else
            {
                m_bShowContext = false;
            }
        }

        private void fpView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // เมื่อมีการเปลี่ยนแถว  จะโหลดข้อมูลของแถวที่เลือกแสดงบนหน้าจอ
            BOMSetupViewDTO dto = ((BOMNode)shtView.Rows[e.Range.Row].Tag).DTO;

            /*
            if (dto == null)
                ClearSection_2();
            else
                LoadBOMDTOToScreen(dto);
            */

            // ปรับปรุงสถานะของปุ่ม Up-Down สำหรับเปลี่ยน SeqNo
            UpdateUpDownButton();
        }

        #endregion

        #region Permission Control
        public void PermissionControl()
        {
            //if (!UserPermission.View)
            //{
            //    EVOFramework.Windows.Forms.MessageDialog.ShowInformation(this, "Permissionn Control"
            //        , EVOFramework.Message.LoadMessage(Messages.eInformation.INF9004.ToString()).MessageDescription);
            //    Close();
            //}
            if (!ActivePermission.Edit)
            {
                CommonLib.CtrlUtil.EnabledControl(false, Controls);
            }
        }
        #endregion

        private void btnItemCD_Click(object sender, EventArgs e)
        {
            if (txtItemCD.Text.Trim() != string.Empty)
                txtItem_KeyPressResult(txtItemCD, true, new NZString(txtItemCD, txtItemCD.Text.Trim()));
        }

        private void fpView_KeyDown(object sender, KeyEventArgs e)
        {
            CtrlUtil.FilterShortCut(e);
        }

    }
}
