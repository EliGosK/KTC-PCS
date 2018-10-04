using Rubik.UIDataModel;
using Rubik.BIZ;
using Rubik.DTO;
using EVOFramework;

namespace Rubik.Controller
{
    class MachineController
    {
        #region Mapping
        private MachineDTO MapModelToDTO(MachineUIDM data)
        {
            MachineDTO dto = new MachineDTO();   
            dto.MACHINE_CD = data.MACHINE_CD;
            dto.MACHINE_TYPE = data.MACHINE_TYPE;
            dto.PROCESS_CD = data.PROCESS_CD;
            dto.MACHINE_GROUP = data.MACHINE_GROUP;
            dto.PROJECT = data.PROJECT;
            dto.REMARK = data.REMARK;            
            dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dto.OLD_DATA = new NZInt(null, 0);

            return dto;
        }

        private MachineUIDM MapDTOToModel(MachineDTO data)
        {
            MachineUIDM model = new MachineUIDM();
            model.MACHINE_CD = data.MACHINE_CD;
            model.MACHINE_TYPE = data.MACHINE_TYPE;
            model.PROCESS_CD = data.PROCESS_CD;
            model.MACHINE_GROUP = data.MACHINE_GROUP;
            model.PROJECT = data.PROJECT;
            model.REMARK = data.REMARK;
            model.CRT_BY = data.CRT_BY;
            model.CRT_MACHINE = data.CRT_MACHINE;
            model.CRT_DATE = data.CRT_DATE;
            model.UPD_BY = data.UPD_BY;
            model.UPD_MACHINE = data.UPD_MACHINE;
            model.UPD_DATE = data.UPD_DATE;            

            return model;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        /// <exception cref="EVOFramework.BusinessException"><c>BusinessException</c>.</exception>
        public void SaveNew(MachineUIDM data)
        {
            MachineDTO dto = MapModelToDTO(data);

            MachineBIZ biz = new MachineBIZ();
            biz.AddNew(dto);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        /// <exception cref="EVOFramework.BusinessException"><c>BusinessException</c>.</exception>
        public void SaveUpdate(MachineUIDM data)
        {
            MachineDTO dto = MapModelToDTO(data);

            MachineBIZ biz = new MachineBIZ();
            biz.SaveUpdate(dto);
        }

        public MachineUIDM LoadMachine(NZString MachineNo) {
            MachineBIZ biz = new MachineBIZ();
            MachineDTO dto = biz.LoadMachine(MachineNo);

            return MapDTOToModel(dto);
        }

        public void DeleteMachine(NZString MachineNo) {
            MachineBIZ biz = new MachineBIZ();
            biz.DeleteMachine(MachineNo);
        }
    }
}
