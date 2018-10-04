using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemMaintenance.BIZ;
using SystemMaintenance.UIDataModel;
using SystemMaintenance.DTO;
using EVOFramework;

namespace SystemMaintenance.Controller
{
    public class ScreenImportController
    {
        //ScreenImportBIZ m_ScreenImportBIZ;

        public ScreenImportController()
        {
        }

        public void ImportData(List<ScreenImportUIDM> ScreenImportList, List<ScreenDetailUIDM> UIDMScreenDetailList)
        {
            LangBIZ bizLang = new LangBIZ();
            LangDTO dtoLang = new LangDTO();

            ScreenDetailBIZ bizScreenDetail = new ScreenDetailBIZ();

            List<ScreenDTO> screenDTOList = new List<ScreenDTO>();
            List<ScreenLangDTO> screenLangDTOList = new List<ScreenLangDTO>();
            List<ScreenDetailDTO> screenDetailDTOList = new List<ScreenDetailDTO>();
            List<ScreenDetailLangDTO> screenDetailLangDTOList = new List<ScreenDetailLangDTO>();
            // count lang detail
            List<LangDTO> langDTOList = bizLang.LoadAll();

            #region Collect Data
            foreach (ScreenImportUIDM ScreenImport in ScreenImportList)
            {
                // check if screen is never been import then import to screen ms
                if (ScreenImport.ImportStatus.StrongValue.ToUpper() == "NOTIMPORT")
                {


                    ScreenDTO dtoScreen = new ScreenDTO();
                    dtoScreen.SCREEN_CD = ScreenImport.ScreenCD;
                    dtoScreen.SCREEN_NAME = ScreenImport.ScreenName;
                    dtoScreen.ORIGINAL_TITLE = ScreenImport.ScreenName;
                    dtoScreen.IMAGE_CD.Value = "DEFAULT";
                    dtoScreen.SCREEN_TYPE = ScreenImport.ScreenType;
                    dtoScreen.SCREEN_ACTION.Value = 0;
                    dtoScreen.EXT_PROGRAM.Value = string.Empty;
                    dtoScreen.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dtoScreen.CRT_DATE.Value = DateTime.Now;
                    dtoScreen.CRT_MACHINE.Value = Environment.MachineName;
                    dtoScreen.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dtoScreen.UPD_DATE.Value = DateTime.Now;
                    dtoScreen.UPD_MACHINE.Value = Environment.MachineName;

                    screenDTOList.Add(dtoScreen);

                    if (langDTOList.Count > 0)
                    {
                        foreach (LangDTO langdto in langDTOList)
                        {
                            ScreenLangDTO dtoScreenLang = new ScreenLangDTO();
                            // add multilang for screen name
                            dtoScreenLang.SCREEN_CD = ScreenImport.ScreenCD;
                            dtoScreenLang.SCREEN_DESC = ScreenImport.ScreenName;
                            dtoScreenLang.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                            dtoScreenLang.CRT_DATE.Value = DateTime.Now;
                            dtoScreenLang.CRT_MACHINE.Value = Environment.MachineName;
                            dtoScreenLang.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                            dtoScreenLang.UPD_DATE.Value = DateTime.Now;
                            dtoScreenLang.UPD_MACHINE.Value = Environment.MachineName;
                            dtoScreenLang.LANG_CD = langdto.LANG_CD;
                            //bizScreenLang.AddNew(dtoScreenLang);
                            screenLangDTOList.Add(dtoScreenLang);
                        }
                    }

                }
            }

            foreach (ScreenDetailUIDM ScreenDetail in UIDMScreenDetailList)
            {
                ScreenDetailDTO dtoScreenDetail = new ScreenDetailDTO();
                dtoScreenDetail.SCREEN_CD = ScreenDetail.ScreenCD;
                dtoScreenDetail.CONTROL_TYPE = ScreenDetail.ControlType;
                dtoScreenDetail.ORIGINAL_TITLE = ScreenDetail.ControlCaption;
                dtoScreenDetail.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoScreenDetail.CRT_DATE.Value = DateTime.Now;
                dtoScreenDetail.CRT_MACHINE.Value = Environment.MachineName;
                dtoScreenDetail.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoScreenDetail.UPD_DATE.Value = DateTime.Now;
                dtoScreenDetail.UPD_MACHINE.Value = Environment.MachineName;
                dtoScreenDetail.CONTROL_CD = ScreenDetail.ControlCD;
                screenDetailDTOList.Add(dtoScreenDetail);

                if (langDTOList.Count > 0)
                {
                    foreach (LangDTO langdto in langDTOList)
                    {
                        ScreenDetailLangDTO dtoScreenDetailLang = new ScreenDetailLangDTO();
                        // add spread column to screen detail ms
                        dtoScreenDetailLang.SCREEN_CD = ScreenDetail.ScreenCD;
                        dtoScreenDetailLang.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                        dtoScreenDetailLang.CRT_DATE.Value = DateTime.Now;
                        dtoScreenDetailLang.CRT_MACHINE.Value = Environment.MachineName;
                        dtoScreenDetailLang.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                        dtoScreenDetailLang.UPD_DATE.Value = DateTime.Now;
                        dtoScreenDetailLang.UPD_MACHINE.Value = Environment.MachineName;
                        // add multilang for spread column
                        dtoScreenDetailLang.CONTROL_CD = ScreenDetail.ControlCD;//.Value = fpsspread.Name + ".Column[" + i.ToString() + "]";
                        dtoScreenDetailLang.CONTROL_CAPTION = ScreenDetail.ControlCaption;//.Value = fpsspread.Sheets[0].Columns[i].Label;
                        dtoScreenDetailLang.LANG_CD = langdto.LANG_CD;
                        screenDetailLangDTOList.Add(dtoScreenDetailLang);
                    }

                }

            }
            #endregion

            ImportScreenBIZ bizImportScreen = new ImportScreenBIZ();
            bizImportScreen.ImportData(screenDTOList, screenLangDTOList, screenDetailDTOList, screenDetailLangDTOList);
        }

