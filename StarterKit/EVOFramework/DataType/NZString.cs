/*
 * Created by : Mr.Teerayut Sinlan
 * Created date : 2008-07-02
 * Description : String business data type.
 * 
 * Record of change
 * ===========
 * 20091002: Add convert implicit and explicit operator.
*/

using System;
using EVOFramework.Windows.Forms;

namespace EVOFramework
{    
    [Serializable]
    public class NZString : NZBaseObject
    {
        #region Constructor
        public NZString()  { }
        public NZString(IControlIdentify controlIdentify) : base(controlIdentify) { }
        public NZString(IControlIdentify controlIdentify, object value) : base(controlIdentify, value) {
            // if value is empty string, should be store DBNull value.
            if (value != null && value is string) {
                if (value.ToString() == string.Empty)
                    m_value = DBNull.Value;
            }
        }
        public NZString(IControlIdentify controlIdentify, object value, object defaultNullValue) : base(controlIdentify, value, defaultNullValue) { }    
        #endregion

        /// <summary>
        /// Get strongly type of this object.
        /// </summary>
        public override Type StrongType
        {
            get
            {
                return typeof(string);
            }
        }
        /// <summary>
        /// Get strong value.        
        /// </summary>
        /// <exception cref="InvalidCastException">Value must have value.</exception>
        public string StrongValue
        {
            get
            {
                if (IsNull)
                    return String.Empty;

                return m_value.ToString();
            }
        }

        /// <summary>
        /// NVL value to Specific value.
        /// </summary>
        /// <param name="value">Specific value.</param>
        /// <returns></returns>
        public string NVL(string value)
        {
            return Convert.ToString(NVL((object)value));
        }

        public override bool IsNull
        {
            get
            {
                if (base.IsNull)
                    return true;

                if (m_value.ToString().Trim() == string.Empty)
                    return true;

                return false;
            }
        }
        /// <summary>
        /// Clone object. Copy to new reference object.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            object obj = base.Clone();
            return obj as NZString;
        }

        #region Public method
        /// <summary>
        /// Clone this object to new NZString with value upper-case.
        /// </summary>
        /// <returns></returns>
        public NZString ToUpper() {
            NZString temp = this.Clone() as NZString;
            if (temp != null) {
                temp.Value = temp.NVL(string.Empty).ToUpper();
            }

            return temp;
        }

        /// <summary>
        /// Clone this object to new NZString with value lower-case.
        /// </summary>
        /// <returns></returns>
        public NZString ToLower() {
            NZString temp = this.Clone() as NZString;
            if (temp != null)
            {
                temp.Value = temp.NVL(string.Empty).ToLower();
            }

            return temp;
        }
        #endregion

        #region Implicit / Explicit Operator
        public static implicit operator string(NZString value) {
            if (value.IsNull)
                return null;
            
            return value.StrongValue;
        }
        public static explicit operator NZString(string value) {
            return new NZString(null, value);
        }        
        #endregion
    }
}


