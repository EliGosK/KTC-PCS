/* Create by: Mr. Teerayut Sinlan
 * Create on: 2009-08-05
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 */

using System;

namespace SystemMaintenance.Forms
{
    /// <summary>
    /// Represents data for drag and drop.
    /// </summary>
    internal class ScreenFavoriteData
    {
        public enum eDirection {
            /// <summary>
            /// Drag from favorite
            /// </summary>
            FromFavorite,

            /// <summary>
            /// Drag from menu.
            /// </summary>
   
            FromMenu
        }

        public string USER_ACCOUNT = String.Empty;
        public string SCREEN_CD = String.Empty;
        public int SEQ = 0;
        public eDirection DIRECTION = eDirection.FromMenu;
    }
}
