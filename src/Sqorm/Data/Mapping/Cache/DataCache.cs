using System.Collections.Generic;
using System.Data;

namespace Sqorm.Data.Mapping.Cache
{
    internal sealed class DataCache
    {
        private readonly DataTable _dataTable;
        
        /// <summary>
        /// Map [lowercaseName : originalName]
        /// </summary>
        private Dictionary<string, string> _dataColumnInfo;
        
        internal DataCache(DataTable dataTable)
        {
            _dataTable = dataTable;
        }

        internal Dictionary<string, string> GetDataColumnInfo()
        {
            if(_dataColumnInfo != null)
                return _dataColumnInfo;

            _dataColumnInfo = new Dictionary<string, string>();
            for(int i = 0; i < _dataTable.Columns.Count; ++i)
            {
                string columnName = _dataTable.Columns[i].ColumnName;
                _dataColumnInfo.Add(columnName.ToLower(), columnName);
            }

            return _dataColumnInfo;
        }
    }
}