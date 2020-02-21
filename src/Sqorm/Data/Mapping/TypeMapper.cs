using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Sqorm.Data.Mapping.Cache;
using Sqorm.Exceptions;

namespace Sqorm.Data.Mapping
{
    internal sealed class TypeMapper<T>
    {
        private readonly Type _type;
        private readonly bool _isTypeConvertibleFromString;

        private IDataReader _dataReader;
        private DataTable _dataTable;
        private ObjectCache _objectCache;
        private DataCache _dataCache;

        internal TypeMapper()
        {
            _type = typeof(T);
            _isTypeConvertibleFromString = typeof(IConvertible).IsAssignableFrom(_type) &&
                                            typeof(IEquatable<T>).IsAssignableFrom(_type);
        }

        internal IEnumerable<T> MapDataReader(IDataReader reader)
        {
            _dataReader = reader;
            _dataTable = new DataTable();
            _dataTable.Load(_dataReader);

            if(!_isTypeConvertibleFromString)
            {
                _objectCache = new ObjectCache(_type);
                _dataCache = new DataCache(_dataTable);
            }

            List<T> result = new List<T>();
            T rowObject;
            foreach(DataRow row in _dataTable.Rows)
            {
                rowObject = _isTypeConvertibleFromString ? MapScalar(row[0]) : MapDataRow(row);
                result.Add(rowObject);
            }
            
            return result;
        }

        internal T MapScalar(object value)
        {
            if(!_isTypeConvertibleFromString)
                throw new InvalidCastException($"Cannont convert object of type '{value.GetType()}' to '{_type}'.");

            return (T)Convert.ChangeType(value, _type);
        }

        private T MapDataRow(DataRow row)
        {
            T result = (T)Activator.CreateInstance(_type);

            var objectPropertyInfo = _objectCache.GetObjectPropertyInfo();
            var dataColummnInfo = _dataCache.GetDataColumnInfo();
            foreach(var columnInfo in dataColummnInfo)
            {
                PropertyInfo propertyInfo;
                if(!objectPropertyInfo.TryGetValue(columnInfo.Key, out propertyInfo))
                    throw new PropertyNotFoundException($"Could not find property with name or data field attribute " +
                                                        "'{columnInfo.Value}'.");

                object dataValue = row[columnInfo.Value];
                if(!(dataValue is DBNull))
                    propertyInfo.SetValue(result, Convert.ChangeType(dataValue, propertyInfo.PropertyType));
            }

            return result;
        }
    }
}