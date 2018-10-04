using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubik
{
    public class TKPMessages
    {
        public enum eValidate
        {
            /// <summary>
            /// Location Code can not be empty.
            /// </summary>
            VLM0001,
            /// <summary>
            /// Location Name can not be empty.
            /// </summary>
            VLM0002,
            /// <summary>
            /// Location Type can not be empty.
            /// </summary>
            VLM0003,
            /// <summary>
            /// Location Code does not exist.
            /// </summary>
            VLM0004,
            /// <summary>
            /// Location Code alredy exist.
            /// </summary>
            VLM0005,
            /// <summary>
            /// Item Code can not be empty.
            /// </summary>
            VLM0006,
            /// <summary>
            /// Item Description can not be empty.
            /// </summary>
            VLM0007,
            /// <summary>
            /// Item Type can not be empty.
            /// </summary>
            VLM0008,
            /// <summary>
            /// Item Code does not exist.
            /// </summary>
            VLM0009,
            /// <summary>
            /// Item Code alredy exist.
            /// </summary>
            VLM0010,
            /// <summary>
            /// Lot Control not be empty.
            /// </summary>
            VLM0011,
            /// <summary>
            /// Order Warehouse does not exist.
            /// </summary>
            VLM0012,
            /// <summary>
            /// Order Area does not exist.
            /// </summary>
            VLM0013,
            /// <summary>
            /// Order Shelf does not exist.
            /// </summary>
            VLM0014,
            /// <summary>
            ///  Store Warehouse does not exist.
            /// </summary>
            VLM0015,
            /// <summary>
            /// Store Area does not exist.
            /// </summary>
            VLM0017,
            /// <summary>
            /// Store Shelf does not exist.
            /// </summary>
            VLM0018,
            /// <summary>
            /// Issue Qty Shouldn’t be more than On hand Qty.
            /// </summary>
            VLM0019,
            /// <summary>
            /// Inventory Month can not be empty.
            /// </summary>
            VLM0020,
            /// <summary>
            /// Inventory Period Begin Date can not be empty.
            /// </summary>
            VLM0021,
            /// <summary>
            /// Inventory Period End Date can not be empty.
            /// </summary>
            VLM0022,
            /// <summary>
            /// Begin Date can not more than End Date.
            /// </summary>
            VLM0023,
            /// <summary>
            /// Inventory Period already exist.
            /// </summary>
            VLM0024,
            /// <summary>
            /// Source Location can not be empty.
            /// </summary>
            VLM0025,
            /// <summary>
            /// Target Location can not be empty.
            /// </summary>
            VLM0026,
            /// <summary>
            /// Issue Qty can not be 0.
            /// </summary>
            VLM0027,
            /// <summary>
            /// Issue Qty can not more than Onhand Qty.
            /// </summary>
            VLM0028,
            /// <summary>
            /// Onhand Qty can not be 0.
            /// </summary>
            VLM0029,
            /// <summary>
            /// From and To Location can not be same location.
            /// </summary>
            VLM0030,
            /// <summary>
            /// Issue Date can not be empty.
            /// </summary>
            VLM0031,
            /// <summary>
            /// Issue Date is not in Period range.
            /// </summary>
            VLM0032,
            /// <summary>
            /// Adjust Date cannot be empty
            /// </summary>
            VLM0033,
            /// <summary>
            /// Adjust Date is not in Period range
            /// </summary>
            VLM0034,
            /// <summary>
            /// Adjust Qty cannot be 0
            /// </summary>
            VLM0035,
            /// <summary>
            /// No stock for decrease
            /// </summary>
            VLM0036,
            /// <summary>
            /// Ship Date cannot be empty.
            /// </summary>
            VLM0037,
            /// <summary>
            /// Ship Date is not in Period range.
            /// </summary>
            VLM0038,
            /// <summary>
            /// Adjust Qty cannot be 0
            /// </summary>
            VLM0039,
            /// <summary>
            /// Ship Qty can not more than Onhand Qty.
            /// </summary>
            VLM0040,
            /// <summary>
            /// Receive Date cannot be empty.
            /// </summary>
            VLM0041,
            /// <summary>
            /// Receive Date is not in Period range.
            /// </summary>
            VLM0042,
            /// <summary>
            /// Receive Qty cannot be 0.
            /// </summary>
            VLM0043,
            /// <summary>
            /// PO No. cannot be empty.
            /// </summary>
            VLM0044,
            /// <summary>
            /// Inventory Month does not exist.
            /// </summary>
            VLM0045,
            /// <summary>
            /// Work Result Date cannot be empty.
            /// </summary>
            VLM0046,
            /// <summary>
            /// Work Result Date is not in Period range.
            /// </summary>
            VLM0047,
            /// <summary>
            /// Work Result Qty cannot be 0.
            /// </summary>
            VLM0048,
            /// <summary>
            /// The {0} not enough support {1} item. Another {2} missing qty.
            /// </summary>
            VLM0049,
            /// <summary>
            /// Please specify lot no. for {0} item.
            /// </summary>
            VLM0050,
            /// <summary>
            /// Consumption of {0} cannot more than Onhand Qty.
            /// </summary>
            VLM0051,
            /// <summary>
            /// Issue Qty of {0} cannot more than Onhand Qty.
            /// </summary>
            VLM0052,
            /// <summary>
            /// Barcode format incorrect.
            /// </summary>
            VLM0053,
            /// <summary>
            /// Lot of {0} does not exist.
            /// </summary>
            VLM0054,
            /// <summary>
            /// Receiving List cannot be empty.
            /// </summary>
            VLM0055,
            /// <summary>
            /// Order Process cannot be empty.
            /// </summary>
            VLM0056,
            /// <summary>
            /// Inventory U/M cannot be empty.
            /// </summary>
            VLM0057,
            /// <summary>
            /// Order U/M cannot be empty.
            /// </summary>
            VLM0058,
            /// <summary>
            /// Unit Convert cannot be empty.
            /// </summary>
            VLM0059,
            /// <summary>
            /// Order U/M rate must be more than 0.
            /// </su
            /// mmary>
            VLM0060,
            /// <summary>
            /// Consumption Class cannot be empty.
            /// </summary>
            VLM0061,
            /// <summary>
            /// Consumption qty of {0} over support {1} item. Excess {1} qty.
            /// </summary>
            VLM0062,
            /// <summary>
            /// The {0} in {1} location not enough.
            /// </summary>
            VLM0063,
            /// <summary>
            /// This item: {0} and lot no: {1} already exists
            /// </summary>
            VLM0064,
            /// <summary>
            /// Lot No. can not be specify because this Item is not control by Lot.
            /// </summary>
            VLM0065,
            /// <summary>
            /// 
            /// </summary>
            VLM0066,
            /// <summary>
            /// Lot No. dose not exist in {0} location.
            /// </summary>
            VLM0067,
            /// <summary>
            /// Cannot delete data because the {0} in {1} location not enough.
            /// </summary>
            VLM0068,
            /// <summary>
            /// Shipment List cannot be empty.
            /// </summary>
            VLM0069,
            /// <summary>
            /// Please select some row to delete.
            /// </summary>
            VLM0070,
            /// <summary>
            /// Cannot print. Please add data to list.
            /// </summary>
            VLM0071,
            /// <summary>
            /// Cannot specify space in Part No.
            /// </summary>
            VLM0072,
            /// <summary>
            /// All transaction of this part will be deleted.
            /// </summary>
            VLM0073,
            /// <summary>
            /// The stock open balance for {0} was just initiated. No need to execute again.
            /// </summary>
            VLM0074,
            /// <summary>
            /// Transaction date is not in period range.
            /// </summary>
            VLM0075,
            /// <summary>
            /// There are some negative qty in your current period. Do you want to continue ?
            /// </summary>
            VLM0076,
            /// <summary>
            /// Cannot do this process. Your previous inventory period is missing.
            /// </summary>
            VLM0077,
            /// <summary>
            /// Cannot do this process. Your current inventory period is not match.
            /// </summary>
            VLM0078,
            /// <summary>
            /// Reason code cannot be empty.
            /// </summary>
            VLM0079,
            /// <summary>
            /// Sub Type cannot be empty.
            /// </summary>
            VLM0080,
            /// <summary>
            /// Shift Type cannot be empty.
            /// </summary>
            VLM0081,
            /// <summary>
            /// Supplier code cannot be empty.
            /// </summary>
            VLM0082,
            /// <summary>
            /// Same part & lot {0} {1} as ID {2}.
            /// </summary>
            VLM0083,
            /// <summary>
            /// Stock Taking in a different month.
            /// </summary>
            VLM0084,
            /// <summary>
            /// Cannot run Pre-process early than the latest stock taking date.
            /// </summary>
            VLM0085,
            /// <summary>
            /// Please run Stock Taking Prepare Process.
            /// </summary>
            VLM0086,
            /// <summary>
            /// Please choose Location.
            /// </summary>
            VLM0087,
            /// <summary>
            /// Please input Count Qty.
            /// </summary>
            VLM0088,
            /// <summary>
            /// No lot match.
            /// </summary>
            VLM0089,
            /// <summary>
            /// Location {0} has already run Update Process
            /// </summary>
            VLM0090,
            /// <summary>
            /// There are some part in {0} does not input Count Qty.
            /// </summary>
            VLM0091,
            /// <summary>
            /// Same part & lot {0} {1} as ID {2}.
            /// </summary>
            VLM0092,
            /// <summary>
            /// The {0}  / {1} in {2} location not enough.
            /// </summary>
            VLM0093,
            /// <summary>
            /// The item has more than 1 child part.
            /// </summary>
            VLM0094,
            /// <summary>
            /// Work Result Type cannot be empty.
            /// </summary>
            VLM0095,
            /// <summary>
            /// This item: {0} , lot no: {1} and supplier lot no : {2} already exists
            /// </summary>
            VLM0096,
            /// <summary>
            /// Consumption class must be 'Manual type'
            /// </summary>
            VLM0097,
            /// <summary>
            /// Upper qty / Lower qty in bom must be 1 / 1 qty
            /// </summary>
            VLM0098,
            /// <summary>
            /// Consumption of {0} must be {1} only.
            /// </summary>
            VLM0099,
            /// <summary>
            /// Plese reload data.
            /// </summary>
            VLM0100,
            /// <summary>
            /// Please specify Item, Lot before duplicate.
            /// </summary>
            VLM0101,
            /// <summary>
            /// Duplicate data in the database.
            /// </summary>
            VLM0102,
            /// <summary>
            /// Plese select Location.
            /// </summary>
            VLM0103,
            /// <summary>
            /// Invalid shipment value
            /// </summary>
            VLM0104,
            /// <summary>
            /// Please input {0}
            /// </summary>
            VLM0105,
            ///<summary>
            /// Customer Code cannot be empty
            /// </summary>
            VLM0106,
            ///<summary>
            /// Demand Order is exists. 
            /// </summary>
            VLM0107,
            ///<summary>
            /// Customer Code does not exist
            /// </summary>
            VLM0108,
            ///<summary>
            /// Item Code does not exist
            /// </summary>
            VLM0109,
            ///<summary>
            /// PO No. already exists.
            /// </summary>
            VLM0110,
            ///<summary>
            /// PO already recieve PO Item.
            /// </summary>
            VLM0111,
            ///<summary>
            /// Please input order item before save.
            /// </summary>
            VLM0115,
            /// <summary>
            /// Recover Duration cannot be empty.
            /// </summary>
            VLM0143,
            /// <summary>
            /// Cannot save without data.
            /// </summary>
            VLM0151,
            /// <summary>
            /// Selected Date is exixts in table..
            /// </summary>
            VLM0152,
            /// <summary>
            /// Order Qty cannot be 0 or empty.
            /// </summary>
            VLM0153,
            /// <summary>
            /// Date cannot be empty.
            /// </summary>
            VLM0154,
            /// <summary>
            /// Date is out of range.
            /// </summary>
            VLM0155,
            /// <summary>
            /// Data not found.
            /// </summary>
            VLM0156,
            /// <summary>
            /// Machine No. can not be empty.
            /// </summary>
            VLM0157,
            /// <summary>
            /// Cannot specify space in Machine No.
            /// </summary>
            VLM0158,
            /// <summary>
            /// Machine Type can not be empty.
            /// </summary>
            VLM0159,
            /// <summary>
            /// Process can not be empty.
            /// </summary>
            VLM0160,
            /// <summary>
            /// Machine Group can not be empty.
            /// </summary>
            VLM0161,
            /// <summary>
            /// Project can not be empty.
            /// </summary>
            VLM0162,
            /// <summary>
            /// Machine No. alredy exist.
            /// </summary>
            VLM0163,
            /// <summary>
            /// Machine No. does not exist.
            /// </summary>
            VLM0164,
            /// <summary>
            /// Sales Unit Price is exist.
            /// </summary>
            VLM0165,
            /// <summary>
            /// Master No. can not be empty.
            /// </summary>
            VLM0166,
            /// <summary>
            /// Start Effice Date can not be empty.
            /// </summary>
            VLM0167,
            /// <summary>
            /// Currency can not be empty.
            /// </summary>
            VLM0168,
            /// <summary>
            /// Price can not be empty.
            /// </summary>
            VLM0169,
            /// <summary>
            /// Move No. can not be empty.
            /// </summary>
            VLM0170,
            /// <summary>
            /// Move Date can not be empty.
            /// </summary>
            VLM0171,
            /// <summary>
            /// Shift can not be empty.
            /// </summary>
            VLM0172,
            /// <summary>
            /// From Process can not be empty.
            /// </summary>
            VLM0173,
            /// <summary>
            /// To Process can not be empty.
            /// </summary>
            VLM0174,
            /// <summary>
            /// Qty can not be empty.
            /// </summary>
            VLM0175,
            /// <summary>
            /// Qty must more than zero.
            /// </summary>
            VLM0176,
            /// <summary>
            /// Qty must less than or equal On Hand Qty.
            /// </summary>
            VLM0177,
            /// <summary>
            /// File is incorrect format
            /// </summary>
            VLM0178,
            /// <summary>
            /// Please check Lot No. format
            /// </summary>
            VLM0179,
            /// <summary>
            /// There are some errors in file.
            /// </summary>
            VLM0180,
            /// <summary>
            /// Can not clear data because system already adjust inventory.
            /// </summary>
            VLM0181,
            /// <summary>
            /// Item does not belong to Customer.
            /// </summary>
            VLM0182,
            /// <summary>
            /// Please choose Data to view log
            /// </summary>
            VLM0183,
            /// <summary>
            /// Quantity is over limit
            /// </summary>
            VLM0184,
            /// <summary>
            /// Cannot input duplicate Master No.
            /// </summary>
            VLM0185,
            /// <summary>
            /// Cannot save packing data with no packing item.
            /// </summary>
            VLM0186,
            /// <summary>
            /// Packing Date can not be empty.
            /// </summary>
            VLM0187,
            /// <summary>
            /// Packing No. can not be empty.
            /// </summary>
            VLM0188,
            /// <summary>
            /// Lot No. has already exists.
            /// </summary>
            VLM0189,
            /// <summary>
            /// Please add at least one Order.
            /// </summary>
            VLM0190,
            /// <summary>
            /// Process is used in Machine Information.
            /// </summary>
            VLM0191,
            /// <summary>
            /// Product LT must more than zero.
            /// </summary>
            VLM0192,
            /// <summary>
            /// Kind of Product cannot be empty.
            /// </summary>
            VLM0193,
            /// <summary>
            /// Some order do not Choose Pack yet.
            /// </summary>
            VLM0194,
            /// <summary>
            /// Return Qty must less than Returnable Qty
            /// </summary>
            VLM0195,
            /// <summary>
            /// Return Qty must greater than 0.
            /// </summary>
            VLM0196,
            /// <summary>
            /// Please add return order.
            /// </summary>
            VLM0197,
            /// <summary>
            /// This process is exists in routing information.
            /// </summary>
            VLM0198,
            /// <summary>
            /// This Master No. is exists in component information.
            /// </summary>
            VLM0199,
            /// <summary>
            /// This process and machine is exists in machine information.
            /// </summary>
            VLM0200,
            /// <summary>
            /// Cannot save unpacking data with no selected packing item.
            /// </summary>
            VLM0201,
            /// <summary>
            /// This order has return transaction. Not allow to adjust pack.
            /// </summary>
            VLM0202,
            /// <summary>
            /// This order has been delivered ,cannot change to Forecast Order.
            /// </summary>
            VLM0203,
            /// <summary>
            /// Cannot adjust Order Qty less then delivery Qty.
            /// </summary>
            VLM0204,
            /// <summary>
            /// Cannot delete deliveried order.
            /// </summary>
            VLM0205,
            /// <summary>
            /// Cannot display data more than {0} records
            /// </summary>
            VLM0206,
            /// <summary>
            /// Component qty cannot be empty or zero.
            /// </summary>
            VLM0207,
            /// <summary>
            /// Delivery Date cannot be empty.
            /// </summary>
            VLM0208,
            /// <summary>
            /// Order Qty must greater than 0.
            /// </summary>
            VLM0209,
            /// <summary>
            /// Prod LT cannot be empty or less than 1.
            /// </summary>
            VLM0210,
            /// <summary>
            /// Seq No cannot be empty.
            /// </summary>
            VLM0211,
            /// <summary>
            /// Part No cannot be empty.
            /// </summary>
            VLM0212,
            /// <summary>
            /// Delete sale unit price will not effect to the price of existent customer order.
            /// </summary>
            VLM0213,
            /// <summary>
            /// Cannot delivery over order qty.
            /// </summary>
            VLM0214,
            /// <summary>
            /// Same part & lot {0} {1} as ID {2}.
            /// </summary>
            VLM0215,
            /// <summary>
            /// Unpacking Date can not be empty.
            /// </summary>
            VLM0216,
            /// <summary>
            /// Please define routing of Item.
            /// </summary>
            VLM0217,
            /// <summary>
            /// Pack No. can not be empty, please select lot from list.
            /// </summary>
            VLM0218,
            /// <summary>
            /// Process is used in Component(Rolling)
            /// </summary>
            VLM0219,
            /// <summary>
            /// Price cannot be zero.
            /// </summary>
            VLM0220,
            /// <summary>
            /// Cannot edit/delete Packing data after unpack.
            /// </summary>
            VLM0221,
            /// <summary>
            /// Delivery Date is not in Period range.
            /// </summary>
            VLM0222,
            /// <summary>
            /// Exchange Rate can not be 0.
            /// </summary>
            VLM0223,
            /// <summary>
            /// Plese specify Month/Year.
            /// </summary>
            VLM0224,
            /// <summary>
            /// Term Of Payment can not be empty.
            /// </summary>
            VLM0225,
            /// <summary>
            /// Invoice Pattern can not be empty.
            /// </summary>
            VLM0226,
            /// <summary>
            /// Cannot edit this data.
            /// </summary>
            VLM0227,
            /// <summary>
            /// Tag No. must be between 1-99999
            /// </summary>
            VLM0228,
            /// <summary>
            /// FG No. cannot be empty.
            /// </summary>
            VLM0229,
        }

        public enum eInformation
        {
            /// <summary>
            /// No data found.
            /// </summary>
            INF0001,
            /// <summary>
            /// Pack No. is already exists.
            /// </summary>
            INF0002,
            /// <summary>
            /// Lot No. is already exists.
            /// </summary>
            INF0003,
        }

        public enum eConfirm
        {
            /// <summary>
            /// The {0} not enough support {1} item. Another {2} missing qty. Do you want to save?
            /// </summary>
            CFM0001,
            /// <summary>
            /// Consumption qty of {0} over support {1} item. Excess {2} qty. Do you want to save?
            /// </summary>
            CFM0002,
            CFM0003,
            CFM0004,
            /// <summary>
            /// Do you to Run Process ? 
            /// </summary>
            CFM0005,
            /// <summary>
            /// Do you want to clear all import Data? 
            /// </summary>
            CFM0006,
            /// <summary>
            /// Do you want to delete this pack?
            /// </summary>
            CFM0007,
            /// <summary>
            /// Do you want to delete this order?
            /// </summary>
            CFM0008,
            /// <summary>
            /// Do you want to delete this delivery Group?
            /// </summary>
            CFM0009,
            /// <summary>
            /// Do you want to delete group?
            /// </summary>
            CFM0010,
            /// <summary>
            /// Data {0} records. System might take long time to display. Would you like to display data?
            /// </summary>
            CFM0011,
        }

        //public enum eError
        //{
        //    /// <summary>
        //    /// Cannot delete this data
        //    /// </summary>
        //    ERR0001,

        //}
    }
}