        /// <summary>
        /// Re import จะเอาข้อมูลทั้งหมด update ลง db
        /// โดยที่ จะ clear IS_USED ให้เป็น 0 ก่อน แล้วค่อย update IS_USED ให้เป็น 1 เพื่อดูว่าข้อมูลไหนได้ใช้บ้าง
        /// จะต่างกับ Import ธรรมดา ตรงที่ import ธรรมดาจะไม่สนใจ screen ที่ import ไปแล้ว
        /// ส่วน re import จะสนใจข้อมูลที่อยู่ใน db เพราะจะไป update เฉพาะ IS_USED
        /// และดูถึงระดับ control, lang ว่าถ้าไม่มีจะ insert ให้ แต่ถ้ามีอยู่แล้วจะ update เฉพาะ IS_USED
        /// </summary>
        /// <param name="ScreenImportList"></param>
        /// <param name="UIDMScreenDetailList"></param>
        public void ReImportData(List<ScreenImportUIDM> ScreenImportList, List<ScreenDetailUIDM> UIDMScreenDetailList)
        {
            LangBIZ bizLang = new LangBIZ();
            LangDTO dtoLang = new LangDTO();

            ScreenDetailBIZ bizScreenDetail = new ScreenDetailBIZ();

            List<ScreenDTO> screenDTOList = new List<ScreenDTO>();
            List<ScreenLangDTO> screenLangDTOList = new List<ScreenLangDTO>();
            List<ScreenDetailDTO> screenDetailDTOList = new List<ScreenDetailDTO>();
            List<ScreenDetailLangDTO> screenDetailLangDTOList = new List<ScreenDetailLangDTO>();
            // count lang detail
            List<LangDTO> langDTOList = bizLang.LoadAll();

            #region Collect Data
            foreach (ScreenImportUIDM ScreenImport in ScreenImportList)
            {
                // check if screen is never been import then import to screen ms
                //if (ScreenImport.ImportStatus.StrongValue.ToUpper() == "NOTIMPORT")
                //{


                ScreenDTO dtoScreen = new ScreenDTO();
                dtoScreen.SCREEN_CD = ScreenImport.ScreenCD;
                dtoScreen.SCREEN_NAME = ScreenImport.ScreenName;
                dtoScreen.ORIGINAL_TITLE = ScreenImport.ScreenName;
                dtoScreen.IMAGE_CD.Value = "DEFAULT";
                dtoScreen.SCREEN_TYPE = ScreenImport.ScreenType;
                dtoScreen.SCREEN_ACTION.Value = 0;
                dtoScreen.EXT_PROGRAM.Value = string.Empty;
                dtoScreen.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoScreen.CRT_DATE.Value = DateTime.Now;
                dtoScreen.CRT_MACHINE.Value = Environment.MachineName;
                dtoScreen.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoScreen.UPD_DATE.Value = DateTime.Now;
                dtoScreen.UPD_MACHINE.Value = Environment.MachineName;

                screenDTOList.Add(dtoScreen);

                if (langDTOList.Count > 0)
                {
                    foreach (LangDTO langdto in langDTOList)
                    {

                        ScreenLangDTO dtoScreenLang = new ScreenLangDTO();
                        // add multilang for screen name
                        dtoScreenLang.SCREEN_CD = ScreenImport.ScreenCD;
                        dtoScreenLang.SCREEN_DESC = ScreenImport.ScreenName;
                        dtoScreenLang.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                        dtoScreenLang.CRT_DATE.Value = DateTime.Now;
                        dtoScreenLang.CRT_MACHINE.Value = Environment.MachineName;
                        dtoScreenLang.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                        dtoScreenLang.UPD_DATE.Value = DateTime.Now;
                        dtoScreenLang.UPD_MACHINE.Value = Environment.MachineName;
                        dtoScreenLang.LANG_CD = langdto.LANG_CD;
                        //bizScreenLang.AddNew(dtoScreenLang);
                        screenLangDTOList.Add(dtoScreenLang);

                    }
                }

                //}
            }

            foreach (ScreenDetailUIDM ScreenDetail in UIDMScreenDetailList)
            {
                ScreenDetailDTO dtoScreenDetail = new ScreenDetailDTO();
                dtoScreenDetail.SCREEN_CD = ScreenDetail.ScreenCD;
                dtoScreenDetail.CONTROL_TYPE = ScreenDetail.ControlType;
                dtoScreenDetail.ORIGINAL_TITLE = ScreenDetail.ControlCaption;
                dtoScreenDetail.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoScreenDetail.CRT_DATE.Value = DateTime.Now;
                dtoScreenDetail.CRT_MACHINE.Value = Environment.MachineName;
                dtoScreenDetail.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                dtoScreenDetail.UPD_DATE.Value = DateTime.Now;
                dtoScreenDetail.UPD_MACHINE.Value = Environment.MachineName;
                dtoScreenDetail.CONTROL_CD = ScreenDetail.ControlCD;
                screenDetailDTOList.Add(dtoScreenDetail);

                if (langDTOList.Count > 0)
                {
                    foreach (LangDTO langdto in langDTOList)
                    {
                        ScreenDetailLangDTO dtoScreenDetailLang = new ScreenDetailLangDTO();
                        // add spread column to screen detail ms
                        dtoScreenDetailLang.SCREEN_CD = ScreenDetail.ScreenCD;
                        dtoScreenDetailLang.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                        dtoScreenDetailLang.CRT_DATE.Value = DateTime.Now;
                        dtoScreenDetailLang.CRT_MACHINE.Value = Environment.MachineName;
                        dtoScreenDetailLang.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                        dtoScreenDetailLang.UPD_DATE.Value = DateTime.Now;
                        dtoScreenDetailLang.UPD_MACHINE.Value = Environment.MachineName;
                        // add multilang for spread column
                        dtoScreenDetailLang.CONTROL_CD = ScreenDetail.ControlCD;//.Value = fpsspread.Name + ".Column[" + i.ToString() + "]";
                        dtoScreenDetailLang.CONTROL_CAPTION = ScreenDetail.ControlCaption;//.Value = fpsspread.Sheets[0].Columns[i].Label;
                        dtoScreenDetailLang.LANG_CD = langdto.LANG_CD;
                        screenDetailLangDTOList.Add(dtoScreenDetailLang);
                    }

                }

            }
            #endregion

            ImportScreenBIZ bizImportScreen = new ImportScreenBIZ();
            bizImportScreen.ReImportData(screenDTOList, screenLangDTOList, screenDetailDTOList, screenDetailLangDTOList);
        }

