/* Create by: Mr. Teerayut Sinlan
 * Create on: 2009-08-05
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 */
using System;

namespace EVOFramework.Windows.Forms
{
    public interface IUIDataModelSupport: IControlIdentify
    {
        /// <summary>
        /// Specifiy path value of variable's property.
        /// <para>style: [DomainName].[NestedPropertyName, ...].[ResultPropertyName]</para>
        /// <para>example: UserDomain.Username.Value</para>
        /// </summary>
        string PathString { get; set; }

        /// <summary>
        /// Assign path value.
        /// </summary>
        object PathValue { get; set; }
    }
}
