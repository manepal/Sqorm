using System;

namespace Sqorm.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SqormIgnoreAttribute : Attribute
    {
        public SqormIgnoreAttribute() {}
    }
}