using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVOFramework.Data
{
    /// <summary>
    /// Indicate that this property cannot assign null value
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldNotNullAttribute : Attribute
    {
    }
}
