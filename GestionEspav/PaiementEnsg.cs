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
    internal class PaiementEnsg
    {
        DBclass connect = new DBclass();

        public bool insertPayementE(String type, float prixHeure, float TotalHeure, float montant, int idenseignant, DateTime dateD, DateTime dateF)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `payementens`(`type`, `prixHeure`, `TotalHeure`, `montant`, `idenseignant`, `dateD`, `dateF`, statut)" +
                "VALUES (@tp,@ph,@th,@mt,@ie,@dd,@df,1)", connect.getconnection);

            // command.Parameters.Add("@dp", MySqlDbType.Date).Value = datePaiement;
            command.Parameters.Add("@tp", MySqlDbType.VarChar).Value = type;
            command.Parameters.Add("@ph", MySqlDbType.Float).Value = prixHeure;
            command.Parameters.Add("@th", MySqlDbType.Float).Value = TotalHeure;
            command.Parameters.Add("@mt", MySqlDbType.Float).Value = montant;
            command.Parameters.Add("@ie", MySqlDbType.Int64).Value = idenseignant;
            command.Parameters.Add("@dd", MySqlDbType.Date).Value = dateD;
            command.Parameters.Add("@df", MySqlDbType.Date).Value = dateF;

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

        public string verify(int id, DateTime dateverify)
        {
            MySqlCommand command = new MySqlCommand("select count(statut) from payementens where idenseignant = @ide and @dt BETWEEN dateD and dateF; ", connect.getconnection);
            command.Parameters.Add("@ide", MySqlDbType.Int64).Value = id;
            command.Parameters.Add("@dt", MySqlDbType.Date).Value = dateverify;
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

        public DataTable getPayementListE(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public String requpTotalHeure(int idenseignant, DateTime dateVerifyD, DateTime dateVerifyF)
        {
            MySqlCommand command = new MySqlCommand("select sum(HeureT) from presenceens where idEnseignant = @ide and dateP BETWEEN @dateD and @dateF; ", connect.getconnection);
            command.Parameters.Add("@ide", MySqlDbType.Int64).Value = idenseignant;
            command.Parameters.Add("@dateD", MySqlDbType.Date).Value = dateVerifyD;
            command.Parameters.Add("@dateF", MySqlDbType.Date).Value = dateVerifyF;

            MySqlDataReader reader;
            connect.openConnect();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                String ve = reader["sum(HeureT)"].ToString();
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

