using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Nandalala.Paas.Core
{
    public class DefaultStringConverter : StringConverter
    {
        private readonly Type _type;

        public DefaultStringConverter(Type type)
        {
            _type = type;
        }

        public override string ConvertToString(object value, CultureInfo culture)
        {
            TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(_type);

            if (_type.IsSerializable && !converter.CanConvertFrom(typeof(String)))
            {
                var stream = new MemoryStream();
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, value);
                stream.Close();
                return Convert.ToBase64String(stream.ToArray());
            }

            return converter.ConvertToString(null, culture, value);
        }

        public override object ConvertFromString(string s, CultureInfo culture)
        {
            TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(_type);

            if (_type.IsSerializable && !converter.CanConvertFrom(typeof(string)))
            {
                var formatter = new BinaryFormatter();
                var mem = new MemoryStream(Convert.FromBase64String(s));
                object obj = formatter.Deserialize(mem);
                mem.Close();
                return obj;
            }

            return converter.ConvertFromString(null, culture, s);
        }
    }
}
