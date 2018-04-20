using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umrbrwn.Objtention.Tests
{
    class DataSource
    {
        public DataTable GetStudents()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("cgpa", typeof(double));
            dt.Columns.Add("isclubmember", typeof(bool));
            dt.Columns.Add("funds", typeof(decimal));
            dt.Columns.Add("createdon", typeof(DateTime));
            dt.Columns.Add(new DataColumn
            {
                ColumnName = "modifiedon",
                DataType = typeof(DateTime),
                AllowDBNull = true
            });
            dt.Columns.Add("othercolumn", typeof(short));
            dt.Columns.Add(new DataColumn
            {
                ColumnName = "isdeleted",
                DataType = typeof(bool),
                AllowDBNull = true
            });

            dt.Rows.Add(new object[] { 1, "umr", 3.4, false, 0.00m, DateTime.Today, default(DateTime?), 0, default(bool?) });
            dt.Rows.Add(new object[] { 2, "brwn", 2.5, true, 1.00m, DateTime.Today, DateTime.Today, 0, false });

            return dt;
        }
    }
}
