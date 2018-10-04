

/*
Created by : Mr.Teerayut Sinlan
Created date : 2008-07-02
Description : Decimal business data type.
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
    public class NZDecimal : NZBaseObject
    {
        #region Constructor
        public NZDecimal()  { }
        public NZDecimal(IControlIdentify controlIdentify) : base(controlIdentify) { }
        public NZDecimal(IControlIdentify controlIdentify, object value) : base(controlIdentify, value) { }
        public NZDecimal(IControlIdentify controlIdentify, object value, object defaultNullValue) : base(controlIdentify, value, defaultNullValue) { }    
        #endregion

        /// <summary>
        /// Get strongly type of this object.
        /// </summary>
        public override Type StrongType
        {
            get
            {
                return typeof (decimal);
            }
        }
        /// <summary>
        /// Get strong value.        
        /// </summary>
        /// <exception cref="InvalidCastException">Value must have value.</exception>
        public decimal StrongValue
        {
            get
            {
                if (IsNull)
                    throw new InvalidCastException(String.Format(ResourceBundle.ALL.S_INVALID_CAST_TYPE, m_value.GetType().Name, StrongType.Name));

                return (decimal)Convert.ChangeType(m_value, typeof(decimal));
            }
        }

        /// <summary>
        /// NVL value to Specific value.
        /// </summary>
        /// <param name="value">Specific value.</param>
        /// <returns></returns>
        public decimal NVL(decimal value)
        {
            return Convert.ToDecimal(NVL((object)value));
        }

        /// <summary>
        /// Clone object. Copy to new reference object.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            object obj = base.Clone();
            return obj as NZDecimal;
        }

        #region Implicit / Explicit Operator
        public static implicit operator decimal(NZDecimal value)
        {
            return value.StrongValue;
        }
        public static explicit operator NZDecimal(NZInt value)
        {
            return new NZDecimal(value.Owner, value.Value);            
        }

        public static explicit operator NZDecimal(decimal value)
        {
            return new NZDecimal(null, value);
        }
        #endregion
    }
}


