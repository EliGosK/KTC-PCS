using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
    public class FormatUtil
    {
        public static void SetDateFormat(FarPoint.Win.Spread.Column col)
        {
            string strDateFormat = Common.CurrentUserInfomation.DateFormatString;

            FarPoint.Win.Spread.CellType.DateTimeCellType type = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            type.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            type.UserDefinedFormat = strDateFormat;

            col.CellType = type;
            //type.user define FormatException
        }

        public static void SetDateFormat(EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar textbox)
        {
            string strDateFormat = Common.CurrentUserInfomation.DateFormatString;
            textbox.Format = strDateFormat;
        }

        public static void SetDateTimeFormat(FarPoint.Win.Spread.Column col)
        {
            string strDateFormat = Common.CurrentUserInfomation.DateFormatString;

            FarPoint.Win.Spread.CellType.DateTimeCellType type = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            type.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            type.UserDefinedFormat = strDateFormat + " HH:mm:ss";

            col.CellType = type;
            //type.user define FormatException
        }

        public static void SetDateTimeFormat(EVOFramework.Windows.Forms.EVODateTextBoxWithCalendar textbox)
        {
            string strDateFormat = Common.CurrentUserInfomation.DateFormatString;
            textbox.Format = strDateFormat + " HH:mm:ss";
        }

        public static void SetDateTimeFormat(EVOFramework.Windows.Forms.EVODateTextBox textbox)
        {
            string strDateFormat = Common.CurrentUserInfomation.DateFormatString;
            textbox.Format = strDateFormat + " HH:mm:ss";
        }

        public enum eNumberFormat
        {
            Qty_PCS,
            Qty_KG,
            Qty_Gram,
            Qty_Box,
            UnitPrice,
            Amount,
            Amount_THB,
            ExchangeRate,
            MasterNo,
            Qty_Adjust_PCS,
            Qty_Adjust_KG,
            Total_Qty_PCS,
            TagNo
        }

        public static void SetNumberFormat(FarPoint.Win.Spread.Column col, eNumberFormat format)
        {
            FarPoint.Win.Spread.CellType.NumberCellType type = new FarPoint.Win.Spread.CellType.NumberCellType();

            type.ButtonAlign = FarPoint.Win.ButtonAlign.Right;

            col.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;

            switch (format)
            {
                case eNumberFormat.Amount:
                    type.DecimalPlaces = 2;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = true;
                    type.MaximumValue = (Math.Pow(10, 10 /*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.Amount_THB:
                    type.DecimalPlaces = 2;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = true;
                    type.MaximumValue = (Math.Pow(10, 10 /*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.Qty_KG:
                    type.DecimalPlaces = 2;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = true;
                    type.MinimumValue = 0;
                    type.MaximumValue = (Math.Pow(10, 5 /*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.Qty_Adjust_KG:
                    type.DecimalPlaces = 2;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = true;
                    type.MinimumValue = 0;
                    type.MaximumValue = (Math.Pow(10, 5 /*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.Qty_Gram:
                    type.DecimalPlaces = 4;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = true;
                    type.MinimumValue = 0;
                    type.MaximumValue = (Math.Pow(10, 4 /*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.Qty_PCS:
                    type.DecimalPlaces = 0;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = true;
                    type.MinimumValue = 0;
                    type.MaximumValue = (Math.Pow(10, 9 /*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.Qty_Adjust_PCS:
                    type.DecimalPlaces = 0;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = true;
                    type.MinimumValue = 0;
                    type.MaximumValue = (Math.Pow(10, 12 /*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.UnitPrice:
                    type.DecimalPlaces = 4;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = true;
                    type.MaximumValue = (Math.Pow(10, 5/*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.ExchangeRate:
                    type.DecimalPlaces = 4;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = true;
                    type.MaximumValue = (Math.Pow(10, 4 /*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.MasterNo:
                    type.DecimalPlaces = 0;
                    type.DecimalSeparator = ".";
                    type.Separator = "";
                    type.ShowSeparator = false;
                    type.MaximumValue = (Math.Pow(10, 10 /*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.Total_Qty_PCS:
                    type.DecimalPlaces = 0;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = true;
                    type.MinimumValue = 0;
                    type.MaximumValue = (Math.Pow(10, 8 /*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.Qty_Box:
                    type.DecimalPlaces = 0;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = true;
                    type.MinimumValue = 0;
                    type.MaximumValue = (Math.Pow(10, 4 /*จำนวนหลัก*/) - 1);
                    break;
                case eNumberFormat.TagNo:
                    type.DecimalPlaces = 0;
                    type.DecimalSeparator = ".";
                    type.Separator = ",";
                    type.ShowSeparator = false;                    
                    type.MinimumValue = 0;
                    type.MaximumValue = (Math.Pow(10, 5 /*จำนวนหลัก*/) - 1);
                    break;
                default: break;
            }

            col.CellType = type;
        }

        public static void SetNumberFormat(EVOFramework.Windows.Forms.EVONumericTextBox txtNumber, eNumberFormat format)
        {
            txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtNumber.FixDecimalPosition = true;

            switch (format)
            {
                case eNumberFormat.Amount:
                    txtNumber.MaxDecimalPlaces = 2;
                    txtNumber.MaxWholeDigits = 10;
                    if (txtNumber.AllowNegative)
                    {
                        txtNumber.RangeMin = (-1) * (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                        txtNumber.NegativeSign = '-';
                    }
                    else
                    {
                        txtNumber.RangeMin = 0;
                    }
                    txtNumber.DigitsInGroup = 3;
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                                            + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                                            + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                                            + txtNumber.MaxWholeDigits
                                            + txtNumber.MaxDecimalPlaces;
                    break;
                case eNumberFormat.Amount_THB:
                    txtNumber.MaxDecimalPlaces = 2;
                    txtNumber.MaxWholeDigits = 10;
                    if (txtNumber.AllowNegative)
                    {
                        txtNumber.RangeMin = (-1) * (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                        txtNumber.NegativeSign = '-';
                    }
                    else
                    {
                        txtNumber.RangeMin = 0;
                    }
                    txtNumber.DigitsInGroup = 3;
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                                            + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                                            + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                                            + txtNumber.MaxWholeDigits
                                            + txtNumber.MaxDecimalPlaces;
                    break;
                case eNumberFormat.Qty_KG:
                    txtNumber.MaxDecimalPlaces = 2;
                    txtNumber.MaxWholeDigits = 5;
                    if (txtNumber.AllowNegative)
                    {
                        txtNumber.RangeMin = (-1) * (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                        txtNumber.NegativeSign = '-';
                    }
                    else
                    {
                        txtNumber.RangeMin = 0;
                    }
                    txtNumber.DigitsInGroup = 3;
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                                            + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                                            + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                                            + txtNumber.MaxWholeDigits
                                            + txtNumber.MaxDecimalPlaces;
                    break;
                case eNumberFormat.Qty_Adjust_KG:
                    txtNumber.MaxDecimalPlaces = 2;
                    txtNumber.MaxWholeDigits = 5;
                    if (txtNumber.AllowNegative)
                    {
                        txtNumber.RangeMin = (-1) * (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                        txtNumber.NegativeSign = '-';
                    }
                    else
                    {
                        txtNumber.RangeMin = 0;
                    }
                    txtNumber.DigitsInGroup = 3;
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                                            + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                                            + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                                            + txtNumber.MaxWholeDigits
                                            + txtNumber.MaxDecimalPlaces;
                    break;
                case eNumberFormat.Qty_Gram:
                    txtNumber.MaxDecimalPlaces = 4;
                    txtNumber.MaxWholeDigits = 4;
                    if (txtNumber.AllowNegative)
                    {
                        txtNumber.RangeMin = (-1) * (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                        txtNumber.NegativeSign = '-';
                    }
                    else
                    {
                        txtNumber.RangeMin = 0;
                    }
                    txtNumber.DigitsInGroup = 3;
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                        + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                        + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                        + txtNumber.MaxWholeDigits
                        + txtNumber.MaxDecimalPlaces;
                    break;
                case eNumberFormat.Qty_PCS:
                    txtNumber.MaxDecimalPlaces = 0;
                    txtNumber.MaxWholeDigits = 11;
                    if (txtNumber.AllowNegative)
                    {
                        txtNumber.RangeMin = (-1) * (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                        txtNumber.NegativeSign = '-';
                    }
                    else
                    {
                        txtNumber.RangeMin = 0;
                    }
                    txtNumber.DigitsInGroup = 3;
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                        + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                        + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                        + txtNumber.MaxWholeDigits
                        + txtNumber.MaxDecimalPlaces;
                    break;
                case eNumberFormat.Qty_Adjust_PCS:
                    txtNumber.MaxDecimalPlaces = 0;
                    txtNumber.MaxWholeDigits = 12;
                    if (txtNumber.AllowNegative)
                    {
                        txtNumber.RangeMin = (-1) * (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                        txtNumber.NegativeSign = '-';
                    }
                    else
                    {
                        txtNumber.RangeMin = 0;
                    }
                    txtNumber.DigitsInGroup = 3;
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                        + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                        + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                        + txtNumber.MaxWholeDigits
                        + txtNumber.MaxDecimalPlaces;
                    break;
                case eNumberFormat.UnitPrice:
                    txtNumber.MaxDecimalPlaces = 4;
                    txtNumber.MaxWholeDigits = 5;
                    if (txtNumber.AllowNegative)
                    {
                        txtNumber.RangeMin = (-1) * (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                        txtNumber.NegativeSign = '-';
                    }
                    else
                    {
                        txtNumber.RangeMin = 0;
                    }
                    txtNumber.DigitsInGroup = 3;
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                        + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                        + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                        + txtNumber.MaxWholeDigits
                        + txtNumber.MaxDecimalPlaces;
                    break;
                case eNumberFormat.ExchangeRate:
                    txtNumber.MaxDecimalPlaces = 4;
                    txtNumber.MaxWholeDigits = 4;
                    if (txtNumber.AllowNegative)
                    {
                        txtNumber.RangeMin = (-1) * (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                        txtNumber.NegativeSign = '-';
                    }
                    else
                    {
                        txtNumber.RangeMin = 0;
                    }
                    txtNumber.DigitsInGroup = 3;
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                        + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                        + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                        + txtNumber.MaxWholeDigits
                        + txtNumber.MaxDecimalPlaces;
                    break;
                case eNumberFormat.MasterNo:
                    txtNumber.MaxDecimalPlaces = 0;
                    txtNumber.MaxWholeDigits = 10;
                    txtNumber.RangeMin = 0;
                    txtNumber.DigitsInGroup = 0;
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                        + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                        + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                        + txtNumber.MaxWholeDigits
                        + txtNumber.MaxDecimalPlaces;
                    break;
                case eNumberFormat.Total_Qty_PCS:
                    txtNumber.MaxDecimalPlaces = 0;
                    txtNumber.MaxWholeDigits = 8;
                    if (txtNumber.AllowNegative)
                    {
                        txtNumber.RangeMin = (-1) * (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                        txtNumber.NegativeSign = '-';
                    }
                    else
                    {
                        txtNumber.RangeMin = 0;
                    }
                    txtNumber.DigitsInGroup = 3;
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                        + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                        + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                        + txtNumber.MaxWholeDigits
                        + txtNumber.MaxDecimalPlaces;
                    break;
                case eNumberFormat.TagNo:
                    txtNumber.MaxDecimalPlaces = 0;
                    txtNumber.MaxWholeDigits = 5;
                    txtNumber.RangeMin = 0;
                    txtNumber.DigitsInGroup = 0;                    
                    txtNumber.GroupSeparator = ',';
                    txtNumber.RangeMax = (Math.Pow(10, txtNumber.MaxWholeDigits) - 1);
                    txtNumber.MaxLength = (txtNumber.MaxDecimalPlaces > 0 ? ((txtNumber.MaxWholeDigits - 1) / 3) : 0)// คำนวณ ,
                        + (txtNumber.MaxDecimalPlaces > 0 ? 1 : 0) // คำนวณ .
                        + (txtNumber.AllowNegative ? 1 : 0) // คำนวณ -
                        + txtNumber.MaxWholeDigits
                        + txtNumber.MaxDecimalPlaces;
                    break;
                default: break;
            }
        }

        public static void CheckFormatLotNo(EVOFramework.NZString argLotNo)
        {
            //skip checking lot no format

            //string strLotNo = argLotNo.NVL("");

            //if ("".Equals(strLotNo)) return;

            //EVOFramework.ErrorItem errorItem = null;

            //if (strLotNo.Length < 7)
            //{
            //    errorItem = new EVOFramework.ErrorItem(argLotNo.Owner, Rubik.TKPMessages.eValidate.VLM0179.ToString());
            //}
            //if (null != errorItem) EVOFramework.ValidateException.ThrowErrorItem(errorItem);

            //double decNum = 0;

            //if (!Double.TryParse(strLotNo.Substring(0, 7), out decNum))
            //{
            //    errorItem = new EVOFramework.ErrorItem(argLotNo.Owner, Rubik.TKPMessages.eValidate.VLM0179.ToString());
            //}
            //if (null != errorItem) EVOFramework.ValidateException.ThrowErrorItem(errorItem);

        }

    }
}
