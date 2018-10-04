/*
Created by : Mr.Teerayut Sinlan
Created date : 2008-07-02
Description : DateTime business data type.
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
    public class NZDateTime : NZBaseObject
    {
        #region Constructor
        public NZDateTime()  { }
        public NZDateTime(IControlIdentify controlIdentify) : base(controlIdentify) { }
        public NZDateTime(IControlIdentify controlIdentify, object value) : base(controlIdentify, value) { }
        public NZDateTime(IControlIdentify controlIdentify, object value, object defaultNullValue) : base(controlIdentify, value, defaultNullValue) { }    
        #endregion

        /// <summary>
        /// Get strongly type of this object.
        /// </summary>
        public override Type StrongType
        {
            get
            {
                return typeof (DateTime);
            }
        }
        
        /// <summary>
        /// Get strong value.        
        /// </summary>
        /// <exception cref="InvalidCastException">Value must have value.</exception>
        public DateTime StrongValue
        {
            get
            {
                if (IsNull)
                    throw new InvalidCastException(String.Format(ResourceBundle.ALL.S_INVALID_CAST_TYPE, m_value.GetType().Name, StrongType.Name));

                return (DateTime)Convert.ChangeType(m_value, typeof(DateTime));
            }
        }

        /// <summary>
        /// NVL value to Specific value.
        /// </summary>
        /// <param name="value">Specific value.</param>
        /// <returns></returns>
        public DateTime NVL(DateTime value)
        {
            return Convert.ToDateTime(NVL((object)value));
        }

        /// <summary>
        /// Clone object. Copy to new reference object.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            object obj = base.Clone();
            return obj as NZDateTime;
        }

        #region Implicit / Explicit Operator
        public static implicit operator DateTime(NZDateTime value)
        {
            return value.StrongValue;
        }
        public static explicit operator NZDateTime(DateTime value)
        {
            return new NZDateTime(null, value);
        }
        #endregion
    }
}


