/* Create by: Mr. Teerayut Sinlan
 * Create on: 2009-08-05
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 */
namespace EVOFramework.Windows.Forms
{
    /// <summary>
    /// Windows Control should be implement this interface to support identify own control.
    /// </summary>
    public interface IControlIdentify : IControlFocusable
    {
        /// <summary>
        /// Represents control's identify. It should be unique.
        /// It references multilanguage and mapping owner error.
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        string ControlID { get; set; }
    }
}
