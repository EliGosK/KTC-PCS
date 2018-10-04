using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemMaintenance.DTO;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    class ImportScreenBIZ
    {
        public bool ClearData(List<string> ScreenCDList)
        {
            IScreenDAO daoScreen = DAOFactory.CreateScreenDAO(CommonLib.Common.CurrentDatabase);
            IScreenLangDAO daoScreenLang = DAOFactory.CreateScreenLangDAO(CommonLib.Common.CurrentDatabase);
            IScreenDetailDAO daoScreenDetail = DAOFactory.CreateScreenDetailDAO(CommonLib.Common.CurrentDatabase);
            IScreenDetailLangDAO daoScreenDetailLang = DAOFactory.CreateScreenDetailLangDAO(CommonLib.Common.CurrentDatabase);
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();
            foreach (string ScreenCD in ScreenCDList)
            {
                daoScreen.DeleteByScreenCD(CommonLib.Common.CurrentDatabase, ScreenCD);
                daoScreenLang.DeleteByScreenCD(CommonLib.Common.CurrentDatabase, ScreenCD);
                daoScreenDetail.DeleteByScreenCD(CommonLib.Common.CurrentDatabase, ScreenCD);
                daoScreenDetailLang.DeleteByScreenCD(CommonLib.Common.CurrentDatabase, ScreenCD);
            }
            CommonLib.Common.CurrentDatabase.Commit();
            return true;
        }

        public bool ImportData(List<ScreenDTO> screenDTOList, List<ScreenLangDTO> screenLangDTOList, List<ScreenDetailDTO> screenDetailDTOList, List<ScreenDetailLangDTO> screenDetailLangDTOList)
        {
            IScreenDAO daoScreen = DAOFactory.CreateScreenDAO(CommonLib.Common.CurrentDatabase);
            IScreenLangDAO daoScreenLang = DAOFactory.CreateScreenLangDAO(CommonLib.Common.CurrentDatabase);
            IScreenDetailDAO daoScreenDetail = DAOFactory.CreateScreenDetailDAO(CommonLib.Common.CurrentDatabase);
            IScreenDetailLangDAO daoScreenDetailLang = DAOFactory.CreateScreenDetailLangDAO(CommonLib.Common.CurrentDatabase);
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            foreach (ScreenDTO screenDTO in screenDTOList)
            {
                if (daoScreen.Exist(CommonLib.Common.CurrentDatabase, screenDTO.SCREEN_CD))
                {
                    daoScreen.UpdateWithoutPK(CommonLib.Common.CurrentDatabase, screenDTO);
                }
                else
                {
                    daoScreen.AddNew(CommonLib.Common.CurrentDatabase, screenDTO);
                }
            }

            foreach (ScreenLangDTO screenLangDTO in screenLangDTOList)
            {
                if (daoScreenLang.Exist(CommonLib.Common.CurrentDatabase, screenLangDTO.SCREEN_CD, screenLangDTO.LANG_CD))
                {
                    daoScreenLang.UpdateWithoutPK(CommonLib.Common.CurrentDatabase, screenLangDTO);
                }
                else
                {
                    daoScreenLang.AddNew(CommonLib.Common.CurrentDatabase, screenLangDTO);
                }
            }

            foreach (ScreenDetailDTO screenDetailDTO in screenDetailDTOList)
            {
                if (daoScreenDetail.Exist(CommonLib.Common.CurrentDatabase, screenDetailDTO.SCREEN_CD, screenDetailDTO.CONTROL_CD))
                {
                    daoScreenDetail.UpdateWithoutPK(CommonLib.Common.CurrentDatabase, screenDetailDTO);
                }
                else
                {
                    daoScreenDetail.AddNew(CommonLib.Common.CurrentDatabase, screenDetailDTO);
                }
            }

            foreach (ScreenDetailLangDTO screenDetailLangDTO in screenDetailLangDTOList)
            {
                if (daoScreenDetailLang.Exist(CommonLib.Common.CurrentDatabase, screenDetailLangDTO.CONTROL_CD, screenDetailLangDTO.LANG_CD, screenDetailLangDTO.SCREEN_CD))
                {
                    daoScreenDetailLang.UpdateWithoutPK(CommonLib.Common.CurrentDatabase, screenDetailLangDTO);
                }
                else
                {
                    daoScreenDetailLang.AddNew(CommonLib.Common.CurrentDatabase, screenDetailLangDTO);
                }
            }

            CommonLib.Common.CurrentDatabase.Commit();
            return true;
        }

        public bool ReImportData(List<ScreenDTO> screenDTOList, List<ScreenLangDTO> screenLangDTOList
            , List<ScreenDetailDTO> screenDetailDTOList, List<ScreenDetailLangDTO> screenDetailLangDTOList)
        {
            IScreenDAO daoScreen = DAOFactory.CreateScreenDAO(CommonLib.Common.CurrentDatabase);
            IScreenLangDAO daoScreenLang = DAOFactory.CreateScreenLangDAO(CommonLib.Common.CurrentDatabase);
            IScreenDetailDAO daoScreenDetail = DAOFactory.CreateScreenDetailDAO(CommonLib.Common.CurrentDatabase);
            IScreenDetailLangDAO daoScreenDetailLang = DAOFactory.CreateScreenDetailLangDAO(CommonLib.Common.CurrentDatabase);
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            daoScreen.ResetUsageFlag();
            daoScreenLang.ResetUsageFlag();
            daoScreenDetail.ResetUsageFlag();
            daoScreenDetailLang.ResetUsageFlag();

            LangBIZ bizLang = new LangBIZ();
            string strDefaultLang = bizLang.LoadSystemDefaultLanguage();

            foreach (ScreenDTO screenDTO in screenDTOList)
            {
                if (daoScreen.Exist(CommonLib.Common.CurrentDatabase, screenDTO.SCREEN_CD))
                {
                    daoScreen.UpdateIsUsed(CommonLib.Common.CurrentDatabase, screenDTO);
                }
                else
                {
                    daoScreen.AddNew(CommonLib.Common.CurrentDatabase, screenDTO);
                }
            }

            foreach (ScreenLangDTO screenLangDTO in screenLangDTOList)
            {
                if (daoScreenLang.Exist(CommonLib.Common.CurrentDatabase, screenLangDTO.SCREEN_CD, screenLangDTO.LANG_CD))
                {
                    if (strDefaultLang.Equals(screenLangDTO.LANG_CD.NVL("")))
                    {
                        daoScreenLang.UpdateWithoutPK(CommonLib.Common.CurrentDatabase, screenLangDTO);
                    }

                    daoScreenLang.UpdateIsUsed(CommonLib.Common.CurrentDatabase, screenLangDTO);
                }
                else
                {
                    daoScreenLang.AddNew(CommonLib.Common.CurrentDatabase, screenLangDTO);
                }
            }

            foreach (ScreenDetailDTO screenDetailDTO in screenDetailDTOList)
            {
                if (daoScreenDetail.Exist(CommonLib.Common.CurrentDatabase, screenDetailDTO.SCREEN_CD, screenDetailDTO.CONTROL_CD))
                {
                    daoScreenDetail.UpdateIsUsed(CommonLib.Common.CurrentDatabase, screenDetailDTO);
                }
                else
                {
                    daoScreenDetail.AddNew(CommonLib.Common.CurrentDatabase, screenDetailDTO);
                }
            }

            foreach (ScreenDetailLangDTO screenDetailLangDTO in screenDetailLangDTOList)
            {
                if (daoScreenDetailLang.Exist(CommonLib.Common.CurrentDatabase, screenDetailLangDTO.CONTROL_CD, screenDetailLangDTO.LANG_CD, screenDetailLangDTO.SCREEN_CD))
                {
                    if (strDefaultLang.Equals(screenDetailLangDTO.LANG_CD.NVL("")))
                    {
                        daoScreenDetailLang.UpdateWithoutPK(CommonLib.Common.CurrentDatabase, screenDetailLangDTO);
                    }

                    daoScreenDetailLang.UpdateIsUsed(CommonLib.Common.CurrentDatabase, screenDetailLangDTO);

                }
                else
                {
                    daoScreenDetailLang.AddNew(CommonLib.Common.CurrentDatabase, screenDetailLangDTO);
                }
            }

            CommonLib.Common.CurrentDatabase.Commit();
            return true;
        }

    }
}
