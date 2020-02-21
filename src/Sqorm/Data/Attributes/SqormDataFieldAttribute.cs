using System;

namespace Sqorm.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SqormDataFieldAttribute : Attribute
    {
        private readonly string _name;

        public SqormDataFieldAttribute(string name)
        {
            _name = name;
        }

        public String Name => _name;
    }
}