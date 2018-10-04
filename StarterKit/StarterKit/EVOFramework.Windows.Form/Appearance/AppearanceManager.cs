using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EVOFramework.Windows.Forms
{
    public static class AppearanceManager
    {
        /// <summary>
        /// Set of default appearance item.
        /// </summary>
        public static AppearanceList DefaultAppearanceSet = null;

        static AppearanceManager() {
            //DefaultAppearanceSet = new DefaultAppearance().GetAppearance();

            System.IO.MemoryStream mem = new MemoryStream(Properties.Resources.DefaultAppearance);
            DefaultAppearanceSet = AppearanceSerializer.Deserialize(mem);
            //DefaultAppearanceSet = EVOFramework.Windows.Form.Properties.Resources.DefaultAppearance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appearanceList"></param>
        public static void RegisterAppearance(AppearanceList appearanceList) {
            DefaultAppearanceSet = appearanceList;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void UnregisterAppearance() {
            System.IO.MemoryStream mem = new MemoryStream(Properties.Resources.DefaultAppearance);
            DefaultAppearanceSet = AppearanceSerializer.Deserialize(mem);
        }
    }
}
