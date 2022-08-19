using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionEspav
{
    internal class Materiel
    {
        DBclass connect = new DBclass();

        public bool InsertMateriel(string nomMateriel, string codeMateriel, int nbrUnite)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `materiels`(`nomMateriel`, `codeMateriel`, `nbrUnite`) VALUES(@nomM, @codeM, @nbrU)", connect.getconnection);

            command.Parameters.Add("@nomM", MySqlDbType.VarChar).Value = nomMateriel;
            command.Parameters.Add("@codeM", MySqlDbType.VarChar).Value = codeMateriel;
            command.Parameters.Add("@nbrU", MySqlDbType.Int16).Value = nbrUnite;


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
        public DataTable getMaterielslist(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updateMateriel(int id, string nomMateriel, string codeMateriel, int nbrUnite)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `materiels` SET `nomMateriel`=@nomM,`codeMateriel`=@codeM,`nbrUnite`=@nbrU WHERE  `id` = @id", connect.getconnection);
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
            command.Parameters.Add("@nomM", MySqlDbType.VarChar).Value = nomMateriel;
            command.Parameters.Add("@codeM", MySqlDbType.VarChar).Value = codeMateriel;
            command.Parameters.Add("@nbrU", MySqlDbType.Int64).Value = nbrUnite;


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