        private void AddControlDetailtoDatabase(List<LangDTO> langDTOList, string ScreenCD, Control control, List<ScreenDetailDTO> screenDetailDTOList, List<ScreenDetailLangDTO> screenDetailLangDTOList)
        {
            AddControlDetailtoDatabase(langDTOList, ScreenCD, control, control.Name, screenDetailDTOList, screenDetailLangDTOList);
        }
        private void AddControlDetailtoDatabase(List<LangDTO> langDTOList, string ScreenCD, Control control, string controlName, List<ScreenDetailDTO> screenDetailDTOList, List<ScreenDetailLangDTO> screenDetailLangDTOList)
        {
            ScreenDetailDTO dtoScreenDetail = new ScreenDetailDTO();

            // add all control id to screen detail
            //
            dtoScreenDetail.SCREEN_CD.Value = ScreenCD;
            dtoScreenDetail.CONTROL_CD.Value = controlName;
            dtoScreenDetail.CONTROL_TYPE.Value = control.GetType().Name;
            dtoScreenDetail.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoScreenDetail.CRT_DATE.Value = DateTime.Now;
            dtoScreenDetail.CRT_MACHINE.Value = Environment.MachineName;
            dtoScreenDetail.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dtoScreenDetail.UPD_DATE.Value = DateTime.Now;
            dtoScreenDetail.UPD_MACHINE.Value = Environment.MachineName;

            screenDetailDTOList.Add(dtoScreenDetail);


            if (langDTOList.Count > 0)
            {
                foreach (LangDTO langdto in langDTOList)
                {
                    ScreenDetailLangDTO dtoScreenDetailLang = new ScreenDetailLangDTO();
                    dtoScreenDetailLang.SCREEN_CD.Value = ScreenCD;
                    dtoScreenDetailLang.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dtoScreenDetailLang.CRT_DATE.Value = DateTime.Now;
                    dtoScreenDetailLang.CRT_MACHINE.Value = Environment.MachineName;
                    dtoScreenDetailLang.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
                    dtoScreenDetailLang.UPD_DATE.Value = DateTime.Now;
                    dtoScreenDetailLang.UPD_MACHINE.Value = Environment.MachineName;
                    dtoScreenDetailLang.CONTROL_CD.Value = controlName;
                    dtoScreenDetailLang.CONTROL_CAPTION.Value = control.Text;
                    dtoScreenDetailLang.LANG_CD = langdto.LANG_CD;

                    screenDetailLangDTOList.Add(dtoScreenDetailLang);
                }
            }
        }

