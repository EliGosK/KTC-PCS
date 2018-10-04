using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework;
using Rubik.DAO;
using Rubik.DTO;

namespace Rubik.BIZ
{
    public class ClassListBIZ
    {
        public Rubik.DTO.ClassListDTO LoadByPK(NZString CLS_INFO_CD, NZString CLS_CD)
        {
            ClassListDAO dao = new ClassListDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, CLS_INFO_CD, CLS_CD);
        }

        public List<Rubik.DTO.ClassListDTO> LoadByClassInfo(NZString CLS_INFO_CD)
        {
            ClassListDAO dao = new ClassListDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByClassInfo(null, CLS_INFO_CD);
        }

        public List<ClassListDTO> LoadAll()
        {
            ClassListDAO dao = new ClassListDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAll(null);
        }
        public int UpdateData(ClassListDTO data)
        {
            ClassListDAO dao = new ClassListDAO(CommonLib.Common.CurrentDatabase);
            return dao.UpdateWithoutPK(null, data);
        }
        public int AddData(ClassListDTO data)
        {
            ClassListDAO dao = new ClassListDAO(CommonLib.Common.CurrentDatabase);
            return dao.AddNewAndCheck(null, data);
        }
        public int DeleteData(ClassListDTO data)
        {
            ClassListDAO dao = new ClassListDAO(CommonLib.Common.CurrentDatabase);
            return dao.Delete(null, data);
        }
    }
}
