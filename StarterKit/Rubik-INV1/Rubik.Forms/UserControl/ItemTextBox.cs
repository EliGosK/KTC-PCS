using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVOFramework.Windows.Forms;
using Rubik.UserControl;
using System.ComponentModel;
using EVOFramework;
using Rubik.Validators;
using System.Windows.Forms;
using Rubik.BIZ;
using Rubik.DTO;
using Rubik.Forms.FindDialog;
using Rubik.UIDataModel;
using System.Reflection;


namespace Rubik.Forms.UserControl
{
    public delegate void ItemFoundHandler(object sender, bool isFound, NZString ItemCD);

    public class ItemTextBox : EVONumericTextBox
    {
        #region Variables
        /// <summary>
        /// SQL Operator
        /// </summary>
        private eSqlOperator m_sqlOperator = eSqlOperator.In;
        /// <summary>
        /// Store ItemType that need to find.
        /// </summary>
        private eItemType[] m_itemType;
        /// <summary>
        /// TextBox that used to display item description.
        /// </summary>
        private EVOTextBox m_descriptionTextBox = null;
        private EVOTextBox m_customernameTextBox = null;
        /// <summary>
        /// Button that used to enter item find dialog.
        /// </summary>
        private EVOButton m_evoHelpButton = null;


        private bool m_bChooseItem = false;
        #endregion



        #region Constructor
        public ItemTextBox()
        {
            KeyPress += ItemTextBox_KeyPress;
            KeyDown += ItemTextBox_KeyDown;
            Validating += new CancelEventHandler(ItemTextBox_Validating);
            MaxLength = 10;
            CharacterCasing = CharacterCasing.Upper;
            CommonLib.FormatUtil.SetNumberFormat(this, CommonLib.FormatUtil.eNumberFormat.MasterNo);
        }



        #endregion

        #region Event
        [Category(CR.CATEGORY)]
        public event ItemFoundHandler KeyPressResult;
        #endregion

        #region Properties
        /// <summary>
        /// เก็บค่า DTO ของ Item ที่ได้เลือกไปแล้ว
        /// </summary>
        public ItemDTO SelectedItemData { get; set; }
        /// <summary>
        /// เก็บค่า DTO ของ Item process ของ Item ที่ได้เลือกไปแล้ว
        /// </summary>
        public ItemProcessDTO SelectedItemProcessData { get; set; }
        /// <summary>
        /// เก็บค่า DTO ของ Dealing ของ Item ที่ได้เลือกไปแล้ว
        /// </summary>
        public DealingDTO SelectedCustomerData { get; set; }

        [Category(CR.CATEGORY)]
        public eItemType[] ItemType
        {
            get { return m_itemType; }
            set { m_itemType = value; }
        }
        [Category(CR.CATEGORY)]
        public EVOTextBox DescriptionTextBox
        {
            get { return m_descriptionTextBox; }
            set { m_descriptionTextBox = value; }
        }
        [Category(CR.CATEGORY)]
        public EVOTextBox CustomerNameTextBox
        {
            get { return m_customernameTextBox; }
            set { m_customernameTextBox = value; }
        }
        [Category(CR.CATEGORY)]
        public EVOButton HelpButton
        {
            get { return m_evoHelpButton; }
            set
            {
                m_evoHelpButton = value;
                if (m_evoHelpButton != null)
                {
                    m_evoHelpButton.Click += HelpButton_Click;

                }
            }
        }
        [Category(CR.CATEGORY)]
        public bool CheckEmpty { get; set; }
        [Category(CR.CATEGORY)]
        public bool CheckExist { get; set; }
        [Category(CR.CATEGORY)]
        public bool CheckNotExist { get; set; }

        public string CustomerCode { get; set; }
        /// <summary>
        /// เงื่อนไขที่จะใช้ค้นหา
        /// Recommend to use two operator are 'In' and 'NotIn' Only!!
        /// </summary>
        [Category(CR.CATEGORY)]
        [Description("Recommend to use two operator are 'In' and 'NotIn' Only!!")]
        public eSqlOperator SqlOperator
        {
            get { return m_sqlOperator; }
            set { m_sqlOperator = value; }
        }

