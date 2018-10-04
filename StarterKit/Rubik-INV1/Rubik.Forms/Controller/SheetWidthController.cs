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
    public class SheetWidthController
    {

        public void ResetSheetWidth(FarPoint.Win.Spread.SheetView shtResetWidth)
        {
            for (int i = 0; i < shtResetWidth.Columns.Count; i++)
            {
                if (shtResetWidth.Columns[i].Visible == true)
                {
                    //default size ให้เล็กๆไว้ก่อน มันจะได้คำนวณหา width ที่พอดีได้
                    shtResetWidth.Columns[i].Width = 50;

                    // + 20 เพราะมันมีแสดง filter , sorting
                    shtResetWidth.Columns[i].Width = shtResetWidth.GetPreferredColumnWidth(i, false, true) + 20;
                }
            }
        }

        public void SetSheetWidth(FarPoint.Win.Spread.SheetView shtSetWidth, string ScreenCode)
        {
            SheetWidthBIZ biz = new SheetWidthBIZ();

            SheetWidthDTO objSize = new SheetWidthDTO();
            objSize.SCREEN_CD = ScreenCode.ToNZString();
            objSize.SHEET_ID = shtSetWidth.SheetName.ToNZString();
            List<SheetWidthDTO> listColumnWidth = biz.LoadColumnWidth(objSize);

            if (listColumnWidth != null)
            {
                for (int i = 0; i < listColumnWidth.Count; i++)
                {
                    if (i < shtSetWidth.Columns.Count)
                    {
                        int index = (int)listColumnWidth[i].COL_INDEX.NVL(0);
                        if (index < 0)
                            shtSetWidth.RowHeader.Columns[0].Width = (float)listColumnWidth[i].COL_WIDTH.NVL(25);
                        else
                            //shtSetWidth.Columns[i].Width = (float)listColumnWidth[i].COL_WIDTH.NVL(25);
                            shtSetWidth.Columns[index].Width = (float)listColumnWidth[i].COL_WIDTH.NVL(25);
                    }
                }
            }
        }

        public void SaveSheetWidth(FarPoint.Win.Spread.SheetView shtSaveWidth, string ScreenCode)
        {
            List<SheetWidthDTO> listSize = new List<SheetWidthDTO>();
            SheetWidthDTO objSize = null;

            //Header    
            objSize = new SheetWidthDTO();
            objSize.COL_INDEX = (-1).ToNZInt();
            objSize.COL_WIDTH = shtSaveWidth.RowHeader.Columns[0].Width.ToNZDecimal();
            objSize.SCREEN_CD = ScreenCode.ToNZString();
            objSize.SHEET_ID = shtSaveWidth.SheetName.ToNZString();

            listSize.Add(objSize);


            for (int i = 0; i < shtSaveWidth.Columns.Count; i++)
            {
                objSize = new SheetWidthDTO();
                objSize.COL_INDEX = i.ToNZInt();
                objSize.COL_WIDTH = shtSaveWidth.Columns[i].Width.ToNZDecimal();
                objSize.SCREEN_CD = ScreenCode.ToNZString();
                objSize.SHEET_ID = shtSaveWidth.SheetName.ToNZString();

                listSize.Add(objSize);
            }


            SheetWidthBIZ biz = new SheetWidthBIZ();
            biz.SaveColumnWidth(listSize);
        }
    }
}
