using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Nandalala.Paas.Core
{
    public abstract class StringConverter
    {
        public abstract string ConvertToString(object o, CultureInfo culture);
        public abstract object ConvertFromString(string s, CultureInfo culture);
    }
}
