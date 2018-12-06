using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;

namespace AppDevProject
{
    class DB
    {
        public DB()
        {

        }

        public OleDbConnection GetOleDbConnection()
        {
            String connection = @"Provider=Microsoft.JET.OLEDB.4.0; 
				 Data Source =" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DB\AppDevProjectDB.accdb");
            OleDbConnection myConnection = new OleDbConnection(connection);
            return myConnection;
        }

        public void getStuff()
        {
            String connection = @"Provider=Microsoft.JET.OLEDB.4.0; 
				 Data Source =" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DB\AppDevProjectDB.mdb");
            OleDbConnection myConnection = new OleDbConnection(connection);

            string myQuery = "SELECT * FROM Question";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myConnection.Open();
            try
            {
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    int id = (int)myReader["ID"];
                    System.Diagnostics.Debug.WriteLine(id);
                    string myString = (string)myReader["Question"];
                    System.Diagnostics.Debug.WriteLine(myString);
                    string type = (string)myReader["Type"];
                    System.Diagnostics.Debug.WriteLine(type);
                }
            }
            catch (Exception ex)
            {
                Console.Out.Write("SOMETHING WENT WRONG!!!!!!!");
            }
            finally
            {
                myConnection.Close();
            }
        }

    }
}

