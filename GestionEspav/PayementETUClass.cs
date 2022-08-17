using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEspav
{
    internal class PayementETUClass
    {
        DBclass connect = new DBclass();
        public bool insertPayement(float montant, string modep, DateTime moisD, DateTime moisF, int idE)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `payement`(`montant`, `modep`, `moisD`, `moisF`, `Etudiantid` , `statut`) VALUES (@mt,@mp,@md,@mf,@ie,1)", connect.getconnection);

            //@ie, @mt, @mp, @md, @mf

            command.Parameters.Add("@mt", MySqlDbType.Float).Value = montant;
            command.Parameters.Add("@mp", MySqlDbType.VarChar).Value = modep;
            command.Parameters.Add("@md", MySqlDbType.Date).Value = moisD;
            command.Parameters.Add("@mf", MySqlDbType.Date).Value = moisF;
            command.Parameters.Add("@ie", MySqlDbType.Int64).Value = idE;


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
        public DataTable getPayementList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public string verify(int id, DateTime dateverify)
        {
            MySqlCommand command = new MySqlCommand("select count(statut) from payement where Etudiantid = @ide and @dt BETWEEN moisD and moisF; ", connect.getconnection);
            command.Parameters.Add("@ide", MySqlDbType.Int64).Value = id;
            command.Parameters.Add("@dt", MySqlDbType.VarChar).Value = dateverify;
            MySqlDataReader reader;
            connect.openConnect();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                string ve = reader["count(statut)"].ToString();
                reader.Close();
                connect.closeConnect();
                return ve;

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
