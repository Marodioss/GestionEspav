using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEspav
{
    internal class Matiere
    {
        DBclass connect = new DBclass();

        public bool InsertMatiere(string nom, int idclass)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `matiere`(`nom`, `idclass`) VALUES(@na, @pre)", connect.getconnection);

            //@na, @pre2
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@pre", MySqlDbType.Int64).Value = idclass;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }

        }
        public string getMatiereId(string nom)
        {
            MySqlCommand command = new MySqlCommand("SELECT id FROM `matiere` WHERE nom = @nm", connect.getconnection);
            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = nom;
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
        public DataTable getMatiereList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
}