        public void ClearData(List<ScreenImportUIDM> ScreenImportList)
        {
            ImportScreenBIZ bizImportScreen = new ImportScreenBIZ();

            List<string> ScreenCDList = new List<string>();
            foreach (ScreenImportUIDM ScreenImport in ScreenImportList)
            {
                ScreenCDList.Add(ScreenImport.ScreenCD.StrongValue);
            }
            bizImportScreen.ClearData(ScreenCDList);
        }

        public void ClearUnnecessary(List<ScreenImportUIDM> ScreenImportList)
        {

        }

        public DatabaseScreenList LoadAllScreen()
        {
            //List<ScreenImportUIDM> screenList = new List<ScreenImportUIDM>();
            ScreenBIZ biz = new ScreenBIZ();
            DatabaseScreenList screenList = biz.LoadScreens();

            return screenList;
        }

        public bool IsScreenAlreadyExist(string ScreenCD)
        {
            ScreenBIZ biz = new ScreenBIZ();
            NZString screenCD = new NZString();
            screenCD.Value = ScreenCD;
            DatabaseScreen dbscreen = biz.LoadScreen(screenCD);

            return dbscreen != null;
        }

        public bool IsScreenDetailAlreadyExist(string ScreenCD, string ControlCD)
        {
            ScreenDetailBIZ biz = new ScreenDetailBIZ();
            return biz.isExist(ScreenCD, ControlCD);

        }
    }


}