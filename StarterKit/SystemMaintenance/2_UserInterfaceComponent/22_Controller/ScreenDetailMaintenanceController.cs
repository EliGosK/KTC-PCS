using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.UIDataModel;
using System.Data;
using SystemMaintenance.BIZ;
using EVOFramework;
using SystemMaintenance.DTO;
using EVOFramework.Data;

namespace SystemMaintenance.Controller
{
    class ScreenDetailMaintenanceController
    {
        internal object LoadAllDatabyLangCD(string LangCD)
        {
            ScreenBIZ biz = new ScreenBIZ();
            NZString langCD = new NZString();
            langCD.Value = LangCD;
            DatabaseScreenList screenList = biz.LoadScreensWithLangCD(langCD);

            DataTable dt = new DataTable();
            dt.Columns.Add("SCREEN_CD");
            dt.Columns.Add("ORIGINAL_TITLE");
            dt.Columns.Add("DISPLAY_TITLE");
            dt.Columns.Add("IMAGE_CD");
            for (int i = 0; i < screenList.Count; i++)
            {
                dt.Rows.Add(screenList[i].ScreenCD.StrongValue,
                    screenList[i].ScreenName.StrongValue,
                    screenList[i].ScreenDescription.StrongValue,
                    screenList[i].ImageCD.StrongValue);
            }
            return dt;
        }

        internal int SaveScreenDisplayText(string ScreenCD, string LangCD, string DisplayTitle)
        {
            ScreenLangBIZ biz = new ScreenLangBIZ();
            ScreenLangDTO dto = new ScreenLangDTO();
            dto.SCREEN_CD.Value = ScreenCD;
            dto.LANG_CD.Value = LangCD;
            dto.SCREEN_DESC.Value = DisplayTitle;
            dto.UPD_BY.Value = CommonLib.Common.CurrentUserInfomation.UserCD.StrongValue;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE.Value = Environment.MachineName;
            return biz.UpdateScreenDisplayText(dto);
        }

        public DataTable LoadScreenDetailWithOriginalCaptionByLangCD(string screenCD, string LangCD)
        {
            ScreenDetailLangBIZ biz = new ScreenDetailLangBIZ();
            return biz.LoadScreenDetailWithOriginalCaptionByLangCD(screenCD, LangCD);
           
        }

        internal int SaveScreenDetailDisplayText(string ScreenCD, string ControlCD, string LangCD, string DisplayTitle)
        {
            ScreenDetailLangBIZ biz = new ScreenDetailLangBIZ();
            ScreenDetailLangDTO dto = new ScreenDetailLangDTO();
            dto.CONTROL_CD.Value = ControlCD;
            dto.LANG_CD.Value = LangCD;
            dto.SCREEN_CD.Value = ScreenCD;
            dto.CONTROL_CAPTION.Value = DisplayTitle;
            dto.UPD_BY.Value = CommonLib.Common.CurrentUserInfomation.UserCD.StrongValue;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE.Value = Environment.MachineName;
            return biz.UpdateScreenDisplayText(dto);
        }

        internal int SaveChangeImage(string screenCD, string imageCD)
        {
            ScreenBIZ biz = new ScreenBIZ();
            ScreenDTO dto = new ScreenDTO();
            dto.SCREEN_CD.Value = screenCD;
            dto.IMAGE_CD.Value = imageCD;
            dto.UPD_BY.Value = CommonLib.Common.CurrentUserInfomation.UserCD.StrongValue;
            dto.UPD_DATE.Value = DateTime.Now;
            dto.UPD_MACHINE.Value = Environment.MachineName;
            return biz.UpdateScreenImage(dto);
        }
    }

}
