using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace DevToolkit.Helpers
{
    public static class DataReader
    {
        public static T GetValue<T>(DbDataReader reader, int ordinal)
        {
            reader.IsNotNull(nameof(reader));

            object o = reader.GetValue(ordinal);

            if (o == null || o == DBNull.Value)
            {
                return default(T);
            }

            return (T)o;
        }

        public static T GetValue<T>(DbDataReader reader, string name)
        {
            reader.IsNotNull(nameof(reader));

            name.IsNotEmptyString(nameof(name));

            object o = reader[name];

            if (o == null || o == DBNull.Value)
            {
                return default(T);
            }

            return (T)o;
        }

        public static T Get<T>(this DbDataReader reader, int ordinal)
        {
            reader.IsNotNull(nameof(reader));

            object o = reader.GetValue(ordinal);

            if (o == null || o == DBNull.Value)
            {
                return default(T);
            }

            return (T)o;
        }

        public static T Get<T>(this DbDataReader reader, string name)
        {
            reader.IsNotNull(nameof(reader));
            name.IsNotEmptyString(nameof(name));

            object o = reader[name];

            if (o == null || o == DBNull.Value)
            {
                return default(T);
            }

            return (T)o;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
