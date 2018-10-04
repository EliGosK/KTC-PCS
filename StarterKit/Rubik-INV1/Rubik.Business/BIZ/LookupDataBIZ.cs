using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EVOFramework;
using EVOFramework.Data;
using Rubik.DAO;
using Rubik.DTO;
using EVOFramework.Database;
using System.Collections;
//using SystemMaintenance.DAO;
//using SystemMaintenance.BIZ;
//using SystemMaintenance.DTO;

namespace Rubik.BIZ
{
    public class LookupDataBIZ
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public LookupData LoadLookupLocation()
        {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = DTOUtility.ConvertListToDataTable(dao.LoadAll(null, true));
            LookupData lookupData = new LookupData(dt,
                DealingDTO.eColumns.LOC_DESC.ToString(),
                DealingDTO.eColumns.LOC_CD.ToString());
            return lookupData;
        }

        /// <summary>
        /// Load All Location
        /// </summary>
        /// <param name="dtoAddedLocation">Dummy Location to Added and Set to first Row</param>
        /// <returns></returns>
        public LookupData LoadLookupLocation_AddDummy(DealingDTO dtoAddedLocation)
        {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            List<DealingDTO> dtoLocations = dao.LoadAll(null, true);
            //add Dummy Location and Set to first Row
            dtoLocations.Insert(0, dtoAddedLocation);

            DataTable dt = DTOUtility.ConvertListToDataTable(dtoLocations);
            LookupData lookupData = new LookupData(dt,
                DealingDTO.eColumns.LOC_DESC.ToString(),
                DealingDTO.eColumns.LOC_CD.ToString());
            return lookupData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LocationType"></param>
        /// <returns></returns>
        public LookupData LoadLookupLocation(NZString[] LocationType)
        {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = dao.LoadByLocationType(null, LocationType, null, false);
            LookupData lookupData = new LookupData(dt,
                DealingDTO.eColumns.LOC_DESC.ToString(),
                DealingDTO.eColumns.LOC_CD.ToString());
            return lookupData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LocationType"></param>
        /// <returns></returns>
        public LookupData LoadLookupLocation(NZString[] LocationType, NZString[] ExceptLocation)
        {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = dao.LoadByLocationType(null, LocationType, ExceptLocation, false);
            LookupData lookupData = new LookupData(dt,
                DealingDTO.eColumns.LOC_DESC.ToString(),
                DealingDTO.eColumns.LOC_CD.ToString());
            return lookupData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClassInfoCD"></param>
        /// <returns></returns>
        public LookupData LoadLookupClassType(NZString ClassInfoCD)
        {
            ClassListDAO dao = new ClassListDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = DTOUtility.ConvertListToDataTable(dao.LoadByClassInfo(null, ClassInfoCD));
            LookupData lookupData = new LookupData(dt,
                ClassListDTO.eColumns.CLS_DESC.ToString(),
                ClassListDTO.eColumns.CLS_CD.ToString());
            return lookupData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClassInfoCD"></param>
        /// <returns></returns>
        public LookupData LoadLookupLogTable()
        {
            InvTranLogDAO dao = new InvTranLogDAO(CommonLib.Common.CurrentDatabase);

            DataTable dt = dao.LoadLogTable(null);
            LookupData lookupData = new LookupData(dt,
                LogTableDTO.eColumns.TABLE_DESCRIPTION.ToString(),
                LogTableDTO.eColumns.TABLE_NAME.ToString());
            return lookupData;
        }

        /// <summary>
        /// Load all ClassType where condition at CLS_INFO_CD and CLS_CD
        /// </summary>
        /// <param name="ClassInfoCD"></param>
        /// <param name="ClassfoCD"></param>
        /// <returns></returns>
        public LookupData LoadLookupClassType(NZString ClassInfoCD, NZString[] ClassfoCD)
        {
            ClassListDAO dao = new ClassListDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = DTOUtility.ConvertListToDataTable(dao.LoadByClassInfo(null, ClassInfoCD, ClassfoCD));
            LookupData lookupData = new LookupData(dt,
                ClassListDTO.eColumns.CLS_DESC.ToString(),
                ClassListDTO.eColumns.CLS_CD.ToString());
            return lookupData;
        }

        /// <summary>
        /// Load lookup for lot number by item and location code
        /// If these lot no has no onhand qty will be supressed.
        /// </summary>
        /// <param name="ItemCD"></param>
        /// <param name="LocationCD"></param>
        /// <returns></returns>
        public LookupData LoadLookupLotNo(NZString ItemCD, NZString LocationCD, NZString YearMonth)
        {
            InventoryOnhandDAO dao = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
            InventoryPeriodBIZ inventoryPeriodBIZ = new InventoryPeriodBIZ();
            InventoryPeriodDTO inventoryPeriodDTO = inventoryPeriodBIZ.LoadCurrentPeriod();

            List<InventoryOnhandDTO> listOnhand = dao.LoadLotNoWithHasOnhandQty(null, YearMonth, inventoryPeriodDTO.YEAR_MONTH, ItemCD, LocationCD);
            DataTable dt = DTOUtility.ConvertListToDataTable(listOnhand);

            LookupData lookupData = new LookupData(dt,
                InventoryOnhandDTO.eColumns.LOT_NO.ToString(),
                InventoryOnhandDTO.eColumns.LOT_NO.ToString());
            return lookupData;
        }

        /// <summary>
        /// ใช้โหลดมาเป็น text autocomplete สำหรับหน้า Item master เท่านั้น
        /// โดยส่งค่าที่ต้องการมาเป็นชื่อ column ที่อยู่ในตาราง Item เท่านั้น
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public LookupData LoadLookupTextHelper(ItemDTO.eColumns column)
        {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = dao.LoadLookupTextHelper(null, column.ToString());
            LookupData lookupData = new LookupData(dt,
                           column.ToString(),
                           column.ToString());

            return lookupData;
        }

        /// <summary>
        /// ใช้โหลดมาเป็น text autocomplete 
        /// โดยส่งค่าที่ต้องการมาเป็นชื่อ column และ table
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public LookupData LoadLookupTextHelper(string TableName, string ColumnName)
        {
            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = dao.LoadLookupTextHelper(null, TableName, ColumnName);
            LookupData lookupData = new LookupData(dt, ColumnName, ColumnName);

            return lookupData;
        }

        public LookupData LoadMachineAll()
        {
            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = dao.LoadMachine(null, false);
            LookupData lookupData = new LookupData(dt,
                MachineDTO.eColumns.MACHINE_CD.ToString(),
                MachineDTO.eColumns.MACHINE_CD.ToString());
            return lookupData;
        }

        public LookupData LoadMachineByProcess(NZString ItemCD, NZString Process)
        {
            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = dao.LoadMachineByProcess(null, ItemCD.StrongValue, Process.StrongValue, false);
            LookupData lookupData = new LookupData(dt,
                MachineDTO.eColumns.MACHINE_CD.ToString(),
                MachineDTO.eColumns.MACHINE_CD.ToString());
            return lookupData;
        }

        public LookupData LoadPersonInCharge()
        {
            SystemMaintenance.BIZ.UserBIZ biz = new SystemMaintenance.BIZ.UserBIZ();
            List<SystemMaintenance.DTO.UserDTO> listUser = biz.LoadPersonInCharge();
            DataTable dtUser = DTOUtility.ConvertListToDataTable(listUser);

            LookupData lookupData = new LookupData(dtUser,
                SystemMaintenance.DTO.UserDTO.eColumns.FULL_NAME.ToString(),
                SystemMaintenance.DTO.UserDTO.eColumns.USER_ACCOUNT.ToString());

            return lookupData;
        }

        public LookupData LoadLookupMachine(DataTable dt)
        {
            //DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            //DataTable dt = dao.LoadByLocationType(null, LocationType, null, false);
            DataTable dtSource = new DataTable();

            foreach (DataColumn dc in dt.Columns) 
            {
                DataColumn dcSource = new DataColumn(dc.ColumnName);
                dtSource.Columns.Add(dcSource);
            }

            //DataColumn dc0 = new DataColumn(ItemViewProcessDTO.eColumns.PROCESS_NAME.ToString());
            //DataColumn dc1 = new DataColumn(ItemViewProcessDTO.eColumns.PROCESS_CD.ToString());
            //dtSource.Columns.Add(dc0);
            //dtSource.Columns.Add(dc1);

            Hashtable hash = new Hashtable();
            foreach (DataRow dr in dt.Rows) 
            {
                if (dr.RowState != DataRowState.Deleted &&
                    (dr[(int)ItemViewProcessDTO.eColumns.PROCESS_CD] != (object)DBNull.Value ||
                    dr[(int)ItemViewProcessDTO.eColumns.PROCESS_NAME] != (object)DBNull.Value)
                    ) 
                {
                    string ProcessCD = dr[(int)ItemViewProcessDTO.eColumns.PROCESS_CD].ToString();
                    string ProcessName = dr[(int)ItemViewProcessDTO.eColumns.PROCESS_NAME].ToString();

                    if (hash.ContainsKey(ProcessCD))
                        continue;

                    DataRow drSource = dtSource.NewRow();
                    drSource[ItemViewProcessDTO.eColumns.PROCESS_NAME.ToString()] = ProcessName;
                    drSource[ItemViewProcessDTO.eColumns.PROCESS_CD.ToString()] = ProcessCD;
                    dtSource.Rows.Add(drSource);

                    hash.Add(ProcessCD, ProcessCD);
                }
            }
            LookupData lookupData = new LookupData(dtSource,
                ItemViewProcessDTO.eColumns.PROCESS_NAME.ToString(),
                ItemViewProcessDTO.eColumns.PROCESS_CD.ToString());
            return lookupData;
        }

        public LookupData LoadMachineGroup() 
        {
            MachineBIZ biz = new MachineBIZ();         
            DataTable dt = biz.LoadMachineGroup();

            LookupData lookupData = new LookupData(dt,
                MachineDTO.eColumns.MACHINE_GROUP.ToString(),
                MachineDTO.eColumns.MACHINE_GROUP.ToString());

            return lookupData;
        }

        public LookupData LoadMachineGroupOfProcess(string Process)
        {
            MachineBIZ biz = new MachineBIZ();
            DataTable dt = biz.LoadMachineGroupOfProcess(Process);

            LookupData lookupData = new LookupData(dt,
                MachineDTO.eColumns.MACHINE_GROUP.ToString(),
                MachineDTO.eColumns.MACHINE_GROUP.ToString());

            return lookupData;
        }

        public LookupData LoadLookupLocationByItem(NZString MasterNo, NZString[] ExceptLocation) {
            DealingDAO dao = new DealingDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = dao.LoadByLocationType(null, MasterNo, ExceptLocation, false);
            LookupData lookupData = new LookupData(dt,
                DealingDTO.eColumns.LOC_DESC.ToString(),
                DealingDTO.eColumns.LOC_CD.ToString());
            return lookupData;
        }
    }
}
