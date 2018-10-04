using System;
using System.Collections.Generic;
using System.Data;
using Rubik.DAO;
using Rubik.DTO;
using EVOFramework.Database;
using Rubik.Validators;
using EVOFramework;
using Rubik.Data;

namespace Rubik.BIZ {

    public class CustomerBIZ {

        #region Load Data

        public CustomerDTO LoadCustomerByPK(CustomerDTO dto) {

            CustomerDAO dao = new CustomerDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadByPK(null, dto.CUSTOMER_CODE);

        }

        public List<CustomerDTO> LoadAll() {

            CustomerDAO dao = new CustomerDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadAll(null);

        }

        public DataTable LoadCustomerAll() {

            CustomerDAO dao = new CustomerDAO(CommonLib.Common.CurrentDatabase);
            return dao.LoadCustomerAll(null);

        }

        #endregion

        #region Validate

        public bool IsExists(CustomerDTO dto) 
        {
            CustomerDAO dao = new CustomerDAO(CommonLib.Common.CurrentDatabase);
            return dao.Exist(null, dto.CUSTOMER_CODE);
        }


        #endregion

    }
}
