using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EVOFramework.Database
{
    [Serializable]
    public sealed class Parameter : IDisposable, ICloneable
    {
        #region Variables
        private string m_paramName = String.Empty;
        private DataType m_paramType = DataType.Decimal;
        private object m_value = DBNull.Value;
        private int m_size = 0;
        private ParameterDirection m_paramDirection = ParameterDirection.Input;
        private ParameterCollection m_collection = null;
        #endregion

        #region Constructor
        public Parameter() { }
        public Parameter(string ParameterName) 
            : this(ParameterName, DataType.Decimal, 0, DBNull.Value) { }
        public Parameter(string ParameterName, object Value) 
            : this(ParameterName, DataType.Default, Value) { }
        public Parameter(string ParameterName, DataType ParameterType) 
            : this(ParameterName, ParameterType, 0, DBNull.Value) { }
        public Parameter(string ParameterName, DataType ParameterType, object Value) 
            : this(ParameterName, ParameterType, 0, Value) { }
        public Parameter(string ParameterName, DataType ParameterType, NZBaseObject objectValue) 
            : this(ParameterName, ParameterType, 0, objectValue.Value) { }

        public Parameter(string ParameterName, DataType ParameterType, int Size, object Value)
        {
            this.Name = ParameterName;
            this.DataType = ParameterType;
            this.Value = (Value == typeof(NZBaseObject)) ? ((NZBaseObject)Value).Value : Value;
            //this.Size = (this.Value == DBNull.Value) ? 1 : Size; 
            this.Size = Size;

        }

        #endregion

        public ParameterCollection Collection
        {
            get { return this.m_collection; }
            internal set { this.m_collection = value; }
        }

        #region Properties
        /// <summary>
        /// Name of parameter
        /// </summary>
        public string Name
        {
            get { return this.m_paramName; }
            set { this.m_paramName = value; }
        }

        /// <summary>
        /// Data type of parameter.
        /// </summary>
        public DataType DataType
        {
            get { return this.m_paramType; }
            set { this.m_paramType = value; }
        }

        /// <summary>
        /// Value of parameter.
        /// </summary>
        public object Value
        {
            get { return this.m_value; }
            set {
                if (value == null) {
                    this.m_value = DBNull.Value;
                } else if (value == typeof(NZBaseObject)) {
                    this.m_value = ( (NZBaseObject) value ).Value;
                }
                else {
                    this.m_value = value;
                }
            }
        }

        /// <summary>
        /// Size of parameter.
        /// </summary>
        public int Size
        {
            get { return this.m_size; }
            set { this.m_size = value; }
        }

        /// <summary>
        /// Parameter Direction
        /// </summary>
        public ParameterDirection Direction
        {
            get { return this.m_paramDirection; }
            set { this.m_paramDirection = value; }
        }

        
        #endregion

        #region Override

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception><filterpriority>2</filterpriority>
        /// <exception cref="ArgumentException">Parameter can't compare Equals because argument isn't class Parameter</exception>
        public override bool Equals(object obj)
        {
            Parameter param = obj as Parameter;
            if (param == null)
                throw new ArgumentException("Parameter can't compare Equals because argument isn't class Parameter");

            if (param.Name == this.Name)
                return true;
            

            return false;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return this.Name;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public object Clone()
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(m, this);
            m.Position = 0;

            return f.Deserialize(m);
        }        
        #endregion
    }
}
