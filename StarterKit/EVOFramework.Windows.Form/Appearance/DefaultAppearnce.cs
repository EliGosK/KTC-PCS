using System.Drawing;

namespace EVOFramework.Windows.Forms
{
    internal class DefaultAppearance
    {
        public AppearanceList GetAppearance() {
            AppearanceList list = new AppearanceList();

            list.Add(new Appearance("Header", "Tahoma", 10f, FontStyle.Regular, Color.Black, Color.Transparent));
            list.Add(new Appearance("SubHeader", "Tahoma", 10f, FontStyle.Regular, Color.Black, Color.Transparent));
            list.Add(new Appearance("Data", "Tahoma", 10f, FontStyle.Regular, Color.Black, Color.Blue));
            list.Add(new Appearance("DataReadOnly", "Tahoma", 10f, FontStyle.Regular, Color.Black, Color.Transparent));

            return list;
        }        
    }
}
