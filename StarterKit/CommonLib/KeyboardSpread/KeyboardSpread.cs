using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using Action=FarPoint.Win.Spread.Action;

namespace CommonLib
{
    /// <summary>
    /// คลาสช่วยสำหรับจัดการเรื่องคีย์ ที่ต้องใช้บน Spread  ตาม Standard convention.
    /// </summary>
    public class KeyboardSpread
    {
        /* 
         * Standard KeyStroke:
         * ==============
         *   CTRL + INS :: Add new row.
         *   CTRL + DEL :: Remove selected row.
         *   F2 (obsolute), use ENTER Key :: Being edit cell.
         *   ESC :: Cancel editing cell.
         *   TAB :: Move next cell.
         *   F5 :: Show Find Dialog.
         *   
         * */

        #region Enum
        public enum eAction {
            AddRow,
            RemoveRow,

        }
        #endregion

        #region Variables

        private readonly FpSpread m_owner = null;

        /// <summary>
        /// Flag indicate that binded.
        /// </summary>
        private bool m_bBind = false;
        #endregion

        #region Delegate

        public delegate void RowAddingHandler(object sender, EventRowAdding e);
        public delegate void RowRemovingHandler(object sender, EventRowRemoving e);

        public delegate void RowAddedHandler(object sender, int rowIndex);
        public delegate void RowRemovedHandler(object sender);

        public delegate void KeyPressF5Handler(object sender, int rowIndex, int colIndex);
        #endregion

        #region Events
        //RowAdding
        //RowAdded
        //RowRemoving
        //RowRemoved
        //KeyPressF5
        public event RowAddingHandler RowAdding;
        public event RowAddedHandler RowAdded;
        public event RowRemovingHandler RowRemoving;
        public event RowRemovedHandler RowRemoved;
        public event KeyPressF5Handler KeyPressF5;
        #endregion

