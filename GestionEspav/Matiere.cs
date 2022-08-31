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

        public bool InsertMatiere(string nom)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `matiere`(`nom`) VALUES(@na)", connect.getconnection);

            //@na, @pre2
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = nom;

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
        public bool deleteMatiere(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `matiere` WHERE `id`=@id", connect.getconnection);

            //@id
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

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
        public bool verifieidmat(string nom)
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
                return true;

            }
            else
            {
                reader.Close();
                connect.closeConnect();
                return false;

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
