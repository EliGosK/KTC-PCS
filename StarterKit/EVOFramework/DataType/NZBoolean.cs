/*
Created by : Mr.Teerayut Sinlan
Created date : 2008-09-01
Description : Boolean business data type.
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
    public class NZBoolean : NZBaseObject
    {
        #region Constructor
        public NZBoolean()  { }
        public NZBoolean(IControlIdentify controlIdentify) : base(controlIdentify) { }
        public NZBoolean(IControlIdentify controlIdentify, object value) : base(controlIdentify, value) { }
        public NZBoolean(IControlIdentify controlIdentify, object value, object defaultNullValue) : base(controlIdentify, value, defaultNullValue) { }    
        #endregion

        /// <summary>
        /// Get strongly type of this object.
        /// </summary>
        public override Type StrongType
        {
            get
            {
                return typeof (bool);
            }
        }
        /// <summary>
        /// Get strong value.        
        /// </summary>
        /// <exception cref="InvalidCastException">Value must have value.</exception>
        public bool StrongValue
        {
            get
            {
                if (IsNull)
                    throw new InvalidCastException(String.Format(ResourceBundle.ALL.S_INVALID_CAST_TYPE, m_value.GetType().Name, StrongType.Name));

                return (bool)Convert.ChangeType(m_value, StrongType);
            }
        }       

        /// <summary>
        /// NVL value to Specific value.
        /// </summary>
        /// <param name="value">Specific value.</param>
        /// <returns></returns>
        public bool NVL(bool value)
        {
            return Convert.ToBoolean(NVL((object)value));
        }

        /// <summary>
        /// Clone object. Copy to new reference object.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            object obj = base.Clone();
            return obj as NZBoolean;
        }

        #region Implicit / Explicit Operator
        public static implicit operator bool(NZBoolean value)
        {
            return value.StrongValue;
        }
        public static explicit operator NZBoolean(bool value)
        {
            return new NZBoolean(null, value);
        }
        #endregion
    }
}


