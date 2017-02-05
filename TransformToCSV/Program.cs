using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 1. assign value to numberOfLoops
 * 2. change connection string in settings
 * 3. create/drop index idx_2
 */
namespace TransformToCSV
{
    class Program
    {
        static List<string> listParams = new List<string>() { "Mary", "Ann", "WALLIN", "Julia" };
        static private int numberOfLoops = 100;
        static void Main(string[] args)
        {
            string sql = "", sqlWhere = "";
            string connection = Properties.Settings.Default.ConnectionString;
            Console.WriteLine("Start = " + DateTime.Now.ToString());
            for (int i = 0; i < numberOfLoops; i++)
            {
                listParams[0] = RandomExp.StringByLength(5);
                listParams[1] = RandomExp.StringByLength(5);
                listParams[2] = RandomExp.StringByLength(5);
                listParams[3] = RandomExp.StringByLength(5);
//                Console.WriteLine(listParams[0] + "->" + listParams[1] + "->" + listParams[2] + "->" + listParams[3]);
                sqlWhere = Names.BuildWhereForPatientsSql(listParams);
                sql = "Select count(1) From Patients With(Index(idx_2) " + sqlWhere;
                Db.DoSqlSelect(connection, sql);
            }
            Console.WriteLine("Finish = " + DateTime.Now.ToString());
        }
    }
}

