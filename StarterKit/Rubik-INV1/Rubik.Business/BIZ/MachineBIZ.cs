using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DTO;
using EVOFramework.Database;
using Rubik.DAO;
using System.Data;
using Rubik.Validators;
using EVOFramework;

namespace Rubik.BIZ {
    public class MachineBIZ 
    {
        #region Load

        public MachineDTO LoadMachine(NZString MachineNo) {
            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase); 
            return dao.LoadByPK(null, MachineNo);
        }

        public List<MachineDTO> LoadAllMachines(bool LimitRow) {
            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
            if (LimitRow) {
                return dao.LoadAllWithLimit(CommonLib.Common.CurrentDatabase, true, MachineDTO.eColumns.MACHINE_CD);
            }
            return dao.LoadAll(null, true);
        }

        public DataTable LoadMachineList() 
        {
            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadMachineList(null, false);
        }

        public DataTable LoadMachineGroup() 
        {
            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadMachineGroup(null);
        }

        public DataTable LoadMachineGroupOfProcess(string Process)
        {
            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadMachineGroupOfProcess(null, Process);
        }

        #endregion

        #region Operation

        public int AddNew(MachineDTO dtoMachine) 
        {
            MachineValidator validator = new MachineValidator();
            validator.ValidateBeforeSaveNew(dtoMachine);

            Database db = CommonLib.Common.CurrentDatabase;
            db.KeepConnection = true;
            db.BeginTransaction();
            try {
                MachineDAO daoMachine = new MachineDAO(CommonLib.Common.CurrentDatabase);
                daoMachine.AddNew(null, dtoMachine);                

                db.Commit();
                return 1;
            }
            catch (Exception err) {
                db.Rollback();
                throw err;
            }
            finally {
                if (db.DBConnectionState == ConnectionState.Open)
                    db.Close();
            }
        }

        public int SaveUpdate(MachineDTO data) 
        {
            MachineValidator validator = new MachineValidator();
            validator.ValidateBeforeSaveUpdate(data);

            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
            return dao.UpdateWithoutPK(null, data);
        }

        public int DeleteMachine(NZString MachineNo) 
        {
            Database db = CommonLib.Common.CurrentDatabase;
            db.KeepConnection = true;
            db.BeginTransaction();
            try 
            {
                MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
                dao.Delete(null, MachineNo);

                db.Commit();
                return 1;
            }
            catch (Exception err) 
            {
                db.Rollback();
                throw err;
            }
            finally {
                if (db.DBConnectionState == ConnectionState.Open)
                    db.Close();
            }
        }

        #endregion
    }
}
