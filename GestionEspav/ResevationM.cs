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
        public bool insertReservationMat(String nom, String prenom, DateTime dateL, DateTime dateR, int idMateriel, int nbrItem)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `reservationMateriel`(`nom`, `prenom`, `dateL`, `date`R, `idMateriel`, `nbrItem`)" +
            "VALUES (@nm,@pr,@dl,@dr,@im,@nbr)", connect.getconnection);
          
            command.Parameters.Add("@nm", MySqlDbType.String).Value = nom;
            command.Parameters.Add("@pr", MySqlDbType.String).Value = prenom;
            command.Parameters.Add("@dl", MySqlDbType.Date).Value = dateL;
            command.Parameters.Add("@dr", MySqlDbType.Date).Value = dateR;
            command.Parameters.Add("@im", MySqlDbType.Int64).Value = idMateriel;
            command.Parameters.Add("@nbr", MySqlDbType.Int64).Value = nbrItem;
            
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
