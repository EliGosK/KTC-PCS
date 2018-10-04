using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonLib
{
    public class SaveDialogUtil
    {
        private static SaveFileDialog dialog = null;

        private static string desktopPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";


        static SaveDialogUtil()
        {
            dialog = new SaveFileDialog();
            dialog.ValidateNames = true;
            dialog.DefaultExt = "xls";
            dialog.AddExtension = true;

            dialog.Filter = "Excel file|*.xls|All files|*.*";

            dialog.InitialDirectory = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory).ToString();

        }


        public static string GetBrowseFileDialogForExport()
        {
            string ret = "";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ret = dialog.FileName;
            }

            return ret;
        }

        public static string GetBrowseFileDialogForExport(string argFileName)
        {
            string ret = "";

            dialog.FileName = argFileName;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ret = dialog.FileName;
            }

            return ret;
        }

        public static string GetBrowseFileDialogForExport(string argFileName, string argPath)
        {
            string ret = "";

            dialog.InitialDirectory = argPath;

            dialog.FileName = argFileName;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ret = dialog.FileName;
            }

            return ret;
        }

        //public static string GetBrowseFileDialogForExport(string argFileName, DTO_ReportDetail dtoReportDetail)
        //{
        //    string ret = "";

        //    dialog.FileName = argFileName;

        //    if (dtoReportDetail.ExportToExportFolder == 0)
        //    {
        //        if (dtoReportDetail.DisplaySaveDialog == 0)
        //        {
        //            ret = desktopPath + argFileName;
        //        }
        //        else
        //        {
        //            if (dialog.ShowDialog() == DialogResult.OK)
        //            {
        //                ret = dialog.FileName;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            FileSystemWatcher watcher = new FileSystemWatcher(dtoReportDetail.ExpFolder);

        //            if (dtoReportDetail.DisplaySaveDialog == 0)
        //            {
        //                ret = dtoReportDetail.ExpFolder + argFileName;
        //            }
        //            else
        //            {
        //                dialog.InitialDirectory = dtoReportDetail.ExpFolder;

        //                if (dialog.ShowDialog() == DialogResult.OK)
        //                {
        //                    ret = dialog.FileName;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //MessageDialog.ShowSystemErrorMsg(this, ex);
        //            dialog.InitialDirectory = desktopPath;

        //            if (dialog.ShowDialog() == DialogResult.OK)
        //            {
        //                ret = dialog.FileName;
        //            }
        //        }
        //    }

        //    return ret;
        //}

        public static string GetBrowseFileDialog(string strTitle, string strFilter) 
        {
            string ret = "";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = strTitle;
            dialog.InitialDirectory = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory).ToString();
            dialog.Filter = strFilter;
            if (dialog.ShowDialog() == DialogResult.OK) {
                ret = dialog.FileName;
            }

            return ret;
        }
    }
}
