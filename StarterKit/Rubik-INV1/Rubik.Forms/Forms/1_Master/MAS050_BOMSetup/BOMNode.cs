using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DTO;

namespace Rubik.Master
{
    partial class MAS050_BOMSetup
    {
        /// <summary>
        /// โครงสร้าง BOM Structure node.
        /// </summary>
        private class BOMNode : System.Windows.Forms.TreeNode
        {
            #region Variables
            private BOMSetupViewDTO m_dto = null;
            #endregion

            #region Constructor
            public BOMNode() {}

            public BOMNode(BOMSetupViewDTO dto)
            {
                this.m_dto = dto;
                Text = this.ToString();
            }
            #endregion

            #region Properties
            public BOMSetupViewDTO DTO
            {
                get { return m_dto; }
                set { 
                    m_dto = value;
                    Text = this.ToString();
                }
            }

            private string PrimaryKeys
            {
                get
                {
                    if (DTO == null)
                        return string.Empty;

                    return String.Format("{0}~{1}", DTO.UPPER_ITEM_CD.Value, DTO.LOWER_ITEM_CD.Value);
                }
            }
            #endregion

            #region Public method
            public bool HasChildNodes {
                get { return this.Nodes.Count > 0; }
            }
            #endregion

            #region Overriden method
            public override object Clone()
            {                
                BOMNode node = base.Clone() as BOMNode;
                if (node != null)
                    node.DTO = this.DTO.Clone() as BOMSetupViewDTO;

                return node;
            }
            public override string ToString()
            {
                return String.Format("Level: {0}, [{1}]", this.Level, PrimaryKeys);
            }
            #endregion

        }
    }
}
