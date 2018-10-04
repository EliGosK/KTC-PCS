/* Create by: Mr. Teerayut Sinlan
 * Create on: 2009-08-31
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using EVOFramework.Windows.Forms;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;

/* Control ที่มีผลบังคับใช้กับ Domain ประกอบด้วย
 * 1. TextBox
 * 2. RadioButton
 * 3. CheckBox
 * 4. ComboBox
 * 5. ListBox
 * 6. Spread
 * 
 * Control เหล่านี้จะต้อง Implememnt interface IDomainSupport ก่อนจึงจะสามารถนำมาใช้งานได้
 * */
namespace EVOFramework.Data
{
    /// <summary>
    /// Domain controller. Manage about domain value and mapping to UI.
    /// </summary>
    public class UIDataModelController : Component
    {
        #region Variables
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// List of domain which support get and set value.
        /// </summary>
        private readonly List<IUIDataModelSupport> m_listControlDomainSupport = new List<IUIDataModelSupport>();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public UIDataModelController(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion

        #region Dispose
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Add / Remove Domain
        /// <summary>
        /// Add an object to the last of list.
        /// </summary>
        /// <param name="domainSupport">Object which implement interface IDomainSupport</param>
        public void AddControl(IUIDataModelSupport domainSupport)
        {
            ListDomainSupport.Add(domainSupport);
        }

        /// <summary>
        /// Add a multiple object to the last of list.
        /// </summary>
        /// <param name="domainSupports"></param>
        /// <exception cref="ArgumentNullException"><c>domainSupports</c> is null.</exception>
        public void AddRangeControl(params IUIDataModelSupport[] domainSupports)
        {
            if (domainSupports == null)
                throw new ArgumentNullException("domainSupports", "Argument is null.");

            for (int i = 0; i < domainSupports.Length; i++)
            {
                ListDomainSupport.Add(domainSupports[i]);
            }
        }

        /// <summary>
        /// Insert an element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="domainSupport">The object to insert</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index is less than 0.-or-index is greater than <see cref="P:System.Collections.Generic.List`1.Count" />.</exception>
        public void InsertControl(int index, IUIDataModelSupport domainSupport)
        {
            ListDomainSupport.Insert(index, domainSupport);
        }

        /// <summary>
        /// Remove the first occurence of a specific object.
        /// </summary>
        /// <param name="domainSupport">The object to remove</param>
        public void RemoveControl(IUIDataModelSupport domainSupport)
        {
            ListDomainSupport.Remove(domainSupport);
        }

        /// <summary>
        /// Removes the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException"><c>ArgumentOutOfRangeException</c>.</exception>
        public void RemoveControlAt(int index)
        {
            ListDomainSupport.RemoveAt(index);
        }

        #endregion

        #region Forward domain to UI
        /// <summary>
        /// Load data from Domain to UI
        /// </summary>
        /// <param name="data"></param>
        public void LoadData(IUIDataModel data)
        {

            List<string> listRadioGroup = new List<string>();
            for (int i = 0; i < ListDomainSupport.Count; i++)
            {
                if (ListDomainSupport[i].PathString == null || ListDomainSupport[i].PathString == String.Empty)
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("UI Model has empty path on object: \"{0}\"", ListDomainSupport[i].GetType().Name));
                    continue;
                }

                object objValue = GetValueDomainFromPath(ListDomainSupport[i].PathString, data);


                if (ListDomainSupport[i] is EVORadioButton)
                {
                    // Check duplicate.
                    if (listRadioGroup.Contains(ListDomainSupport[i].PathString))
                        continue;

                    // Otherwise will add into list.
                    for (int iControl = i; iControl < ListDomainSupport.Count; iControl++)
                    {
                        if (ListDomainSupport[iControl] is EVORadioButton)
                        {

                            EVORadioButton radioButton = (EVORadioButton)ListDomainSupport[iControl];

                            // if element in loop is equal property value on path.
                            if (object.Equals(radioButton.SpecificValue, objValue))
                            {
                                radioButton.Checked = true;
                                break;
                            }
                        }
                    }

                    listRadioGroup.Add(ListDomainSupport[i].PathString);

                }
                else if (ListDomainSupport[i] is EVOCheckBox)
                {
                    // Check duplicate.
                    if (listRadioGroup.Contains(ListDomainSupport[i].PathString))
                        continue;

                    // Otherwise will add into list.
                    for (int iControl = i; iControl < ListDomainSupport.Count; iControl++)
                    {
                        if (ListDomainSupport[iControl] is EVOCheckBox)
                        {

                            EVOCheckBox chkBox = (EVOCheckBox)ListDomainSupport[iControl];

                            // if element in loop is equal property value on path.
                            if (object.Equals(chkBox.CheckedValue, objValue.ToString()))
                            {
                                chkBox.Checked = true;
                                break;
                            }
                            else
                            {
                                chkBox.Checked = false;
                                break;
                            }
                        }
                    }

                    listRadioGroup.Add(ListDomainSupport[i].PathString);

                }
                else
                {  // General control editor.

                    ListDomainSupport[i].PathValue = objValue;

                }


            }
        }
        #endregion

