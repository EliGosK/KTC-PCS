using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.IO;
using System.Text;

namespace Cube.AFD.Windows.Controls.CalendarControls.Design {
    internal class CalendarDesigner : ControlDesigner{
        private Calendar m_calendar = null;


        public override void Initialize(IComponent component) {
            m_calendar = (Calendar)component;
            base.Initialize(component);
            
        }

        public override DesignerVerbCollection Verbs {
            get {
                DesignerVerbCollection vs = new DesignerVerbCollection(new DesignerVerb[] {
                    new DesignerVerb("Calendar Designer", new EventHandler(OnCalendarDesigner))
                });
                    
                return vs;
            }
        }

        void OnCalendarDesigner(object sender, EventArgs e) {
            try {
                CalendarEditor frm = new CalendarEditor(this, m_calendar.CalendarStyle, m_calendar);
                if (frm.ShowDialog() == DialogResult.OK) {
                    // Calendar Style
                    PropertyDescriptor prop = TypeDescriptor.GetProperties(Component)["CalendarStyle"];
                    prop.SetValue(Component, frm.CalendarStyle);

                    // Calendar Type
                    prop = TypeDescriptor.GetProperties(Component)["CalendarType"];
                    prop.SetValue(Component, frm.CalendarType);

                    // Calendar View
                    prop = TypeDescriptor.GetProperties(Component)["CalendarView"];
                    prop.SetValue(Component, frm.CalendarView);
                    // Show Checked Box
                    prop = TypeDescriptor.GetProperties(Component)["ShowCheckBox"];
                    prop.SetValue(Component, frm.ShowCheckBox);
                    // Selection Policy
                    prop = TypeDescriptor.GetProperties(Component)["SelectionPolicy"];
                    prop.SetValue(Component, frm.SelectionPolicy);
                    // Editor Control
                    //prop = TypeDescriptor.GetProperties(Component)[""];
                    prop = TypeDescriptor.GetProperties(Component)["EditorControlType"];
                    prop.SetValue(Component, frm.EditorControlType);
                    // Editor Mode
                    prop = TypeDescriptor.GetProperties(Component)["EditorMode"];
                    prop.SetValue(Component, frm.EditorMode);
                    // Editor View
                    prop = TypeDescriptor.GetProperties(Component)["EditorView"];
                    prop.SetValue(Component, frm.EditorView);
                    // Editor When
                    prop = TypeDescriptor.GetProperties(Component)["EditorWhen"];
                    prop.SetValue(Component, frm.EditorWhen);

                    
                    //prop = TypeDescriptor.GetProperties(Component)["CalendarStyle.MonthText"];
                    //prop.SetValue(Component, frm.CalendarStyle.MonthText);

                    //prop = TypeDescriptor.GetProperties(Component)["CalendarStyle.WeekText"];
                    //prop.SetValue(Component, frm.CalendarStyle.WeekText);

                    m_calendar.InvalidateAll();
                }
            } catch (Exception ex) {
                MessageBox.Show("Error occor during open calendar designer : " + ex.ToString());
            }

        }


    }
}
