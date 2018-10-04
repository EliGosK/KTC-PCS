

/*
Created by : Mr.Teerayut Sinlan
Created date : 2008-07-02
Description : Integer business data type.
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
    public class NZLong : NZBaseObject
    {
        #region Constructor
        public NZLong()  { }
        public NZLong(IControlIdentify controlIdentify) : base(controlIdentify) { }
        public NZLong(IControlIdentify controlIdentify, object value) : base(controlIdentify, value) { }
        public NZLong(IControlIdentify controlIdentify, object value, object defaultNullValue) : base(controlIdentify, value, defaultNullValue) { }    
        #endregion

        public override Type StrongType
        {
            get
            {
                return typeof (long);
            }
        }
        /// <summary>
        /// Get strong value.        
        /// </summary>
        /// <exception cref="InvalidCastException">Value must have value.</exception>
        public int StrongValue
        {
            get
            {
                if (IsNull)
                    throw new InvalidCastException(String.Format(ResourceBundle.ALL.S_INVALID_CAST_TYPE, m_value.GetType().Name, StrongType.Name));

                return (int)Convert.ChangeType(m_value, typeof(int));
            }
        }        

        /// <summary>
        /// NVL value to Specific value.
        /// </summary>
        /// <param name="value">Specific value.</param>
        /// <returns></returns>
        public long NVL(int value)
        {
            return Convert.ToInt64(NVL((object)value));
        }

        /// <summary>
        /// Clone object. Copy to new reference object.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            object obj = base.Clone();
            return obj as NZInt;
        }

        #region Implicit / Explicit Operator
        public static implicit operator long(NZLong value)
        {
            return value.StrongValue;
        }
        public static explicit operator NZLong(long value)
        {
            return new NZLong(null, value);
        }
        #endregion
    }
}