        public bool IsSelected
        {
            get
            {
                bool bTmp = m_bChooseItem;
                m_bChooseItem = false;
                return bTmp;
            }
        }

        public NZString ToNZString()
        {
            return new NZString(this, this.Text);
        }

        public override object PathValue
        {
            get
            {
                return this.Text;
            }
            set
            {
                if (value == null || value == DBNull.Value)
                {
                    base.PathValue = "";
                    return;
                }
                base.PathValue = value;
            }
        }

        #endregion

        #region Methods
        public string GetItemDescription(NZString ItemCD)
        {
            ItemBIZ bizItem = new ItemBIZ();
            ItemDTO dtoItem = bizItem.LoadItem(ItemCD);

            ItemProcessDTO dtoItemProcess = bizItem.LoadItemProcess(ItemCD);

            if (dtoItem == null || dtoItem.SHORT_NAME.IsNull)
                return string.Empty;

            SelectedItemData = dtoItem;
            SelectedItemProcessData = dtoItemProcess;

            return dtoItem.SHORT_NAME.StrongValue;
        }
        public string GetCustomerData(NZString ItemCD)
        {
            ItemBIZ bizItem = new ItemBIZ();
            ItemDTO dtoItem = bizItem.LoadItem(ItemCD);

            if (dtoItem == null || dtoItem.ITEM_DESC.IsNull)
                return string.Empty;

            //get customer
            DealingBIZ bizCust = new DealingBIZ();
            DealingDTO dtoCust = bizCust.LoadLocation(dtoItem.CUSTOMER_CD);

            if (dtoCust == null || dtoCust.LOC_DESC.IsNull)
                return string.Empty;

            SelectedCustomerData = dtoCust;

            return dtoCust.LOC_DESC.StrongValue;
        }

        private bool Validate()
        {
            try
            {
                ItemValidator valItem = new ItemValidator();
                NZString ItemCD = new NZString(this, Text);
                ErrorItem errorItem = null;

                string[] strItemTypes = null;
                //if (ItemType != null && ItemType.Length > 0)
                //{
                //    if (ItemType.Length == 1 && ItemType[0] == eItemType.All)
                //    {
                //        strItemTypes = new string[] { "01", "02", "03", "04" };
                //    }
                //    else
                //    {
                //        strItemTypes = new string[ItemType.Length];
                //        for (int i = 0; i < ItemType.Length; i++)
                //        {
                //            strItemTypes[i] = string.Format("{0:00}", (int)ItemType[i]);
                //        }
                //    }
                //}

                if (CheckEmpty)
                {
                    errorItem = valItem.CheckEmptyItemCode(ItemCD);
                }
                if (CheckExist)
                {
                    ValidateException.ThrowErrorItem(valItem.CheckExistWithItemType(ItemCD, SqlOperator, strItemTypes));
                }
                if (CheckNotExist)
                {
                    ValidateException.ThrowErrorItem(valItem.CheckNotExistWithItemType(ItemCD, SqlOperator, strItemTypes));
                    //BusinessException businessException = valItem.CheckItemNotExist(ItemCD);
                    //if (businessException != null)
                    //{
                    //    throw businessException;
                    //}
                }


                if (CustomerCode != null && !"".Equals(CustomerCode))
                {
                    ValidateException.ThrowErrorItem(valItem.CheckItemByCustomer(ItemCD, CustomerCode.ToNZString()));
                }

                if (null != errorItem) ValidateException.ThrowErrorItem(errorItem);


            }
            catch (ValidateException err)
            {
                for (int i = 0; i < err.ErrorResults.Count; i++)
                {
                    MessageDialog.ShowBusiness(this.FindForm(), err.ErrorResults[i].Message);
                    err.ErrorResults[i].FocusOnControl();
                }
                return false;
            }
            catch (BusinessException err)
            {
                MessageDialog.ShowBusiness(this.FindForm(), err.Error.Message);
                err.Error.FocusOnControl();
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness(this.FindForm(), ex.Message);
                return false;
            }
            return true;
        }

