using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Windows.Forms;
using EVOFramework.Data;
using System.Data;



namespace CommonLib
{
    public class ComboUtil
    {
        public static void LoadLookup<T>(EVOComboBox control, List<T> listData, string displayMember, string valueMember) 
            where T:IDataTransferObject {

            DataTable dt = DTOUtility.ConvertListToDataTable(listData);
            LoadLookup(control, dt, displayMember, valueMember);
        }

        public static void LoadLookup(EVOComboBox control, DataTable listData, string displayMember, string valueMember)
        {
            control.DisplayMember = displayMember;
            control.ValueMember = valueMember;
            control.DataSource = listData;
        }

        public static void AssignLookup(EVOComboBox control, LookupData data) {
            control.DisplayMember = data.DisplayMember;
            control.ValueMember = data.ValueMember;
            control.DataSource = data.DataSource;
        }        
    }
}
