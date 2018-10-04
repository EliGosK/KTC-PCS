using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVOFramework.Data;
using EVOFramework.Windows.Forms;
using SystemMaintenance.BIZ;
using SystemMaintenance.DTO;
using FarPoint.Win.Spread;
using SystemMaintenance.Controller;
using CommonLib;

namespace SystemMaintenance.Forms
{
    public partial class CustomizeBaseForm : EVOForm
    {
        public ActivePermissionValue ActivePermission { get; set; }
        private PermissionValue GroupPermission { get; set; }
        private PermissionValue UserPermission { get; set; }

        public CustomizeBaseForm()
        {
            InitializeComponent();
            UserPermission = new PermissionValue();
            GroupPermission = new PermissionValue();
            ActivePermission = new ActivePermissionValue();
        }

        #region Overriden methods
        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode)
            {
                // Interception load control text.
                if (this.ScreenCode != "SYS_LOGIN")
                {
                InitializeControlText();
                }
            }

            base.OnLoad(e);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }
        #endregion

        #region Virtual methods
        /// <summary>
        /// Initialize all control text following by stored data on database, depend on current user's language.
        /// </summary>
        protected virtual void InitializeControlText()
        {
            if (this.ScreenCode == string.Empty)
                return;

            Map<string, ScreenDetail> mapControlList = this.GetControlList();
            ScreenDetailLangBIZ bizScreenDetailLang = new ScreenDetailLangBIZ();

            string langCD = CommonLib.Common.SystemLanguage.StrongValue;

            if (CommonLib.Common.CurrentUserInfomation != null)
                langCD = CommonLib.Common.CurrentUserInfomation.LanguageCD.StrongValue;

            // Load screen detail depend on language.
            List<ScreenDetailLangDTO> listScreenDetailLang = bizScreenDetailLang.LoadScreenDetailByLangCD(this.ScreenCode, langCD);
            for (int i = 0; i < listScreenDetailLang.Count; i++)
            {
                ScreenDetailLangDTO dto = listScreenDetailLang[i];
                MapKeyValue<string, ScreenDetail> mapKeyValue = mapControlList[dto.CONTROL_CD.StrongValue];
                if (mapKeyValue == null)
                    continue;

                ScreenDetail screenDetail = mapKeyValue.Value;
                Control ctrl = null;
                switch (screenDetail.Type)
                {
                    case ScreenDetail.TYPE_FORM:
                        ctrl = screenDetail.ObjOwner as Control;
                        if (ctrl != null)
                            ctrl.Text = ScreenAttribute.GetScreenAttribute(screenDetail.ObjOwner.GetType()).ScreenCD + ": " + dto.CONTROL_CAPTION.NVL(string.Empty);
                        break;
                    case ScreenDetail.TYPE_BUTTON:
                    case ScreenDetail.TYPE_CHECKBOX:
                    case ScreenDetail.TYPE_GROUPBOX:
                    case ScreenDetail.TYPE_LABEL:
                    case ScreenDetail.TYPE_RADIOBUTTON:
                    case ScreenDetail.TYPE_TABPAGE:
                        ctrl = screenDetail.ObjOwner as Control;
                        if (ctrl != null)
                            ctrl.Text = dto.CONTROL_CAPTION.NVL(string.Empty);

                        break;

                    case ScreenDetail.TYPE_SPREAD_COLUMN:
                        Column column = screenDetail.ObjOwner as Column;
                        if (column != null)
                            column.Label = dto.CONTROL_CAPTION.NVL(string.Empty);
                        break;
                }
            }
        }
        #endregion

        protected void CustomizeBaseForm_Shown(object sender, EventArgs e)
        {
            InitialPermissionValue();
            // EnableButtonByPermission();
        }

        #region Permission

        protected void InitialPermissionValue()
        {
            if (Common.CurrentUserInfomation == null)
            {
                return;
            }
            UserPermission.View = PermissionValue.ePermission.No;
            UserPermission.Add = PermissionValue.ePermission.No;
            UserPermission.Edit = PermissionValue.ePermission.No;
            UserPermission.Delete = PermissionValue.ePermission.No;

            GroupPermission.View = PermissionValue.ePermission.No;
            GroupPermission.Add = PermissionValue.ePermission.No;
            GroupPermission.Edit = PermissionValue.ePermission.No;
            GroupPermission.Delete = PermissionValue.ePermission.No;



            #region Get Permission value from database
            AuthorizedMaintenanceController authorizedMntCtrl = new AuthorizedMaintenanceController();

            EVOFramework.Windows.Forms.ScreenAttribute screenAttribute = EVOFramework.Windows.Forms.ScreenAttribute.GetScreenAttribute(this.GetType());

            if (screenAttribute != null)
            {
                DataTable dtUser = authorizedMntCtrl.LoadUserPermissionJoinScreen(screenAttribute.ScreenCD);
                // Check User Permission First
                if (dtUser != null)
                {
                    DataRow[] dr = dtUser.Select(String.Format("USER_CD = '{0}'", Common.CurrentUserInfomation.UserCD.StrongValue));

                    if (dr.Length != 0)
                    {

                        UserPermission.View = (PermissionValue.ePermission)Enum.Parse(typeof(PermissionValue.ePermission), dr[0][(int)PermissionValue.eUserPermission.FLG_VIEW].ToString());

                        UserPermission.Add = (PermissionValue.ePermission)Enum.Parse(typeof(PermissionValue.ePermission), dr[0][(int)PermissionValue.eUserPermission.FLG_ADD].ToString());

                        UserPermission.Edit = (PermissionValue.ePermission)Enum.Parse(typeof(PermissionValue.ePermission), dr[0][(int)PermissionValue.eUserPermission.FLG_CHG].ToString());

                        UserPermission.Delete = (PermissionValue.ePermission)Enum.Parse(typeof(PermissionValue.ePermission), dr[0][(int)PermissionValue.eUserPermission.FLG_DEL].ToString());

                        //if (dr[0][PermissionValue.eUserPermission.FLG_VIEW.ToString()].ToString() == "1")
                        //    UserPermission.View = PermissionValue.ePermission.Yes;

                        //if (dr[0][PermissionValue.eUserPermission.FLG_ADD.ToString()].ToString() == "1")
                        //    UserPermission.Add = PermissionValue.ePermission.Yes;

                        //if (dr[0][PermissionValue.eUserPermission.FLG_CHG.ToString()].ToString() == "1")
                        //    UserPermission.Edit = PermissionValue.ePermission.Yes;

                        //if (dr[0][PermissionValue.eUserPermission.FLG_DEL.ToString()].ToString() == "1")
                        //    UserPermission.Delete = PermissionValue.ePermission.Yes;

                        //if (dr[0][PermissionValue.eUserPermission.FLG_VIEW.ToString()].ToString() == "0")
                        //    UserPermission.View = PermissionValue.ePermission.No;

                        //if (dr[0][PermissionValue.eUserPermission.FLG_ADD.ToString()].ToString() == "0")
                        //    UserPermission.Add = PermissionValue.ePermission.No;

                        //if (dr[0][PermissionValue.eUserPermission.FLG_CHG.ToString()].ToString() == "0")
                        //    UserPermission.Edit = PermissionValue.ePermission.No;

                        //if (dr[0][PermissionValue.eUserPermission.FLG_DEL.ToString()].ToString() == "0")
                        //    UserPermission.Delete = PermissionValue.ePermission.No;

                        //if (dr[0][PermissionValue.eUserPermission.FLG_VIEW.ToString()].ToString() == "-1")
                        //    UserPermission.View = PermissionValue.ePermission.UpToGroup;

                        //if (dr[0][PermissionValue.eUserPermission.FLG_ADD.ToString()].ToString() == "-1")
                        //    UserPermission.Add = PermissionValue.ePermission.UpToGroup;

                        //if (dr[0][PermissionValue.eUserPermission.FLG_CHG.ToString()].ToString() == "-1")
                        //    UserPermission.Edit = PermissionValue.ePermission.UpToGroup;

                        //if (dr[0][PermissionValue.eUserPermission.FLG_DEL.ToString()].ToString() == "-1")
                        //    UserPermission.Delete = PermissionValue.ePermission.UpToGroup;
                    }
                }

                // Check Group Permission
                DataTable dtGroup = authorizedMntCtrl.LoadGroupPermissionJoinScreen(screenAttribute.ScreenCD);

                if (dtGroup != null)
                {
                    DataRow[] dr = dtGroup.Select(String.Format("GROUP_CD = '{0}'", Common.CurrentUserInfomation.GroupCode.StrongValue));

                    GroupPermission.View = (PermissionValue.ePermission)Enum.Parse(typeof(PermissionValue.ePermission), dr[0][(int)PermissionValue.eUserPermission.FLG_VIEW].ToString());

                    GroupPermission.Add = (PermissionValue.ePermission)Enum.Parse(typeof(PermissionValue.ePermission), dr[0][(int)PermissionValue.eUserPermission.FLG_ADD].ToString());

                    GroupPermission.Edit = (PermissionValue.ePermission)Enum.Parse(typeof(PermissionValue.ePermission), dr[0][(int)PermissionValue.eUserPermission.FLG_CHG].ToString());

                    GroupPermission.Delete = (PermissionValue.ePermission)Enum.Parse(typeof(PermissionValue.ePermission), dr[0][(int)PermissionValue.eUserPermission.FLG_DEL].ToString());


                    //if (dr[0][PermissionValue.eGroupPermission.FLG_VIEW.ToString()].ToString() == "1")
                    //    GroupPermission.View = PermissionValue.ePermission.Yes;

                    //if (dr[0][PermissionValue.eGroupPermission.FLG_ADD.ToString()].ToString() == "1")
                    //    GroupPermission.Add = PermissionValue.ePermission.Yes;

                    //if (dr[0][PermissionValue.eGroupPermission.FLG_CHG.ToString()].ToString() == "1")
                    //    GroupPermission.Edit = PermissionValue.ePermission.Yes;

                    //if (dr[0][PermissionValue.eGroupPermission.FLG_DEL.ToString()].ToString() == "1")
                    //    GroupPermission.Delete = PermissionValue.ePermission.Yes;

                    //if (dr[0][PermissionValue.eGroupPermission.FLG_VIEW.ToString()].ToString() == "0")
                    //    GroupPermission.View = PermissionValue.ePermission.No;

                    //if (dr[0][PermissionValue.eGroupPermission.FLG_ADD.ToString()].ToString() == "0")
                    //    GroupPermission.Add = PermissionValue.ePermission.No;

                    //if (dr[0][PermissionValue.eGroupPermission.FLG_CHG.ToString()].ToString() == "0")
                    //    GroupPermission.Edit = PermissionValue.ePermission.No;

                    //if (dr[0][PermissionValue.eGroupPermission.FLG_DEL.ToString()].ToString() == "0")
                    //    GroupPermission.Delete = PermissionValue.ePermission.No;
                }
            }
            #endregion

            #region Set Active Permission Value
            ActivePermission.View = GetActivePermission(GroupPermission.View, UserPermission.View);
            ActivePermission.Add = GetActivePermission(GroupPermission.Add, UserPermission.Add);
            ActivePermission.Edit = GetActivePermission(GroupPermission.Edit, UserPermission.Edit);
            ActivePermission.Delete = GetActivePermission(GroupPermission.Delete, UserPermission.Delete);
            #endregion
        }

        protected bool GetActivePermission(PermissionValue.ePermission GroupPermission, PermissionValue.ePermission UserPermission)
        {
            // Permission Matrix
            // Group    User    Active
            //   0        0         0
            //   0        1         1
            //   0       -1         0
            //   1        0         0
            //   1        1         1
            //   1       -1         1
            if (UserPermission == PermissionValue.ePermission.No)
                return false;
            else if (UserPermission == PermissionValue.ePermission.Yes)
                return true;
            else//UserPermission == PermissionValue.ePermission.uptoGroup
            {
                if (GroupPermission == PermissionValue.ePermission.Yes)
                    return true;
                else
                    return false;
            }
        }

        #endregion
    }


    public class PermissionValue
    {
        public enum eGroupPermission
        {
            SCREEN_CD,
            GROUP_CD,
            FLG_VIEW,
            FLG_ADD,
            FLG_CHG,
            FLG_DEL,
            GROUP_NAME
        }
        public enum eUserPermission
        {
            SCREEN_CD,
            USER_CD,
            FLG_VIEW,
            FLG_ADD,
            FLG_CHG,
            FLG_DEL
        }

        public enum ePermission
        {
            Yes = 1,
            No = 0,
            UpToGroup = 2
        }


        public ePermission View { get; set; }
        public ePermission Add { get; set; }
        public ePermission Edit { get; set; }
        public ePermission Delete { get; set; }

    }

    public class ActivePermissionValue
    {

        public bool View { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }

    }
}
