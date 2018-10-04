using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;

namespace EVOFramework
{
    /// <summary>
    /// Represents list of NZBaseObject.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NZList<T> : List<T>, ITypedList where T: NZBaseObject
    {

        #region ITypedList Members

        /// <summary>
        /// Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"/> that represents the properties on each item used to bind data.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"/> that represents the properties on each item used to bind data.
        /// </returns>
        /// <param name="listAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"/> objects to find in the collection as bindable. This can be null. </param>
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {            

            if (listAccessors != null && listAccessors.Length > 0) {
                PropertyDescriptor childProperty = listAccessors[listAccessors.Length - 1];
            }

            ArrayList input = new ArrayList(TypeDescriptor.GetProperties(typeof (T)));
            return GetPropertyDescriptorCollection(input);
        }

        /// <summary>
        /// Returns the name of the list.
        /// </summary>
        /// <returns>
        /// The name of the list.
        /// </returns>
        /// <param name="listAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"/> objects, for which the list name is returned. This can be null. </param>
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return this.GetType().Name;
        }

        #endregion

        protected PropertyDescriptorCollection GetPropertyDescriptorCollection(ArrayList properties) {
            if ( properties == null || properties.Count == 0 )
				return new PropertyDescriptorCollection(null);

			ArrayList output = new ArrayList();

            foreach (PropertyDescriptor p in properties) {
                Type pType = p.PropertyType;
                bool isNZType = pType.IsSubclassOf(typeof(NZBaseObject));
                if (isNZType) {
                    output.Add(NZPropertyDescriptor.GetProperty(p.Name, p.PropertyType));
                } 
            }

            return new PropertyDescriptorCollection((PropertyDescriptor[])output.ToArray(typeof(PropertyDescriptor)));
        }
    }    
}
