

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
    public class NZInt : NZBaseObject
    {
        #region Constructor
        public NZInt()  { }
        public NZInt(IControlIdentify controlIdentify) : base(controlIdentify) { }
        public NZInt(IControlIdentify controlIdentify, object value) : base(controlIdentify, value) { }
        public NZInt(IControlIdentify controlIdentify, object value, object defaultNullValue) : base(controlIdentify, value, defaultNullValue) { }    
        #endregion

        /// <summary>
        /// Get strongly type of this object.
        /// </summary>
        public override Type StrongType
        {
            get
            {
                return typeof (int);
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
        public int NVL(int value)
        {
            return Convert.ToInt32(NVL((object)value));
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
        public static implicit operator int(NZInt value)
        {
            return value.StrongValue;
        }
        public static explicit operator NZInt(int value)
        {
            return new NZInt(null, value);
        }
        #endregion
    }
}


