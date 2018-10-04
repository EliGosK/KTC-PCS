using System;
using System.Reflection;

namespace EVOFramework.Data
{
    /// <summary>
    /// Helper class.
    /// </summary>
    internal class Helper
    {
        #region Property Helper Functions.
        /// <summary>
        /// Get value of specified property.
        /// </summary>
        /// <param name="objOwner">owner object.</param>
        /// <param name="propertyName">Specified propertyName</param>
        /// <returns></returns>
        public static object GetPropertyValue(object objOwner, string propertyName)
        {
            try
            {
                Type objType = objOwner.GetType();

                if (objType.GetProperty(propertyName) == null)
                    return null;

                return objType.GetProperty(propertyName).GetValue(objOwner, null);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get value of specified property.
        /// </summary>
        /// <param name="typeOwner">owner Type of object.</param>
        /// <param name="propertyName">Specified propertyName</param>
        /// <returns></returns>
        public static object GetPropertyValue(Type typeOwner, string propertyName)
        {            
            try
            {
                return typeOwner.GetProperty(propertyName).GetValue(typeOwner, null);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Set value to specified property.
        /// </summary>
        /// <param name="objOwner">owner object.</param>
        /// <param name="propertyName">Specified propertyName.</param>
        /// <param name="value">value that will assign.</param>
        public static void SetPropertyValue(object objOwner, string propertyName, object value)
        {
            Type type = objOwner.GetType();
            try
            {
                type.GetProperty(propertyName).SetValue(objOwner, value, null);
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.Message);
                return;
            }
        }

        /// <summary>
        /// Get value from NZValue
        /// </summary>
        /// <param name="nzObject">NZObject object.</param>
        /// <returns></returns>
        public static object GetPropertyNZValue(object nzObject)
        {
            Type nzType = nzObject.GetType();
            return nzType.GetProperty("Value").GetValue(nzObject, null);
        }

        /// <summary>
        /// Set value of the NZDataType object
        /// </summary>
        /// <param name="nzObject">The object whose property value will be returned. </param>
        /// <param name="value">The new value for this property. </param>
        public static void SetPropertyNZValue(object nzObject, object value)
        {
            Type nzType = nzObject.GetType();
            nzType.GetProperty("Value").SetValue(nzObject, value, null);
        }
        #endregion

        #region Assembly Helper Functions.
        public static Type GetTypeFromAssembly(string assemblyFile, string className)
        {
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyFile);
            Assembly asm = Assembly.LoadFrom(filePath);
            Type type = asm.GetType(className);
            return type;        
        }
        #endregion

    }
}
