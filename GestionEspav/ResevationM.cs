using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEspav
{
    internal class ResevationM
    {
        DBclass connect = new DBclass();
        

        public DataTable getReservationMatList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updateReservation(int id, String nom, String prenom, DateTime dateL, DateTime dateR, int idMateriel, int nbrItem, String retourne)
        {
           // MySqlCommand command = new MySqlCommand("UPDATE `enseignant` SET `nom`=@na,`prenom`=@pre,`cin`=@ci,`idmE`=@mat,`telephone`=@tel,`whatsapp`=@wts,`email`=@em,`photo`=@img WHERE  `id`= @id", connect.getconnection);
            //
            MySqlCommand command = new MySqlCommand("UPDATE `reservationMat` SET `nom` = @nm, `prenom` = @pr, `dateL` = @dl, `dateR` = @dr, `idMateriel` = @im, `nbrItem` = @nbr, `retourne` = @rt  WHERE `id` = @id", connect.getconnection);
           
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            command.Parameters.Add("@nm", MySqlDbType.String).Value = nom;
            command.Parameters.Add("@pr", MySqlDbType.String).Value = prenom;
            command.Parameters.Add("@dl", MySqlDbType.Date).Value = dateL;
            command.Parameters.Add("@dr", MySqlDbType.Date).Value = dateR;
            command.Parameters.Add("@im", MySqlDbType.Int64).Value = idMateriel;
            command.Parameters.Add("@nbr", MySqlDbType.Int64).Value = nbrItem;
            command.Parameters.Add("@rt", MySqlDbType.String).Value = retourne;

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
        public string getMaterielNP(string nomMateriel)
        {
            MySqlCommand command = new MySqlCommand("SELECT id FROM `materiels` WHERE nomMateriel = @nm", connect.getconnection);
            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = nomMateriel;
          
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
        public String requpNbrMatRest(String nomMateriel)
        {
            MySqlCommand command = new MySqlCommand("select nbrUnite from materiels where nomMateriel = @ide; ", connect.getconnection);
            command.Parameters.Add("@ide", MySqlDbType.VarChar).Value = nomMateriel;


            MySqlDataReader reader;
            connect.openConnect();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                String ve = reader["nbrUnite"].ToString();
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
        public String requpNbrMatRes(int idMateriel)
        {
            MySqlCommand command = new MySqlCommand("select sum(nbrItem) from reservationmat where idMateriel = @ide;", connect.getconnection);
            command.Parameters.Add("@ide", MySqlDbType.Int64).Value = idMateriel;


            MySqlDataReader reader;
            connect.openConnect();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                String ve = reader["sum(nbrItem)"].ToString();
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
        public bool insertReservationMat(String nom, String prenom, DateTime dateL, DateTime dateR, int idMateriel, int nbrItem, String retourne)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `reservationMat`(`nom`, `prenom`, `dateL`, `dateR`, `idMateriel`, `nbrItem`,`retourne`)" +
            "VALUES (@nm,@pr,@dl,@dr,@im,@nbr,@rt)", connect.getconnection);
          
            command.Parameters.Add("@nm", MySqlDbType.String).Value = nom;
            command.Parameters.Add("@pr", MySqlDbType.String).Value = prenom;
            command.Parameters.Add("@dl", MySqlDbType.Date).Value = dateL;
            command.Parameters.Add("@dr", MySqlDbType.Date).Value = dateR;
            command.Parameters.Add("@im", MySqlDbType.Int64).Value = idMateriel;
            command.Parameters.Add("@nbr", MySqlDbType.Int64).Value = nbrItem;
            command.Parameters.Add("@rt", MySqlDbType.String).Value = retourne;


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
