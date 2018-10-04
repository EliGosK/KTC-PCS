using System;
using System.Collections.Generic;
using System.Drawing;
using EVOFramework.Data;
using System.Data;

namespace EVOFramework.Windows.Forms
{    
    public class Appearance
    {
        #region Variables
        private readonly string m_name = String.Empty;
        private readonly string m_fontName = String.Empty;
        private readonly float m_fontSize = 0;
        private readonly FontStyle m_fontStyle = FontStyle.Regular;
        private readonly Color m_foreColor = Color.Black;
        private readonly Color m_backColor = Color.White;
        #endregion

        #region Constructor
        public Appearance(string name, string fontName, float fontSize, FontStyle fontStyle, Color foreColor, Color backColor) {
            m_name = name;
            m_fontName = fontName;
            m_fontSize = fontSize;
            m_fontStyle = fontStyle;
            m_foreColor = foreColor;
            m_backColor = backColor;
        }
        #endregion

        #region Properties
        public string Name {
            get { return m_name; }
        }

        public string FontName {
            get { return m_fontName; }
        }

        public float FontSize {
            get { return m_fontSize; }
        }

        public FontStyle FontStyle {
            get { return m_fontStyle; }
        }

        public Color ForeColor {
            get { return m_foreColor; }
        }

        public Color BackColor {
            get { return m_backColor; }
        }
        #endregion

