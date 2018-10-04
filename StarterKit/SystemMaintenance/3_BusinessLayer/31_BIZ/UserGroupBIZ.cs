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
   public class UserGroupBIZ
   {
       public LookupData LoadLookup(bool orderByKey)
       {
           IUserGroupDAO dao = DAOFactory.CreateUserGroupDAO(CommonLib.Common.CurrentDatabase);
           List<UserGroupDTO> dtos = dao.LoadAll(null, orderByKey);
           return new LookupData(DTOUtility.ConvertListToDataTable(dtos),
               UserGroupDTO.eColumns.GROUP_NAME.ToString(),
               UserGroupDTO.eColumns.GROUP_CD.ToString());
       }
       public List<UserGroupDTO> LoadAllGroup()
       {
           IUserGroupDAO dao = DAOFactory.CreateUserGroupDAO(CommonLib.Common.CurrentDatabase);
           return dao.LoadAll(null);
       }

       public int AddNewGroup(UserGroupDTO dto)
       {
           UserGroupValidator valUserGroup = new UserGroupValidator();
           if (valUserGroup.ValidateBeforeAdd(dto))
           {
               IUserGroupDAO dao = DAOFactory.CreateUserGroupDAO(CommonLib.Common.CurrentDatabase);
               return dao.AddNew(null, dto);
           }
           return 0;
       }
       public bool isExistGroupCD(NZString GroupCD)
       {
           return DAOFactory.CreateUserGroupDAO(CommonLib.Common.CurrentDatabase).Exist(null, GroupCD);
       }

       public int DeleteGroup(NZString GROUP_CD)
       {
           IUserGroupDAO dao = DAOFactory.CreateUserGroupDAO(CommonLib.Common.CurrentDatabase);
           return dao.Delete(null, GROUP_CD);
       }

       public int UpdateGroupDesc(UserGroupDTO dto)
       {
           IUserGroupDAO dao = DAOFactory.CreateUserGroupDAO(CommonLib.Common.CurrentDatabase);
           return dao.UpdateGroupDesc(null, dto);
       }
    }
}
