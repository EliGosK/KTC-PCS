#define MODIFY_BY_ITIM
using System;
using System.Collections.Generic;
using System.Data;
using Rubik.DAO;
using Rubik.DTO;
using EVOFramework.Database;
using Rubik.Validators;
using EVOFramework;
using EVOFramework.Data;

namespace Rubik.BIZ
{
    public class ItemBIZ
    {
        public List<ItemDTO> LoadAllItem()
        {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAll(null, true);
        }

        public DataTable LoadItemList()
        {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadItemList(null, false);
        }

        public int AddNew(ItemDTO dtoItem, List<ItemProcessDTO> NewProcess, List<BOMDTO> NewComponent, List<ItemMachineDTO> NewItemMachine)
        {
            ItemValidator validator = new ItemValidator();
            validator.ValidateBeforeSaveNew(dtoItem, null);

            Database db = CommonLib.Common.CurrentDatabase;
            db.KeepConnection = true;
            db.BeginTransaction();
            try
            {
                ItemDAO daoItem = new ItemDAO(CommonLib.Common.CurrentDatabase);
                daoItem.AddNew(null, dtoItem);

                ItemProcessDAO daoItemProcess = new ItemProcessDAO(CommonLib.Common.CurrentDatabase);
                BOMDAO daoBOM = new BOMDAO(CommonLib.Common.CurrentDatabase);
                ItemMachineDAO daoItemMachine = new ItemMachineDAO(CommonLib.Common.CurrentDatabase);

                foreach (ItemProcessDTO dto in NewProcess)
                {
                    daoItemProcess.AddNew(null, dto);
                }

                //Component
                foreach (BOMDTO dto in NewComponent)
                {
                    daoBOM.AddNew(null, dto);
                }

                //Item Machine
                foreach (ItemMachineDTO dto in NewItemMachine)
                {
                    daoItemMachine.AddNew(null, dto);
                }

                db.Commit();
                return 1;
            }
            catch (Exception err)
            {
                db.Rollback();
                throw err;
            }
            finally
            {
                if (db.DBConnectionState == ConnectionState.Open)
                    db.Close();
            }
        }

        //public int AddNew(ItemDTO dtoItem, ItemProcessDTO dtoItemProcess)
        //{
        //    ItemValidator validator = new ItemValidator();
        //    validator.ValidateBeforeSaveNew(dtoItem, dtoItemProcess);

        //    Database db = CommonLib.Common.CurrentDatabase;
        //    db.KeepConnection = true;
        //    db.BeginTransaction();
        //    try
        //    {
        //        ItemDAO daoItem = new ItemDAO(CommonLib.Common.CurrentDatabase);
        //        daoItem.AddNew(null, dtoItem);
        //        //ItemProcessDAO daoItemProcess = new ItemProcessDAO(CommonLib.Common.CurrentDatabase);
        //        //daoItemProcess.AddNew(null, dtoItemProcess);

        //        db.Commit();
        //        return 1;
        //    }
        //    catch (Exception err)
        //    {
        //        db.Rollback();
        //        throw err;
        //    }
        //    finally
        //    {
        //        if (db.DBConnectionState == ConnectionState.Open)
        //            db.Close();
        //    }
        //}

        public int DeleteItem(NZString ItemCD)
        {
            Database db = CommonLib.Common.CurrentDatabase;
            db.KeepConnection = true;
            db.BeginTransaction();
            try
            {
                ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
                dao.Delete(null, ItemCD);

                ItemProcessDAO daoProc = new ItemProcessDAO(CommonLib.Common.CurrentDatabase);
                daoProc.DeleteByItem(null, ItemCD);

                InventoryTransactionDAO daoInvTrans = new InventoryTransactionDAO(db);
                daoInvTrans.DeleteByItem(null, ItemCD);

                InventoryOnhandDAO daoInv = new InventoryOnhandDAO(CommonLib.Common.CurrentDatabase);
                daoInv.DeleteByItem(null, ItemCD);

                //ItemImageBIZ bizImage = new ItemImageBIZ();
                //bizImage.DeleteImage(ItemCD);

                db.Commit();
                return 1;
            }
            catch (Exception err)
            {
                db.Rollback();
                throw err;
            }
            finally
            {
                if (db.DBConnectionState == ConnectionState.Open)
                    db.Close();
            }
        }

