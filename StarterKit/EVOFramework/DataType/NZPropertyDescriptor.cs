using System;
using System.IO;
using System.ComponentModel;
using System.Collections;
using System.Reflection;

namespace EVOFramework
{
    internal class NZPropertyDescriptor : PropertyDescriptor
    {
        /// <summary>
        /// Only way to create the PropertyDescriptor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nzType"></param>
        /// <returns></returns>
        public static NZPropertyDescriptor GetProperty(string name, Type nzType)
        {
            // we need to use the attributes of the base type
            Type baseType = nzType.GetProperty("Value").PropertyType;
            ArrayList attribs = new ArrayList(TypeDescriptor.GetAttributes(baseType));

            Attribute[] attrs = (Attribute[])attribs.ToArray(typeof(Attribute));

            return new NZPropertyDescriptor(name, attrs, nzType, baseType);
        }

        private Type m_NZType;
        private readonly Type m_baseType;

        #region Constructor
        public NZPropertyDescriptor(string name, Attribute[] attrs) : base(name, attrs) {
        }

        public NZPropertyDescriptor(MemberDescriptor descr) : base(descr) {
        }

        public NZPropertyDescriptor(MemberDescriptor descr, Attribute[] attrs) : base(descr, attrs) {
        }

        // use this
        protected NZPropertyDescriptor(string name, Attribute[] attrs, Type nzType, Type baseType)
            : base(name, attrs)
		{
			m_NZType = nzType;
			m_baseType = baseType;
		}
        #endregion

        /// <summary>
        /// When overridden in a derived class, returns whether resetting an object changes its value.
        /// </summary>
        /// <returns>
        /// true if resetting the component changes its value; otherwise, false.
        /// </returns>
        /// <param name="component">The component to test for reset capability. </param>
        public override bool CanResetValue(object component)
        {
            return false;
        }

        /// <summary>
        /// When overridden in a derived class, gets the type of the component this property is bound to.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Type"/> that represents the type of component this property is bound to. When the <see cref="M:System.ComponentModel.PropertyDescriptor.GetValue(System.Object)"/> or <see cref="M:System.ComponentModel.PropertyDescriptor.SetValue(System.Object,System.Object)"/> methods are invoked, the object specified might be an instance of this type.
        /// </returns>
        public override Type ComponentType
        {
            get { return m_baseType; }
        }

        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether this property is read-only.
        /// </summary>
        /// <returns>
        /// true if the property is read-only; otherwise, false.
        /// </returns>
        public override bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// When overridden in a derived class, gets the type of the property.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Type"/> that represents the type of the property.
        /// </returns>
        public override Type PropertyType
        {
            get { return m_baseType; }
        }

        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When overridden in a derived class, gets the current value of the property on a component.
        /// </summary>
        /// <returns>
        /// The value of a property for a given component.
        /// </returns>
        /// <param name="component">The component with the property for which to retrieve the value. </param>
        public override object GetValue(object component)
        {
            try
            {
                object Property = component.GetType().GetProperty(this.Name).GetValue(component, null);

                // handle nulls
                if ((bool)Property.GetType().GetProperty("IsNull").GetValue(Property, null)) return DBNull.Value;

                object Value = Property.GetType().GetProperty("Value").GetValue(Property, null);
                return Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        /// <summary>
        /// When overridden in a derived class, sets the value of the component to a different value.
        /// </summary>
        /// <param name="component">The component with the property value that is to be set. </param><param name="value">The new value. </param>
        public override void SetValue(object component, object value)
        {
            try {
                PropertyInfo pi = component.GetType().GetProperty(this.Name);
                                
                object objValue = pi.GetValue(component, null);
                NZBaseObject baseObject = objValue as NZBaseObject;
                if (baseObject == null)
                    throw new InvalidDataException("Invalid NZBaseObject type.");

                if (baseObject.CanConvertToStrongType(value)) {
                    Type valueType = objValue.GetType();
                    PropertyInfo piValue = valueType.GetProperty("Value", BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance);
                    piValue.SetValue(objValue, value, null);
                }
            } catch (Exception err) {
                Console.WriteLine(err.Message);
                throw;
            }
        }

        /// <summary>
        /// When overridden in a derived class, determines a value indicating whether the value of this property needs to be persisted.
        /// </summary>
        /// <returns>
        /// true if the property should be persisted; otherwise, false.
        /// </returns>
        /// <param name="component">The component with the property to be examined for persistence. </param>
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
