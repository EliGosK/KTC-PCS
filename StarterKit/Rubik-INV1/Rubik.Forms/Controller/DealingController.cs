using Rubik.UIDataModel;
using Rubik.BIZ;
using Rubik.DTO;
using EVOFramework;

namespace Rubik.Controller
{
    class DealingController
    {
        #region Mapping
        private DealingDTO MapModelToDTO(DealingUIDM data)
        {
            DealingDTO dto = new DealingDTO();
            dto.LOC_CD = data.LOC_CD;
            dto.LOC_DESC = data.LOC_DESC;
            dto.LOC_CLS = data.LOC_CLS;
            dto.TERM_OF_PAYMENT = data.TERM_OF_PAYMENT;
            dto.INVOICE_PATTERN = data.INVOICE_PATTERN;
            dto.ADDRESS1 = data.ADDRESS1;
            dto.TEL1 = data.TEL1;
            dto.FAX1 = data.FAX1;
            dto.EMAIL1 = data.EMAIL1;
            dto.CONTACT_PERSON1 = data.CONTACT_PERSON1;
            dto.REMARK1 = data.REMARK1;
            dto.ADDRESS2 = data.ADDRESS2;
            dto.TEL2 = data.TEL2;
            dto.FAX2 = data.FAX2;
            dto.EMAIL2 = data.EMAIL2;
            dto.CONTACT_PERSON2 = data.CONTACT_PERSON2;
            dto.REMARK2 = data.REMARK2;
            dto.ADDRESS3 = data.ADDRESS3;
            dto.TEL3 = data.TEL3;
            dto.FAX3 = data.FAX3;
            dto.EMAIL3 = data.EMAIL3;
            dto.CONTACT_PERSON3 = data.CONTACT_PERSON3;
            dto.REMARK3 = data.REMARK3;
            dto.ALLOW_NEGATIVE = "01".ToNZString(); // yes 
            dto.OLD_DATA = (0).ToNZInt(); 
            dto.CRT_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.CRT_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;
            dto.UPD_BY = CommonLib.Common.CurrentUserInfomation.UserCD;
            dto.UPD_MACHINE = CommonLib.Common.CurrentUserInfomation.Machine;

            return dto;
        }

        private DealingUIDM MapDTOToModel(DealingDTO data)
        {
            DealingUIDM model = new DealingUIDM();
            model.LOC_CD = data.LOC_CD;
            model.LOC_DESC = data.LOC_DESC;
            model.LOC_CLS = data.LOC_CLS;
            model.TERM_OF_PAYMENT = data.TERM_OF_PAYMENT;
            model.INVOICE_PATTERN = data.INVOICE_PATTERN;
            model.ADDRESS1 = data.ADDRESS1;
            model.TEL1 = data.TEL1;
            model.FAX1 = data.FAX1;
            model.EMAIL1 = data.EMAIL1;
            model.CONTACT_PERSON1 = data.CONTACT_PERSON1;
            model.REMARK1 = data.REMARK1;
            model.ADDRESS2 = data.ADDRESS2;
            model.TEL2 = data.TEL2;
            model.FAX2 = data.FAX2;
            model.EMAIL2 = data.EMAIL2;
            model.CONTACT_PERSON2 = data.CONTACT_PERSON2;
            model.REMARK2 = data.REMARK2;
            model.ADDRESS3 = data.ADDRESS3;
            model.TEL3 = data.TEL3;
            model.FAX3 = data.FAX3;
            model.EMAIL3 = data.EMAIL3;
            model.CONTACT_PERSON3 = data.CONTACT_PERSON3;
            model.REMARK3 = data.REMARK3;
            model.ALLOW_NEGATIVE = data.ALLOW_NEGATIVE;
            model.OLD_DATA = data.OLD_DATA;
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
        public void SaveNew(DealingUIDM data)
        {

            DealingDTO dto = MapModelToDTO(data);

            DealingBIZ biz = new DealingBIZ();
            biz.SaveNew(dto);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="EVOFramework.ValidateException"><c>ValidateException</c>.</exception>
        /// <exception cref="EVOFramework.BusinessException"><c>BusinessException</c>.</exception>
        public void SaveUpdate(DealingUIDM data)
        {
            DealingDTO dto = MapModelToDTO(data);

            DealingBIZ biz = new DealingBIZ();
            biz.SaveUpdate(dto);
        }

        public DealingUIDM LoadLocation(NZString locationCode)
        {
            DealingBIZ biz = new DealingBIZ();
            DealingDTO dto = biz.LoadLocation(locationCode);

            return MapDTOToModel(dto);
        }

        public void DeleteLocation(NZString locationCode)
        {
            DealingBIZ biz = new DealingBIZ();
            biz.DeleteLocation(locationCode);
        }
    }
}
