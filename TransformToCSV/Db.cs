using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformToCSV
{
    static class Db
    {
        static public void DoSqlSelect(string connection, string sqlString)
        {
            int countRows = 0;
            //            listTable = new List<CsvColumns>();
            //            csv = new CsvColumns();
            using (var conn = new SqlConnection(connection))
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlString, conn);
                    //                    cmd.Parameters.AddWithValue("DocId", idd);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        countRows = (int)(rdr[0] as int?);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    String message = String.Format("DoSqlSelect: failed list filling",
                        ex.Message);
                    return;
                }
                finally
                {
                    conn.Close();
                }
        }

    }
}
