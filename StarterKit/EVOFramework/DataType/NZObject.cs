

/*
Created by : Mr.Teerayut Sinlan
Created date : 2008-07-02
Description : Integer business data type.
*/

using System;
using EVOFramework.Windows.Forms;

namespace EVOFramework
{
    [Serializable]
    public class NZObject : NZBaseObject
    {
        #region Constructor
        public NZObject()  { }
        public NZObject(IControlIdentify controlIdentify) : base(controlIdentify) { }
        public NZObject(IControlIdentify controlIdentify, object value) : base(controlIdentify, value) { }
        public NZObject(IControlIdentify controlIdentify, object value, object defaultNullValue) : base(controlIdentify, value, defaultNullValue) { }    
        #endregion

        /// <summary>
        /// Get strong value.        
        /// </summary>
        /// <exception cref="InvalidOperationException">Value must have value.</exception>
        public object StrongValue
        {
            get
            {                
                return m_value;
            }
        }

        /// <summary>
        /// NVL value to Specific value.
        /// </summary>
        /// <param name="value">Specific value.</param>
        /// <returns></returns>
        public new object NVL(object value)
        {            
            return base.NVL((object)value);
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
    }
}


