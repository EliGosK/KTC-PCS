using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;
using SystemMaintenance.DTO;
using EVOFramework;
using System.Data;
using SystemMaintenance.DAO;

namespace SystemMaintenance.BIZ
{
    public class ClassListBIZ
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClassInfoCD"></param>
        /// <returns></returns>
        public LookupData LoadLookupClassType(NZString ClassInfoCD)
        {
            IClassListDAO dao = DAOFactory.CreateClassListDAO(CommonLib.Common.CurrentDatabase);
            DataTable dt = DTOUtility.ConvertListToDataTable(dao.LoadByClassInfo(null, ClassInfoCD));
            LookupData lookupData = new LookupData(dt,
                ClassListDTO.eColumns.CLS_DESC.ToString(),
                ClassListDTO.eColumns.CLS_CD.ToString());
            return lookupData;
        }        

        //public LookupData LoadLookup(bool orderByKey)
        //{
        //    ClassListDAO dao = new ClassListDAO(CommonLib.Common.CurrentDatabase);
            
        //    List<ClassListDTO> dtos = dao.LoadAll(null, orderByKey);
        //    return new LookupData(DTOUtility.ConvertListToDataTable(dtos),
        //        ClassListDTO.eColumns.CLS_DESC.ToString(),
        //        ClassListDTO.eColumns.CLS_CD.ToString());
        //}
    }
}
