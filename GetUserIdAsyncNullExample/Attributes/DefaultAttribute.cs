using System;

namespace GetUserIdAsyncNullExample.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DefaultValueAttribute : Attribute
    {
        private string _value;
        public string Value {
            get {
                return _value;
            }
        }

        private bool _isLiteral;
        public bool IsLiteral {
            get {
                return _isLiteral;
            }
        }

        public DefaultValueAttribute(string value, bool isLiteral = false)
        {
            _isLiteral = isLiteral;
            _value = value;
        }
    }
}
