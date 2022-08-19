using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEspav
{
    internal class Etudiant
    {
        DBclass connect = new DBclass();
        public bool insertStudent(string nom, string prenom, string cin, DateTime datei, string idclass, string telephone, string whatsapp, string email, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `etudiant`(`nom`, `prenom`, `cin`, `dateinscription`, `idclass`, `telephone`, `whatsapp`, `email`, `photo`) VALUES(@na, @pre, @ci, @di, @ic, @tel, @wts, @em, @img)", connect.getconnection);

            //@na, @pre, @ci, @di, @ic, @tel, @wts, @em, @img
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@pre", MySqlDbType.VarChar).Value = prenom;
            command.Parameters.Add("@ci", MySqlDbType.VarChar).Value = cin;
            command.Parameters.Add("@di", MySqlDbType.Date).Value = datei;
            command.Parameters.Add("@ic", MySqlDbType.Decimal).Value = idclass;
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
        public DataTable getStudentlist(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updateStudent(int id, string nom, string prenom, string cin, DateTime datei, int idclass, string telephone, string whatsapp, string email, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `etudiant` SET `nom`=@na,`prenom`=@pre,`cin`=@ci,`dateinscription`=@di,`idclass`=@ic,`telephone`=@tel,`whatsapp`=@wts,`email`=@em,`photo`=@img WHERE  `id`= @id", connect.getconnection);

            //@na, @pre, @ci, @di, @ic, @tel, @wts, @em, @img
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@pre", MySqlDbType.VarChar).Value = prenom;
            command.Parameters.Add("@ci", MySqlDbType.VarChar).Value = cin;
            command.Parameters.Add("@di", MySqlDbType.Date).Value = datei;
            command.Parameters.Add("@ic", MySqlDbType.Int64).Value = idclass;
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
        public bool deleteStudent(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `etudiant` WHERE `id`=@id", connect.getconnection);

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
        public string getEtudiantNP(string nom, string prenom)
        {
            MySqlCommand command = new MySqlCommand("SELECT id FROM `etudiant` WHERE nom = @nm and prenom = @pr", connect.getconnection);
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

    }
}
