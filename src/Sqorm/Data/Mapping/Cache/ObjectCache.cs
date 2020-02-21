using System;
using System.Collections.Generic;
using System.Reflection;
using Sqorm.Data.Attributes;

namespace Sqorm.Data.Mapping.Cache
{
    internal sealed class ObjectCache
    {
        private readonly Type _objectType;
        private Dictionary<string, PropertyInfo> _objectPropertyInfo;

        internal ObjectCache(Type type)
        {
            _objectType = type;
        }

        internal Dictionary<string, PropertyInfo> GetObjectPropertyInfo()
        {
            if(_objectPropertyInfo != null)
                return _objectPropertyInfo;

            _objectPropertyInfo = new Dictionary<string, PropertyInfo>();
            PropertyInfo[] propertyInfo = _objectType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach(var pInfo in propertyInfo)
            {
                SqormIgnoreAttribute sqormIgnoreAttribute = pInfo.GetCustomAttribute<SqormIgnoreAttribute>(false);
                if(sqormIgnoreAttribute != null)
                    continue;
                
                SqormDataFieldAttribute sqormDataFieldAttribute = pInfo.GetCustomAttribute<SqormDataFieldAttribute>(false);
                string dataFieldName = sqormDataFieldAttribute?.Name ?? pInfo.Name;
            
                _objectPropertyInfo.Add(dataFieldName.ToLower(), pInfo);
            }

            return _objectPropertyInfo;
        }
    }
}