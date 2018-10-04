using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Data;

namespace SystemMaintenance
{
    /// <summary>
    /// Collection messages.
    /// </summary>
    public class Messages
    {
        /// <summary>
        /// Message about validation.
        /// </summary>
        public enum eValidate
        {
            /// <summary>
            /// User account already exist.
            /// </summary>
            VLM9001,
            /// <summary>
            /// User Account can not be empty.
            /// </summary>
            VLM9002,
            /// <summary>
            /// User Name can not be empty.
            /// </summary>
            VLM9003,
            /// <summary>
            /// Password can not be empty.
            /// </summary>
            VLM9004,
            /// <summary>
            /// Default Date Format can not be empty.
            /// </summary>
            VLM9005,
            /// <summary>
            /// Default Lang can not be empty.
            /// </summary>
            VLM9006,
            VLM9007,
            /// <summary>
            /// Data isn't an item in  list.
            /// </summary>
            VLM9008,

            /// <summary>
            /// The Password you typed do not match. Type the new password in both text boxes.
            /// </summary>
            VLM9009,
            /// <summary>
            /// The user account or old password is incorrect.
            /// </summary>
            VLM9010,
            /// <summary>
            /// Group User can not be empty.
            /// </summary>
            VLM9011,
            /// <summary>
            /// Menu Set Code can not be empty.
            /// </summary>
            VLM9012,
            /// <summary>
            /// Menu Set Code already exist.
            /// </summary>
            VLM9013,
            /// <summary>
            /// Sub Menu Code can not be empty.
            /// </summary>
            VLM9014,
            /// <summary>
            /// Sub Menu Name can not be empty
            /// </summary>
            VLM9015,
            /// <summary>
            /// Sub Menu Code already exist.
            /// </summary>
            VLM9016,
            /// <summary>
            /// Screen Favorite already exist.
            /// </summary>
            VLM9017,

            /// <summary>
            /// Demand Month cannot be empty.
            /// </summary>
            VLM0112,
            /// <summary>
            /// Customer Code cannot be empty.
            /// </summary>
            VLM0113,
            /// <summary>
            /// Invalid Customer Code.
            /// </summary>
            VLM0114,
            /// <summary>
            /// Purchase Order Date cannot be empty.
            /// </summary>
            VLM0116,
            /// <summary>
            /// Purchase Order Type cannot be empty.
            /// </summary>
            VLM0117,
            /// <summary>
            /// Supplier Code cannot be empty.
            /// </summary>
            VLM0118,
            /// <summary>
            /// Delivery Location cannot be empty.
            /// </summary>
            VLM0119,
            /// <summary>
            /// Purchase Order status cannot be empty.
            /// </summary>
            VLM0120,
            /// <summary>
            /// Currency cannot be empty.
            /// </summary>
            VLM0121,
            /// <summary>
            /// Vat Type cannot be empty.
            /// </summary>
            VLM0122,
            /// <summary>
            /// Vat Rate cannot be zero.
            /// </summary>
            VLM0123,
            /// <summary>
            /// Cannot delete purchase item with receive Qty greater than 0
            /// </summary>
            VLM0124,
            /// <summary>
            /// Cannot save purchase order with no purchase item.
            /// </summary>
            VLM0125,
            /// <summary>
            /// Qty cannot be zero.
            /// </summary>
            VLM0126,
            /// <summary>
            /// Qty must greater than or equal receive qty.
            /// </summary>
            VLM0127,
            /// <summary>
            /// Cannot add duplicate item.
            /// </summary>
            VLM0128,
            /// <summary>
            /// Item description cannot be empty.
            /// </summary>
            VLM0129,
            /// <summary>
            /// Require date cannot be empty.
            /// </summary>
            VLM0130,
            /// <summary>
            /// Unit price cannot be empty.
            /// </summary>
            VLM0131,
            /// <summary>
            /// Puchase Order Qty cannot be empty.
            /// </summary>
            VLM0132,
            /// <summary>
            /// Unit cannot be empty.
            /// </summary>
            VLM0133,
            /// <summary>
            /// Amount cannot be empty.
            /// </summary>
            VLM0134,
            /// <summary>
            /// Receive Qty cannot be empty.
            /// </summary>
            VLM0135,
            /// <summary>
            /// Remain Qty  cannot be empty.
            /// </summary>
            VLM0136,
            /// <summary>
            /// Status cannot be empty.
            /// </summary>
            VLM0137,
            /// <summary>
            /// Please complete data records.
            /// </summary>
            VLM0138,
            /// <summary>
            /// No. of month cannot be greater than 120.
            /// </summary>
            VLM0139,
            /// <summary>
            /// 'Has no data in selected period ,Return to nearest period.'
            /// </summary>
            VLM0140,
            /// <summary>
            /// Cannot delete purchase order with status is finish.
            /// </summary>
            VLM0141,
            /// <summary>
            /// Has no Purchase order Detail in this Purchase Order
            /// </summary>
            VLM0142,
            /// <summary>
            /// Yield Rate cannot be empty or zero.
            /// </summary>
            VLM0144,
            /// <summary>
            /// Leadtime cannot be empty or zero.
            /// </summary>
            VLM0145,
            /// <summary>
            /// MRP Flag cannot be empty.
            /// </summary>
            VLM0146,
            /// <summary>
            /// Order condition cannot be empty.
            /// </summary>
            VLM0147,
            /// <summary>
            /// Reorder Point must more than or equal Safety Stock.
            /// </summary>
            VLM0148,
            /// <summary>
            /// Reorder Point cannot be empty..
            /// </summary>
            VLM0149,
            /// <summary>
            /// Safty Stock cannot be empty.
            /// </summary>
            VLM0150,
            /// <summary>
            /// Cannot save without data.
            /// </summary>
            VLM0151,
            /// <summary>
            /// Cannot input duplicate Master No.
            /// </summary>
            VLM0152,
        }

