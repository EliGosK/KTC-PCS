using System.Data;
using System;
namespace EVOFramework.Data
{
    /// <summary>
    /// Wrapper Class for lookup data on combobox.
    /// </summary>
    public class LookupData : ICloneable
    {
        private readonly DataTable m_dataSource;
        private readonly string m_displayMember;
        private readonly string m_valueMember;

        public LookupData(DataTable dataSource, string displayMember, string valueMember) {
            this.m_dataSource = dataSource;
            this.m_displayMember = displayMember;
            this.m_valueMember = valueMember;
        }

        /// <summary>
        /// DataSource of data.
        /// </summary>
        public DataTable DataSource {
            get { return m_dataSource; }
        }

        /// <summary>
        /// Field name of DataSource that will display text.
        /// </summary>
        public string DisplayMember {
            get { return m_displayMember; }
        }
        /// <summary>
        /// Field name of DataSource that stored value.
        /// </summary>
        public string ValueMember {
            get { return m_valueMember; }
        }

        #region Implementation of ICloneable

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        object ICloneable.Clone()
        {
            LookupData data = new LookupData(this.DataSource.Copy(), this.DisplayMember, this.ValueMember);
            return data;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns></returns>
        public LookupData Clone() {
            return (LookupData) ( (ICloneable) this ).Clone();
        }
        #endregion
    }
}
