using FarPoint.Win.Spread.CellType;
using System;
using EVOFramework.Data;


namespace EVOFramework.Windows.Forms
{
    /// <summary>
    /// This CellType represents to spread cell type.
    ///  How to use:  Use like ComboBoxCellType.
    /// </summary>
    public class ReadOnlyPairCellType : TextCellType
    {
        #region Variables
        private string[] _itemData = null;
        private string[] _items = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Custom own formatting string.
        /// </summary>
        public ReadOnlyPairCellType() { }

        /// <summary>
        /// Use default pattern formatting string.
        /// <para>Pattern: [VALUE][SEPERATOR][DISPLAY STRING]</para>
        /// <para>Example: "01 : My Value."</para>
        /// </summary>
        /// <param name="lookupData"></param>
        /// <param name="seperator"></param>
        public ReadOnlyPairCellType(LookupData lookupData, string seperator) : this(lookupData, seperator, true) { }

        /// <summary>
        /// Use default pattern formatting string.
        /// <para>Pattern: [VALUE][SEPERATOR][DISPLAY STRING]</para>
        /// <para>Example: "01 : My Value."</para>
        /// </summary>
        /// <param name="lookupData"></param>
        /// <param name="seperator"></param>
        /// <param name="showValue">If true will use default pattern. Otherwise display data without value and seperator.</param>
        public ReadOnlyPairCellType(LookupData lookupData, string seperator, bool showValue)
        {
            int rowCount = lookupData.DataSource.Rows.Count;

            _itemData = new string[rowCount];
            _items = new string[rowCount];

            for (int i = 0; i < rowCount; i++)
            {
                _itemData[i] = lookupData.DataSource.Rows[i][lookupData.ValueMember].ToString();
                if (showValue)
                {

                    if (null != lookupData.DataSource.Rows[i][lookupData.DisplayMember]
                        && DBNull.Value != lookupData.DataSource.Rows[i][lookupData.DisplayMember]
                        && "" != Convert.ToString(lookupData.DataSource.Rows[i][lookupData.DisplayMember]))
                    {
                        _items[i] = String.Format("{0}{1}{2}",
                                                  _itemData[i],
                                                  seperator,
                                                  lookupData.DataSource.Rows[i][lookupData.DisplayMember]);
                    }
                    else
                    {
                        _items[i] = _itemData[i];
                    }
                }
                else
                {
                    _items[i] = lookupData.DataSource.Rows[i][lookupData.DisplayMember].ToString();
                }
            }
        }

        #endregion

        #region Properties
        /// <summary>
        /// Get or set ItemData value.
        /// </summary>
        public string[] ItemData
        {
            get { return _itemData; }
            set { _itemData = value; }
        }
        /// <summary>
        /// Get or set Items to display.
        /// </summary>
        public string[] Items
        {
            get { return _items; }
            set { _items = value; }
        }
        #endregion

        #region Overriden methods
        public override void PaintCell(System.Drawing.Graphics g, System.Drawing.Rectangle r, FarPoint.Win.Spread.Appearance appearance, object value, bool isSelected, bool isLocked, float zoomFactor)
        {
            if (value != null && value != DBNull.Value)
            {
                string strValue = value.ToString();
                for (int i = 0; i < ItemData.Length; i++)
                {
                    if (ItemData[i] == strValue)
                    {
                        base.PaintCell(g, r, appearance, Items[i], isSelected, isLocked, zoomFactor);
                        return;
                    }
                }
                base.PaintCell(g, r, appearance, value, isSelected, isLocked, zoomFactor);
            }
            else
            {
                base.PaintCell(g, r, appearance, value, isSelected, isLocked, zoomFactor);
            }
        }
        #endregion
    }
}
