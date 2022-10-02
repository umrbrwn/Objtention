using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Objtention
{
    public static class DataTableUtils
    {
        /// <summary>
        /// Converts a DataTable to a list of generic type
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="table">DataTable to convert from</param>
        /// <returns>List of generic type</returns>
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            Type targetType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                            object originalValue = row[prop.Name];
                            object safeValue = (originalValue == null) ? null : Convert.ChangeType(originalValue, targetType);
                            propertyInfo.SetValue(obj, safeValue, null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Converts a DataTable first row to object of generic type
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="table">DataTable to convert from</param>
        /// <returns>Object of generic type</returns>
        public static T DataTableToType<T>(this DataTable table) where T : class, new()
        {
            try
            {
                if (table == null || table.Rows.Count == 0)
                    return default(T);

                var row = table.Rows[0];

                T obj = new T();

                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        Type targetType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                        object originalValue = row[prop.Name];
                        object safeValue = (originalValue == null) ? null : Convert.ChangeType(originalValue, targetType);
                        propertyInfo.SetValue(obj, safeValue, null);
                    }
                    catch
                    {
                        continue;
                    }
                }

                return obj;
            }
            catch
            {
                return null;
            }
        }
    }
}