        #region Backward UI to domain
        /// <summary>
        /// Save data from UI to domain
        /// </summary>
        /// <typeparam name="T">Type of class which will store data.</typeparam>
        /// <param name="data">Instance of class which will store data.</param>
        /// <returns>Return class which has stored data.</returns>
        public T SaveData<T>(T data) where T : IUIDataModel
        {
            List<string> listRadioGroup = new List<string>();

            for (int i = 0; i < ListDomainSupport.Count; i++)
            {
                if (String.IsNullOrEmpty(ListDomainSupport[i].PathString))
                    continue;

                if (ListDomainSupport[i] is EVORadioButton)
                {
                    if (listRadioGroup.Contains(ListDomainSupport[i].PathString))
                        continue;

                    // Otherwise will add into list.
                    for (int iControl = i; iControl < ListDomainSupport.Count; iControl++)
                    {
                        EVORadioButton radioButton = (EVORadioButton)ListDomainSupport[iControl];
                        if (radioButton.PathString == ListDomainSupport[iControl].PathString)
                        {
                            if (radioButton.Checked)
                            {
                                SetValueIntoDomain(ListDomainSupport[iControl], data, radioButton.SpecificValue);
                                break;
                            }
                        }
                    }
                    listRadioGroup.Add(ListDomainSupport[i].PathString);
                }
                // ADD BY JESSADA C.
                else if (ListDomainSupport[i] is EVOCheckBox)
                {
                    if (listRadioGroup.Contains(ListDomainSupport[i].PathString))
                        continue;

                    // Otherwise will add into list.
                    for (int iControl = i; iControl < ListDomainSupport.Count; iControl++)
                    {
                        EVOCheckBox chkBox = (EVOCheckBox)ListDomainSupport[iControl];
                        if (chkBox.PathString == ListDomainSupport[iControl].PathString)
                        {
                            if (chkBox.Checked)
                            {
                                SetValueIntoDomain(ListDomainSupport[iControl], data, chkBox.CheckedValue);
                                break;
                            }
                            else
                            {
                                SetValueIntoDomain(ListDomainSupport[iControl], data, chkBox.UnCheckedValue);
                                break;
                            }
                        }
                    }
                    listRadioGroup.Add(ListDomainSupport[i].PathString);
                }
                // END ADD ----------------------
                else
                {
                    SetValueIntoDomain(ListDomainSupport[i], data, ListDomainSupport[i].PathValue);
                }
            }

            return data;
        }
        #endregion

        #region Reflection Method Helper
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"><c>ApplicationException</c>.</exception>
        private object GetValueDomainFromPath(string path, IUIDataModel data)
        {
            //string domainName = ExtractDomainName(path);
            string[] nestedPropertyNames = ExtractNestedPropertyName(path);
            string resutlPropertyName = ExtractResultPropertyName(path);

            // ค้นหาทุกๆ Nested Property เพื่อทำการ Get
            object objLastNestedProperty = data;
            if (nestedPropertyNames != null)
            {
                for (int i = 0; i < nestedPropertyNames.Length; i++)
                {
                    Type typeProperty = objLastNestedProperty.GetType();
                    PropertyInfo propInfo = typeProperty.GetProperty(nestedPropertyNames[i]);
                    if (propInfo == null)
                    {
                        throw new ApplicationException(String.Format("Not found property \"{0}\" on path: \"{1}\"", nestedPropertyNames[i], path));
                    }

                    if (!propInfo.CanRead)
                    {
                        throw new ApplicationException(String.Format("path: \"{0}\", cannot access property name \"{1}\"", path, nestedPropertyNames[i]));
                    }
                    objLastNestedProperty = propInfo.GetGetMethod().Invoke(objLastNestedProperty, null);
                }
            }

            // ค้นหา Result Property เพื่อทำการ get object

            Type typeObject = objLastNestedProperty.GetType();
            PropertyInfo propResultInfo = typeObject.GetProperty(resutlPropertyName);
            if (propResultInfo == null)
                throw new ApplicationException(String.Format("Not found property \"{0}\" on path: \"{1}\"", resutlPropertyName, path));

            if (!propResultInfo.CanRead)
            {
                throw new ApplicationException(String.Format("path: \"{0}\", cannot access property name \"{1}\"", path, resutlPropertyName));
            }

            return propResultInfo.GetValue(objLastNestedProperty, null);
        }