        #region Object overriden method
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return String.Format("{0}", this.Name);
        }
        #endregion
    }

    public class AppearanceList : ICollection<Appearance>
    {
        #region Variables
        /// <summary>
        /// Stored list of appearance object.
        /// </summary>
        private readonly Map<string, Appearance> m_appearanceList = new Map<string, Appearance>();
        #endregion

        #region Indexer
        /// <summary>
        /// Get Appearance object at index (zero-based).
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"><c>index</c> is out of range.</exception>
        public Appearance this[int index] {
            get {
                if (index > Appearances.Count - 1)
                    return null;

                return Appearances[index].Value;
            }
            set {
                Appearances.Put(value.Name, value);
            }
        }

        /// <summary>
        /// Get Appearance object at the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"><c>name</c> is out of range.</exception>
        public Appearance this[string name] {
            get {
                if (!Appearances.FoundKey(name))
                    return null;

                return Appearances[name].Value;
            }
            set {
                Appearances.Put(name, value);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Stored list of appearance object.
        /// </summary>
        public Map<string, Appearance> Appearances {
            get { return m_appearanceList; }
        }
        #endregion

        #region Public method
        /// <summary>
        /// Get all of Appearance.
        /// </summary>
        /// <returns></returns>
        public Appearance[] GetAppearances()
        {
            Appearance[] aprs = new Appearance[Appearances.Count];
            for (int i = 0; i < Appearances.Count; i++) {
                aprs[i] = Appearances[i].Value;
            }
            return aprs;
        }
        #endregion

        #region ICollection<Appearance> Members

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        /// <exception cref="ArgumentException"><c>ArgumentException</c>.</exception>
        public void Add(Appearance item)
        {
            if (Appearances.FoundKey(item.Name))
                throw new ArgumentException(String.Format("\"{0}\", Name has already existing.", item.Name));

            Appearances.Put(item.Name, item);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only. </exception>
        public void Clear()
        {
            Appearances.RemoveAll();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
        /// </summary>
        /// <returns>
        /// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
        /// </returns>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public bool Contains(Appearance item)
        {
            return ( Appearances.FoundKey(item.Name) );
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param><param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null.</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception><exception cref="T:System.ArgumentException"><paramref name="array"/> is multidimensional.-or-<paramref name="arrayIndex"/> is equal to or greater than the length of <paramref name="array"/>.-or-The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.-or-Type <paramref name="T"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><c></c> is out of range.</exception>
        public void CopyTo(Appearance[] array, int arrayIndex)
        {
            if (arrayIndex > array.Length-1)
                throw new ArgumentOutOfRangeException();

            array = new Appearance[Appearances.Count - arrayIndex];
            int iCount = 0;
            for (int i=arrayIndex; i<Appearances.Count; i++, iCount++) {
                array[iCount] = Appearances[i].Value;                
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public int Count
        {
            get { return Appearances.Count;}
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public bool Remove(Appearance item)
        {
            try {
                Appearances.Remove(item.Name);
                return true;
            } catch (Exception err) {
                System.Diagnostics.Debug.WriteLine(err.Message);
                return false;
            }
        }

        #endregion

        #region IEnumerable<Appearance> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<Appearance> GetEnumerator()
        {
            for (int i = 0; i < Appearances.Count; i++ )
                yield return Appearances[i].Value;
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Object overriden method
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return String.Format("Count: {0}", this.Count);
        }
        #endregion
    }

    public static class AppearanceSerializer
    {     
        #region Private method
        private static string ConvertFontStyleToString(FontStyle fontStyle) {
            string comma = string.Empty;
            string result = string.Empty;

            if ((fontStyle | FontStyle.Regular) == FontStyle.Regular) {
                result += comma + FontStyle.Regular;
                comma = ",";
            }

            if ((fontStyle | FontStyle.Bold) == FontStyle.Bold)
            {
                result += comma + FontStyle.Bold;
                comma = ",";
            }

            if ((fontStyle | FontStyle.Italic) == FontStyle.Italic)
            {
                result += comma + FontStyle.Italic;
                comma = ",";
            }

            if ((fontStyle | FontStyle.Underline) == FontStyle.Underline)
            {
                result += comma + FontStyle.Underline;
                comma = ",";
            }

            if ((fontStyle | FontStyle.Strikeout) == FontStyle.Strikeout)
            {
                result += comma + FontStyle.Strikeout;
                comma = ",";
            }


            return result;
        }
        private static FontStyle ConvertStringToFontStyle(string fontStyleText) {
            string[] strSplits = fontStyleText.Split(',');

            FontStyle result = FontStyle.Regular;
            for (int i = 0; i < strSplits.Length; i++ ) {
                string strSplit = strSplits[i].Trim();
                try {
                    result |= (FontStyle)Enum.Parse(typeof (FontStyle), strSplit);
                } catch {}
            }
            return result;
        }

        private static string ConvertColorToString(Color color) {
            string strColor = string.Empty;
            if (color.IsNamedColor || color.IsSystemColor) {
                strColor = "$" + color.Name;
            } else if (color.IsKnownColor) {
                strColor = color.ToKnownColor().ToString();
            } else {
                strColor = String.Format("{0},{1},{2},{3}", color.A, color.R, color.G, color.B);
            }

            return strColor;
        }
        private static Color ConvertStringToColor(string colorText) {
            if (colorText.IndexOf('$') > -1) {
                // SystemColor
                string strColor = colorText.Substring(1);
                return Color.FromName(strColor);
            }

            if (colorText.IndexOf(',') > -1) {
                // ARGB
                string[] strSplit = colorText.Split(',');
                int a = Convert.ToInt32(strSplit[0].Trim());
                int r = Convert.ToInt32(strSplit[1].Trim());
                int g = Convert.ToInt32(strSplit[2].Trim());
                int b = Convert.ToInt32(strSplit[3].Trim());
                return Color.FromArgb(a, r, g, b);                
            }

            // KnownColor
            KnownColor knownColor = (KnownColor) Enum.Parse(typeof (KnownColor), colorText);
            return Color.FromKnownColor(knownColor);
        }

        private static DataTable CreateDataTableSchema() {
            DataTable dtView = new DataTable("Root");            
            dtView.Columns.Add("Name", typeof (string));
            dtView.Columns.Add("FontName", typeof(string));
            dtView.Columns.Add("FontStyle", typeof(string));
            dtView.Columns.Add("FontSize", typeof(float));
            dtView.Columns.Add("ForeColor", typeof(string));
            dtView.Columns.Add("BackColor", typeof (string));

            return dtView;
        }
        #endregion

        #region Public Serialize/Deserialize method
        private static AppearanceList ConvertDataTableToAppearanceList(DataTable dtView) {
            AppearanceList list = new AppearanceList();
            for (int i = 0; i < dtView.Rows.Count; i++)
            {
                Appearance apr = new Appearance(
                    dtView.Rows[i]["Name"].ToString(),
                    dtView.Rows[i]["FontName"].ToString(),
                    Convert.ToSingle(dtView.Rows[i]["FontSize"]),
                    ConvertStringToFontStyle(dtView.Rows[i]["FontStyle"].ToString()),
                    ConvertStringToColor(dtView.Rows[i]["ForeColor"].ToString()),
                    ConvertStringToColor(dtView.Rows[i]["BackColor"].ToString())
                    );

                list.Add(apr);
            }
            return list;
        }

        public static void Serialize(string filename, AppearanceList appearanceList) {
            DataTable dtView = CreateDataTableSchema();

            for (int i = 0; i < appearanceList.Count; i++) {
                Appearance apr = appearanceList[i];
                dtView.Rows.Add(
                    apr.Name,
                    apr.FontName,
                    apr.FontStyle,
                    apr.FontSize,
                    ConvertColorToString(apr.ForeColor),
                    ConvertColorToString(apr.BackColor)
                    );
            }

            dtView.WriteXml(filename, XmlWriteMode.IgnoreSchema);

        }


        public static AppearanceList Deserialize(string filename) {
            DataTable dtView = CreateDataTableSchema();
            dtView.ReadXml(filename);

            return ConvertDataTableToAppearanceList(dtView);
        }

        public static AppearanceList Deserialize(System.IO.Stream stream) {
            DataTable dtView = CreateDataTableSchema();
            dtView.ReadXml(stream);

            return ConvertDataTableToAppearanceList(dtView);
        }
        #endregion
    }
}