        public ItemDTO LoadItem(NZString ItemCD)
        {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, ItemCD);
        }

        public int UpdateWithoutPK(ItemDTO dtoItem, List<ItemProcessDTO> NewProcess, List<ItemProcessDTO> EditProcess, List<ItemProcessDTO> DeleteProcess,
            List<BOMDTO> NewComponent, List<BOMDTO> EditComponent, List<BOMDTO> DeleteComponent, List<ItemMachineDTO> ItemMachine)
        {
            ItemValidator validator = new ItemValidator();
            validator.ValidateBeforeSaveUpdate(dtoItem, null);

            Database db = CommonLib.Common.CurrentDatabase;
            db.KeepConnection = true;
            db.BeginTransaction();
            try
            {
                ItemDAO daoItem = new ItemDAO(CommonLib.Common.CurrentDatabase);
                daoItem.UpdateWithoutPK(null, dtoItem);

                ItemProcessDAO daoItemProcess = new ItemProcessDAO(CommonLib.Common.CurrentDatabase);
                BOMDAO daoBOM = new BOMDAO(CommonLib.Common.CurrentDatabase);
                ItemMachineDAO daoItemMachine = new ItemMachineDAO(CommonLib.Common.CurrentDatabase);

                foreach (ItemProcessDTO dto in DeleteProcess)
                {
                    daoItemProcess.Delete(null, dto.ITEM_CD, dto.ITEM_SEQ);
                }
                foreach (ItemProcessDTO dto in NewProcess)
                {
                    daoItemProcess.AddNew(null, dto);
                }

                foreach (ItemProcessDTO dto in EditProcess)
                {
                    daoItemProcess.UpdateWithoutPK(null, dto);
                }



                //Component
                foreach (BOMDTO dto in DeleteComponent)
                {
                    daoBOM.Delete(null, dto.UPPER_ITEM_CD, dto.LOWER_ITEM_CD, dto.ITEM_SEQ);
                }
                foreach (BOMDTO dto in NewComponent)
                {
                    daoBOM.AddNew(null, dto);
                }
                foreach (BOMDTO dto in EditComponent)
                {
                    daoBOM.UpdateWithoutPK(null, dto);
                }


                //Item Machine
                daoItemMachine.DelteItemMachineByItemCD(dtoItem.ITEM_CD);
                foreach (ItemMachineDTO dto in ItemMachine)
                {
                    daoItemMachine.AddNew(null, dto);
                }

                db.Commit();
                return 1;
            }
            catch (Exception err)
            {
                db.Rollback();
                throw err;
            }
            finally
            {
                if (db.DBConnectionState == ConnectionState.Open)
                    db.Close();
            }
        }

        public ItemProcessDTO LoadItemProcess(NZString ItemCD)
        {
            ItemProcessDAO dao = new ItemProcessDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByItemCD(null, ItemCD);
        }



        public List<ItemViewProcessDTO> LoadItemProcessList(NZString ItemCD)
        {
            ItemProcessDAO dao = new ItemProcessDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadProcessListByItemCD(null, ItemCD);
        }

        public List<ItemComponentDTO> LoadItemComponentList(NZString ItemCD)
        {
            BOMDAO dao = new BOMDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadComponentListByItemCD(null, ItemCD);
        }

        public DataTable LoadAllItemWithItemType(eSqlOperator sqlOperator, string[] ItemTypes)
        {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAllItemWithItemType(null, sqlOperator, ItemTypes);
        }

        public DataTable LoadAllItemWithItemType(eSqlOperator sqlOperator, string[] ItemTypes, NZString strDealing, DataDefine.eDealingType argDealingType)
        {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAllItemWithItemType(null, sqlOperator, ItemTypes, strDealing, argDealingType);
        }
        public DataTable LoadConsumptionList(NZString itemCode)
        {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadConsumptionList(null, itemCode);
        }
        public List<ItemEquivalentDTO> LoadEquivalentItem(ItemDTO argItem)
        {
            ItemEquivalentDAO dao = new ItemEquivalentDAO(CommonLib.Common.CurrentDatabase);

            return dao.LoadEquivalentItem(null, argItem);

        }

