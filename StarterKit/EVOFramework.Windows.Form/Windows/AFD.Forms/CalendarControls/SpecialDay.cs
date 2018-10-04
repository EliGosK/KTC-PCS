using System;
using System.Drawing;
using System.Drawing.Design;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;


namespace Cube.AFD.Windows.Controls.CalendarControls {

    public enum SpecialDayOccorence {
        Once,
        EveryMonth,
        EveryYear
    }

    [TypeConverter(typeof(ImageIndexMappingConverter))]
    public class ImageIndexMapping {
        //private ImageList m_imageList = null;
        private int m_iImageIndex = -1;
        private SpecialDay m_owner;
        public ImageIndexMapping() {

        }

        public ImageIndexMapping(SpecialDay owner, int index) {
            m_owner = owner;
            m_iImageIndex = index;
        }
        //public ImageIndexMapping(int index) {
        //    m_iImageIndex = index;
        //}
        [Category("Behavior")]
        [Description("The ImageList control from which this item takes the images")]
        [DefaultValue(null)]
        [Browsable(false)]
        public ImageList ImageList {
            get {
                if (this.Owner != null) {
                    if (this.Owner.Owner != null) {
                        return this.Owner.Owner.IconImageList;
                    }
                }

                return null;
            }
        }



        //[Category("Appearance"), Description("..."), DefaultValue(-1)]
        //[TypeConverter(typeof(ExtImageIndexConverter)), Editor(typeof(ExtImageIndexEditor), typeof(UITypeEditor))]
        [DefaultValue(-1)]
        [Localizable(true)]
        [TypeConverter(typeof(System.Windows.Forms.ImageIndexConverter))]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(System.Drawing.Design.UITypeEditor))]
        public int ImageIndex {
            get { return this.m_iImageIndex; }
            set {
                this.m_iImageIndex = value;
            }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SpecialDay Owner {
            get {
                return m_owner;
            }
            set {
                m_owner = value;
            }
        }

        public override string ToString() {
            return "ImageIndex {" + m_iImageIndex.ToString() + "}";
        }

    }

    public class ImageIndexMappingConverter : TypeConverter {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            if (destinationType == typeof(InstanceDescriptor))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
            if (destinationType == typeof(InstanceDescriptor)) {
                try {
                    ImageIndexMapping m = (ImageIndexMapping)value;
                    ConstructorInfo cInfo = typeof(ImageIndexMapping).GetConstructor(new Type[] { typeof(SpecialDay), typeof(int) });
                    return new InstanceDescriptor(cInfo, new object[] { m.Owner, m.ImageIndex }, true);
                } catch (Exception ex) {
                    MessageBox.Show("Poo : " + ex.ToString());
                    return base.ConvertTo(context, culture, value, destinationType);
                }
                //m = new ImageIndexMapping(SpecialDay, int);
                //ConstructorInfo cInfo = typeof(ImageIndexMapping).GetConstructor(new Type[] { typeof(int) });
                //return new InstanceDescriptor(cInfo, new object[] {m.ImageIndex}, true);

                //ConstructorInfo cInfo = typeof(ImageIndexMapping).GetConstructor(System.Type.EmptyTypes);
                //return new InstanceDescriptor(cInfo, null, false);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    //[TypeConverter(typeof(SpecialDayConverter))]xxxxxx
    public class SpecialDay {
        //private ImageList m_imageList = null;
        private ImageIndexMappingCollection m_indexs = null;
        private int m_iImageBackIndex = -1;
        private DateTime m_date;
        private SpecialDayOccorence m_occor = SpecialDayOccorence.Once;
        private Calendar m_owner = null;

        public SpecialDay() {
            m_indexs = new ImageIndexMappingCollection(this);
        }

        public SpecialDay(Calendar owner) {
            m_owner = owner;
            m_indexs = new ImageIndexMappingCollection(this);
        }

        public SpecialDay(DateTime date) {
            //m_owner = owner;
            m_indexs = new ImageIndexMappingCollection(this);
            m_date = date.Date;
        }

        [Category("Behavior")]
        [Description("The ImageList control from which this item takes the images")]
        [DefaultValue(null)]
        [Browsable(false)]
        public ImageList ImageList {
            get {
                if (this.Owner != null) {
                    return this.Owner.DayBackgroundImageList;
                }
                return null;
            }
        }

        [DefaultValue(-1)]
        [Localizable(true)]
        [TypeConverter(typeof(System.Windows.Forms.ImageIndexConverter))]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(System.Drawing.Design.UITypeEditor))]
        public int ImageIndex {
            get { return this.m_iImageBackIndex; }
            set {
                this.m_iImageBackIndex = value;
            }
        }

        public SpecialDay(Calendar owner, DateTime date, int iImgBackgroundIndex, SpecialDayOccorence occor, params int[] indexs) {
            m_owner = owner;
            m_iImageBackIndex = iImgBackgroundIndex;
            m_indexs = new ImageIndexMappingCollection(this);
            if (indexs != null) {
                foreach (int index in indexs) {
                    m_indexs.Add(new ImageIndexMapping(this, index));
                }
            }
            m_date = date;
            m_occor = occor;
        }

        public SpecialDayOccorence Occorence {
            get { return m_occor; }
            set {
                if (m_occor != value) {
                    m_occor = value;
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Calendar Owner {
            get { return m_owner; }
            set {
                m_owner = value;
                if (m_indexs == null)
                    m_indexs = new ImageIndexMappingCollection(this);
            }
        }

        public DateTime Date {
            get { return m_date; }
            set {
                if (m_date != value) {
                    m_date = value;
                }
            }
        }

        //[Category("Behavior")]
        //[Description("The ImageList control from which this item takes the images")]
        //[DefaultValue(null)]
        //[Browsable(false)]
        //public ImageList ImageList {
        //    get { return this.m_imageList; }
        //    set {
        //        this.m_imageList = value;
        //        foreach (ImageIndexMapping m in m_indexs){
        //            m.ImageList = this.m_imageList;
        //        }
        //    }
        //}

        //[Category("Behavior")]
        //[Description("The ImageList control from which this item takes the images")]
        //[DefaultValue(null)]
        //[Browsable(false)]
        //public ImageList ImageList{
        //    get {
        //        return 
        //    }
        //}


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        Editor(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ImageIndexMappingCollection ImageIndexies {
            get {
                return m_indexs;
            }
        }

        public override bool Equals(object obj) {
            return this.m_date == ((SpecialDay)obj).m_date;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            if (m_date <= DateTime.MinValue) {
                return "SpecialDay[Not Set]";
            } else {
                return CalendarObject.FormatDate(null, "SpecialDay[{0:dd/MMM/yyyy}]", m_date);
            }
        }

        internal class SpecialDayConverter : TypeConverter {
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor))
                    return true;

                return base.CanConvertTo(context, destinationType);
            }

            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
                if (destinationType == typeof(InstanceDescriptor)) {
                    try {
                        SpecialDay sDay = (SpecialDay)value;
                        ConstructorInfo cInfo = typeof(SpecialDay).GetConstructor(new Type[] { typeof(Calendar), typeof(DateTime), typeof(int), typeof(SpecialDayOccorence), typeof(int[]) });
                        return new InstanceDescriptor(cInfo, new object[] { sDay.Owner, sDay.Date, sDay.ImageIndex, sDay.Occorence, sDay.ImageIndexies.ToIntegerArray }, true);
                        //if (sDay.ImageIndexies != null) {
                        //    return new InstanceDescriptor(cInfo, new object[] { sDay.Owner, sDay.Date, sDay.Occorence, sDay.ImageIndexies.ToIntegerArray }, true);
                        //} else {
                        //    return new InstanceDescriptor(cInfo, new object[] { sDay.Owner, sDay.Date, sDay.Occorence, null }, true);
                        //}
                    } catch (Exception) {
                        string msg = string.Empty;
                        Type t1 = value.GetType();
                        Type t2 = typeof(SpecialDay);
                        msg += "Old Value = " + t1.Assembly.GetFiles()[0].Name + "\n";
                        msg += "New Value = " + t2.Assembly.GetFiles()[0].Name;
                        MessageBox.Show(msg);

                        //t.Assembly.GetFiles()[0].Name
                        //MessageBox.Show("Assembly 1 " + t1.ToString());
                        //MessageBox.Show("Assembly 2 " + t2.ToString());
                        //MessageBox.Show("Assembly 1 and 2 is " + (t1 == t2).ToString());
                        //MessageBox.Show("Poo2 : " + ex.ToString());
                        return base.ConvertTo(context, culture, value, destinationType);
                    }

                    //return base.ConvertTo(context, culture, value, destinationType);

                    //sDay = new SpecialDay(Calendar, DateTime, SpecialDayOccorence);
                    //ConstructorInfo cInfo = typeof(SpecialDay).GetConstructor(new Type[] { typeof(DateTime) });//, typeof(DateTime), typeof(SpecialDayOccorence) });
                    //return base.ConvertTo(context, culture, value, destinationType);
                    //return new InstanceDescriptor(cInfo, new object[] { sDay.Date }, true);//, sDay.Date, sDay.Occorence}, true);


                    //ConstructorInfo cInfo = typeof(SpecialDay).GetConstructor(System.Type.EmptyTypes);
                    //return new InstanceDescriptor(cInfo, null, false);
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }



    
    public class SpecialDayCollection : CollectionBase {

        //public delegate void AddNewButtonHandler(OutlookButtonItem button);

        private Calendar m_owner = null;

        internal SpecialDayCollection(Calendar owner) {
            m_owner = owner;
        }

        public SpecialDay this[int index] {
            get {
                return (SpecialDay)this.InnerList[index];
            }
        }

        public void AddRange(SpecialDay[] value) {
            //foreach (SpecialDay b in value) {
            //    b.ImageList = m_owner.IconImageList;
            //}
            this.InnerList.AddRange(value);
        }

        public int IndexOf(SpecialDay day) {
            return InnerList.IndexOf(day);
        }

        public int IndexOf(int year, int month, int day) {
            SpecialDay sp = new SpecialDay(new DateTime(year, month, day));
            return this.IndexOf(sp);
        }

        public int IndexOf(int month, int day) {
            for (int i = 0; i < this.InnerList.Count; ++i) {
                SpecialDay s = (SpecialDay)this[i];
                if (s.Date.Month == month && s.Date.Day == day) {
                    return i;
                }
            }
            return -1;
        }

        public int IndexOf(int day) {
            for (int i = 0; i < this.InnerList.Count; ++i) {
                SpecialDay s = (SpecialDay)this[i];
                if (s.Date.Day == day) {
                    return i;
                }
            }
            return -1;
        }

        public SpecialDay GetSpecialDay(DateTime date) {
            foreach (SpecialDay sDay in this) {
                DateTime dt = sDay.Date;
                switch (sDay.Occorence) {
                    case SpecialDayOccorence.Once:
                        if (dt.Year == date.Year && dt.Month == date.Month && dt.Day == date.Day)
                            return sDay;
                        break;
                    case SpecialDayOccorence.EveryMonth:
                        if (dt.Day == date.Day)
                            return sDay;
                        break;
                    case SpecialDayOccorence.EveryYear:
                        if (dt.Month == date.Month && dt.Day == date.Day)
                            return sDay;
                        break;
                }
            }
            return null;
        }

        public bool Contains(SpecialDay day) {

            return InnerList.Contains(day);
        }

        protected override void OnInsert(int index, object value) {
            if (value is SpecialDay) {
                SpecialDay s = (SpecialDay)value;
                s.Owner = m_owner;
                //if (s.ImageIndexies == null)
                //s.ImageIndexies = new ImageIndexMappingCollection(s.Owner);
                //((SpecialDay)value).Owner = m_owner;
                //    //m_owner.Invalidate();
            }
            base.OnInsert(index, value);
        }

        public int Add(SpecialDay day) {

            int i;
            i = InnerList.Add(day);
            // Must be refres control
            //if (OnAddNewButton != null) {
            //    OnAddNewButton(Button);
            //}
            return i;
        }

        public void Remove(SpecialDay day) {
            InnerList.Remove(day);
        }
    }

    
    public class ImageIndexMappingCollection : CollectionBase {

        //public delegate void AddNewButtonHandler(OutlookButtonItem button);

        private SpecialDay m_owner = null;

        internal ImageIndexMappingCollection(SpecialDay owner) {
            m_owner = owner;
        }

        public int[] ToIntegerArray {
            get {
                int[] indexies = new int[this.Count];
                for (int i = 0; i < this.Count; ++i) {
                    indexies[i] = this[i].ImageIndex;
                }
                return indexies;
            }
        }

        public ImageIndexMapping this[int index] {
            get {
                return (ImageIndexMapping)this.InnerList[index];
            }
        }

        public void AddRange(ImageIndexMapping[] value) {
            //foreach (SpecialDay b in value) {
            //    b.ImageList = m_owner.IconImageList;
            //}
            this.InnerList.AddRange(value);
        }

        public int IndexOf(ImageIndexMapping day) {
            return InnerList.IndexOf(day);
        }

        public SpecialDay Owner {
            get {
                return m_owner;
            }
            set {
                m_owner = value;
            }
        }


        public bool Contains(ImageIndexMapping day) {

            return InnerList.Contains(day);
        }

        protected override void OnInsert(int index, object value) {
            //MessageBox.Show("ImageINdexMappingCollection OnInsert");
            if (value is ImageIndexMapping) {
                ((ImageIndexMapping)value).Owner = m_owner;

                //    //m_owner.Invalidate();
            }
            base.OnInsert(index, value);
        }

        public int Add(ImageIndexMapping day) {

            int i;
            i = InnerList.Add(day);
            // Must be refres control
            //if (OnAddNewButton != null) {
            //    OnAddNewButton(Button);
            //}
            return i;
        }

        public void Remove(ImageIndexMapping day) {
            InnerList.Remove(day);
        }
    }

    //public class ImageIndexMappingCollection : CollectionBase {

    //    //public delegate void AddNewButtonHandler(OutlookButtonItem button);
    //    private Calendar m_owner = null;
    //    public event EventHandler CollectionChanged;

    //    internal ImageIndexMappingCollection(Calendar owner) {
    //        m_owner = owner;
    //    }

    //    public virtual ImageIndexMapping Add(ImageIndexMapping value) {
    //        int pos = List.Count;
    //        base.List.Add(value);
    //        return value;
    //    }

    //    public virtual void AddRange(params ImageIndexMapping[] values) {
    //        foreach (ImageIndexMapping value in values) {
    //            this.Add(value);
    //        }
    //    }

    //    public virtual void Remove(ImageIndexMapping value) {
    //        if (this.List.Contains(value) == false)
    //            return;
    //        this.List.Remove(value);
    //    }

    //    public virtual void RemoveAdd(int index) {
    //        if (this.List.Count > index) {
    //            ImageIndexMapping v = (ImageIndexMapping)this.List[index];
    //            this.Remove(v);
    //        }
    //    }

    //    public virtual ImageIndexMapping Insert(int index, ImageIndexMapping value) {
    //        if (index >= List.Count)
    //            this.Add(value);
    //        else
    //            base.List.Insert(index, value);
    //        return value;
    //    }

    //    public virtual bool Contains(ImageIndexMapping value) {
    //        if (List.Contains(value))
    //            return true;
    //        else
    //            return false;
    //    }

    //    public virtual ImageIndexMapping this[int index] {
    //        get {
    //            if (List.Count > index) {
    //                return (ImageIndexMapping)base.List[index];
    //            } else {
    //                return null;
    //            }
    //        }
    //    }

    //    public virtual int IndexOf(ImageIndexMapping value) {
    //        return base.List.IndexOf(value);
    //    }

    //    protected virtual void OnCollectionChanged() {
    //        if (CollectionChanged != null)
    //            CollectionChanged(this, EventArgs.Empty);
    //    }

    //    protected override void OnRemoveComplete(int index, object value) {
    //        if (value is ImageIndexMapping) {
    //            ((ImageIndexMapping)value).Owner = null;
    //        }
    //        OnCollectionChanged();
    //    }

    //    protected override void OnInsertComplete(int index, object value) {
    //        if (value is ImageIndexMapping) {
    //            ((ImageIndexMapping)value).Owner = m_owner;
    //            MessageBox.Show("OnInsertCompleted");
    //        }
    //        OnCollectionChanged();
    //    }

    //    protected override void OnClear() {
    //        foreach (object o in List) {
    //            ((ImageIndexMapping)o).Owner = null;
    //        }
    //        OnCollectionChanged();
    //    }

    //}

    //internal class ExtImageIndexConverter : ImageIndexConverter {

    //    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
    //        if (value is string) {
    //            if (((string)value) != "(none)" && ((string)value) != "") {
    //                try {
    //                    return Int32.Parse(((string)value));
    //                } catch {
    //                    return -1;
    //                }
    //            } else
    //                return -1;
    //        } else
    //            return null;
    //    }

    //    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
    //        if (value is Int32) {
    //            if (((int)value) >= 0)
    //                return ((int)value).ToString();
    //            else
    //                return "(none)";
    //        } else
    //            return null;
    //    }

    //    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
    //        ArrayList ResultList = new ArrayList();
    //        ImageList ImageList = null;
    //        if (context.Instance != null && context.Instance is ImageIndexMapping) {
    //            // Step 1 - Determine who has the imagelist. 
    //            if (((ImageIndexMapping)context.Instance).Owner != null)
    //                ImageList = ((ImageIndexMapping)context.Instance).Owner.IconImageList;
    //            // Step 2 - Construct list of index for the images in the ImageList if any.
    //            if (ImageList != null) {
    //                for (int Idx = 0; Idx < ImageList.Images.Count; Idx++) {
    //                    ResultList.Add(Idx);
    //                }
    //                ResultList.Add(-1);
    //            }
    //        }
    //        StandardValuesCollection Result = new StandardValuesCollection(ResultList);
    //        MessageBox.Show("Result.Count = " + Result.Count.ToString());
    //        return Result;
    //    }

    //    public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
    //        if (context.Instance != null)
    //            return true;
    //        else
    //            return false;
    //    }

    //}


    //internal class ExtImageIndexEditor : UITypeEditor {
    //    public override bool GetPaintValueSupported(ITypeDescriptorContext context) {
    //        return true;
    //    }

    //    public override void PaintValue(PaintValueEventArgs pe) {
    //        // choose the right bitmap based on the value
    //        Image Image = null;
    //        int ImageIdx = (int)pe.Value;

    //        ArrayList ResultList = new ArrayList();
    //        ImageList ImageList = null;
    //        if (ImageIdx >= 0 && pe.Context.Instance != null && pe.Context.Instance is ImageIndexMapping) {
    //            // Step 1 - Determine who has the imagelist. 
    //            if (((ImageIndexMapping)pe.Context.Instance).Owner != null)
    //                ImageList = ((ImageIndexMapping)pe.Context.Instance).Owner.IconImageList;
    //            else
    //                MessageBox.Show("Owner of ImageIndexMapping = null");
    //            // Step 2 - Construct list of index for the images in the ImageList if any.
    //            if (ImageList != null && ImageList.Images.Count > ImageIdx) {
    //                Image = ImageList.Images[ImageIdx];
    //            } else {
    //                MessageBox.Show("ImageList of Owner = null");
    //            }
    //        }
    //        if (ImageIdx < 0 || Image == null) {	// value -1 : Draws a cross to indicate no image. 
    //            MessageBox.Show("Draw Cross");
    //            pe.Graphics.DrawLine(Pens.Black, pe.Bounds.X + 1, pe.Bounds.Y + 1, pe.Bounds.Right - 1, pe.Bounds.Bottom - 1);
    //            pe.Graphics.DrawLine(Pens.Black, pe.Bounds.Right - 1, pe.Bounds.Y + 1, pe.Bounds.X + 1, pe.Bounds.Bottom - 1);
    //        } else {
    //            pe.Graphics.DrawImage(Image, pe.Bounds);
    //        }
    //    }

    //}
}

