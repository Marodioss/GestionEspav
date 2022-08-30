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
    internal class Enseignant
    {
        DBclass connect = new DBclass();
        public bool InsertEnseignant(string nom, string prenom, string cin, int idmE, string telephone, string whatsapp, string email, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `enseignant`(`nom`, `prenom`, `cin`, `idmE`, `telephone`, `whatsapp`, `email`, `photo`) VALUES(@na, @pre, @ci, @mat, @tel, @wts, @em, @img)", connect.getconnection);

            //@na, @pre, @ci, @mat, @tel, @wts, @em, @img
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@pre", MySqlDbType.VarChar).Value = prenom;
            command.Parameters.Add("@ci", MySqlDbType.VarChar).Value = cin;
            command.Parameters.Add("@mat", MySqlDbType.Int16).Value = idmE;
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("@wts", MySqlDbType.VarChar).Value = whatsapp;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

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
        public DataTable getEnseignantlist(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updateEnseignant(int id, string nom, string prenom, string cin, int idmE, string telephone, string whatsapp, string email, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `enseignant` SET `nom`=@na,`prenom`=@pre,`cin`=@ci,`idmE`=@mat,`telephone`=@tel,`whatsapp`=@wts,`email`=@em,`photo`=@img WHERE  `id`= @id", connect.getconnection);

            //@na, @pre, @ci, @mat, @tel, @wts, @em, @img
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@pre", MySqlDbType.VarChar).Value = prenom;
            command.Parameters.Add("@ci", MySqlDbType.VarChar).Value = cin;
            command.Parameters.Add("@mat", MySqlDbType.Int64).Value = idmE;
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("@wts", MySqlDbType.VarChar).Value = whatsapp;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

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
        public string getEnseignantNP(string nom, string prenom)
        {
            MySqlCommand command = new MySqlCommand("SELECT id FROM `enseignant` WHERE nom = @nm and prenom = @pr", connect.getconnection);
            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@pr", MySqlDbType.VarChar).Value = prenom;
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
        public bool deleteEnseignat(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `enseignant` WHERE `id`=@id", connect.getconnection);

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

    }
}
