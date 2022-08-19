using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace GestionEspav
{
    internal class PresenceEns
    {
        DBclass connect = new DBclass();

        public DataTable getPresenceList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool insertPresence(DateTime dateP, int idenseignant, float heureT)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `presenceens`(`dateP`, `idenseignant`, `heureT`)" +
            "VALUES (@dp,@ie,@ht)", connect.getconnection);

            command.Parameters.Add("@dp", MySqlDbType.Date).Value = dateP;
            command.Parameters.Add("@ie", MySqlDbType.Int64).Value = idenseignant;
            command.Parameters.Add("@ht", MySqlDbType.Float).Value = heureT;


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
    }
}
