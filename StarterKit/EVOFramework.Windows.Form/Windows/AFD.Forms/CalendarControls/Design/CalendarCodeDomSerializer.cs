using System;
using System.Drawing;
using System.Windows.Forms;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace Cube.AFD.Windows.Controls.CalendarControls.Design {

    internal class CalendarCodeDomSerializer : CodeDomSerializer {
        private CodeCommentStatement[] m_codeCommentHeader;
        public CalendarCodeDomSerializer(){
            m_codeCommentHeader = new CodeCommentStatement[]{
                new CodeCommentStatement("Author : Kitisak S."),
                new CodeCommentStatement("Company : CSI Thailand."),
                new CodeCommentStatement("Group : PI-RD")};
        }
        private void InsertCodeCommentHeader(CodeStatementCollection statements) {

            for (int i = m_codeCommentHeader.Length - 1; i >= 0; --i) {
                statements.Insert(0,m_codeCommentHeader[i]);
            }
        }

        public override object Serialize(IDesignerSerializationManager manager, object value) {
            try {
                CodeDomSerializer serial = (CodeDomSerializer)manager.GetSerializer(typeof(Component), typeof(CodeDomSerializer));
                if (serial == null)
                    return null;

                CodeStatementCollection statements = (CodeStatementCollection)serial.Serialize(manager, value);
                IDesignerHost host = (IDesignerHost)manager.GetService(typeof(IDesignerHost));
                if (host == value)
                    return statements;

                InsertCodeCommentHeader(statements);

                Calendar cdr = (Calendar)value;
                CodeExpression cnref = SerializeToExpression(manager, value);

                CodePropertyReferenceExpression propref = null;
                //CodeAssignStatement cassign = null;
                //cdr.CalendarStyle.CalendarHeader = new HeaderStyle(Font, foreColor, backColor, height);
                // CalendarStyle.CalendarHeader
                propref = new CodePropertyReferenceExpression(cnref, "CalendarStyle.CalendarHeader");
              


                return statements;
            } catch (Exception ex) {
                MessageBox.Show("Error during Serialize : " + ex.ToString());
                return null;
            }
        }

        public override object Deserialize(IDesignerSerializationManager manager, object codeObject) {
            try {
                CodeDomSerializer serial = (CodeDomSerializer)manager.GetSerializer(typeof(Component), typeof(CodeDomSerializer));
                return serial.Deserialize(manager, codeObject);
            } catch (Exception ex) {
                MessageBox.Show("Error during Deserialize : " + ex.ToString());
                return null;
            }
        }
    }
}
