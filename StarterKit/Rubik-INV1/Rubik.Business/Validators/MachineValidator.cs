using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.DTO;
using EVOFramework;
using Rubik.DAO;

namespace Rubik.Validators {
    public class MachineValidator 
    {
        #region Mandatory Check

        public ErrorItem CheckEmptyMachineNo(NZString MachineNo) {
            if (MachineNo.IsNull)
                return new ErrorItem(MachineNo.Owner, TKPMessages.eValidate.VLM0157.ToString());
            
            if (!MachineNo.StrongValue.Equals(MachineNo.StrongValue.Trim()))
                return new ErrorItem(MachineNo.Owner, TKPMessages.eValidate.VLM0158.ToString());

            return null;
        }        

        public ErrorItem CheckEmptyMachineType(NZString MachineType) {
            if (MachineType.IsNull)
                return new ErrorItem(MachineType.Owner, TKPMessages.eValidate.VLM0159.ToString());

            return null;
        }

        public ErrorItem CheckEmptyProcess(NZString Process) {
            if (Process.IsNull)
                return new ErrorItem(Process.Owner, TKPMessages.eValidate.VLM0160.ToString());

            return null;
        }

        public ErrorItem CheckEmptyMachineGroup(NZString MachineGroup) {
            if (MachineGroup.IsNull)
                return new ErrorItem(MachineGroup.Owner, TKPMessages.eValidate.VLM0161.ToString());

            return null;
        }

        public ErrorItem CheckEmptyProject(NZString Project) {
            if (Project.IsNull)
                return new ErrorItem(Project.Owner, TKPMessages.eValidate.VLM0162.ToString());

            return null;
        }
        
        #endregion

        public BusinessException CheckMachineExist(NZString MachineNo) {
            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
            if (dao.Exist(null, MachineNo)) 
            {
                ErrorItem errorItem = new ErrorItem(MachineNo.Owner, TKPMessages.eValidate.VLM0163.ToString());
                return new BusinessException(errorItem);
            }
            return null;
        }

        public BusinessException CheckMachineNotExist(NZString MachineNo) 
        {
            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
            if (!dao.Exist(null, MachineNo)) {
                ErrorItem errorItem = new ErrorItem(MachineNo.Owner, TKPMessages.eValidate.VLM0164.ToString());
                return new BusinessException(errorItem);
            }
            return null;
        }

        public void ValidateBeforeSaveNew(MachineDTO dtoMachine) 
        {
            //ValidateException validateException = new ValidateException();
            //ErrorItem errorItem = null;

            //#region mandatory check
            //errorItem = CheckEmptyMachineNo(dtoMachine.MACHINE_CD);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyMachineType(dtoMachine.MACHINE_TYPE);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyProcess(dtoMachine.PROCESS_CD);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyMachineGroup(dtoMachine.MACHINE_GROUP);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyProject(dtoMachine.PROJECT);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);
           
            //validateException.ThrowIfHasError();
            
            //#endregion

            BusinessException businessException = CheckMachineExist(dtoMachine.MACHINE_CD);
            if (businessException != null) {
                throw businessException;
            }
        }

        public void ValidateBeforeSaveUpdate(MachineDTO dtoMachine) 
        {
            //ValidateException validateException = new ValidateException();
            //ErrorItem errorItem = null;

            //#region mandatory check
            //errorItem = CheckEmptyMachineNo(dtoMachine.MACHINE_CD);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyMachineType(dtoMachine.MACHINE_TYPE);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyProcess(dtoMachine.PROCESS_CD);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyMachineGroup(dtoMachine.MACHINE_GROUP);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //errorItem = CheckEmptyProject(dtoMachine.PROJECT);
            //if (errorItem != null)
            //    validateException.AddError(errorItem);

            //validateException.ThrowIfHasError();

            //#endregion

            BusinessException businessException = CheckMachineNotExist(dtoMachine.MACHINE_CD);
            if (businessException != null) {
                throw businessException;
            }
        }

        public ErrorItem ValidateBeforeDelete(NZString MACHINE_CD)
        {

            MachineDAO dao = new MachineDAO(CommonLib.Common.CurrentDatabase);
            string returnString = dao.ValidateBeforeDelete(null, MACHINE_CD);
            if (returnString == null)
            {
                return null;
            }
            else
            {
                return new ErrorItem(MACHINE_CD.Owner, returnString);
            }
        }
    }
}
