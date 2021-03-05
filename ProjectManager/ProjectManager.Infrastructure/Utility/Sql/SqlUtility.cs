using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Infrastructure.Utility.Sql
{
    public static class SqlUtility
    {
        public static FilterCondition BuildInCondition<T>(string columnName, List<T> inputs)
        {
            StringBuilder condition = new StringBuilder(columnName + " IN ({" + 0 + "}");

            for (int i = 1; i < inputs.Count; i++)
            {
                condition.Append(", {" + i + "}");
            }

            condition.Append(")");

            object[] parameters = new object[inputs.Count];

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = inputs[i];
            }

            return new FilterCondition(condition.ToString(), parameters);
        }
    }
}
