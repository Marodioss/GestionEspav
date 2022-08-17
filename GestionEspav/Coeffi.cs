using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEspav
{
    internal class Coeffi
    {
        DBclass connect = new DBclass();
        public bool InsertCoedd(int coff, int idmatiere, int idclass)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `coefficient`(`coff`, `idmatiere`, `idclass`  ) VALUES(@co, @idm, @idc)", connect.getconnection);

            //@na, @pre2
            command.Parameters.Add("@co", MySqlDbType.Int64).Value = coff;
            command.Parameters.Add("@idm", MySqlDbType.Int64).Value = idmatiere;
            command.Parameters.Add("@idc", MySqlDbType.Int64).Value = idclass;

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
