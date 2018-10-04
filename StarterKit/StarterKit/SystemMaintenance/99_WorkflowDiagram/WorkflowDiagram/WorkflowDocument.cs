using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkFlowDiagram.DTO;
using WorkFlowDiagram.DAO;
using System.Windows.Forms;
using System.Drawing;
using EVOFramework.Database;

namespace WorkFlowDiagram
{
    /// <summary>
    /// Represents data model to use on WorkFlow Viewer.
    /// </summary>
    public class WorkflowDocument
    {
        #region "  Variables  "
        private string m_workflowID = String.Empty;
        private WorkflowButtonList m_buttonList = new WorkflowButtonList();
        private WorkflowLineHeaderList m_lineHeaderList = new WorkflowLineHeaderList();
        #endregion

        #region "  Constructor  "
        internal WorkflowDocument(string workflowID, WorkflowButtonList buttonList, WorkflowLineHeaderList lineHeaderList)
        {
            m_workflowID = workflowID;
            ButtonList = buttonList;
            LineHeaderList = lineHeaderList;
        }
        #endregion

        #region "  Properties  "
        /// <summary>
        /// Get WorkFlow ID.
        /// </summary>
        public string WorkflowID
        {
            get { return m_workflowID; }
            internal set { m_workflowID = value; }
        }

        /// <summary>
        /// Get or set ButtonList
        /// </summary>
        internal WorkflowButtonList ButtonList
        {
            get { return m_buttonList; }
            set { m_buttonList = value; }
        }

        /// <summary>
        /// Get or set LineHeaderList
        /// </summary>
        internal WorkflowLineHeaderList LineHeaderList
        {
            get { return m_lineHeaderList; }
            set { m_lineHeaderList = value; }
        }

        /// <summary>
        /// Get button count.
        /// </summary>
        public int ButtonsCount
        {
            get
            {
                if (ButtonList == null)
                    return 0;

                return ButtonList.Count;
            }
        }

        /// <summary>
        /// Get line header count.
        /// </summary>
        public int LinesCount
        {
            get
            {
                if (LineHeaderList == null)
                    return 0;

                return LineHeaderList.Count;
            }
        }
        #endregion

        #region "  Static method  "
        public static WorkflowDocument LoadDatabase(Database db, string workflowID, string USER_ACCOUNT)
        {
            WorkflowButtonList buttonList = new WorkflowButtonList();
            WorkflowLineHeaderList lineHeaderList = new WorkflowLineHeaderList();

            ButtonDAO daoButton = new ButtonDAO();
            LineHeaderDAO daoLineHeader = new LineHeaderDAO();
            LineDetailDAO daoLineDetail = new LineDetailDAO();
            ConnectorDAO daoConnector = new ConnectorDAO();

            #region "  Load Buttons  "

            //== Generate all Button (not binding event click)
            //  Event ButtonClick will bind when assign document to viewer.
            List<ButtonDTO> listButtons = daoButton.FindButton(db, workflowID, USER_ACCOUNT, SystemMaintenance.DataDefine.AUTO_ARRANGE_ICON, SystemMaintenance.DataDefine.ICON_PER_ROW);
            for (int i = 0; i < listButtons.Count; i++)
            {
                ButtonDTO dto = listButtons[i];
                WorkflowButton button = new WorkflowButton(dto);
                button.Dock = DockStyle.Fill;
                button.Anchor = AnchorStyles.None;
                button.Name = String.Format("{0}.{1}.{2}", dto.WF_ID, dto.ROW_INDEX, dto.COL_INDEX);
                //button.Click += new EventHandler(buttonClick);
                button.Location = new Point(0, 0);

                if (dto.FLG_VIEW == 1)
                {
                    button.Visible = true;
                }
                else
                {
                    button.Visible = false;
                }

                // add to collection
                buttonList.Add(button);
            }

            #endregion


            //ถ้าเปิดให้ auto arrange icon จะไม่มี work flow line 
            if (SystemMaintenance.DataDefine.AUTO_ARRANGE_ICON != true)
            {
                #region "  Load Lines  "

                List<LineHeaderDTO> listLineHeader = daoLineHeader.GetLineHeaders(db, workflowID);
                for (int i = 0; i < listLineHeader.Count; i++)
                {

                    LineHeaderDTO lineHeaderDTO = listLineHeader[i];
                    List<LineDetailDTO> listLineDetail = daoLineDetail.GetLineDetails(db, workflowID, lineHeaderDTO.ID);
                    List<ConnectorDTO> listConnector = daoConnector.GetConnectors(db, workflowID, lineHeaderDTO.ID);

                    // Create Model Header
                    WorkflowLineHeader wf_header = new WorkflowLineHeader(null, lineHeaderDTO.ID, lineHeaderDTO.ZINDEX);

                    // Loop for Create inner Model LineDetail.
                    for (int iLine = 0; iLine < listLineDetail.Count; iLine++)
                    {

                        LineDetailDTO lineDetailDTO = listLineDetail[iLine];
                        WorkflowLineDetail wf_detail = new WorkflowLineDetail(wf_header
                                                                              ,
                                                                              new Cell(null, lineDetailDTO.FROM_ROW,
                                                                                       lineDetailDTO.FROM_COL)
                                                                              ,
                                                                              new Cell(null, lineDetailDTO.TO_ROW,
                                                                                       lineDetailDTO.TO_COL)
                                                                              , (WorkflowLineStatus)lineDetailDTO.STATUS);

                        wf_header.Lines.Add(wf_detail);
                    }

                    // Loop for Create inner Model LineConnector.
                    for (int iConnector = 0; iConnector < listConnector.Count; iConnector++)
                    {
                        ConnectorDTO connectorDTO = listConnector[iConnector];
                        WorkflowLineConnector wf_connector = new WorkflowLineConnector(wf_header
                                                                                       ,
                                                                                       new Cell(null, connectorDTO.ROW_INDEX,
                                                                                                connectorDTO.COL_INDEX)
                                                                                       ,
                                                                                       (WorkflowConnectorType)
                                                                                       connectorDTO.STATUS);

                        wf_header.Connectors.Add(wf_connector);
                    }
                    lineHeaderList.Add(wf_header);
                }

                #endregion
            }

            WorkflowDocument document = new WorkflowDocument(workflowID, buttonList, lineHeaderList);
            return document;
        }

        public static WorkflowDocument LoadXML(string filename)
        {
            return null;
        }
        #endregion
    }
}
