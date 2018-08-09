using System;

namespace Nandalala.Paas.Core
{
    public class GuidKeyValuePair
    {
        private readonly Guid _key;
        private readonly Guid _value;

        public GuidKeyValuePair(Guid key, Guid value)
        {
            _key = key;
            _value = value;
        }

        public Guid Key
        {
            get { return _key; }
        }

        public Guid Value
        {
            get { return _value; }
        }
    }
}