        public List<ItemEquivalentDTO> Load(ItemDTO argItem)
        {
            ItemEquivalentDAO dao = new ItemEquivalentDAO(CommonLib.Common.CurrentDatabase);

            return dao.Load(null, argItem);

        }

        public ItemDTO LoadItem(NZString MasterNo, NZString PartNo)
        {
            ItemDAO dao = new ItemDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadItemByNo(null, MasterNo, PartNo);
        }

        public List<ItemMachineDTO> LoadItemMachineByItemCD(NZString MasterNo)
        {
            ItemMachineDAO dao = new ItemMachineDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadItemMachineByItemCD(MasterNo);
        }

        public ItemDescriptionDTO LoadItemDescription(NZString MasterNo, NZString PartNo)
        {
            ItemDescriptionDTO dtoItemDesc = new ItemDescriptionDTO();
            ItemDTO dtoItem = LoadItem(MasterNo, PartNo);
            if (dtoItem == null)
                return null;

            dtoItemDesc.MASTER_NO = dtoItem.ITEM_CD;
            dtoItemDesc.PART_NO = dtoItem.SHORT_NAME;

            //get customer
            DealingBIZ bizCust = new DealingBIZ();
            DealingDTO dtoCust = bizCust.LoadLocation(dtoItem.CUSTOMER_CD);
            if (dtoCust != null)
            {
                dtoItemDesc.CUSTOMER_CD = dtoCust.LOC_CD;
                dtoItemDesc.CUSTOMER_NAME = dtoCust.LOC_DESC;
            }

            return dtoItemDesc;
        }

        public ItemWeightDTO ConvertKGtoPCS(NZString MasterNo, NZString ProcessNo, NZDecimal QtyKG, NZInt processCount)
        {
            ItemWeightDTO weightDTO = new ItemWeightDTO();


            NZDecimal decQtyPCS = null;
            //ถ้า convert จาก KG เป็น PCS จะ ใช้น้ำหนักตาม Process
            ItemProcessDAO dao = new ItemProcessDAO();

            ItemProcessDTO itemProcess = new ItemProcessDTO();
            itemProcess.ITEM_CD = MasterNo;
            itemProcess.PROCESS_CD = ProcessNo;
            itemProcess = dao.LoadWeightByItemProcessCount(CommonLib.Common.CurrentDatabase, itemProcess, new NZInt(null, (processCount.NVL(0) <= 1 ? 1 : processCount.Value)));

            if (itemProcess != null)
            {

                weightDTO.ItemCD = MasterNo;
                weightDTO.ProcessCD = ProcessNo;
                weightDTO.QtyKG = QtyKG;

                decimal decQtyKG = QtyKG.NVL(0);


                if (itemProcess.WEIGHT.NVL(0) == 0)
                {
                    decQtyPCS = null;
                }
                else
                {
                    decQtyPCS = new NZDecimal(null, Math.Round(QtyKG / itemProcess.WEIGHT * 1000, MidpointRounding.AwayFromZero));
                }

                if (decQtyPCS != null && decQtyPCS.NVL(0) > 10000000)
                {

                    EVOFramework.ErrorItem errorItem = null;

                    errorItem = new EVOFramework.ErrorItem(QtyKG.Owner, Rubik.TKPMessages.eValidate.VLM0184.ToString());

                    EVOFramework.ValidateException.ThrowErrorItem(errorItem);



                }

                weightDTO.QtyPCS = decQtyPCS;

            }

            return weightDTO;
        }

        public ItemWeightDTO ConvertPCStoKG(NZString MasterNo, NZString ProcessNo, NZDecimal QtyPCS, NZInt processCount)
        {
            //ถ้า convert จาก PCS เป็น KG จะ default เป็น 0
            ItemWeightDTO weightDTO = new ItemWeightDTO();
            weightDTO.ItemCD = MasterNo;
            weightDTO.ProcessCD = ProcessNo;
            weightDTO.QtyPCS = QtyPCS;


            return null;
        }
    }
}
