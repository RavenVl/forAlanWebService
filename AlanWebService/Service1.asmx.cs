using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SQLite;
using System.Data;

namespace AlanWebService
{
    /// <summary>
    /// Сводное описание для Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку.
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        string s = @"Data Source=e:/ruby/test_sqllite/db/development.sqlite3";
        SQLiteConnection ObjConnection;
        SQLiteCommand ObjCommand;
        DataSet dataSet;
        SQLiteDataAdapter ObjDataAdapter; 

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello all!";
        }

        [WebMethod]
        public string show_student ()
        {
            string student="";
            ObjConnection = new SQLiteConnection(s);
            ObjCommand = new SQLiteCommand("SELECT * FROM nds", ObjConnection);
            ObjCommand.CommandType = CommandType.Text;
            ObjDataAdapter = new SQLiteDataAdapter(ObjCommand);
            dataSet = new DataSet();
            ObjDataAdapter.Fill(dataSet, "nds");
            ObjDataAdapter.TableMappings.Add("Table_nds", "nds");
            DataTable table = dataSet.Tables["nds"];

            foreach (DataRow dr in table.Rows)
            {
                student+= dr["name"].ToString();
            }
            return student;
        }
    }
}