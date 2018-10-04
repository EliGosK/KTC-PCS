using System;
using EVOFramework.Windows.Forms;

namespace EVOFramework
{
    [Serializable]
    public class NZBaseObject : ICloneable
    {
        #region " Variables "
        /// <summary>
        /// Default Null Value.
        /// </summary>
        protected object m_nullValue = DBNull.Value;

        /// <summary>
        /// Current Value.
        /// </summary>
        protected object m_value = DBNull.Value;

        /// <summary>
        /// Store any data type to used for refer to this object.
        /// </summary>
        [NonSerialized]
        protected IControlIdentify m_owner;
        #endregion

        #region " Constructor "
        /// <summary>
        /// Constructor
        /// </summary>
        public NZBaseObject()
        {
            m_value = DBNull.Value;
            m_nullValue = DBNull.Value;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controlIdentify">Control Identifier.</param>
        public NZBaseObject(IControlIdentify controlIdentify) : this() {
            m_owner = controlIdentify;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controlIdentify">Control Identifier.</param>
        /// <param name="value">Current value.</param>        
        public NZBaseObject(IControlIdentify controlIdentify, object value) : this(controlIdentify) {
            if (value == null)
                m_value = DBNull.Value;
            else if (value == typeof(string)) {
                m_value = value.ToString().Trim();
            } else {
                m_value = value;                
            }                
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controlIdentify">Control Identifier.</param>
        /// <param name="value">Value.</param>        
        /// <param name="defaultNullValue">Default null value.</param>        
        public NZBaseObject(IControlIdentify controlIdentify, object value, object defaultNullValue) 
            :this(controlIdentify, value)
        {
            if (defaultNullValue == null)
                m_nullValue = DBNull.Value;
            else if (defaultNullValue == typeof(string))
            {
                m_nullValue = defaultNullValue.ToString().Trim();
            }
            else
            {
                m_nullValue = defaultNullValue;
            }        
        }
        #endregion

        #region " Public methods "
        /// <summary>
        /// Get strongly type of this object.
        /// </summary>
        public virtual Type StrongType
        {
            get { return typeof(object); }
        }

        /// <summary>
        /// Decision to check that given value can convert to strong type of this object.
        /// </summary>
        /// <param name="value">given object to test.</param>
        /// <returns></returns>
        public virtual bool CanConvertToStrongType(object value)
        {
            try
            {
                Convert.ChangeType(value, StrongType);
                return true;
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.Message);
                return false;
            }            
        }

        /// <summary>
        /// Get weakly type value.        
        /// </summary>     
        /// <exception cref="ArgumentException">Cannot assign type which derived from NZBaseObject type</exception>
        [System.Diagnostics.DebuggerNonUserCode]
        public virtual object Value
        {
            get {
                return m_value;
            }
            set {
                if (value == null)
                    m_value = DBNull.Value;
                else if (value is NZBaseObject)
                    throw new ArgumentException("Cannot assign type which derived from NZBaseObject type");
                else
                {
                    if (value.GetType() == typeof(string))
                    {
                        if (Convert.ToString(value).Equals(String.Empty))
                            m_value = DBNull.Value;
                        else
                            m_value = value.ToString().Trim();
                    }
                    else
                    {
                        m_value = value;
                    }
                }
            }
        }

        /// <summary>
        /// Convert null value to given value.
        /// </summary>
        /// <param name="defaultValue">Specific Value.</param>
        /// <returns></returns>
        protected virtual object NVL(object defaultValue)
        {
            if (IsNull)
                return defaultValue;
            
            return m_value;
        }

        /// <summary>
        /// Check if value is null.
        /// </summary>
        public virtual bool IsNull
        {
            get {
                if (m_value == null || m_value == DBNull.Value)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Get or set owner of value.
        /// </summary>
        public IControlIdentify Owner
        {
            get { return this.m_owner; }
            set { m_owner = value;}
        }
        /// <summary>
        /// Display object string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0}", m_value == DBNull.Value ? "(null)" : m_value.ToString());
        }
        #endregion

        #region ICloneable Members

        /// <summary>
        /// Clone object to new object
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bf.Serialize(ms, this);
            ms.Position = 0;
            object obj = bf.Deserialize(ms);
            ms.Close();

            NZBaseObject baseObject = obj as NZBaseObject;
            if (baseObject != null)
                baseObject.m_owner = this.Owner;

            return obj;
            
        }

        #endregion                  
    }
}
