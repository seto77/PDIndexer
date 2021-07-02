﻿using System;
using System.ComponentModel;

namespace Crystallography
{
    /// <summary>
    /// 変換を行う
    /// </summary>
    public class ConverterBase : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);// stringからなら変換可能
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);// stringへなら変換可能
        }
    }

    public class RectangleDConverter : ConverterBase
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] filter)
        {
            return TypeDescriptor.GetProperties(value, filter).Sort(new[] { "X", "Y", "Width", "Height" });
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is RectangleD d)
            {
                return string.Format("{0}, {1}, {2}, {3}", d.X, d.Y, d.Width, d.Height);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string @string)
            {
                string[] ss = @string.Split(new char[] { ',' }, 4);
                return new RectangleD(Convert.ToDouble(ss[0]), Convert.ToDouble(ss[1]), Convert.ToDouble(ss[2]), Convert.ToDouble(ss[3]));
            }
            return base.ConvertFrom(context, culture, value);
        }
    }

    public class PointDConverter : ConverterBase
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] filter)
        {
            return TypeDescriptor.GetProperties(value, filter).Sort(new[] { "X", "Y" });
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is PointD g)
                return string.Format("{0}, {1}", g.X, g.Y);
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                string[] ss = ((string)value).Split(new char[] { ',' }, 2);
                return new PointD(Convert.ToDouble(ss[0]), Convert.ToDouble(ss[1]));
            }
            return base.ConvertFrom(context, culture, value);
        }
    }

    public class SizeDConverter : ConverterBase
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] filter)
        {
            return TypeDescriptor.GetProperties(value, filter).Sort(new[] { "Width", "Height" });
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is SizeD d)
                return string.Format("{0}, {1}", d.Width, d.Height);
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                string[] ss = ((string)value).Split(new char[] { ',' }, 2);
                return new SizeD(Convert.ToDouble(ss[0]), Convert.ToDouble(ss[1]));
            }
            return base.ConvertFrom(context, culture, value);
        }
    }

    public class Vector3DConverter : ConverterBase
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] filter)
        {
            return TypeDescriptor.GetProperties(value, filter).Sort(new[] { "X", "Y", "Z" });
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string) || value is not Vector3DBase)
                return base.ConvertTo(context, culture, value, destinationType);
            Vector3DBase g = (Vector3DBase)value;
            return string.Format("{0}, {1}, {2}", g.X, g.Y, g.Z);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                string[] ss = ((string)value).Split(new char[] { ',' }, 4);
                return new Vector3DBase(Convert.ToDouble(ss[0]), Convert.ToDouble(ss[1]), Convert.ToDouble(ss[2]));
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}