        #endregion

        #region Control event
        void ItemTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && !ReadOnly) HelpButton_Click(this, new EventArgs());
        }

        public void HelpButton_Click(object sender, EventArgs e)
        {
            // show find dialog

            ItemFindDialog fdItem = null;

            if (CustomerCode != null && !"".Equals(CustomerCode))
            {
                fdItem = new ItemFindDialog(m_sqlOperator, ItemType, (NZString)CustomerCode, DataDefine.eDealingType.Customer);
            }
            else
            {
                fdItem = new ItemFindDialog(m_sqlOperator, ItemType);
            }
            fdItem.ShowDialog();
            if (fdItem.IsSelected)
            {
                Text = fdItem.SelectedItem.ITEM_CD.StrongValue;
                if (DescriptionTextBox != null)
                    DescriptionTextBox.Text = GetItemDescription(fdItem.SelectedItem.ITEM_CD);
                if (CustomerNameTextBox != null)
                    CustomerNameTextBox.Text = GetCustomerData(fdItem.SelectedItem.ITEM_CD);

                m_bChooseItem = true;
            }
            else
            {
                //if (DescriptionTextBox != null)
                //{
                //    DescriptionTextBox.Text = string.Empty;
                //    SelectedItemData = null;
                //    SelectedItemProcessData = null;
                //}
                //if (CustomerNameTextBox != null)
                //    CustomerNameTextBox.Text = string.Empty;

                m_bChooseItem = false;
            }
            Focus();
        }


        public void ItemTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != (char)Keys.Return || ReadOnly) return;

            NZString ItemCD = new NZString(this, Text);

            // validate before do something
            if (Validate())
            {
                // if item exist then load description to DescriptionTextBox
                if (DescriptionTextBox != null)
                    DescriptionTextBox.Text = GetItemDescription(ItemCD);
                if (CustomerNameTextBox != null)
                    CustomerNameTextBox.Text = GetCustomerData(ItemCD);

                m_bChooseItem = true;

                if (KeyPressResult != null)
                    KeyPressResult(this, true, ItemCD);
            }
            else
            {
                e.Handled = true;

                if (DescriptionTextBox != null)
                    DescriptionTextBox.Text = string.Empty;
                if (CustomerNameTextBox != null)
                    CustomerNameTextBox.Text = string.Empty;

                SelectedItemData = null;
                SelectedItemProcessData = null;
                SelectedCustomerData = null;

                if (KeyPressResult != null)
                    KeyPressResult(this, false, ItemCD);
            }
        }



        void ItemTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (this.Text.Trim().Equals(""))
                return;



            NZString ItemCD = new NZString(this, Text);

            // validate before do something
            if (Validate())
            {
                // if item exist then load description to DescriptionTextBox
                if (DescriptionTextBox != null)
                    DescriptionTextBox.Text = GetItemDescription(ItemCD);
                if (CustomerNameTextBox != null)
                    CustomerNameTextBox.Text = GetCustomerData(ItemCD);

                Int32 iMasterNo = 0;

                if (Int32.TryParse(Text, out iMasterNo))
                {
                    Int = iMasterNo;
                }

                m_bChooseItem = true;

                if (KeyPressResult != null)
                    KeyPressResult(this, true, ItemCD);
            }
            else
            {
                e.Cancel = true;

                if (DescriptionTextBox != null)
                    DescriptionTextBox.Text = string.Empty;
                if (CustomerNameTextBox != null)
                    CustomerNameTextBox.Text = string.Empty;

                SelectedItemData = null;
                SelectedItemProcessData = null;
                SelectedCustomerData = null;

                if (KeyPressResult != null)
                    KeyPressResult(this, false, ItemCD);
            }
        }

        #endregion




    }
}
