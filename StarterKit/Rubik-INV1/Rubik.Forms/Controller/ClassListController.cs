using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rubik.BIZ;
using System.Data;
using EVOFramework;
using Rubik.DTO;
using Rubik.UIDataModel;
using EVOFramework.Data;

namespace Rubik.Controller
{
    public class ClassListController
    {
        internal ClassListUIDM LoadClassList()
        {
            ClassListUIDM model = new ClassListUIDM();
            ClassListBIZ biz = new ClassListBIZ();
            List<ClassListDTO> ListClassList = biz.LoadAll();
            model.DATA_VIEW = DTOUtility.ConvertListToDataTable<ClassListDTO>(ListClassList);
            return model;
        }
        internal int UpdateClassList(ClassListDTO data)
        {
            ClassListBIZ biz = new ClassListBIZ();
            return biz.UpdateData(data);
        }
        internal int UpdateClassList(ClassListUIDM classUIDM)
        {
            ClassListDTO data = new ClassListDTO();
            data.CLS_INFO_CD = classUIDM.ClsInfoCd;
            data.CLS_CD = classUIDM.ClsCd;
            data.CLS_DESC = classUIDM.ClsDesc;
            data.SEQ = classUIDM.SEQ;
            int update = UpdateClassList(data);
            return update;
        }
        internal int AddClassList(ClassListDTO data)
        {
            ClassListBIZ biz = new ClassListBIZ();
            return biz.AddData(data);
        }
        internal int AddClassList(ClassListUIDM classUIDM, int EditFlag)
        {
            ClassListDTO data = new ClassListDTO();
            data.CLS_INFO_CD = classUIDM.ClsInfoCd;
            data.CLS_CD = classUIDM.ClsCd;
            data.CLS_DESC = classUIDM.ClsDesc;
            data.SEQ = classUIDM.SEQ;
            data.EDIT_FLAG.Value = EditFlag;
            int Add = AddClassList(data);
            return Add;
        }
        internal int DeleteClassList(ClassListDTO data)
        {
            ClassListBIZ biz = new ClassListBIZ();
            return biz.DeleteData(data);
        }
        internal int DeleteClassList(ClassListUIDM classUIDM)
        {
            ClassListDTO data = new ClassListDTO();
            data.CLS_INFO_CD = classUIDM.ClsInfoCd;
            data.CLS_CD = classUIDM.ClsCd;
            data.CLS_DESC = classUIDM.ClsDesc;
            data.SEQ = classUIDM.SEQ;
            int Del = DeleteClassList(data);
            return Del;
        }


  
    }
}