        /// <summary>
        /// Message about confirmation.
        /// </summary>
        public enum eConfirm
        {
            /// <summary>
            /// Do you to save ? 
            /// </summary>
            CFM9001,
            /// <summary>
            /// Do you to delete ? 
            /// </summary>
            CFM9002,
            /// <summary>
            /// Do you to cancel ?
            /// </summary>
            CFM9003,
            /// <summary>
            /// Do you want to import screen ?
            /// </summary>
            CFM9004,
            /// <summary>
            /// Do you want to clear screen data ?
            /// </summary>
            CFM9005,
            /// <summary>
            /// Do you want to clear unnecessary data ?
            /// </summary>
            CFM9006,
            /// <summary>
            /// Do you want to close with out save data?
            /// </summary>  
            CFM9007,
            /// <summary>
            /// Do you want to run Pre-Process for Stock Taking ?
            /// </summary>           
            CFM9008,
            /// <summary>
            /// Do you want to run Update Process for Stock Taking ?
            /// </summary>           
            CFM9009,
            /// <summary>
            /// Stock taking on {0} has already run. Would you like to replace exists data?
            /// </summary>           
            CFM9010,
            /// <summary>
            /// Do you want to Import selected screen(s) ?
            /// </summary>
            CFM9011,
            /// <summary>
            /// Do you want to Generate Working Calendar ?
            /// </summary>
            CFM9012,
            /// <summary>
            /// Has no data do you want to edit?
            /// </summary>
            CFM9013,
            /// <summary>
            /// Do you want to cancel PO ?
            /// </summary>
            CFM9014,
            /// <summary>
            /// Do you want to open file now ?
            /// </summary>
            CFM9015,
        }

        /// <summary>
        /// Message about information
        /// </summary>
        public enum eInformation
        {
            /// <summary>
            /// Import screen complete.
            /// </summary>
            INF9001,
            /// <summary>
            /// Clear screen complete.
            /// </summary>
            INF9002,

            /// <summary>
            /// Process Complete.
            /// </summary>
            INF9003,

            /// <summary>
            /// You don't have permission to view this screen.
            /// </summary>
            INF9004,

            /// <summary>
            /// You don't have permission to view this screen.
            /// </summary>
            INF9005,
            /// <summary>
            /// Save file complete.
            /// </summary>
            INF0006,
        }
    }
}
