using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DTO;
using EVOFramework.Windows.Forms;

namespace Rubik.Master
{
    partial class MAS050_BOMSetup
    {        
        private bool CheckBeforeAddNewChildItem(BOMNode parentNode, BOMNode newChildNode) {

            //== Check Recursion Looping.
            List<BOMNode> listNewChild = new List<BOMNode>();
            RetrieveListOfNodes(newChildNode, listNewChild);

            List<BOMNode> listTopNode = new List<BOMNode>();
            RetrieveListOfTopNodes(parentNode, listTopNode);

            for (int i = 0; i < listTopNode.Count; i++ ) {
                for (int j = 0; j<listNewChild.Count; j++) {
                    if (Equals(listTopNode[i].DTO.LOWER_ITEM_CD.Value, listNewChild[j].DTO.LOWER_ITEM_CD.Value)) {
                        MessageDialog.ShowBusiness(this, null, "Recursive occurs.");
                        return false;
                    }
                }
            }


            //== Check duplicate Node on same level.
            for (int i=0; i<parentNode.Nodes.Count; i++) {
                BOMSetupViewDTO childDTO = ( (BOMNode) parentNode.Nodes[i] ).DTO;                
                if (Equals(childDTO.LOWER_ITEM_CD.Value, newChildNode.DTO.LOWER_ITEM_CD.Value)) {
                    MessageDialog.ShowBusiness(this, null, "Duplicate occurs.");
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// ตรวจสอบ Node ก่อนที่จะทำการเปลี่ยน LowerItem.
        /// </summary>
        private bool CheckBeforeChangeItem(BOMNode activeNode, BOMNode newNode)
        {
            //== Check Recursion Looping.
            List<BOMNode> listNewChild = new List<BOMNode>();
            RetrieveListOfNodes(newNode, listNewChild);

            List<BOMNode> listTopNode = new List<BOMNode>();
            RetrieveListOfTopNodes((BOMNode)activeNode.Parent, listTopNode);

            for (int i = 0; i < listTopNode.Count; i++)
            {
                for (int j = 0; j < listNewChild.Count; j++)
                {
                    if (Equals(listTopNode[i].DTO.LOWER_ITEM_CD.Value, listNewChild[j].DTO.LOWER_ITEM_CD.Value))
                    {
                        MessageDialog.ShowBusiness(this, null, "Recursive occurs.");
                        return false;
                    }
                }
            }

            //== Check duplicate Node on same level.
            BOMNode parentNode = (BOMNode) activeNode.Parent;
            for (int i = 0; i < parentNode.Nodes.Count; i++)
            {
                BOMSetupViewDTO childDTO = ((BOMNode)parentNode.Nodes[i]).DTO;
                if (Equals(childDTO.LOWER_ITEM_CD.Value, newNode.DTO.LOWER_ITEM_CD.Value))
                {
                    MessageDialog.ShowBusiness(this, null, "Duplicate occurs.");
                    return false;
                }
            }



            return true;
        }
    }
}
