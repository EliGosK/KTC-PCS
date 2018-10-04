using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using SystemMaintenance.DTO;
using SystemMaintenance.Validators;
using EVOFramework;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    public class MenuSetMaintenanceBIZ
    {
        public LookupData LoadLookup(bool orderByKey) {
            IMenuSetDAO dao = DAOFactory.CreateMenuSetDAO(CommonLib.Common.CurrentDatabase);

            List<MenuSetDTO> dtos = dao.LoadAll(null, orderByKey);
            return new LookupData(DTOUtility.ConvertListToDataTable(dtos),
                MenuSetDTO.eColumns.MENU_SET_NAME.ToString(),
                MenuSetDTO.eColumns.MENU_SET_CD.ToString());                        
        }

        internal List<MenuSetDTO> LoadAllMenuSet()
        {
            IMenuSetDAO dao = DAOFactory.CreateMenuSetDAO(CommonLib.Common.CurrentDatabase);

            List<MenuSetDTO> dtoList = dao.LoadAll(null, true);

            return dtoList;
        }

        internal System.Data.DataTable LoadMenuSubByMenuSetCD(string MenuSetCD)
        {
            IMenuSetDetailDAO dao = DAOFactory.CreateMenuSetDetailDAO(CommonLib.Common.CurrentDatabase);

            return dao.LoadMenuSubByMenuSetCD(null, MenuSetCD);
        }

        internal List<MenuSetDetailDTO> LoadAllMenuSubByMenuSetCD(string MenuSetCD)
        {
            IMenuSetDetailDAO dao = DAOFactory.CreateMenuSetDetailDAO(CommonLib.Common.CurrentDatabase);

            return dao.LoadAllMenuSubByMenuSetCD(null, MenuSetCD);
        }

        internal void UpdateMenuSetDesc(MenuSetDTO dto)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                IMenuSetDAO dao = DAOFactory.CreateMenuSetDAO(CommonLib.Common.CurrentDatabase);
                dao.UpdateMenuSetDesc(null, dto);
                CommonLib.Common.CurrentDatabase.Commit();

            }
            catch
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }

        }

        internal int UpdateMenuSetDetailWithoutPK(MenuSetDetailDTO dto)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                IMenuSetDetailDAO dao = DAOFactory.CreateMenuSetDetailDAO(CommonLib.Common.CurrentDatabase);
                dao.UpdateWithoutPK(null, dto);
                CommonLib.Common.CurrentDatabase.Commit();
                return 1;
            }
            catch
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }            

        }

        internal int DeleteMenuSet(MenuSetDTO dto)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                IMenuSetDAO dao = DAOFactory.CreateMenuSetDAO(CommonLib.Common.CurrentDatabase);
                dao.Delete(null, dto.MENU_SET_CD);
                IMenuSetDetailDAO daoDetail = DAOFactory.CreateMenuSetDetailDAO(CommonLib.Common.CurrentDatabase);
                daoDetail.DeleteByMenuSetCD(null, dto.MENU_SET_CD.StrongValue);
                CommonLib.Common.CurrentDatabase.Commit();
                return 1;
            }
            catch
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }           

        }

        internal int AddNewMenuSet(MenuSetDTO dto)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();
            MenuSetMaintenanceValidator valMenuSet = new MenuSetMaintenanceValidator();
            if (valMenuSet.ValidateBeforeAdd(dto))
            {
                try
                {
                    IMenuSetDAO dao = DAOFactory.CreateMenuSetDAO(CommonLib.Common.CurrentDatabase);
                    dao.AddNew(null, dto);
                    CommonLib.Common.CurrentDatabase.Commit();
                    return 1;
                }
                catch
                {
                    CommonLib.Common.CurrentDatabase.Rollback();
                    throw;
                }

            }
            return 0;

        }

        internal bool isExistMenuSet(EVOFramework.NZString MenuSetCD)
        {
            IMenuSetDAO dao = DAOFactory.CreateMenuSetDAO(CommonLib.Common.CurrentDatabase);
            return dao.Exist(null, MenuSetCD);
        }


        internal int DeleteMenuSetDetail(MenuSetDetailDTO dto)
        {
            CommonLib.Common.CurrentDatabase.KeepConnection = true;
            CommonLib.Common.CurrentDatabase.BeginTransaction();

            try
            {
                IMenuSetDetailDAO dao = DAOFactory.CreateMenuSetDetailDAO(CommonLib.Common.CurrentDatabase);
                dao.Delete(null, dto.MENU_SUB_CD, dto.MENU_SET_CD);
                CommonLib.Common.CurrentDatabase.Commit();
                return 1;
            }
            catch
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }


        }

        internal List<MenuSubDTO> LoadAllMenuSubNotInMenuSet(string menuSetCD)
        {
            IMenuSetDetailDAO dao = DAOFactory.CreateMenuSetDetailDAO(CommonLib.Common.CurrentDatabase);

            List<MenuSubDTO> dtoList = dao.LoadAllMenuSubNotInMenuSet(null, menuSetCD);

            return dtoList;
        }

        internal int AddMenuSetDetail(MenuSetDetailDTO dto)
        {
            IMenuSetDetailDAO dao = DAOFactory.CreateMenuSetDetailDAO(CommonLib.Common.CurrentDatabase);
            return dao.AddNew(null, dto);
        }



        internal int GetLastDisplaySEQ(string MenuSetCD)
        {
            try
            {
                IMenuSetDetailDAO dao = DAOFactory.CreateMenuSetDetailDAO(CommonLib.Common.CurrentDatabase);
                return dao.GetLastDisplaySEQ(null, MenuSetCD);
            }
            catch
            {
                CommonLib.Common.CurrentDatabase.Rollback();
                throw;
            }

        }
    }
}
