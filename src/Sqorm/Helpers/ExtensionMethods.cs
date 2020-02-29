using System;
using System.Data;
using System.Data.Common;
using Sqorm.Models;

namespace Sqorm.Helpers
{
    internal static class ExtensionMethods
    {
        internal static void AddParameters(this DbCommand command, ParameterContainer parameters)
        {
            if(parameters == null)
                return;
            
            command.Parameters.Clear();
            foreach(var parameter in parameters)
            {
                var param = command.CreateParameter();
                param.ParameterName = parameter.Key;
                param.Value = parameter.Value;
                command.Parameters.Add(param);
            }
        }

        internal static CommandType ToCommandType(this SqormCommandType sqormCommandType)
        {
            return sqormCommandType == SqormCommandType.Text
                    ? CommandType.Text
                    : CommandType.StoredProcedure;
        }
    }
}