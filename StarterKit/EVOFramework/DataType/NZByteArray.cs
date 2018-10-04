

/*
Created by : Mr.Teerayut Sinlan
Created date : 2008-07-02
Description : Byte Array business data type.
 * 
  * Record of change
 * ===========
 * 20091002: Add convert implicit and explicit operator.
*/

using System;
using System.Drawing;
using System.IO;
using EVOFramework.Windows.Forms;

namespace EVOFramework
{
    [Serializable]
    public class NZByteArray : NZBaseObject
    {
        #region Constructor
        public NZByteArray()  { }
        public NZByteArray(IControlIdentify controlIdentify) : base(controlIdentify) { }
        public NZByteArray(IControlIdentify controlIdentify, object value) : base(controlIdentify, value) { }
        public NZByteArray(IControlIdentify controlIdentify, object value, object defaultNullValue) : base(controlIdentify, value, defaultNullValue) { }    
        #endregion

        /// <summary>
        /// Get strongly type of this object.
        /// </summary>
        public override Type StrongType
        {
            get
            {
                return typeof(byte[]);
            }
        }
        /// <summary>
        /// Get strong value.        
        /// </summary>
        /// <exception cref="InvalidCastException"><c>InvalidCastException</c>.</exception>
        public byte[] StrongValue
        {
            get
            {
                if (IsNull)
                    throw new InvalidCastException(String.Format(ResourceBundle.ALL.S_INVALID_CAST_TYPE, m_value.GetType().Name, StrongType.Name));

                return (byte[])Convert.ChangeType(m_value, typeof(byte[]));
            }
        }

        /// <summary>
        /// NVL value to Specific value.
        /// </summary>
        /// <param name="value">Specific value.</param>
        /// <returns></returns>
        public byte[] NVL(byte[] value)
        {
            return (byte[])(NVL((object)value));
        }

        /// <summary>
        /// Clone object. Copy to new reference object.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            object obj = base.Clone();
            return obj as NZByteArray;
        }

        #region Implicit / Explicit Operator
        public static implicit operator byte[](NZByteArray value)
        {
            return value.StrongValue;
        }
        public static implicit operator Image(NZByteArray value)
        {
            if (value == null || value.IsNull)
                return null;

            System.IO.MemoryStream mem = new MemoryStream(value.StrongValue);
            Image img = Image.FromStream(mem);
            mem.Close();
            return img;
        }

        //========================
        public static explicit operator NZByteArray(byte[] value)
        {
            return new NZByteArray(null, value);
        }
        public static explicit operator NZByteArray(Image value)
        {
            if (value == null)
                return new NZByteArray(null, null);

            MemoryStream mem = new MemoryStream();
            value.Save(mem, value.RawFormat);
            mem.Position = 0;
            byte[] byteArray = mem.ToArray();
            mem.Close();

            return new NZByteArray(null, byteArray);

        }
        #endregion
    }
}


