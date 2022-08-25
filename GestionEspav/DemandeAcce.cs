using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace GestionEspav
{
    internal class DemandeAcce
    {
        DBclass connect = new DBclass();
        public DataTable getDemandeAcceList(MySqlCommand command)
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
        public bool updateReservationSalle(int id, String nom, String prenom, DateTime dateR, DateTime dateH,
                                        String nomParticip, String chefEquipe, float duree, String natureTrav, String salle)
        {
           
            MySqlCommand command = new MySqlCommand("UPDATE `reservationsalle` SET `nom` = @nm, `prenom` = @pr, `dateR` = @dr, `dateH` = @dh," +
                " `nomParticip` = @np, `chefEquipe` = @ce, `duree` = @dur, `natureTrav` = @nt, `salle` = @sl  WHERE `id` = @id", connect.getconnection);
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            command.Parameters.Add("@nm", MySqlDbType.String).Value = nom;
            command.Parameters.Add("@pr", MySqlDbType.String).Value = prenom;
            command.Parameters.Add("@dr", MySqlDbType.Date).Value = dateR;
            command.Parameters.Add("@dh", MySqlDbType.Date).Value = dateH;
           // command.Parameters.Add("@im", MySqlDbType.Int64).Value = idMateriel;
           // command.Parameters.Add("@nbr", MySqlDbType.Int64).Value = nbrItem;
            command.Parameters.Add("@np", MySqlDbType.String).Value = nomParticip;
            command.Parameters.Add("@ce", MySqlDbType.String).Value = chefEquipe;
            command.Parameters.Add("@dur", MySqlDbType.Float).Value = duree;
            command.Parameters.Add("@nt", MySqlDbType.String).Value = natureTrav;
            command.Parameters.Add("@sl", MySqlDbType.String).Value = salle;


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
        public bool insertDemandeAcce(String nom, String prenom, DateTime dateR, DateTime dateH, String nomParticip, String chefEquipe, float duree,String natureTrav, String salle)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `reservationsalle`(`nom`, `prenom`, `dateR`, `dateH`, `nomParticip`, `chefEquipe`, `duree`, `natureTrav`, `salle`) VALUES (@nm,@pr,@dr,@dh,@np,@ce,@dur,@nt,@sl)", connect.getconnection);

            // @nm,@pr,@dr,@dh,@im,@ni,@np,@ce,@dur,@nt,@sl
            command.Parameters.Add("@nm", MySqlDbType.String).Value = nom;
            command.Parameters.Add("@pr", MySqlDbType.String).Value = prenom;
            command.Parameters.Add("@dr", MySqlDbType.Date).Value = dateR;
            command.Parameters.Add("@dh", MySqlDbType.Date).Value = dateH;
          //  command.Parameters.Add("@im", MySqlDbType.Int64).Value = idMateriel;
          //  command.Parameters.Add("@ni", MySqlDbType.Int64).Value = nbrItem;
            command.Parameters.Add("@np", MySqlDbType.String).Value = nomParticip;
            command.Parameters.Add("@ce", MySqlDbType.String).Value = chefEquipe;
            command.Parameters.Add("@dur", MySqlDbType.Float).Value = duree;
            command.Parameters.Add("@nt", MySqlDbType.String).Value = natureTrav;
            command.Parameters.Add("@sl", MySqlDbType.String).Value = salle;
        
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
