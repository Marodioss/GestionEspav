﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEspav
{
    internal class NotesClass
    {
        DBclass connect = new DBclass();
        public bool InsertNote(float note, int idmatiere, int idEtudiant)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `notes`(`note`, `idmatiere`, `idEtudiant`) VALUES(@no, @im, @ie )", connect.getconnection);

            //@na, @pre2
            command.Parameters.Add("@no", MySqlDbType.Float).Value = note;
            command.Parameters.Add("@im", MySqlDbType.Int64).Value = idmatiere;
            command.Parameters.Add("@ie", MySqlDbType.Int64).Value = idEtudiant;     
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
        public DataTable getNotesList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