        /// <summary>
        /// Set value to domain
        /// </summary>
        /// <param name="domainSupport"></param>
        /// <param name="data"></param>
        /// <param name="value"></param>
        /// <exception cref="ApplicationException"><c>ApplicationException</c>.</exception>
        private void SetValueIntoDomain(IUIDataModelSupport domainSupport, IUIDataModel data, object value)
        {
            string path = domainSupport.PathString;

            //string domainName = ExtractDomainName(path);
            string[] nestedPropertyNames = ExtractNestedPropertyName(path);
            string resutlPropertyName = ExtractResultPropertyName(path);

            // ค้นหาทุกๆ Nested Property เพื่อทำการ Get
            object objLastNestedProperty = data;

            if (nestedPropertyNames != null)
            {
                for (int i = 0; i < nestedPropertyNames.Length; i++)
                {
                    Type typeProperty = objLastNestedProperty.GetType();
                    PropertyInfo propInfo = typeProperty.GetProperty(nestedPropertyNames[i]);
                    if (propInfo == null)
                    {
                        throw new ApplicationException(String.Format("Not found property \"{0}\" on path: \"{1}\"", nestedPropertyNames[i], path));
                    }

                    if (!propInfo.CanRead)
                    {
                        throw new ApplicationException(String.Format("path: \"{0}\", cannot access property name \"{1}\"", path, nestedPropertyNames[i]));
                    }
                    objLastNestedProperty = propInfo.GetGetMethod().Invoke(objLastNestedProperty, null);
                }
            }

            // ค้นหา Result Property เพื่อทำการ get object

            Type typeObject = objLastNestedProperty.GetType();
            PropertyInfo propResultInfo = typeObject.GetProperty(resutlPropertyName);
            if (propResultInfo == null)
                throw new ApplicationException(String.Format("Not found property \"{0}\" on path: \"{1}\"", resutlPropertyName, path));

            if (!propResultInfo.CanWrite)
            {
                throw new ApplicationException(String.Format("path: \"{0}\", cannot access property name \"{1}\"", path, resutlPropertyName));
            }

            if (objLastNestedProperty is NZBaseObject)
            {
                ((NZBaseObject)objLastNestedProperty).Owner = domainSupport;
            }

            propResultInfo.SetValue(objLastNestedProperty, value, null);
        }
        #endregion

        #region Lexcial Analyze
        /// <summary>
        /// Delimit symbol.
        /// </summary>
        private const char DELIMIT_SYMBOL = '.';

        /// <summary>
        /// Extract nested property name. If not found nested property name will return null.
        /// </summary>
        /// <param name="path">full path.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><c>ArgumentException</c>.</exception>
        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        internal string[] ExtractNestedPropertyName(string path)
        {
            if (path == null || path.Trim() == string.Empty)
                throw new ArgumentNullException("path", "PathValue is blank.");

            string[] strWords = path.Split(DELIMIT_SYMBOL);
            if (strWords.Length == 1)
                return null;

            if (strWords.Length > 1)
            {

                string[] strReturn = new string[strWords.Length - 1];  // except first and last word.
                for (int i = 0; i < strWords.Length - 1; i++)
                {
                    strReturn[i] = strWords[i];
                }
                return strReturn;
            }

            throw new ArgumentException(String.Format("Not found domain name, path is invalid: {0}", path));

        }

        /// <summary>
        /// Extract Result Property name.
        /// </summary>
        /// <param name="path">full path.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><c>ArgumentException</c>.</exception>
        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        internal string ExtractResultPropertyName(string path)
        {
            if (path == null || path.Trim() == string.Empty)
                throw new ArgumentNullException("path", "PathValue is blank.");

            string[] strWords = path.Split(DELIMIT_SYMBOL);
            if (strWords.Length == 1)
                return strWords[0];

            if (strWords.Length > 1)
            {
                return strWords[strWords.Length - 1];
            }

            throw new ArgumentException(String.Format("Not found domain name, path is invalid: {0}", path));
        }
        #endregion

        #region Show Form Generator Domain
        /// <summary>
        /// Show form generate code domain wizard.
        /// </summary>
        public void ShowGenerateDomainForm()
        {
            string defaultNamespace = string.Empty;
            string defaultClassName = string.Empty;

            if (ListDomainSupport.Count > 0)
            {
                string strNamespace = ((Control)ListDomainSupport[0]).FindForm().GetType().Namespace;
                string[] namespaces = strNamespace.Split('.');

                defaultNamespace = string.Empty;
                for (int i = 0; i < namespaces.Length - 1; i++)
                {
                    defaultNamespace += namespaces[i] + ".";
                }
                defaultNamespace += "UIDataModel";


                defaultClassName = ((Control)ListDomainSupport[0]).FindForm().GetType().Name + "UIDM";
            }
            UIDataModelGeneratorForm form = new UIDataModelGeneratorForm(this, defaultNamespace, defaultClassName);
            form.TopMost = true;
            form.ShowDialog();
        }


        #endregion

        #region Properties
        /// <summary>
        /// List of domain which support get and set value.
        /// </summary>
        [Browsable(false)]
        public List<IUIDataModelSupport> ListDomainSupport
        {
            get { return m_listControlDomainSupport; }
        }

        #endregion

    }
}
