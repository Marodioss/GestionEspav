using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEspav
{
    internal class Class
    {
        DBclass connect = new DBclass();
        public string getClassId(string specialité)
        {
            MySqlCommand command = new MySqlCommand("SELECT id FROM `class` WHERE specialiter = @nm", connect.getconnection);
            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = specialité;
            MySqlDataReader reader;

            connect.openConnect();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                string id = reader["id"].ToString();
                reader.Close();
                connect.closeConnect();
                return id;

            }
            else
            {
                reader.Close();
                connect.closeConnect();
                return null;

            }
        }
    }
}
