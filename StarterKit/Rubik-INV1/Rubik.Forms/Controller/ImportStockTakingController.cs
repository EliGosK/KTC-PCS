using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rubik.DTO;
using CommonLib;
using EVOFramework;
using Rubik.BIZ;
using SystemMaintenance.Forms;

namespace Rubik.Controller
{
    public class ImportStockTakingController
    {
        //dtoImportList = data in import file
        public bool ImportStockTakingTemp(string FilePath, int TotalColumn, List<ImportStockTakingDTO> ImportDataList)
        {
            StockTakingBIZ biz = new StockTakingBIZ();
            biz.InsertStockTakingTemp(ImportDataList);

            List<ImportStockTakingDTO> errorList = biz.ValidateStockTakingTemp(Common.CurrentUserInfomation.UserCD,
                                                                                Common.CurrentUserInfomation.Machine);

            if (errorList == null || errorList.Count == 0)
            {
                biz.UpdateStockTaking(Common.CurrentUserInfomation.UserCD, Common.CurrentUserInfomation.Machine);
                return true;
            }

            WriteErrorToExcelFile(FilePath, TotalColumn + 1, errorList);

            return false;
        }

        private void WriteErrorToExcelFile(string FilePath, int ErrorColumn, List<ImportStockTakingDTO> ErrorList)
        {
            if (FileIsLocked(FilePath))
            {
                throw new ApplicationException("File is used by another program.");
            }

            ExcelControl xlApp = new ExcelControl(FilePath);
            xlApp.Hide();
            //xlApp.Open(FilePath);

            foreach (ImportStockTakingDTO dto in ErrorList)
            {
                xlApp.WriteCellText(dto.LINE_NO.StrongValue, ErrorColumn, dto.ERROR_DESC.StrongValue);
            }

            //#################
            // Save to file.
            //#################
            xlApp.Save();
            xlApp.Show();

            //// Close Excel Application.
            //xlApp.Hide();
            //xlApp.Dispose();
        }

        /// <summary>
        /// ทดสอบว่าไฟล์ที่ระบุมา  ถูกใช้โดยโปรเซสอื่นหรือไม่ ?
        /// </summary>
        /// <param name="strFullFileName"></param>
        /// <returns></returns>
        private bool FileIsLocked(string strFullFileName)
        {
            bool blnReturn = false;
            System.IO.FileStream fs;
            try
            {
                fs = System.IO.File.Open(strFullFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);
                fs.Close();
            }
            catch (System.IO.IOException ex)
            {
                blnReturn = true;
            }
            return blnReturn;
        }

        public void ClearImportStockTaking()
        {
            StockTakingBIZ biz = new StockTakingBIZ();
            if (biz.DoAdjustInventory())
            {
                ErrorItem err = new ErrorItem(null, TKPMessages.eValidate.VLM0181.ToString());
                throw new BusinessException(err);
            }

            biz.ClearImportStockTaking(Common.CurrentUserInfomation.UserCD, Common.CurrentUserInfomation.Machine);
        }
    }
}