        #region Constructor
        public KeyboardSpread(FpSpread view) {
            m_owner = view;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get owner spread.
        /// </summary>
        public FpSpread Owner {
            get { return m_owner; }
        }

        /// <summary>
        /// Check that spread has bind standard keyboard.
        /// </summary>
        public bool IsBinded {
            get { return m_bBind; }
        }
        #endregion

        #region private Action method
        /// <summary>
        /// Action สำหรับเพิ่ม Row ใหม่
        /// </summary>
        /// <param name="sender"></param>
        void actionAddNewRow_Action(object sender)
        {
           
           
            if (sender is SpreadView)
            {                 
                SpreadView view = (SpreadView)sender;
                int sheetIndex = view.ActiveSheetIndex;
                if (sheetIndex < 0)
                {
                    return;
                }

                if (RowAdding != null) {
                     EventRowAdding eArg = new EventRowAdding();
                     RowAdding(this, eArg);
                     if (eArg.Cancel)
                         return;
                 }

                SheetView sheet = view.Sheets[sheetIndex];
                if (sheet.RowCount == 0)
                { // ถ้าไม่ซักแถว
                    sheet.AddRows(0, 1);
                    sheet.SetActiveCell(sheet.RowCount - 1, 1, true);
                    sheet.SetActiveCell(sheet.RowCount - 1, 0, true);
                }
                else
                {
                    // เช็คดูก่อนว่าแถวสุดท้าย ว่างหรือไม่ ??
                    int lastRowNonEmpty = sheet.GetLastNonEmptyRow(NonEmptyItemFlag.Data);
                    if (lastRowNonEmpty == sheet.RowCount - 1)
                    {  // ถ้าแถวสุดท้ายไม่ว่าง ก็เพิ่มแถวได้เลย
                        // Add new row.
                        sheet.AddRows(sheet.RowCount, 1);
                    }
                    
                    sheet.SetActiveCell(sheet.RowCount - 1, 0, true);
                    view.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                }

                if (RowAdded != null)
                    RowAdded(this, sheet.RowCount - 1);
            }
        }
        /// <summary>
        /// Action สำหรับลบแถว
        /// </summary>
        /// <param name="sender"></param>
        void actionRemoveRow_Action(object sender)
        {
            if (sender is SpreadView)
            {
                SpreadView view = (SpreadView)sender;
                int sheetIndex = view.ActiveSheetIndex;
                if (sheetIndex < 0)
                {
                    return;
                }

                
                SheetView sheet = view.Sheets[sheetIndex];

                if (sheet.RowCount <= 0 || sheet.ActiveRowIndex < 0)
                    return;

                if (RowRemoving != null) {
                     EventRowRemoving eArg = new EventRowRemoving();
                    eArg.RowIndex = sheet.ActiveRowIndex;

                     RowRemoving(this, eArg);
                     if (eArg.Cancel)
                         return;
                 }

                sheet.RemoveRows(sheet.ActiveRowIndex, 1);

                if (RowRemoved != null)
                    RowRemoved(this);
            }
        }

        /// <summary>
        /// Action สำหรับกดปุ่ม F5 บน Cell เพื่อแสดง Find Dialog.
        /// </summary>
        /// <param name="sender"></param>
        void actionF5_Action(object sender)
        {
            if (sender is SpreadView)
            {
                if (KeyPressF5 != null) {
                    SpreadView view = (SpreadView) sender;
                    SheetView sheet = view.Sheets[view.ActiveSheetIndex];
                    KeyPressF5(this, sheet.ActiveRowIndex, sheet.ActiveColumnIndex);
                }
            }
        }
        #endregion

        #region Private method

        #endregion

        #region Protected method
        #endregion

        #region Public method
        public void StartBind() {
            //== Prepare Keystroke
            Keystroke CtrlIns = new Keystroke(Keys.Insert, Keys.Control);
            Keystroke CtrlDel = new Keystroke(Keys.Delete, Keys.Control);
            Keystroke F2 = new Keystroke(Keys.F2, Keys.None);
            Keystroke F5 = new Keystroke(Keys.F5, Keys.None);                        
            Keystroke Enter = new Keystroke(Keys.Enter, Keys.None);
            //Keystroke Esc = new Keystroke(Keys.Escape, Keys.None);

            //== Prepare action.
            ActionEvent actionAddNewRow = new ActionEvent();
            actionAddNewRow.Action += actionAddNewRow_Action;

            ActionEvent actionRemoveRow = new ActionEvent();
            actionRemoveRow.Action += actionRemoveRow_Action;

            ActionEvent actionF5 = new ActionEvent();
            actionF5.Action += actionF5_Action;

           //ActionEvent actionEsc = new ActionEvent();
            //actionEsc.Action += actionEsc_Action;
            
            
            //== Start bind keystroke and action.
            InputMap im = m_owner.GetInputMap(InputMapMode.WhenFocused);
            InputMap imx = m_owner.GetInputMap(InputMapMode.WhenAncestorOfFocused);

            ActionMap am = m_owner.GetActionMap();

            im.Put(CtrlIns, eAction.AddRow.ToString());
            im.Put(CtrlDel, eAction.RemoveRow.ToString());
            im.Put(F2, SpreadActions.StopEditing);
            im.Put(F5, "F5");
            im.Put(Enter, SpreadActions.StartEditing);
            
            //imx.Put(Esc, "Esc");

            am.Put(eAction.AddRow.ToString(), actionAddNewRow);
            am.Put(eAction.RemoveRow.ToString(), actionRemoveRow);
            am.Put("F5", actionF5);
           //am.Put("Esc", actionEsc);


            m_bBind = true;
        }

        /// <summary>
        /// Add new row
        /// </summary>        
        public void OnActionAddNewRow()
        {
            if (!m_bBind)
                return;

            SpreadView spView = null;
            if ((m_owner as FpSpread) != null)
            {
                spView = m_owner.GetRootWorkbook();
                
            }

            actionAddNewRow_Action(spView);
        }

        public void OnActionRemoveRow()
        {
            if (!m_bBind)
                return;

            SpreadView spView = null;
            if ((m_owner as FpSpread) != null)
            {
                spView = m_owner.GetRootWorkbook();

            }
            actionRemoveRow_Action(spView);
        }
        #endregion


        #region Action nested class

        private class ActionEvent : Action {
            public delegate void ActionHandler(object sender);

            public event ActionHandler Action;


            #region Overrides of Action

            public override void PerformAction(object sender) {
                if (Action != null)
                    Action(sender);
            }

            #endregion
        }
        
        #endregion
    }

    #region Event Arguments
    public class EventRowAdding : EventArgs {
        private bool m_bCancel = false;


        public bool Cancel {
            get { return m_bCancel; }
            set { m_bCancel = value; }
        }
    }
    public class EventRowRemoving : EventArgs {
        private bool m_bCancel = false;
        private int m_rowIndex = -1;


        public bool Cancel {
            get { return m_bCancel; }
            set { m_bCancel = value; }
        }

        public int RowIndex {
            get { return m_rowIndex; }
            set { m_rowIndex = value; }
        }
    }
    #endregion
}
